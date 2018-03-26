using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// Assembly WebServiceStudio Version = 2.0.50727.7905
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name = "SlowSfqUploadServicePortBinding", Namespace = "http://service.slowsfq.chis.com/")]
public partial class SlowSfqUploadService : System.Web.Services.Protocols.SoapHttpClientProtocol
{

    /// <remarks/>
    public SlowSfqUploadService()
    {
        this.Url = "http://218.90.174.179:8005/SlowSfqUploadService/SlowSfqUploadService";
    }

    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://service.slowsfq.chis.com/", ResponseNamespace = "http://service.slowsfq.chis.com/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary", IsNullable = true)]
    public byte[] uploadSfqSlowCase([System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg0, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string arg1, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary", IsNullable = true)] byte[] arg2)
    {
        object[] results = this.Invoke("uploadSfqSlowCase", new object[] {
                    arg0,
                    arg1,
                    arg2});
        return ((byte[])(results[0]));
    }

    /// <remarks/>
    public System.IAsyncResult BeginuploadSfqSlowCase(string arg0, string arg1, byte[] arg2, System.AsyncCallback callback, object asyncState)
    {
        return this.BeginInvoke("uploadSfqSlowCase", new object[] {
                    arg0,
                    arg1,
                    arg2}, callback, asyncState);
    }

    /// <remarks/>
    public byte[] EnduploadSfqSlowCase(System.IAsyncResult asyncResult)
    {
        object[] results = this.EndInvoke(asyncResult);
        return ((byte[])(results[0]));
    }
}
