﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntellaLend.WFProxy.IntellaLendWF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="IntellaLendWF.IService")]
    public interface IService {
        
        // CODEGEN: Generating message contract since the operation ExecuteWorkFlow is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ExecuteWorkFlow", ReplyAction="http://tempuri.org/IService/ExecuteWorkFlowResponse")]
        IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowResponse ExecuteWorkFlow(IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ExecuteWorkFlow", ReplyAction="http://tempuri.org/IService/ExecuteWorkFlowResponse")]
        System.Threading.Tasks.Task<IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowResponse> ExecuteWorkFlowAsync(IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ExecuteWorkFlowRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays", Order=0)]
        public System.Collections.Generic.Dictionary<string, string> ArrayOfKeyValueOfstringstring;
        
        public ExecuteWorkFlowRequest() {
        }
        
        public ExecuteWorkFlowRequest(System.Collections.Generic.Dictionary<string, string> ArrayOfKeyValueOfstringstring) {
            this.ArrayOfKeyValueOfstringstring = ArrayOfKeyValueOfstringstring;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ExecuteWorkFlowResponse {
        
        public ExecuteWorkFlowResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : IntellaLend.WFProxy.IntellaLendWF.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<IntellaLend.WFProxy.IntellaLendWF.IService>, IntellaLend.WFProxy.IntellaLendWF.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowResponse IntellaLend.WFProxy.IntellaLendWF.IService.ExecuteWorkFlow(IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowRequest request) {
            return base.Channel.ExecuteWorkFlow(request);
        }
        
        public void ExecuteWorkFlow(System.Collections.Generic.Dictionary<string, string> ArrayOfKeyValueOfstringstring) {
            IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowRequest inValue = new IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowRequest();
            inValue.ArrayOfKeyValueOfstringstring = ArrayOfKeyValueOfstringstring;
            IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowResponse retVal = ((IntellaLend.WFProxy.IntellaLendWF.IService)(this)).ExecuteWorkFlow(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowResponse> IntellaLend.WFProxy.IntellaLendWF.IService.ExecuteWorkFlowAsync(IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowRequest request) {
            return base.Channel.ExecuteWorkFlowAsync(request);
        }
        
        public System.Threading.Tasks.Task<IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowResponse> ExecuteWorkFlowAsync(System.Collections.Generic.Dictionary<string, string> ArrayOfKeyValueOfstringstring) {
            IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowRequest inValue = new IntellaLend.WFProxy.IntellaLendWF.ExecuteWorkFlowRequest();
            inValue.ArrayOfKeyValueOfstringstring = ArrayOfKeyValueOfstringstring;
            return ((IntellaLend.WFProxy.IntellaLendWF.IService)(this)).ExecuteWorkFlowAsync(inValue);
        }
    }
}
