

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;




/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name = "inpatientRedeemWebServiceSoapBinding", Namespace = "http://webservice.cmis.taiyang.com/")]
public partial class RedeemWSJQ : System.Web.Services.Protocols.SoapHttpClientProtocol
{

    /// <remarks/>
    public RedeemWSJQ()
    {
        this.Url = "http://10.81.149.2/jzxdbz/inpatientRedeemService.asmx";
    }


    ///// <remarks/>
    //[System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://webservice.cmis.taiyang.com/", ResponseNamespace = "http://webservice.cmis.taiyang.com/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    //[return: System.Xml.Serialization.XmlArrayAttribute("return", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //[return: System.Xml.Serialization.XmlArrayItemAttribute("list", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //public resReferralsheet[] downloadReferralsheetTY([System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string hoscode, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerno, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string inorout, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string truncode, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberno, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string startturndate, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string endturndate)
    //{
    //    object[] results = this.Invoke("downloadReferralsheet", new object[] {
    //                hoscode,
    //                centerno,
    //                inorout,
    //                truncode,
    //                memberno,
    //                startturndate,
    //                endturndate});
    //    return ((resReferralsheet[])(results[0]));
    //}

    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://webservice.cmis.taiyang.com/", ResponseNamespace = "http://webservice.cmis.taiyang.com/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace = "http://com.taiyang.cmis.webservice.dto.ReferralList")]
    public ReferralResult[] downloadReferralsheet([System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string hoscode, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerno, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string inorout, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string truncode, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberno, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string startturndate, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string endturndate)
    {
        object[] results = this.Invoke("downloadReferralsheet", new object[] {
                    hoscode,
                    centerno,
                    inorout,
                    truncode,
                    memberno,
                    startturndate,
                    endturndate});
        return ((ReferralResult[])(results[0]));
    }

    /// <remarks/>
    public System.IAsyncResult BegindownloadReferralsheet(string hoscode, string centerno, string inorout, string truncode, string memberno, string startturndate, string endturndate, System.AsyncCallback callback, object asyncState)
    {
        return this.BeginInvoke("downloadReferralsheet", new object[] {
                    hoscode,
                    centerno,
                    inorout,
                    truncode,
                    memberno,
                    startturndate,
                    endturndate}, callback, asyncState);
    }

    /// <remarks/>
    public ReferralResult[] EnddownloadReferralsheet(System.IAsyncResult asyncResult)
    {
        object[] results = this.EndInvoke(asyncResult);
        return ((ReferralResult[])(results[0]));
    }
}