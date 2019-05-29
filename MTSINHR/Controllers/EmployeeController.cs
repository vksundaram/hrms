﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTSEntBlocks.DataBlock;
using MTSINHR.Models;
using Newtonsoft.Json;
using MTS.Login.Data;
using System.Data.Common;
using System.Data;
using System.Globalization;
using MTS.Controllers;
using System.IO;
using MTSEntBlocks.ExceptionBlock.Handlers;
namespace MTSINHR.Controllers
{
    public class EmployeeController : SecureController
    {
        private List<SelectListItem> getdesignation()
        {
            MTSHRDataLayer.Employee data_emp = new MTSHRDataLayer.Employee();
            List<SelectListItem> designationlist = new List<SelectListItem>();
            try
            {
                var employeedesignation = data_emp.getDesignation();
                designationlist.Add(new SelectListItem() { Value = "", Text = "---- Select Designation----" });
                for (int i = 0; i < employeedesignation.Tables[0].Rows.Count; i++)
                {
                    designationlist.Add(new SelectListItem() { Value = employeedesignation.Tables[0].Rows[i]["id"].ToString(), Text = employeedesignation.Tables[0].Rows[i]["Designation"].ToString() });
                }
            }
            catch (Exception exec)
            {
                BaseExceptionHandler.HandleException(ref exec);
            }
            return designationlist;
        }
        private List<SelectListItem> getdepartment()
        {
            MTSHRDataLayer.Employee data_dep = new MTSHRDataLayer.Employee();
            List<SelectListItem> departmentlist = new List<SelectListItem>();
            try
            {
                var employeeDepartment = data_dep.getDepartment();
                departmentlist.Add(new SelectListItem() { Value = "", Text = "---- Select Department----" });
                for (int i = 0; i < employeeDepartment.Tables[0].Rows.Count; i++)
                {
                    departmentlist.Add(new SelectListItem() { Value = employeeDepartment.Tables[0].Rows[i]["id"].ToString(), Text = employeeDepartment.Tables[0].Rows[i]["Department"].ToString() });
                }
            }
            catch (Exception exec)
            {
                BaseExceptionHandler.HandleException(ref exec);
            }
            return departmentlist;
        }
        private List<SelectListItem> getmaritalstatus()
        {

            MTSHRDataLayer.Employee data_emp = new MTSHRDataLayer.Employee();
            var employeemaritalstatus = data_emp.getMaritalstatus();
            List<SelectListItem> maritalstatus = new List<SelectListItem>();
            maritalstatus.Add(new SelectListItem() { Value = "", Text = "---- Select Marital Status----" });
            for (int i = 0; i < employeemaritalstatus.Tables[0].Rows.Count; i++)
            {
                maritalstatus.Add(new SelectListItem() { Value = employeemaritalstatus.Tables[0].Rows[i]["id"].ToString(), Text = employeemaritalstatus.Tables[0].Rows[i]["Marital_status"].ToString() });

            }
            return maritalstatus;
        }
        private List<SelectListItem> getnationality()
        {

            MTSHRDataLayer.Employee data_emp = new MTSHRDataLayer.Employee();
            var employeenationality = data_emp.getNationality();
            List<SelectListItem> nationality = new List<SelectListItem>();
            nationality.Add(new SelectListItem() { Value = "", Text = "----Select Nationality----" });
            for (int i = 0; i < employeenationality.Tables[0].Rows.Count; i++)
            {
                nationality.Add(new SelectListItem() { Value = employeenationality.Tables[0].Rows[i]["id"].ToString(), Text = employeenationality.Tables[0].Rows[i]["Nationality"].ToString() });
            }
            return nationality;
        }

        [HttpPost]
        public ActionResult SetPrimaryid(Int64 id)
        {
            TempData["employeeid"] = id;
            TempData.Keep("employeeid");
            return Content("success");
        }

        [HttpPost]
        public ActionResult SetEmployeeid(FormCollection form)
        {
            if (form.Count >= 1)
            {
                TempData["employeeid"] = form[0].ToString();
                TempData.Keep("employeeid");
            }
            else
            {
                TempData["employeeid"] = "";
                TempData.Keep("employeeid");
            }
            return Content("success");
        }
        [HttpPost]
    
        public int SetActive(Int64 id, int active, string inActiveDate)
        {
            
            MTSHRDataLayer.Employee data_emp = new MTSHRDataLayer.Employee();
           
            int result = data_emp.ActivateAccount(id, active, inActiveDate);
            return result;
        }

        public ActionResult ReadEmployeeDetails()
        {
            try
            {
                Int64 id = (Int64)TempData["employeeid"];
                TempData.Keep("employeeid");
                MTSHRDataLayer.Employee data_emp = new MTSHRDataLayer.Employee();
                var employeeData = Json(JsonConvert.SerializeObject(data_emp.Read(id)), JsonRequestBehavior.AllowGet);
                ViewBag.EmployeeData = employeeData.Data;

                MTSHRDataLayer.EmployeeImage data_image = new MTSHRDataLayer.EmployeeImage();
                byte[] imagedata = data_image.Read(id);

                if (imagedata == null)
                {
                    string path = Server.MapPath("~/Content/images/Default.jpg");
                    byte[] imageByteData = System.IO.File.ReadAllBytes(path);
                    String baseimage = Convert.ToBase64String(imageByteData);
                    ViewBag.Image = baseimage;
                }
                else if (imagedata != null)
                {

                    String baseimage = Convert.ToBase64String(imagedata);
                    ViewBag.Image = baseimage;

                }
            }
            catch (Exception exec)
            {
                BaseExceptionHandler.HandleException(ref exec);
            }
            return View("EmployeeDetails");

        }

        public ActionResult Employee()
        {
            try
            {
                Employee emp = new Employee();
                MTSHRDataLayer.Employee data_emp = new MTSHRDataLayer.Employee();
                ViewBag.designation = getdesignation();
                ViewBag.department = getdepartment();
                ViewBag.maritalstatus = getmaritalstatus();
                ViewBag.nationality = getnationality();
                ViewBag.EmployeeId = data_emp.getlastemployeeid();
                ViewBag.actionURL = "AddEmployee";
                string empid = TempData["employeeid"].ToString();
                TempData.Keep("employeeid");
                if (!String.IsNullOrEmpty(TempData["employeeid"].ToString()))
                {
                    ViewBag.actionURL = "EditEmployee";
                    ViewBag.EmployeeData = JsonConvert.SerializeObject(data_emp.getemployeedetails(empid));
                    DataTable empdata = data_emp.getemployeedetails(empid);
                    emp.Aadhar = (Int64)empdata.Rows[0]["Aadhar"];
                    emp.Mobile = (String)empdata.Rows[0]["Mobile"];
                    emp.Dateofbirth = DateTime.Parse(empdata.Rows[0]["Dateofbirth"].ToString());
                    emp.Dateofjoin = DateTime.Parse(empdata.Rows[0]["Dateofjoin"].ToString());
                    emp.Designation = (Int64)empdata.Rows[0]["designationid"];
                    emp.DepartmentId = (Int64)empdata.Rows[0]["departmentid"];
                   // emp.Department = (String)empdata.Rows[0]["Department"];
                    emp.Email = (String)empdata.Rows[0]["Email"];
                    emp.Employee_ID = (String)empdata.Rows[0]["Employee_Id"];
                    emp.Fathername = (String)empdata.Rows[0]["Fathername"];
                    emp.Firstname = (String)empdata.Rows[0]["Firstname"];
                    emp.Gender = (Int64)empdata.Rows[0]["Gender"];
                    emp.id = (Int64)empdata.Rows[0]["id"];
                    emp.Lastname = (String)empdata.Rows[0]["Lastname"];
                    emp.Maritalstatus = (Int64)empdata.Rows[0]["maritalid"];
                    emp.Nationality = (Int64)empdata.Rows[0]["nationalityid"];
                    emp.Pancard = (String)empdata.Rows[0]["Pancard"];
                    emp.Spousename = (String)empdata.Rows[0]["Spousename"];
                    emp.PF_AccountNumber = (String)empdata.Rows[0]["PF_AccountNumber"];
                    emp.PF_UAN = (Int64)empdata.Rows[0]["PF_UAN"];
                    emp.ESI_Number = empdata.Rows[0]["ESI_Number"].ToString();
                    return PartialView("Employee", emp);

                }
            }
            catch (Exception exec)
            {
                BaseExceptionHandler.HandleException(ref exec);
            }
            return PartialView("Employee");
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            try
            {

                MTSHRDataLayer.Employee data_emp = new MTSHRDataLayer.Employee();
                int Empidresult = data_emp.GetEmployeeId(emp.Employee_ID, emp.Email);
                if (Empidresult != 1)
                {
                    Encrypt encrypt = new Encrypt();
                    string password = encrypt.CreateRandomPassword(6);
                    string hashPwd = encrypt.GetSHA1HashData(password);


                    int RetVal = 0;
                    //Get Paremeters from the Database
                    //Status=1, initial status when user created.
                    string TemplateId = "2";
                    string SpName = emp.Email + "," + emp.Firstname + "," + emp.Lastname + "," + password;

                    DbCommand DCMD = DataAccess.ExecuteNonQueryCMD("MTS_AddEmailMasterEntry", TemplateId, SpName);
                    DbCommand cmd = DataAccess.ExecuteNonQueryCMD("MTS_ADDUSER",
                       emp.Email,
                        hashPwd,
                        emp.Firstname,
                        emp.Lastname,
                        emp.Email,
                        2,//Default user Role
                        true,//Active
                        1,//Status
                        false);//Locked

                    RetVal = Convert.ToInt16(cmd.Parameters["@RETURN_VALUE"].Value.ToString());
                    int result = data_emp.Create(emp.Aadhar, emp.Dateofbirth, emp.Dateofjoin, emp.Designation, emp.Email, emp.Employee_ID, emp.Fathername, emp.Firstname, emp.Gender, emp.Lastname, emp.Maritalstatus, emp.Mobile, emp.Nationality, emp.Pancard, emp.Spousename, emp.PF_AccountNumber, emp.PF_UAN, emp.ESI_Number, emp.DepartmentId);
                    if (result == 1)
                    {
                        return Content("Success");
                    }
                    else
                    {
                        return RedirectToAction("Employee", "Employee");
                    }
                }
                else
                {
                    return Content("Failed");
                }
            }
            catch (Exception exec)
            {
                BaseExceptionHandler.HandleException(ref exec);
            }
            return Content("Failed");
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {

            MTSHRDataLayer.Employee data_emp = new MTSHRDataLayer.Employee();
            Int64 result = data_emp.Edit(emp.Aadhar, emp.Dateofbirth, emp.Dateofjoin, emp.Designation, emp.DepartmentId, emp.Email, emp.Employee_ID, emp.Fathername, emp.Firstname, emp.Gender, emp.id, emp.Lastname, emp.Maritalstatus, emp.Mobile, emp.Nationality, emp.Pancard, emp.Spousename, emp.PF_AccountNumber, emp.PF_UAN, emp.ESI_Number);

            if (result >= 1)
            {
                TempData["employeeid"] = result;
                TempData.Keep("employeeid");
                return Content("EditSuccess");
            }
            else
            {
                return Content("Failed");
            }
        }


        [HttpPost]
        public int ResetEmployeePassword(Employee emp)
        {
            UserLogonData userLogon = new UserLogonData();
            Encrypt encrypt = new Encrypt();
            string password = encrypt.CreateRandomPassword(6);
            string hashPwd = encrypt.GetSHA1HashData(password);
            string shapwd = encrypt.GetSHA1HashData(hashPwd + emp.id);

            
            //Get Paremeters from the Database
            //Status=1, initial status when user created.
            string TemplateId = "3";
            string SpName = emp.Email + "," + emp.Firstname + "," + emp.Lastname + "," + password;

            DbCommand DCMD = DataAccess.ExecuteNonQueryCMD("MTS_AddEmailMasterEntry", TemplateId, SpName);
            int result = userLogon.ForgotPassword(emp.id, shapwd);    
            return result;
        }
    }
}