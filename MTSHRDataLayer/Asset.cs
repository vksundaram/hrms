﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTSEntBlocks.DataBlock;
using System.Data;

namespace MTSHRDataLayer
{
    public class Asset
    {
        public int Create(params object[] parameterValues)
        {
            return Convert.ToInt32( DataAccess.ExecuteScalar("CREATE_ASSET_DETAILS", parameterValues));
        }

        public DataTable ReadLocation()
        {
            return DataAccess.ExecuteDataTable("READ_LOCATION");
        }
        public DataTable ReadVendorNames()
        {
            return DataAccess.ExecuteDataTable("READ_VENDORNAMES");
        }

        public DataTable ReadAssetNames(params object[] parameterValues)
        {
            return DataAccess.ExecuteDataTable("READ_ALLASSETNAMES",parameterValues);
        }

        public int UploadInvoice(params object[] parameterValues)
        {
            return Convert.ToInt32( DataAccess.ExecuteScalar("CREATE_INVOICE",parameterValues));
        }

        public int ReadLastInvoiceId()
        {

            return Convert.ToInt32(DataAccess.ExecuteScalar("READ_LASTINVOICEID"));
        }

        public DataTable ReadAllAssetEntries()
        {
            return DataAccess.ExecuteDataTable("READ_ALLASSETENTRIES");
        }

        public DataSet ReadCategory()
        {
            return DataAccess.ExecuteDataSet("READ_ASSETCATEGORY_DETAILS");
        }
        public DataSet ReadAssetName()
        {
            return DataAccess.ExecuteDataSet("READ_ASSET_NAME");
        }
    }
}
