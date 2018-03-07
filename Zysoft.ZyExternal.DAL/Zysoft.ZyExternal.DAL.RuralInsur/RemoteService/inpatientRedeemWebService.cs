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
[System.Web.Services.WebServiceBindingAttribute(Name="inpatientRedeemWebServiceSoapBinding", Namespace="http://www.springframework.org/schema/beans")]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(queryContractServiceDataResult))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(cancelContractServiceDataResult))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(UnsupportedEncodingException))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(GetChronicICD))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(redeemTypeDownLoadResult[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(hospitalResult[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(FeeClass[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(Member[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(leechdomDetailResult[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(officeResult[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(inpatientGradeResult[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(inpatientDetailResult[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(diseaseResult[]))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(redeemTypeResult[]))]
public partial class inpatientRedeemWebService : System.Web.Services.Protocols.SoapHttpClientProtocol
{
    
    /// <remarks/>
    public inpatientRedeemWebService() {
        this.Url = "http://192.168.102.27:8383/country/webservice/inpatientRedeemService";
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("treatmentModeUpdate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.treatmentModeList")]
    public treatmentModeResult[] treatmentModeUpdate([System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string runYear, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive)
    {
        object[] results = this.Invoke("treatmentModeUpdate", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    runYear,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((treatmentModeResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegintreatmentModeUpdate(string userName, string userPwd, string hospCode, string runYear, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("treatmentModeUpdate", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    runYear,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public treatmentModeResult[] EndtreatmentModeUpdate(System.IAsyncResult asyncResult)
    {
        object[] results = this.EndInvoke(asyncResult);
        return ((treatmentModeResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("SetBankInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SetBankInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sUsrID, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sWDBH, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string Inpatient_sn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sBankCardNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sBankCardName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("SetBankInfo", new object[] {
                    sUsrID,
                    sPwd,
                    sWDBH,
                    Inpatient_sn,
                    sBankCardNo,
                    sBankCardName,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSetBankInfo(string sUsrID, string sPwd, string sWDBH, string Inpatient_sn, string sBankCardNo, string sBankCardName, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SetBankInfo", new object[] {
                    sUsrID,
                    sPwd,
                    sWDBH,
                    Inpatient_sn,
                    sBankCardNo,
                    sBankCardName,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndSetBankInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("createClinicCalculate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public CreareClinicRedeemResult createClinicCalculate([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string username, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string minusMoney, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("createClinicCalculate", new object[] {
                    username,
                    userPwd,
                    hosNo,
                    clinicNo,
                    redeemNo,
                    minusMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((CreareClinicRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincreateClinicCalculate(string username, string userPwd, string hosNo, string clinicNo, string redeemNo, string minusMoney, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("createClinicCalculate", new object[] {
                    username,
                    userPwd,
                    hosNo,
                    clinicNo,
                    redeemNo,
                    minusMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public CreareClinicRedeemResult EndcreateClinicCalculate(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((CreareClinicRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getPersonInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.MemberList")]
    public Member[] getPersonInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bookno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string @operator) {
        object[] results = this.Invoke("getPersonInfo", new object[] {
                    bookno,
                    @operator});
        return ((Member[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetPersonInfo(string bookno, string @operator, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getPersonInfo", new object[] {
                    bookno,
                    @operator}, callback, asyncState);
    }
    
    /// <remarks/>
    public Member[] EndgetPersonInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((Member[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliBalance", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public clinicBanlanceResult cliBalance([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string settlementNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string familyAccountGeld, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userNo) {
        object[] results = this.Invoke("cliBalance", new object[] {
                    settlementNo,
                    familyAccountGeld,
                    userNo});
        return ((clinicBanlanceResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliBalance(string settlementNo, string familyAccountGeld, string userNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliBalance", new object[] {
                    settlementNo,
                    familyAccountGeld,
                    userNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public clinicBanlanceResult EndcliBalance(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((clinicBanlanceResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://webservice.cmis.taiyang.com/queryContractServiceData", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("_return", Namespace="return", IsNullable=true)]
    public object queryContractServiceData(string userName, string userPwd, string hospCode, string centerNo, string redeemno, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive) {
        object[] results = this.Invoke("queryContractServiceData", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    centerNo,
                    redeemno,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((object)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginqueryContractServiceData(string userName, string userPwd, string hospCode, string centerNo, string redeemno, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("queryContractServiceData", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    centerNo,
                    redeemno,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public object EndqueryContractServiceData(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((object)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelLeaveInpatientRegister", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public cancelLeaveInpatientRegisterResult cancelLeaveInpatientRegister([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("cancelLeaveInpatientRegister", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((cancelLeaveInpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelLeaveInpatientRegister(string userName, string userPwd, string hospCode, string inpatientSn, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelLeaveInpatientRegister", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public cancelLeaveInpatientRegisterResult EndcancelLeaveInpatientRegister(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((cancelLeaveInpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelInpatientRegister", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public cancelInpatientRegisterResult cancelInpatientRegister([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cancelCause, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("cancelInpatientRegister", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    cancelCause,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((cancelInpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelInpatientRegister(string userName, string userPwd, string hospCode, string inpatientSn, string cancelCause, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelInpatientRegister", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    cancelCause,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public cancelInpatientRegisterResult EndcancelInpatientRegister(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((cancelInpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("clinicRegister", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ClinicRegisterResult clinicRegister(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string username, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisClinicNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string familyNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string stature, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string weight, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string firstIcdNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string secondIcdNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inOfficeNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string treatCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicDoctor, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cureCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inHosId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string @operator, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string DRGS, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("clinicRegister", new object[] {
                    username,
                    userPwd,
                    hosNo,
                    centerNo,
                    hisClinicNo,
                    familyNo,
                    memberNo,
                    stature,
                    weight,
                    firstIcdNo,
                    secondIcdNo,
                    inOfficeNo,
                    treatCode,
                    clinicDate,
                    clinicDoctor,
                    cureCode,
                    inHosId,
                    @operator,
                    DRGS,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((ClinicRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginclinicRegister(
                string username, 
                string userPwd, 
                string hosNo, 
                string centerNo, 
                string hisClinicNo, 
                string familyNo, 
                string memberNo, 
                string stature, 
                string weight, 
                string firstIcdNo, 
                string secondIcdNo, 
                string inOfficeNo, 
                string treatCode, 
                string clinicDate, 
                string clinicDoctor, 
                string cureCode, 
                string inHosId, 
                string @operator, 
                string DRGS, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("clinicRegister", new object[] {
                    username,
                    userPwd,
                    hosNo,
                    centerNo,
                    hisClinicNo,
                    familyNo,
                    memberNo,
                    stature,
                    weight,
                    firstIcdNo,
                    secondIcdNo,
                    inOfficeNo,
                    treatCode,
                    clinicDate,
                    clinicDoctor,
                    cureCode,
                    inHosId,
                    @operator,
                    DRGS,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public ClinicRegisterResult EndclinicRegister(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((ClinicRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getAreaInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string getAreaInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string LastTime, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo) {
        object[] results = this.Invoke("getAreaInfo", new object[] {
                    LastTime,
                    centerNo,
                    hosNo});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetAreaInfo(string LastTime, string centerNo, string hosNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getAreaInfo", new object[] {
                    LastTime,
                    centerNo,
                    hosNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndgetAreaInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("SaveFamilyPayInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SaveFamilyPayInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string xmlParamater) {
        object[] results = this.Invoke("SaveFamilyPayInfo", new object[] {
                    xmlParamater});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveFamilyPayInfo(string xmlParamater, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveFamilyPayInfo", new object[] {
                    xmlParamater}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndSaveFamilyPayInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliSeek", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cliSeek([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberNo) {
        object[] results = this.Invoke("cliSeek", new object[] {
                    memberNo});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliSeek(string memberNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliSeek", new object[] {
                    memberNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndcliSeek(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("updateDisease", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("diseaseList", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.DiseaseList")]
    public diseaseResult[] updateDisease([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string lastTime, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo) {
        object[] results = this.Invoke("updateDisease", new object[] {
                    lastTime,
                    centerNo});
        return ((diseaseResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginupdateDisease(string lastTime, string centerNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("updateDisease", new object[] {
                    lastTime,
                    centerNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public diseaseResult[] EndupdateDisease(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((diseaseResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("uploadInpatientDetails", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string uploadInpatientDetails([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string xmlParamater) {
        object[] results = this.Invoke("uploadInpatientDetails", new object[] {
                    xmlParamater});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginuploadInpatientDetails(string xmlParamater, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("uploadInpatientDetails", new object[] {
                    xmlParamater}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EnduploadInpatientDetails(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetHospComInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GetHospComInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string xmlParamater) {
        object[] results = this.Invoke("GetHospComInfo", new object[] {
                    xmlParamater});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetHospComInfo(string xmlParamater, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetHospComInfo", new object[] {
                    xmlParamater}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetHospComInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliCancelSettlement", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void cliCancelSettlement([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string settlementNo) {
        this.Invoke("cliCancelSettlement", new object[] {
                    settlementNo});
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliCancelSettlement(string settlementNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliCancelSettlement", new object[] {
                    settlementNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndcliCancelSettlement(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("feeClassDown", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.feeClassList")]
    public FeeClass[] feeClassDown() {
        object[] results = this.Invoke("feeClassDown", new object[0]);
        return ((FeeClass[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginfeeClassDown(System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("feeClassDown", new object[0], callback, asyncState);
    }
    
    /// <remarks/>
    public FeeClass[] EndfeeClassDown(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((FeeClass[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("clinicRegisterSeek", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ClinicRegisterSeekResult clinicRegisterSeek([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string username, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberSysNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("clinicRegisterSeek", new object[] {
                    username,
                    userPwd,
                    hospCode,
                    memberSysNo,
                    centerNo,
                    clinicNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((ClinicRegisterSeekResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginclinicRegisterSeek(string username, string userPwd, string hospCode, string memberSysNo, string centerNo, string clinicNo, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("clinicRegisterSeek", new object[] {
                    username,
                    userPwd,
                    hospCode,
                    memberSysNo,
                    centerNo,
                    clinicNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public ClinicRegisterSeekResult EndclinicRegisterSeek(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((ClinicRegisterSeekResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetFamilyPayInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GetFamilyPayInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string xmlParamater) {
        object[] results = this.Invoke("GetFamilyPayInfo", new object[] {
                    xmlParamater});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetFamilyPayInfo(string xmlParamater, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetFamilyPayInfo", new object[] {
                    xmlParamater}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetFamilyPayInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelContractServiceData", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("_return", Namespace="return", IsNullable=true)]
    public object cancelContractServiceData(string userName, string userPwd, string hosOrgno, string centerNo, string redeemno, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive) {
        object[] results = this.Invoke("cancelContractServiceData", new object[] {
                    userName,
                    userPwd,
                    hosOrgno,
                    centerNo,
                    redeemno,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((object)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelContractServiceData(string userName, string userPwd, string hosOrgno, string centerNo, string redeemno, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelContractServiceData", new object[] {
                    userName,
                    userPwd,
                    hosOrgno,
                    centerNo,
                    redeemno,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public object EndcancelContractServiceData(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((object)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("inpatientPay", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public inpatientRedeemResult inpatientPay([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string minusMoney, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string acceptMan, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string phone, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string invoiceNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("inpatientPay", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    redeemNo,
                    minusMoney,
                    acceptMan,
                    phone,
                    invoiceNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((inpatientRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpatientPay(
                string userName, 
                string userPwd, 
                string hospCode, 
                string inpatientSn, 
                string redeemNo, 
                string minusMoney, 
                string acceptMan, 
                string phone, 
                string invoiceNo, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("inpatientPay", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    redeemNo,
                    minusMoney,
                    acceptMan,
                    phone,
                    invoiceNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public inpatientRedeemResult EndinpatientPay(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((inpatientRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetIsContinousInInsurance", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GetIsContinousInInsurance([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string xmlParamater) {
        object[] results = this.Invoke("GetIsContinousInInsurance", new object[] {
                    xmlParamater});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetIsContinousInInsurance(string xmlParamater, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetIsContinousInInsurance", new object[] {
                    xmlParamater}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetIsContinousInInsurance(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("auditingSeek", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string auditingSeek([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string no, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo) {
        object[] results = this.Invoke("auditingSeek", new object[] {
                    no,
                    centerNo});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginauditingSeek(string no, string centerNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("auditingSeek", new object[] {
                    no,
                    centerNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndauditingSeek(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("isCashRedeem", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isCashRedeem([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string settlementNo) {
        object[] results = this.Invoke("isCashRedeem", new object[] {
                    settlementNo});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginisCashRedeem(string settlementNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("isCashRedeem", new object[] {
                    settlementNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndisCashRedeem(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelClinicPay", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public CancelClinicPayResult cancelClinicPay([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cancelCause, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("cancelClinicPay", new object[] {
                    userName,
                    userPwd,
                    hosNo,
                    clinicNo,
                    cancelCause,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((CancelClinicPayResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelClinicPay(string userName, string userPwd, string hosNo, string clinicNo, string cancelCause, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelClinicPay", new object[] {
                    userName,
                    userPwd,
                    hosNo,
                    clinicNo,
                    cancelCause,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public CancelClinicPayResult EndcancelClinicPay(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((CancelClinicPayResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliSingleCancleFee", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inpRegister(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string opType, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosOrgno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string familySysno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberSysno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string countryTeamCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sexId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string idcardNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string age, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bookno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cardNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdAllNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string opsId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inOfficeId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string officeDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cureId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inHosId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cureDoctor, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bedNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sectionNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string leaveDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string days, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string outOfficeId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string outHosId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnOp, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnOrgNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string ticketNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string ministerNotice, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string procreateNotice, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string operateEmpSysno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosLevelId) {
        object[] results = this.Invoke("inpRegister", new object[] {
                    opType,
                    inpatientSn,
                    hosOrgno,
                    inpatientNo,
                    centerNo,
                    memberName,
                    familySysno,
                    memberSysno,
                    countryTeamCode,
                    sexId,
                    idcardNo,
                    age,
                    bookno,
                    cardNo,
                    icdAllNo,
                    opsId,
                    inOfficeId,
                    officeDate,
                    cureId,
                    inHosId,
                    cureDoctor,
                    bedNo,
                    sectionNo,
                    leaveDate,
                    days,
                    outOfficeId,
                    outHosId,
                    turnOp,
                    turnOrgNo,
                    turnDate,
                    ticketNo,
                    ministerNotice,
                    procreateNotice,
                    operateEmpSysno,
                    hosLevelId});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpRegister(
                string opType, 
                string inpatientSn, 
                string hosOrgno, 
                string inpatientNo, 
                string centerNo, 
                string memberName, 
                string familySysno, 
                string memberSysno, 
                string countryTeamCode, 
                string sexId, 
                string idcardNo, 
                string age, 
                string bookno, 
                string cardNo, 
                string icdAllNo, 
                string opsId, 
                string inOfficeId, 
                string officeDate, 
                string cureId, 
                string inHosId, 
                string cureDoctor, 
                string bedNo, 
                string sectionNo, 
                string leaveDate, 
                string days, 
                string outOfficeId, 
                string outHosId, 
                string turnOp, 
                string turnOrgNo, 
                string turnDate, 
                string ticketNo, 
                string ministerNotice, 
                string procreateNotice, 
                string operateEmpSysno, 
                string hosLevelId, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("inpRegister", new object[] {
                    opType,
                    inpatientSn,
                    hosOrgno,
                    inpatientNo,
                    centerNo,
                    memberName,
                    familySysno,
                    memberSysno,
                    countryTeamCode,
                    sexId,
                    idcardNo,
                    age,
                    bookno,
                    cardNo,
                    icdAllNo,
                    opsId,
                    inOfficeId,
                    officeDate,
                    cureId,
                    inHosId,
                    cureDoctor,
                    bedNo,
                    sectionNo,
                    leaveDate,
                    days,
                    outOfficeId,
                    outHosId,
                    turnOp,
                    turnOrgNo,
                    turnDate,
                    ticketNo,
                    ministerNotice,
                    procreateNotice,
                    operateEmpSysno,
                    hosLevelId}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndinpRegister(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliDetailSeek", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.clinicDetailList")]
    public clinicDetailResult[] cliDetailSeek([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo) {
        object[] results = this.Invoke("cliDetailSeek", new object[] {
                    clinicNo});
        return ((clinicDetailResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliDetailSeek(string clinicNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliDetailSeek", new object[] {
                    clinicNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public clinicDetailResult[] EndcliDetailSeek(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((clinicDetailResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("upRelationship", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void upRelationship([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospitalSysno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string code, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisSpec, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisUnit, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisConf, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisPrice, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string reviewresult, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string reviewpersion, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string reviewdatetime) {
        this.Invoke("upRelationship", new object[] {
                    centerNo,
                    hospitalSysno,
                    code,
                    hisCode,
                    hisName,
                    hisSpec,
                    hisUnit,
                    hisConf,
                    hisPrice,
                    reviewresult,
                    reviewpersion,
                    reviewdatetime});
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginupRelationship(string centerNo, string hospitalSysno, string code, string hisCode, string hisName, string hisSpec, string hisUnit, string hisConf, string hisPrice, string reviewresult, string reviewpersion, string reviewdatetime, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("upRelationship", new object[] {
                    centerNo,
                    hospitalSysno,
                    code,
                    hisCode,
                    hisName,
                    hisSpec,
                    hisUnit,
                    hisConf,
                    hisPrice,
                    reviewresult,
                    reviewpersion,
                    reviewdatetime}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndupRelationship(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("inpatientRegister", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public inpatientRegisterResult inpatientRegister(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosOrgno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string familySysno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberSysno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string stature, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string weight, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdAllNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string secondIcdNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string opsId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string treatCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inOfficeId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string officeDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cureId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string complication, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inHosId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cureDoctor, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bedNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sectionNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnMode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string ticketNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string ministerNotice, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string procreateNotice, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("inpatientRegister", new object[] {
                    userName,
                    userPwd,
                    hosOrgno,
                    inpatientNo,
                    centerNo,
                    familySysno,
                    memberSysno,
                    stature,
                    weight,
                    icdAllNo,
                    secondIcdNo,
                    opsId,
                    treatCode,
                    inOfficeId,
                    officeDate,
                    cureId,
                    complication,
                    inHosId,
                    cureDoctor,
                    bedNo,
                    sectionNo,
                    turnMode,
                    turnCode,
                    turnDate,
                    ticketNo,
                    ministerNotice,
                    procreateNotice,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((inpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpatientRegister(
                string userName, 
                string userPwd, 
                string hosOrgno, 
                string inpatientNo, 
                string centerNo, 
                string familySysno, 
                string memberSysno, 
                string stature, 
                string weight, 
                string icdAllNo, 
                string secondIcdNo, 
                string opsId, 
                string treatCode, 
                string inOfficeId, 
                string officeDate, 
                string cureId, 
                string complication, 
                string inHosId, 
                string cureDoctor, 
                string bedNo, 
                string sectionNo, 
                string turnMode, 
                string turnCode, 
                string turnDate, 
                string ticketNo, 
                string ministerNotice, 
                string procreateNotice, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("inpatientRegister", new object[] {
                    userName,
                    userPwd,
                    hosOrgno,
                    inpatientNo,
                    centerNo,
                    familySysno,
                    memberSysno,
                    stature,
                    weight,
                    icdAllNo,
                    secondIcdNo,
                    opsId,
                    treatCode,
                    inOfficeId,
                    officeDate,
                    cureId,
                    complication,
                    inHosId,
                    cureDoctor,
                    bedNo,
                    sectionNo,
                    turnMode,
                    turnCode,
                    turnDate,
                    ticketNo,
                    ministerNotice,
                    procreateNotice,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public inpatientRegisterResult EndinpatientRegister(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((inpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getHospitalInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.HospitalList")]
    public hospitalResult[] getHospitalInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string name) {
        object[] results = this.Invoke("getHospitalInfo", new object[] {
                    name});
        return ((hospitalResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetHospitalInfo(string name, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getHospitalInfo", new object[] {
                    name}, callback, asyncState);
    }
    
    /// <remarks/>
    public hospitalResult[] EndgetHospitalInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((hospitalResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("clinicCalculate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ClinicCalculateResult clinicCalculate([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string username, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string minusMoney, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("clinicCalculate", new object[] {
                    username,
                    userPwd,
                    hosNo,
                    clinicNo,
                    redeemNo,
                    minusMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((ClinicCalculateResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginclinicCalculate(string username, string userPwd, string hosNo, string clinicNo, string redeemNo, string minusMoney, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("clinicCalculate", new object[] {
                    username,
                    userPwd,
                    hosNo,
                    clinicNo,
                    redeemNo,
                    minusMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public ClinicCalculateResult EndclinicCalculate(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((ClinicCalculateResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliSingleCancleFee", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void cliSingleCancleFee([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string detailNo) {
        this.Invoke("cliSingleCancleFee", new object[] {
                    detailNo});
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliSingleCancleFee(string detailNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliSingleCancleFee", new object[] {
                    detailNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndcliSingleCancleFee(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("downloadReferralsheet", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.ReferralList")]
    public ReferralResult[] downloadReferralsheet([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hoscode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inorout, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string truncode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string startturndate, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string endturndate) {
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
    public System.IAsyncResult BegindownloadReferralsheet(string hoscode, string centerno, string inorout, string truncode, string memberno, string startturndate, string endturndate, System.AsyncCallback callback, object asyncState) {
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
    public ReferralResult[] EnddownloadReferralsheet(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((ReferralResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelInpatientPay", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public cancelInpatientPayResult cancelInpatientPay([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cancelCause, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("cancelInpatientPay", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    cancelCause,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((cancelInpatientPayResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelInpatientPay(string userName, string userPwd, string hospCode, string inpatientSn, string cancelCause, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelInpatientPay", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    cancelCause,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public cancelInpatientPayResult EndcancelInpatientPay(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((cancelInpatientPayResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("uploadReferralsheet_New", RequestElementName="uploadReferralsheetNew", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseElementName="uploadReferralsheetResponseNew", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public uploadReferralsheetResponseNewReturn uploadReferralsheet_New(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string orgContacts, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string orgContactPhone, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string orgContactEmail, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string stype, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string familyNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string idCardNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string name, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sex, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string birthday, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bookNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string telphone, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string relation, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnType, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string fromHospitalCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string fromHospitalName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string toHospitalCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string toHospitalName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inHospitalNum, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string totalCostOfYear, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inPayOfYear, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string selfPayOfYear, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string startMoneyOfYear, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string topLineOfYear, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inNumFamily, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string totalCostFamily, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inPayFamily, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string selfPayFamily, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string joinType, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string familyType, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string townCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string townName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string villageCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string villageName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string groupCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string groupName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string trunCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospitalLevelOfLastTime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string leaveDateOfLastTime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string outOfficeOfLastTime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdCodeOfLastTime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdNameOfLastTime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string startMoneyOfLastTime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string isTransProvincial, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("uploadReferralsheet_New", new object[] {
                    centerNo,
                    orgContacts,
                    orgContactPhone,
                    orgContactEmail,
                    stype,
                    memberNo,
                    familyNo,
                    idCardNo,
                    name,
                    sex,
                    birthday,
                    bookNo,
                    telphone,
                    relation,
                    turnType,
                    icdCode,
                    icdName,
                    turnDate,
                    fromHospitalCode,
                    fromHospitalName,
                    toHospitalCode,
                    toHospitalName,
                    inHospitalNum,
                    totalCostOfYear,
                    inPayOfYear,
                    selfPayOfYear,
                    startMoneyOfYear,
                    topLineOfYear,
                    inNumFamily,
                    totalCostFamily,
                    inPayFamily,
                    selfPayFamily,
                    joinType,
                    familyType,
                    townCode,
                    townName,
                    villageCode,
                    villageName,
                    groupCode,
                    groupName,
                    trunCode,
                    hospitalLevelOfLastTime,
                    leaveDateOfLastTime,
                    outOfficeOfLastTime,
                    icdCodeOfLastTime,
                    icdNameOfLastTime,
                    startMoneyOfLastTime,
                    isTransProvincial,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((uploadReferralsheetResponseNewReturn)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginuploadReferralsheet_New(
                string centerNo, 
                string orgContacts, 
                string orgContactPhone, 
                string orgContactEmail, 
                string stype, 
                string memberNo, 
                string familyNo, 
                string idCardNo, 
                string name, 
                string sex, 
                string birthday, 
                string bookNo, 
                string telphone, 
                string relation, 
                string turnType, 
                string icdCode, 
                string icdName, 
                string turnDate, 
                string fromHospitalCode, 
                string fromHospitalName, 
                string toHospitalCode, 
                string toHospitalName, 
                string inHospitalNum, 
                string totalCostOfYear, 
                string inPayOfYear, 
                string selfPayOfYear, 
                string startMoneyOfYear, 
                string topLineOfYear, 
                string inNumFamily, 
                string totalCostFamily, 
                string inPayFamily, 
                string selfPayFamily, 
                string joinType, 
                string familyType, 
                string townCode, 
                string townName, 
                string villageCode, 
                string villageName, 
                string groupCode, 
                string groupName, 
                string trunCode, 
                string hospitalLevelOfLastTime, 
                string leaveDateOfLastTime, 
                string outOfficeOfLastTime, 
                string icdCodeOfLastTime, 
                string icdNameOfLastTime, 
                string startMoneyOfLastTime, 
                string isTransProvincial, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("uploadReferralsheet_New", new object[] {
                    centerNo,
                    orgContacts,
                    orgContactPhone,
                    orgContactEmail,
                    stype,
                    memberNo,
                    familyNo,
                    idCardNo,
                    name,
                    sex,
                    birthday,
                    bookNo,
                    telphone,
                    relation,
                    turnType,
                    icdCode,
                    icdName,
                    turnDate,
                    fromHospitalCode,
                    fromHospitalName,
                    toHospitalCode,
                    toHospitalName,
                    inHospitalNum,
                    totalCostOfYear,
                    inPayOfYear,
                    selfPayOfYear,
                    startMoneyOfYear,
                    topLineOfYear,
                    inNumFamily,
                    totalCostFamily,
                    inPayFamily,
                    selfPayFamily,
                    joinType,
                    familyType,
                    townCode,
                    townName,
                    villageCode,
                    villageName,
                    groupCode,
                    groupName,
                    trunCode,
                    hospitalLevelOfLastTime,
                    leaveDateOfLastTime,
                    outOfficeOfLastTime,
                    icdCodeOfLastTime,
                    icdNameOfLastTime,
                    startMoneyOfLastTime,
                    isTransProvincial,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public uploadReferralsheetResponseNewReturn EnduploadReferralsheet_New(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((uploadReferralsheetResponseNewReturn)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("connectTesting", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string connectTesting() {
        object[] results = this.Invoke("connectTesting", new object[0]);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginconnectTesting(System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("connectTesting", new object[0], callback, asyncState);
    }
    
    /// <remarks/>
    public string EndconnectTesting(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getInpatientInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public InpatientBasicResult getInpatientInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string loginName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientNo) {
        object[] results = this.Invoke("getInpatientInfo", new object[] {
                    hosCode,
                    loginName,
                    inpatientNo});
        return ((InpatientBasicResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetInpatientInfo(string hosCode, string loginName, string inpatientNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getInpatientInfo", new object[] {
                    hosCode,
                    loginName,
                    inpatientNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public InpatientBasicResult EndgetInpatientInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((InpatientBasicResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetCliComInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GetCliComInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string xmlParamater) {
        object[] results = this.Invoke("GetCliComInfo", new object[] {
                    xmlParamater});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetCliComInfo(string xmlParamater, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetCliComInfo", new object[] {
                    xmlParamater}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetCliComInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("createRedeemInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void createRedeemInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string operateEmpSysno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemId) {
        this.Invoke("createRedeemInfo", new object[] {
                    inpatientSn,
                    operateEmpSysno,
                    redeemId});
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincreateRedeemInfo(string inpatientSn, string operateEmpSysno, string redeemId, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("createRedeemInfo", new object[] {
                    inpatientSn,
                    operateEmpSysno,
                    redeemId}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndcreateRedeemInfo(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.leechdomDetailList")]
    public leechdomDetailResult[] updateLeechdom([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string lastTime, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo) {
        object[] results = this.Invoke("updateLeechdom", new object[] {
                    lastTime,
                    centerNo,
                    hosNo});
        return ((leechdomDetailResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginupdateLeechdom(string lastTime, string centerNo, string hosNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("updateLeechdom", new object[] {
                    lastTime,
                    centerNo,
                    hosNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public leechdomDetailResult[] EndupdateLeechdom(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((leechdomDetailResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("inpDetailSeek", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public inpatientDetailResult[] inpDetailSeek([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo) {
        object[] results = this.Invoke("inpDetailSeek", new object[] {
                    inpatientSn,
                    centerNo});
        return ((inpatientDetailResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpDetailSeek(string inpatientSn, string centerNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("inpDetailSeek", new object[] {
                    inpatientSn,
                    centerNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public inpatientDetailResult[] EndinpDetailSeek(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((inpatientDetailResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("officeCodeDown", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.office")]
    public officeResult[] officeCodeDown([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string loginName) {
        object[] results = this.Invoke("officeCodeDown", new object[] {
                    hosCode,
                    loginName});
        return ((officeResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginofficeCodeDown(string hosCode, string loginName, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("officeCodeDown", new object[] {
                    hosCode,
                    loginName}, callback, asyncState);
    }
    
    /// <remarks/>
    public officeResult[] EndofficeCodeDown(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((officeResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("inpatientRegisterSeek", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public inpatientRegisterSeekResult inpatientRegisterSeek([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberSysNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("inpatientRegisterSeek", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    memberSysNo,
                    centerNo,
                    inpatientNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((inpatientRegisterSeekResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpatientRegisterSeek(string userName, string userPwd, string hospCode, string memberSysNo, string centerNo, string inpatientNo, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("inpatientRegisterSeek", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    memberSysNo,
                    centerNo,
                    inpatientNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public inpatientRegisterSeekResult EndinpatientRegisterSeek(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((inpatientRegisterSeekResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("updateLeechdom", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cliDetailInput(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string type, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string no, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicRxNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string detailNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string code, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string classId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string name, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string spec, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string unit, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string conf, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string price, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string quantity, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string money, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string factMoney, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string useDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string enableRatio, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string enableMoney, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisLeechdomCode) {
        object[] results = this.Invoke("cliDetailInput", new object[] {
                    type,
                    no,
                    clinicRxNo,
                    detailNo,
                    code,
                    classId,
                    name,
                    spec,
                    unit,
                    conf,
                    price,
                    quantity,
                    money,
                    factMoney,
                    useDate,
                    enableRatio,
                    enableMoney,
                    hisLeechdomCode});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliDetailInput(
                string type, 
                string no, 
                string clinicRxNo, 
                string detailNo, 
                string code, 
                string classId, 
                string name, 
                string spec, 
                string unit, 
                string conf, 
                string price, 
                string quantity, 
                string money, 
                string factMoney, 
                string useDate, 
                string enableRatio, 
                string enableMoney, 
                string hisLeechdomCode, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("cliDetailInput", new object[] {
                    type,
                    no,
                    clinicRxNo,
                    detailNo,
                    code,
                    classId,
                    name,
                    spec,
                    unit,
                    conf,
                    price,
                    quantity,
                    money,
                    factMoney,
                    useDate,
                    enableRatio,
                    enableMoney,
                    hisLeechdomCode}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndcliDetailInput(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getInpatientGradeList", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.inpatientGradeList")]
    public inpatientGradeResult[] getInpatientGradeList([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn) {
        object[] results = this.Invoke("getInpatientGradeList", new object[] {
                    inpatientSn});
        return ((inpatientGradeResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetInpatientGradeList(string inpatientSn, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getInpatientGradeList", new object[] {
                    inpatientSn}, callback, asyncState);
    }
    
    /// <remarks/>
    public inpatientGradeResult[] EndgetInpatientGradeList(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((inpatientGradeResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("compen", RequestElementName="compen", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public inpatientCaculateResult calculate() {
        object[] results = this.Invoke("calculate", new object[0]);
        return ((inpatientCaculateResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult Begincalculate(System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("calculate", new object[0], callback, asyncState);
    }
    
    /// <remarks/>
    public inpatientCaculateResult Endcalculate(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((inpatientCaculateResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("matchSeek", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string matchSeek([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string code, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospitalSysno) {
        object[] results = this.Invoke("matchSeek", new object[] {
                    centerNo,
                    code,
                    hisCode,
                    hospitalSysno});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginmatchSeek(string centerNo, string code, string hisCode, string hospitalSysno, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("matchSeek", new object[] {
                    centerNo,
                    code,
                    hisCode,
                    hospitalSysno}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndmatchSeek(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliCalculate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public clinicCaculateResult cliCalculate([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo) {
        object[] results = this.Invoke("cliCalculate", new object[] {
                    clinicNo});
        return ((clinicCaculateResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliCalculate(string clinicNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliCalculate", new object[] {
                    clinicNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public clinicCaculateResult EndcliCalculate(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((clinicCaculateResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("updateDiseaseByPage", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public DiseaseListPage updateDiseaseByPage([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string lastTime, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int start, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int skip) {
        object[] results = this.Invoke("updateDiseaseByPage", new object[] {
                    lastTime,
                    centerNo,
                    start,
                    skip});
        return ((DiseaseListPage)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginupdateDiseaseByPage(string lastTime, string centerNo, int start, int skip, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("updateDiseaseByPage", new object[] {
                    lastTime,
                    centerNo,
                    start,
                    skip}, callback, asyncState);
    }
    
    /// <remarks/>
    public DiseaseListPage EndupdateDiseaseByPage(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((DiseaseListPage)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("upInsureData", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string upInsureData(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string unitid, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cardno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string year, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string personalno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string IDNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string InsureNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string RedeemDateOut, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string totalCost, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string totalpersonalPayMoney, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string CIIEligiblecosts, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string CIIstartMoney, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string CIIRedeemMoney, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("upInsureData", new object[] {
                    userName,
                    userPwd,
                    centerno,
                    unitid,
                    cardno,
                    year,
                    personalno,
                    IDNo,
                    InsureNo,
                    RedeemDateOut,
                    totalCost,
                    totalpersonalPayMoney,
                    CIIEligiblecosts,
                    CIIstartMoney,
                    CIIRedeemMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginupInsureData(
                string userName, 
                string userPwd, 
                string centerno, 
                string unitid, 
                string cardno, 
                string year, 
                string personalno, 
                string IDNo, 
                string InsureNo, 
                string RedeemDateOut, 
                string totalCost, 
                string totalpersonalPayMoney, 
                string CIIEligiblecosts, 
                string CIIstartMoney, 
                string CIIRedeemMoney, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("upInsureData", new object[] {
                    userName,
                    userPwd,
                    centerno,
                    unitid,
                    cardno,
                    year,
                    personalno,
                    IDNo,
                    InsureNo,
                    RedeemDateOut,
                    totalCost,
                    totalpersonalPayMoney,
                    CIIEligiblecosts,
                    CIIstartMoney,
                    CIIRedeemMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndupInsureData(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("FeedbackPayInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string FeedbackPayInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sUsrID, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sWDBH, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string Inpatient_sn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string ISPay, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sBankPayMoney, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("FeedbackPayInfo", new object[] {
                    sUsrID,
                    sPwd,
                    sWDBH,
                    Inpatient_sn,
                    ISPay,
                    sBankPayMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginFeedbackPayInfo(string sUsrID, string sPwd, string sWDBH, string Inpatient_sn, string ISPay, string sBankPayMoney, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("FeedbackPayInfo", new object[] {
                    sUsrID,
                    sPwd,
                    sWDBH,
                    Inpatient_sn,
                    ISPay,
                    sBankPayMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndFeedbackPayInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("TransferInfoUpdate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string TransferInfoUpdate([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string RecCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string transferNO, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string transferDate, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("TransferInfoUpdate", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    RecCode,
                    transferNO,
                    transferDate,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginTransferInfoUpdate(string userName, string userPwd, string hospCode, string RecCode, string transferNO, string transferDate, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("TransferInfoUpdate", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    RecCode,
                    transferNO,
                    transferDate,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndTransferInfoUpdate(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("inpCancelFee", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void inpCancelFee([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string no, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo) {
        this.Invoke("inpCancelFee", new object[] {
                    no,
                    centerNo});
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpCancelFee(string no, string centerNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("inpCancelFee", new object[] {
                    no,
                    centerNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndinpCancelFee(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("redeemTypeDown", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.redeemType")]
    public redeemTypeResult[] redeemTypeDown([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string loginName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string year) {
        object[] results = this.Invoke("redeemTypeDown", new object[] {
                    hosCode,
                    loginName,
                    year});
        return ((redeemTypeResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginredeemTypeDown(string hosCode, string loginName, string year, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("redeemTypeDown", new object[] {
                    hosCode,
                    loginName,
                    year}, callback, asyncState);
    }
    
    /// <remarks/>
    public redeemTypeResult[] EndredeemTypeDown(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((redeemTypeResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getHospitalInfo_New", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string getHospitalInfo_New([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string LastTime, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo) {
        object[] results = this.Invoke("getHospitalInfo_New", new object[] {
                    LastTime,
                    centerNo,
                    hosNo});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetHospitalInfo_New(string LastTime, string centerNo, string hosNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getHospitalInfo_New", new object[] {
                    LastTime,
                    centerNo,
                    hosNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndgetHospitalInfo_New(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("clinicPay", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ClinicRedeemResult clinicPay([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string minusMoney, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string familyAccountGeld, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string acceptMan, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string phone, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string invoiceNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("clinicPay", new object[] {
                    userName,
                    userPwd,
                    hosNo,
                    clinicNo,
                    redeemNo,
                    minusMoney,
                    familyAccountGeld,
                    acceptMan,
                    phone,
                    invoiceNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((ClinicRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginclinicPay(
                string userName, 
                string userPwd, 
                string hosNo, 
                string clinicNo, 
                string redeemNo, 
                string minusMoney, 
                string familyAccountGeld, 
                string acceptMan, 
                string phone, 
                string invoiceNo, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("clinicPay", new object[] {
                    userName,
                    userPwd,
                    hosNo,
                    clinicNo,
                    redeemNo,
                    minusMoney,
                    familyAccountGeld,
                    acceptMan,
                    phone,
                    invoiceNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public ClinicRedeemResult EndclinicPay(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((ClinicRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetFamilyMemberInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GetFamilyMemberInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string xmlParamater) {
        object[] results = this.Invoke("GetFamilyMemberInfo", new object[] {
                    xmlParamater});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetFamilyMemberInfo(string xmlParamater, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetFamilyMemberInfo", new object[] {
                    xmlParamater}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetFamilyMemberInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelReferralsheet_New", RequestElementName="cancelReferralsheetNew", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseElementName="cancelReferralsheetResponseNew", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public cancelReferralsheetResponseNewReturn cancelReferralsheet_New([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string trunCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("cancelReferralsheet_New", new object[] {
                    centerNo,
                    trunCode,
                    memberNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((cancelReferralsheetResponseNewReturn)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelReferralsheet_New(string centerNo, string trunCode, string memberNo, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelReferralsheet_New", new object[] {
                    centerNo,
                    trunCode,
                    memberNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public cancelReferralsheetResponseNewReturn EndcancelReferralsheet_New(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((cancelReferralsheetResponseNewReturn)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getInsureDetail", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string getInsureDetail([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string unitid, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cardno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string personalno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string IDNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string startDate, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string endDate, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("getInsureDetail", new object[] {
                    userName,
                    userPwd,
                    centerno,
                    unitid,
                    cardno,
                    personalno,
                    IDNo,
                    startDate,
                    endDate,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetInsureDetail(
                string userName, 
                string userPwd, 
                string centerno, 
                string unitid, 
                string cardno, 
                string personalno, 
                string IDNo, 
                string startDate, 
                string endDate, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("getInsureDetail", new object[] {
                    userName,
                    userPwd,
                    centerno,
                    unitid,
                    cardno,
                    personalno,
                    IDNo,
                    startDate,
                    endDate,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndgetInsureDetail(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("inpatientCalculate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public inpatientCalculateResult inpatientCalculate([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string minusMoney, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("inpatientCalculate", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    redeemNo,
                    minusMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((inpatientCalculateResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpatientCalculate(string userName, string userPwd, string hospCode, string inpatientSn, string redeemNo, string minusMoney, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("inpatientCalculate", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    redeemNo,
                    minusMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public inpatientCalculateResult EndinpatientCalculate(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((inpatientCalculateResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelInpatientRedeem", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public cancelInpatientRedeemResult cancelInpatientRedeem([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("cancelInpatientRedeem", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((cancelInpatientRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelInpatientRedeem(string userName, string userPwd, string hospCode, string inpatientSn, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelInpatientRedeem", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public cancelInpatientRedeemResult EndcancelInpatientRedeem(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((cancelInpatientRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetFamilyPayInfoByPerson", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GetFamilyPayInfoByPerson([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string xmlParamater) {
        object[] results = this.Invoke("GetFamilyPayInfoByPerson", new object[] {
                    xmlParamater});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetFamilyPayInfoByPerson(string xmlParamater, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetFamilyPayInfoByPerson", new object[] {
                    xmlParamater}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetFamilyPayInfoByPerson(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getClinicInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ClinicBasicResult getClinicInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string loginName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemNo) {
        object[] results = this.Invoke("getClinicInfo", new object[] {
                    hosCode,
                    loginName,
                    redeemNo});
        return ((ClinicBasicResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetClinicInfo(string hosCode, string loginName, string redeemNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getClinicInfo", new object[] {
                    hosCode,
                    loginName,
                    redeemNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public ClinicBasicResult EndgetClinicInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((ClinicBasicResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelClinicRedeem", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public CancelClinicRedeemResult cancelClinicRedeem([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("cancelClinicRedeem", new object[] {
                    userName,
                    userPwd,
                    hosNo,
                    clinicNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((CancelClinicRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelClinicRedeem(string userName, string userPwd, string hosNo, string clinicNo, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelClinicRedeem", new object[] {
                    userName,
                    userPwd,
                    hosNo,
                    clinicNo,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public CancelClinicRedeemResult EndcancelClinicRedeem(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((CancelClinicRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("matchUpdate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void matchUpdate([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospitalSysno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string code, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisSpec, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisUnit, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisConf, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisPrice) {
        this.Invoke("matchUpdate", new object[] {
                    centerNo,
                    hospitalSysno,
                    code,
                    hisCode,
                    hisName,
                    hisSpec,
                    hisUnit,
                    hisConf,
                    hisPrice});
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginmatchUpdate(string centerNo, string hospitalSysno, string code, string hisCode, string hisName, string hisSpec, string hisUnit, string hisConf, string hisPrice, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("matchUpdate", new object[] {
                    centerNo,
                    hospitalSysno,
                    code,
                    hisCode,
                    hisName,
                    hisSpec,
                    hisUnit,
                    hisConf,
                    hisPrice}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndmatchUpdate(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("uploadReferralsheet", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string uploadReferralsheet(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hoscode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string truncode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string stype, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string idcardno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string name, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sex, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string birthday, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bookno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string telphone, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turntype, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdcode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdname, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turndate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string fromhospitalcode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string fromhospitalname, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string tohospitalcode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string tohospitalname, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string tohospitallevel, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string tohospitalteclevel, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string leavedateoflasttime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string outofficeoflasttime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdcodeoflasttime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdnameoflasttime, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string doctorname, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string remark, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("uploadReferralsheet", new object[] {
                    hoscode,
                    centerno,
                    truncode,
                    stype,
                    memberno,
                    idcardno,
                    name,
                    sex,
                    birthday,
                    bookno,
                    telphone,
                    turntype,
                    icdcode,
                    icdname,
                    turndate,
                    fromhospitalcode,
                    fromhospitalname,
                    tohospitalcode,
                    tohospitalname,
                    tohospitallevel,
                    tohospitalteclevel,
                    leavedateoflasttime,
                    outofficeoflasttime,
                    icdcodeoflasttime,
                    icdnameoflasttime,
                    doctorname,
                    remark,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginuploadReferralsheet(
                string hoscode, 
                string centerno, 
                string truncode, 
                string stype, 
                string memberno, 
                string idcardno, 
                string name, 
                string sex, 
                string birthday, 
                string bookno, 
                string telphone, 
                string turntype, 
                string icdcode, 
                string icdname, 
                string turndate, 
                string fromhospitalcode, 
                string fromhospitalname, 
                string tohospitalcode, 
                string tohospitalname, 
                string tohospitallevel, 
                string tohospitalteclevel, 
                string leavedateoflasttime, 
                string outofficeoflasttime, 
                string icdcodeoflasttime, 
                string icdnameoflasttime, 
                string doctorname, 
                string remark, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("uploadReferralsheet", new object[] {
                    hoscode,
                    centerno,
                    truncode,
                    stype,
                    memberno,
                    idcardno,
                    name,
                    sex,
                    birthday,
                    bookno,
                    telphone,
                    turntype,
                    icdcode,
                    icdname,
                    turndate,
                    fromhospitalcode,
                    fromhospitalname,
                    tohospitalcode,
                    tohospitalname,
                    tohospitallevel,
                    tohospitalteclevel,
                    leavedateoflasttime,
                    outofficeoflasttime,
                    icdcodeoflasttime,
                    icdnameoflasttime,
                    doctorname,
                    remark,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EnduploadReferralsheet(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("redeemTypeDownLoad", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.redeemTypeDownLoadList")]
    public redeemTypeDownLoadResult[] redeemTypeDownLoad([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string loginName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string runYear, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("redeemTypeDownLoad", new object[] {
                    hospCode,
                    loginName,
                    runYear,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((redeemTypeDownLoadResult[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginredeemTypeDownLoad(string hospCode, string loginName, string runYear, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("redeemTypeDownLoad", new object[] {
                    hospCode,
                    loginName,
                    runYear,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public redeemTypeDownLoadResult[] EndredeemTypeDownLoad(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((redeemTypeDownLoadResult[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetFamilyInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GetFamilyInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string xmlParamater) {
        object[] results = this.Invoke("GetFamilyInfo", new object[] {
                    xmlParamater});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetFamilyInfo(string xmlParamater, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetFamilyInfo", new object[] {
                    xmlParamater}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetFamilyInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("creareInpatientRedeem", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public creareInpatientRedeemResult creareInpatientRedeem([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string minusMoney, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("creareInpatientRedeem", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    redeemNo,
                    minusMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((creareInpatientRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincreareInpatientRedeem(string userName, string userPwd, string hospCode, string inpatientSn, string redeemNo, string minusMoney, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("creareInpatientRedeem", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    redeemNo,
                    minusMoney,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public creareInpatientRedeemResult EndcreareInpatientRedeem(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((creareInpatientRedeemResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("clinicUpdate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public ClinicRegisterResult clinicUpdate(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string username, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisClinicNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string familyNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string stature, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string weight, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string firstIcdNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string secondIcdNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inOfficeNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string treatCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicDoctor, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cureCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inHosId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string @operator, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("clinicUpdate", new object[] {
                    username,
                    userPwd,
                    clinicNo,
                    hosNo,
                    centerNo,
                    hisClinicNo,
                    familyNo,
                    memberNo,
                    stature,
                    weight,
                    firstIcdNo,
                    secondIcdNo,
                    inOfficeNo,
                    treatCode,
                    clinicDate,
                    clinicDoctor,
                    cureCode,
                    inHosId,
                    @operator,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((ClinicRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginclinicUpdate(
                string username, 
                string userPwd, 
                string clinicNo, 
                string hosNo, 
                string centerNo, 
                string hisClinicNo, 
                string familyNo, 
                string memberNo, 
                string stature, 
                string weight, 
                string firstIcdNo, 
                string secondIcdNo, 
                string inOfficeNo, 
                string treatCode, 
                string clinicDate, 
                string clinicDoctor, 
                string cureCode, 
                string inHosId, 
                string @operator, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("clinicUpdate", new object[] {
                    username,
                    userPwd,
                    clinicNo,
                    hosNo,
                    centerNo,
                    hisClinicNo,
                    familyNo,
                    memberNo,
                    stature,
                    weight,
                    firstIcdNo,
                    secondIcdNo,
                    inOfficeNo,
                    treatCode,
                    clinicDate,
                    clinicDoctor,
                    cureCode,
                    inHosId,
                    @operator,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public ClinicRegisterResult EndclinicUpdate(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((ClinicRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliStrikeBalance", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cliStrikeBalance([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string settlementNo) {
        object[] results = this.Invoke("cliStrikeBalance", new object[] {
                    settlementNo});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliStrikeBalance(string settlementNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliStrikeBalance", new object[] {
                    settlementNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndcliStrikeBalance(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("leaveInpatientRegister", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public leaveInpatientRegisterResult leaveInpatientRegister(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string leaveDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string outOfficeId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string outHosId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdAllNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string treatCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnMode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("leaveInpatientRegister", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    leaveDate,
                    outOfficeId,
                    outHosId,
                    icdAllNo,
                    treatCode,
                    turnMode,
                    turnCode,
                    turnDate,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((leaveInpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginleaveInpatientRegister(
                string userName, 
                string userPwd, 
                string hospCode, 
                string inpatientSn, 
                string leaveDate, 
                string outOfficeId, 
                string outHosId, 
                string icdAllNo, 
                string treatCode, 
                string turnMode, 
                string turnCode, 
                string turnDate, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("leaveInpatientRegister", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    inpatientSn,
                    leaveDate,
                    outOfficeId,
                    outHosId,
                    icdAllNo,
                    treatCode,
                    turnMode,
                    turnCode,
                    turnDate,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public leaveInpatientRegisterResult EndleaveInpatientRegister(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((leaveInpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelClinicRegister", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public CancelClinicRegister cancelClinicRegister([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cancelCause, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("cancelClinicRegister", new object[] {
                    userName,
                    userPwd,
                    hosNo,
                    clinicNo,
                    cancelCause,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((CancelClinicRegister)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelClinicRegister(string userName, string userPwd, string hosNo, string clinicNo, string cancelCause, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelClinicRegister", new object[] {
                    userName,
                    userPwd,
                    hosNo,
                    clinicNo,
                    cancelCause,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public CancelClinicRegister EndcancelClinicRegister(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((CancelClinicRegister)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliCalculate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cliRegister(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string regType, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hisClinicNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string familyNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string countryNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sexCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string idCard, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string age, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bookNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cardNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosLevel, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string firstIcdNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string secondIcdNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inOfficeNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicDoctor, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cureCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inHosId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string @operator, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnLevel, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnHosNo) {
        object[] results = this.Invoke("cliRegister", new object[] {
                    regType,
                    clinicNo,
                    centerNo,
                    hisClinicNo,
                    familyNo,
                    memberNo,
                    countryNo,
                    memberName,
                    sexCode,
                    idCard,
                    age,
                    bookNo,
                    cardNo,
                    hosNo,
                    hosLevel,
                    firstIcdNo,
                    secondIcdNo,
                    inOfficeNo,
                    clinicDate,
                    clinicDoctor,
                    cureCode,
                    inHosId,
                    @operator,
                    turnLevel,
                    turnHosNo});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliRegister(
                string regType, 
                string clinicNo, 
                string centerNo, 
                string hisClinicNo, 
                string familyNo, 
                string memberNo, 
                string countryNo, 
                string memberName, 
                string sexCode, 
                string idCard, 
                string age, 
                string bookNo, 
                string cardNo, 
                string hosNo, 
                string hosLevel, 
                string firstIcdNo, 
                string secondIcdNo, 
                string inOfficeNo, 
                string clinicDate, 
                string clinicDoctor, 
                string cureCode, 
                string inHosId, 
                string @operator, 
                string turnLevel, 
                string turnHosNo, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("cliRegister", new object[] {
                    regType,
                    clinicNo,
                    centerNo,
                    hisClinicNo,
                    familyNo,
                    memberNo,
                    countryNo,
                    memberName,
                    sexCode,
                    idCard,
                    age,
                    bookNo,
                    cardNo,
                    hosNo,
                    hosLevel,
                    firstIcdNo,
                    secondIcdNo,
                    inOfficeNo,
                    clinicDate,
                    clinicDoctor,
                    cureCode,
                    inHosId,
                    @operator,
                    turnLevel,
                    turnHosNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndcliRegister(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliCancelFee", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void cliCancelFee([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo) {
        this.Invoke("cliCancelFee", new object[] {
                    clinicNo});
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliCancelFee(string clinicNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliCancelFee", new object[] {
                    clinicNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndcliCancelFee(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliDetailInput", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inpDetailInput(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string opType, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientRxno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string detailId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hiscode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string insureId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string classId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string name, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string spec, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string unit, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string conf, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string price, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string quantity, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string money, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string factMoney, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string useDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string enableRatio, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string enableMoney) {
        object[] results = this.Invoke("inpDetailInput", new object[] {
                    opType,
                    inpatientSn,
                    centerNo,
                    inpatientRxno,
                    detailId,
                    hiscode,
                    insureId,
                    classId,
                    name,
                    spec,
                    unit,
                    conf,
                    price,
                    quantity,
                    money,
                    factMoney,
                    useDate,
                    enableRatio,
                    enableMoney});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpDetailInput(
                string opType, 
                string inpatientSn, 
                string centerNo, 
                string inpatientRxno, 
                string detailId, 
                string hiscode, 
                string insureId, 
                string classId, 
                string name, 
                string spec, 
                string unit, 
                string conf, 
                string price, 
                string quantity, 
                string money, 
                string factMoney, 
                string useDate, 
                string enableRatio, 
                string enableMoney, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("inpDetailInput", new object[] {
                    opType,
                    inpatientSn,
                    centerNo,
                    inpatientRxno,
                    detailId,
                    hiscode,
                    insureId,
                    classId,
                    name,
                    spec,
                    unit,
                    conf,
                    price,
                    quantity,
                    money,
                    factMoney,
                    useDate,
                    enableRatio,
                    enableMoney}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndinpDetailInput(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getExpectInsure", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string getExpectInsure([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string unitid, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string startDate, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string endDate, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("getExpectInsure", new object[] {
                    userName,
                    userPwd,
                    centerno,
                    unitid,
                    startDate,
                    endDate,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetExpectInsure(string userName, string userPwd, string centerno, string unitid, string startDate, string endDate, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getExpectInsure", new object[] {
                    userName,
                    userPwd,
                    centerno,
                    unitid,
                    startDate,
                    endDate,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndgetExpectInsure(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetChronicICD", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GetChronicICD([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sYear, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("GetChronicICD", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    sYear,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetChronicICD(string userName, string userPwd, string hospCode, string sYear, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetChronicICD", new object[] {
                    userName,
                    userPwd,
                    hospCode,
                    sYear,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetChronicICD(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("inpPay", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public inpatientPayResult inpPay([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string no, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemId, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemEmpsysno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemDate, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string acceptMan, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string acceptDate, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string redeemOrgno) {
        object[] results = this.Invoke("inpPay", new object[] {
                    no,
                    centerNo,
                    redeemId,
                    redeemEmpsysno,
                    redeemDate,
                    acceptMan,
                    acceptDate,
                    redeemOrgno});
        return ((inpatientPayResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpPay(string no, string centerNo, string redeemId, string redeemEmpsysno, string redeemDate, string acceptMan, string acceptDate, string redeemOrgno, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("inpPay", new object[] {
                    no,
                    centerNo,
                    redeemId,
                    redeemEmpsysno,
                    redeemDate,
                    acceptMan,
                    acceptDate,
                    redeemOrgno}, callback, asyncState);
    }
    
    /// <remarks/>
    public inpatientPayResult EndinpPay(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((inpatientPayResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cancelReferralsheet", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void cancelReferralsheet([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hoscode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerno, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string truncode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string memberno) {
        this.Invoke("cancelReferralsheet", new object[] {
                    hoscode,
                    centerno,
                    truncode,
                    memberno});
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincancelReferralsheet(string hoscode, string centerno, string truncode, string memberno, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cancelReferralsheet", new object[] {
                    hoscode,
                    centerno,
                    truncode,
                    memberno}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndcancelReferralsheet(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("updateLeechdomByPage", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public leechdomListPage updateLeechdomByPage([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string lastTime, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int start, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int skip) {
        object[] results = this.Invoke("updateLeechdomByPage", new object[] {
                    lastTime,
                    centerNo,
                    hosNo,
                    start,
                    skip});
        return ((leechdomListPage)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginupdateLeechdomByPage(string lastTime, string centerNo, string hosNo, int start, int skip, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("updateLeechdomByPage", new object[] {
                    lastTime,
                    centerNo,
                    hosNo,
                    start,
                    skip}, callback, asyncState);
    }
    
    /// <remarks/>
    public leechdomListPage EndupdateLeechdomByPage(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((leechdomListPage)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("upContractServiceData", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public upContractServiceDataResponseReturn upContractServiceData(
                string userName, 
                string userPwd, 
                string hosOrgno, 
                string centerNo, 
                string familySysno, 
                string memberSysno, 
                string idCardNo, 
                string Name, 
                string redeemId, 
                string redeemDate, 
                string totalCost, 
                string redeemMoney, 
                string compenFee, 
                string personpayMoney, 
                string registerStartDate, 
                string registerEndDate, 
                servicePackage[] servicePackageList, 
                string Phone, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive) {
        object[] results = this.Invoke("upContractServiceData", new object[] {
                    userName,
                    userPwd,
                    hosOrgno,
                    centerNo,
                    familySysno,
                    memberSysno,
                    idCardNo,
                    Name,
                    redeemId,
                    redeemDate,
                    totalCost,
                    redeemMoney,
                    compenFee,
                    personpayMoney,
                    registerStartDate,
                    registerEndDate,
                    servicePackageList,
                    Phone,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((upContractServiceDataResponseReturn)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginupContractServiceData(
                string userName, 
                string userPwd, 
                string hosOrgno, 
                string centerNo, 
                string familySysno, 
                string memberSysno, 
                string idCardNo, 
                string Name, 
                string redeemId, 
                string redeemDate, 
                string totalCost, 
                string redeemMoney, 
                string compenFee, 
                string personpayMoney, 
                string registerStartDate, 
                string registerEndDate, 
                servicePackage[] servicePackageList, 
                string Phone, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("upContractServiceData", new object[] {
                    userName,
                    userPwd,
                    hosOrgno,
                    centerNo,
                    familySysno,
                    memberSysno,
                    idCardNo,
                    Name,
                    redeemId,
                    redeemDate,
                    totalCost,
                    redeemMoney,
                    compenFee,
                    personpayMoney,
                    registerStartDate,
                    registerEndDate,
                    servicePackageList,
                    Phone,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public upContractServiceDataResponseReturn EndupContractServiceData(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((upContractServiceDataResponseReturn)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("inpSingleCancelFee", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public void inpSingleCancelFee([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string detailId, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo) {
        this.Invoke("inpSingleCancelFee", new object[] {
                    detailId,
                    centerNo});
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpSingleCancelFee(string detailId, string centerNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("inpSingleCancelFee", new object[] {
                    detailId,
                    centerNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public void EndinpSingleCancelFee(System.IAsyncResult asyncResult) {
        this.EndInvoke(asyncResult);
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliAuditingSeek", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cliAuditingSeek([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string settlementNo) {
        object[] results = this.Invoke("cliAuditingSeek", new object[] {
                    settlementNo});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliAuditingSeek(string settlementNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliAuditingSeek", new object[] {
                    settlementNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndcliAuditingSeek(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("inpatientUpdate", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public inpatientRegisterResult inpatientUpdate(
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userName, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userPwd, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientSn, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hosOrgno, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inpatientNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string stature, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string weight, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string icdAllNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string secondIcdNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string opsId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string treatCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inOfficeId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string officeDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cureId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string complication, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string inHosId, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cureDoctor, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string bedNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string sectionNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnMode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnCode, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string turnDate, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string ticketNo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string ministerNotice, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string procreateNotice, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, 
                [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("inpatientUpdate", new object[] {
                    userName,
                    userPwd,
                    inpatientSn,
                    hosOrgno,
                    inpatientNo,
                    stature,
                    weight,
                    icdAllNo,
                    secondIcdNo,
                    opsId,
                    treatCode,
                    inOfficeId,
                    officeDate,
                    cureId,
                    complication,
                    inHosId,
                    cureDoctor,
                    bedNo,
                    sectionNo,
                    turnMode,
                    turnCode,
                    turnDate,
                    ticketNo,
                    ministerNotice,
                    procreateNotice,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((inpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegininpatientUpdate(
                string userName, 
                string userPwd, 
                string inpatientSn, 
                string hosOrgno, 
                string inpatientNo, 
                string stature, 
                string weight, 
                string icdAllNo, 
                string secondIcdNo, 
                string opsId, 
                string treatCode, 
                string inOfficeId, 
                string officeDate, 
                string cureId, 
                string complication, 
                string inHosId, 
                string cureDoctor, 
                string bedNo, 
                string sectionNo, 
                string turnMode, 
                string turnCode, 
                string turnDate, 
                string ticketNo, 
                string ministerNotice, 
                string procreateNotice, 
                string obligateOne, 
                string obligateTwo, 
                string obligateThree, 
                string obligateFour, 
                string obligateFive, 
                System.AsyncCallback callback, 
                object asyncState) {
        return this.BeginInvoke("inpatientUpdate", new object[] {
                    userName,
                    userPwd,
                    inpatientSn,
                    hosOrgno,
                    inpatientNo,
                    stature,
                    weight,
                    icdAllNo,
                    secondIcdNo,
                    opsId,
                    treatCode,
                    inOfficeId,
                    officeDate,
                    cureId,
                    complication,
                    inHosId,
                    cureDoctor,
                    bedNo,
                    sectionNo,
                    turnMode,
                    turnCode,
                    turnDate,
                    ticketNo,
                    ministerNotice,
                    procreateNotice,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public inpatientRegisterResult EndinpatientUpdate(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((inpatientRegisterResult)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("getPersonInfo_New", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseElementName="getPersonInfoResponseNew", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlArrayAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [return: System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.MemberList")]
    public Member[] getPersonInfo_New([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string cardNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string hospCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string centerNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string year, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("getPersonInfo_New", new object[] {
                    cardNo,
                    hospCode,
                    centerNo,
                    year,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((Member[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegingetPersonInfo_New(string cardNo, string hospCode, string centerNo, string year, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("getPersonInfo_New", new object[] {
                    cardNo,
                    hospCode,
                    centerNo,
                    year,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public Member[] EndgetPersonInfo_New(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((Member[])(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetChronicInfo", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string GetChronicInfo([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string PeopCode, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateOne, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateTwo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateThree, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFour, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string obligateFive) {
        object[] results = this.Invoke("GetChronicInfo", new object[] {
                    PeopCode,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetChronicInfo(string PeopCode, string obligateOne, string obligateTwo, string obligateThree, string obligateFour, string obligateFive, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetChronicInfo", new object[] {
                    PeopCode,
                    obligateOne,
                    obligateTwo,
                    obligateThree,
                    obligateFour,
                    obligateFive}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetChronicInfo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("cliSettlement", RequestNamespace="http://webservice.cmis.taiyang.com/", ResponseNamespace="http://webservice.cmis.taiyang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cliSettlement([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string clinicNo, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string userNo) {
        object[] results = this.Invoke("cliSettlement", new object[] {
                    clinicNo,
                    userNo});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BegincliSettlement(string clinicNo, string userNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("cliSettlement", new object[] {
                    clinicNo,
                    userNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndcliSettlement(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.treatmentModeResult")]
public partial class treatmentModeResult
{
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string code;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isDiseaseAppointed;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.treatmentDiseaseList")]
    public treatmentDiseaseResult[] diseaseList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string remark;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string other;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.treatmentDiseaseResult")]
public partial class treatmentDiseaseResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string treatCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string diseaseCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string diseaseName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.CancelClinicRedeemResult")]
public partial class CancelClinicRedeemResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.InpatientCaculateResult")]
public partial class inpatientCaculateResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string factRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyAccountPayMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.InpatientPayResult")]
public partial class inpatientPayResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inpatientRedeemno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyAccountPayMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.inpatientRedeemResult")]
public partial class inpatientRedeemResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string masterName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string relationName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string identityName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCard;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string address;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string joinPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string essentialMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string provinceMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemTypeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isSpecial;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isPaul;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string phoneCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.InpatientFeeList")]
    public InpatientFeeResult[] feeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.inpatientGradeList")]
    public inpatientGradeResult[] gradeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string anlagernMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string fundPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospAssumeMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string personalPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string civilRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string materialMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.InpatientFeeResult")]
public partial class InpatientFeeResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string feeCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string feeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double basicTotalMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double auditMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double checkMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.inpatientGradeList")]
public partial class inpatientGradeResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inpatientSn;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string endMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ratio;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.queryContractServiceDataResult")]
public partial class queryContractServiceDataResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string checkState;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCardNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string masterName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string relationName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string identityName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCard;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string address;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string joinPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string accounUpDownMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string accounUpDownReason;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string phoneCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.ClinicCalculateResult")]
public partial class ClinicCalculateResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicRedeemNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string masterName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string relationName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string identityName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCard;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string address;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string joinPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string essentialMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string provinceMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemTypeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string checkDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isSpecial;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isPaul;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isAduit;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.CreareClinicRedeemResult")]
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.ClinicFeeList")]
    public ClinicFeeResult[] feeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.CreareClinicRedeemResult")]
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.ClinicGradeList")]
    public ClinicGradeResult[] gradeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string anlagernMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string fundPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospAssumeMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string personalPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string civilRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string calculateMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string materialMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double familyAccountMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool familyAccountMoneySpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.ClinicFeeResult")]
public partial class ClinicFeeResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string feeCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string feeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string basicTotalMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string auditMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.ClinicGradeResult")]
public partial class ClinicGradeResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string endMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ratio;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.cancelLeaveInpatientRegisterResult")]
public partial class cancelLeaveInpatientRegisterResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.ClinicBasicResult")]
public partial class ClinicBasicResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string masterName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string relationName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string identityName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCard;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int currYearRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currYearTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currYearEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currYearReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string address;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string joinPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int currFamilyRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currFamilyTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currFamilyEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currFamilyReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double redeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string RedeemTypeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string phonecode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double anlagernMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string reservationOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string reservationTwo;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.ClinicRegisterSeekResult")]
public partial class ClinicRegisterSeekResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familySysNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberSysNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string firstIcdNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.CancelClinicPayResult")]
public partial class CancelClinicPayResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.inpatientRegisterResult")]
public partial class inpatientRegisterResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inpatientSn;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.clinicDetailList")]
public partial class clinicDetailResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string detailId;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicRxno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string insureId;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string spec;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string unit;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string conf;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string price;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string quantity;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string useDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string factMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableRation;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string classNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string money;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.cancelInpatientRedeemResult")]
public partial class cancelInpatientRedeemResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.inpatientCalculateResult")]
public partial class inpatientCalculateResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string masterName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string relationName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string identityName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCard;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string address;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string joinPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string essentialMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string provinceMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string calculateMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemTypeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isSpecial;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isPaul;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.InpatientFeeList")]
    public InpatientFeeResult[] feeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.inpatientGradeList")]
    public inpatientGradeResult[] gradeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string anlagernMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string fundPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospAssumeMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string personalPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string civilRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string materialMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.creareInpatientRedeemResult")]
public partial class creareInpatientRedeemResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string masterName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string relationName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string identityName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCard;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string address;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string joinPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string essentialMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string provinceMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string checkMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemTypeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string checkDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isSpecial;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isPaul;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isAduit;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.InpatientFeeList")]
    public InpatientFeeResult[] feeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.inpatientGradeList")]
    public inpatientGradeResult[] gradeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string anlagernMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string fundPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospAssumeMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string personalPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string civilRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string materialMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string assumeMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.ClinicRegisterResult")]
public partial class ClinicRegisterResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.CreareClinicRedeemResult")]
public partial class ReferralResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string centerno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string truncode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string stype;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idcardno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sex;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string telphone;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string turntype;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string icdcode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string icdname;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string turndate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string fromhospitalcode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string fromhospitalname;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string tohospitalcode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string tohospitalname;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string tohospitallevel;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string tohospitalteclevel;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string leavedateoflasttime;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string outofficeoflasttime;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string icdcodeoflasttime;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string icdnameoflasttime;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doctorname;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string remark;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.leaveInpatientRegisterResult")]
public partial class leaveInpatientRegisterResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string medicineCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string essentialMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string provinceMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cureCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string operationCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string materialCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.leechdomListPage")]
public partial class leechdomListPage {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int rows;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("list", IsNullable=true)]
    public leechdomDetailResult[] list;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.LeechdomDetailResult")]
public partial class leechdomDetailResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string insureId;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string spec;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string unit;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string conf;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string price;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string everyMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ratio;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string adminLevel;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isClinic;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string remark;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inputPyCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inputWbCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string approveMinPrice;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string approveMaxPrice;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string grade;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string updateTime;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string classNo;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.cancelInpatientRegisterResult")]
public partial class cancelInpatientRegisterResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.ClinicCaculateResult")]
public partial class clinicCaculateResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string checkMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyAccountMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorRedeemNumber;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberRedeemNumber;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberRedeemMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.InpatientRedeemGradeResult")]
public partial class InpatientRedeemGradeResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inpatientSn;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string endMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ratio;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.InpatientBasicResult")]
public partial class InpatientBasicResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string masterName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string relationName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string identityName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCard;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int currYearRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currYearTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currYearEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currYearReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string address;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string joinPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int currFamilyRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currFamilyTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currFamilyEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double currFamilyReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double redeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string RedeemTypeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isSpecial;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isPaul;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string phonecode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("feeList", IsNullable=true)]
    public InpatientFeeResult[] feeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("gradeList", IsNullable=true)]
    public InpatientRedeemGradeResult[] gradeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double anlagernMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string reservationOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string reservationTwo;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.CancelClinicRegister")]
public partial class CancelClinicRegister {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.ClinicRedeemResult")]
public partial class ClinicRedeemResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicRedeemNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string masterName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string relationName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string identityName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCard;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string address;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string joinPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string essentialMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string provinceMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemTypeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isSpecial;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isPaul;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string phoneCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.CreareClinicRedeemResult")]
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.ClinicFeeList")]
    public ClinicFeeResult[] feeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.CreareClinicRedeemResult")]
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.ClinicGradeList")]
    public ClinicGradeResult[] gradeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string anlagernMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string fundPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospAssumeMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string personalPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string civilRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string materialMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double familyAccountMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool familyAccountMoneySpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.cancelInpatientPayResult")]
public partial class cancelInpatientPayResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.cancelContractServiceDataResult")]
public partial class cancelContractServiceDataResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://webservice.cmis.taiyang.com/")]
public partial class UnsupportedEncodingException {
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.redeemType")]
public partial class redeemTypeResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string code;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string otherParam;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string comment;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string accountType;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.inpatientDetailList")]
public partial class inpatientDetailResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string detailId;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inpatientSn;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inpatientRxno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string insureId;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string spec;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string unit;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string conf;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string price;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string quantity;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string useDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string everyMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ratio;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string adminLevel;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isClinic;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string remark;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inputPyCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inputWbCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string approveMinPrice;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string approveMaxPrice;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string grade;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string updateTime;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string factMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableRation;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string classNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string money;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.office")]
public partial class officeResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string code;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string otherParam;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string comment;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.feeclass")]
public partial class FeeClass {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string code;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string description;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inputCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string invoiceSign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string parentCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string systemSign;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.hospital")]
public partial class hospitalResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospLevel;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string centerNo;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.redeemTypeDownLoadResult")]
public partial class redeemTypeDownLoadResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string code;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string otherParam;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string comment;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string accountType;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isRedemImmediate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://webservice.cmis.taiyang.com/")]
public partial class servicePackage {
    
    /// <remarks/>
    public string ServicePackageId;
    
    /// <remarks/>
    public string ServicePackageName;
    
    /// <remarks/>
    public string DJ;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://webservice.cmis.taiyang.com/")]
public partial class GetChronicICD {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userPwd;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sYear;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.inpatientRegisterSeekResult")]
public partial class inpatientRegisterSeekResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inpatientSn;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familySysno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberSysno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string icdAllNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string officeDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.DiseaseResult")]
public partial class diseaseResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string icdAllno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string icdName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string scienceName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string description;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string icdType;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string icdFlag;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexLimited;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string createTime;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string updateTime;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inputcodePy;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string inputcodeWb;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string chronicFlag;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string state;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string remark;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string useFrequency;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.diseaseListPage")]
public partial class DiseaseListPage {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int rows;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("list", IsNullable=true)]
    public diseaseResult[] list;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.ClinicBanlanceResult")]
public partial class clinicBanlanceResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string medicineChineseCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string medicineWesternCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string checkCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cureCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMedicineSum;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableSum;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string checkRedeem;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemAccounttype;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemId;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemOrgno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemMoney;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.Member")]
public partial class Member {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNO;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string countryTeamCode;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familySysno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexId;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idcardNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string age;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cardNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyAddress;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string tel;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ideName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string transCode;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://com.taiyang.cmis.webservice.dto.CreareClinicRedeemResult")]
public partial class CreareClinicRedeemResult {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clinicRedeemNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string memberNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string bookNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sexName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string birthday;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string masterName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string relationName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string identityName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string idCard;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currYearReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string familyNo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string address;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string doorPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string joinPropName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyRedeemCount;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyTotal;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyEnableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currFamilyReddemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCosts;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string enableMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string essentialMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string provinceMedicineMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string startMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string checkMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemTypeName;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string checkDate;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isSpecial;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isPaul;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string isAduit;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.ClinicFeeList")]
    public ClinicFeeResult[] feeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("list", Namespace="http://com.taiyang.cmis.webservice.dto.ClinicGradeList")]
    public ClinicGradeResult[] gradeList;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string anlagernMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string fundPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hospAssumeMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string personalPayMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string civilRedeemMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string materialMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public double familyAccountMoney;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool familyAccountMoneySpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://webservice.cmis.taiyang.com/")]
public partial class uploadReferralsheetResponseNewReturn {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string reason;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://webservice.cmis.taiyang.com/")]
public partial class cancelReferralsheetResponseNewReturn {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string reason;
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("WebServiceStudio", "0.0.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://webservice.cmis.taiyang.com/")]
public partial class upContractServiceDataResponseReturn {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sign;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string redeemno;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateOne;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateTwo;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateThree;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFour;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string obligateFive;
}
