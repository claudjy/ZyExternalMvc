
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

 

namespace Zysoft.ZyExternal.DAL.His.RemoteService
{
/// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Web.Services.WebServiceBindingAttribute(Name="WSSelfServiceSoap", Namespace="http://www.zysoft.com.cn/")]
        public partial class HisWSSelfService : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
            /// <remarks/>
            public HisWSSelfService() {
                this.Url = "http://localhost:4940/webservices/WSSelfService.asmx";
            }
    
            /// <remarks/>
            [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.zysoft.com.cn/HelloWorld", RequestNamespace="http://www.zysoft.com.cn/", ResponseNamespace="http://www.zysoft.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            public string HelloWorld() {
                object[] results = this.Invoke("HelloWorld", new object[0]);
                return ((string)(results[0]));
            }
    
            /// <remarks/>
            public System.IAsyncResult BeginHelloWorld(System.AsyncCallback callback, object asyncState) {
                return this.BeginInvoke("HelloWorld", new object[0], callback, asyncState);
            }
    
            /// <remarks/>
            public string EndHelloWorld(System.IAsyncResult asyncResult) {
                object[] results = this.EndInvoke(asyncResult);
                return ((string)(results[0]));
            }
    
            /// <remarks/>
            [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.zysoft.com.cn/BankService", RequestNamespace="http://www.zysoft.com.cn/", ResponseNamespace="http://www.zysoft.com.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            public string BankService(string strXML) {
                object[] results = this.Invoke("BankService", new object[] {
                            strXML});
                return ((string)(results[0]));
            }
    
            /// <remarks/>
            public System.IAsyncResult BeginBankService(string strXML, System.AsyncCallback callback, object asyncState) {
                return this.BeginInvoke("BankService", new object[] {
                            strXML}, callback, asyncState);
            }
    
            /// <remarks/>
            public string EndBankService(System.IAsyncResult asyncResult) {
                object[] results = this.EndInvoke(asyncResult);
                return ((string)(results[0]));
            }
        }


}