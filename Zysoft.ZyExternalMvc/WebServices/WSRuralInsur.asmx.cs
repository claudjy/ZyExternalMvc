using Microsoft.Practices.Unity;
using Zysoft.FrameWork.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using Zysoft.ZyExternal.IBLL.RuralInsur;
using Zysoft.FrameWork;


namespace Zysoft.ZyExternalMvc.WebServices
{
    /// <summary>
    /// WSInterfase 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.Zysoft.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WSRuralInsur : System.Web.Services.WebService  
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        #region A001 获取病人信息函数获取病人信息函数
        /// <summary>
        /// A001 获取病人信息函数获取病人信息函数
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "A001 获取病人信息函数获取病人信息函数")]
        public string getPersonInfo(string rateType, string bookno)
        {
            string outParm = "";
            string successParm;
            IBasicInformation basicInformation = ContainerFactory.GetContainer().Resolve<IBasicInformation>();
            outParm = basicInformation.getPersonInfo(rateType, bookno);
            successParm = StringExtension.StringMid(ref outParm, ":");
            if (!successParm.Equals("success"))
            {
                return "error:" + outParm;
            }
            return "success:" + outParm;
        }
        #endregion


        #region B002 住院登记（扩展函数）
        /// <summary>
        /// B002 住院登记（扩展函数）
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="residenceNo"></param>
        /// <param name="bookNo"></param>
        /// <param name="safetyNo"></param>
        /// <param name="diagnosisCode"></param>
        /// <param name="diagnosisCode2"></param>
        /// <param name="admissionDept"></param>
        /// <param name="admissionTime"></param>
        /// <param name="registType"></param>
        /// <param name="admissionCondition"></param>
        /// <param name="doctor"></param>
        /// <param name="bedNo"></param>
        /// <param name="ward"></param>
        /// <returns></returns>
        [WebMethod(Description = "B002 住院登记（扩展函数）")]
        public string inpatientRegister(string rateType, string centerCodeEx, string residenceNo, string bookNo, string safetyNo, 
                                        string diagnosisCode, string diagnosisCode2, string admissionDept, string admissionTime, string registType,
                                        string admissionCondition, string doctor, string bedNo, string ward, string turnCode)
        {
            string outParm = "";
            string successParm;
            IRuralResi ruralResi = ContainerFactory.GetContainer().Resolve<IRuralResi>();
            outParm = ruralResi.inpatientRegister(rateType, centerCodeEx, residenceNo, bookNo, safetyNo, diagnosisCode,
                                         diagnosisCode2, admissionDept, admissionTime, registType, admissionCondition,  doctor,  bedNo,  ward, turnCode);

               successParm = StringExtension.StringMid(ref outParm, ":");
            if (!successParm.Equals("success"))
            {
                return "error:" + outParm;
            }
            return "success:" + outParm;
        }
        #endregion


        #region B003 取消住院登记（扩展函数）cancelInpatientRegister
        /// <summary>
        /// B003 取消住院登记（扩展函数）cancelInpatientRegister
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = " B003 取消住院登记（扩展函数）cancelInpatientRegister")]
        public string cancelInpatientRegister(string rateType, string centerCodeEx, string insuranceNo)
        {
            string outParm = "";
            string successParm;
            IRuralResi ruralResi = ContainerFactory.GetContainer().Resolve<IRuralResi>();
            outParm = ruralResi.cancelInpatientRegister(rateType, centerCodeEx, insuranceNo);

            successParm = StringExtension.StringMid(ref outParm, ":");
            if (!successParm.Equals("success"))
            {
                return "error:" + outParm;
            }
            return "success:" + outParm;
        }
        #endregion
    }
}
