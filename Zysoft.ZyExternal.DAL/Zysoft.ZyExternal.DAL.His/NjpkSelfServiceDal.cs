using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.OracleClient;
using System.Data;
using Zysoft.FrameWork.Database;
using Zysoft.FrameWork;
using Zysoft.ZyExternal.DAL.Common;
using Zysoft.FrameWork.WebService;
using Zysoft.ZyExternal.DAL.His.RemoteService;
using System.Web.Configuration;

namespace Zysoft.ZyExternal.DAL.His
{
    public class NjpkSelfServiceDal : DB
    {
        string serviceURL = "http://localhost:4940/webservices/WSSelfService.asmx";

        public NjpkSelfServiceDal()
        {
            serviceURL = WebConfigurationManager.AppSettings["SelfServiceURL"];
        }


        #region 2131 办卡
        /// <summary>
        /// 办卡
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int CreateCardPatInfo2131(XmlDocument docRequestPre, out string outParm)
        {
             
            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");

            XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
            ndResponseResultXuan.AppendChild(ndResponseItemXuan);

            string nameEmployeNo, clientType;
            string tradeCode = "2134";
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            string patientName, birthday, sex, mobileNo, address, idCardNo;
            patientName = ndParams.SelectSingleNode("hzxm").InnerText;
            birthday = ndParams.SelectSingleNode("birth").InnerText;
            sex = ndParams.SelectSingleNode("sex").InnerText;
            if (sex == "男")
                sex = "0";
            else
                sex = "1";
            mobileNo = ndParams.SelectSingleNode("lxdh").InnerText;
            address = ndParams.SelectSingleNode("lxdz").InnerText;
            idCardNo = ndParams.SelectSingleNode("sfzh").InnerText;
            //=========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;

            XmlElement eleBankCardNo = docRequest.CreateElement("BankCardNo");
            eleBankCardNo.InnerText = "";
            ndRequest.AppendChild(eleBankCardNo);

            XmlElement elePatientName = docRequest.CreateElement("PatientName");
            elePatientName.InnerText = patientName;
            ndRequest.AppendChild(elePatientName);

            XmlElement eleBirthday = docRequest.CreateElement("Birthday");
            eleBirthday.InnerText = birthday;
            ndRequest.AppendChild(eleBirthday);

            XmlElement eleSex = docRequest.CreateElement("Sex");
            eleSex.InnerText = sex;
            ndRequest.AppendChild(eleSex);

            XmlElement eleAge = docRequest.CreateElement("Age");
            eleAge.InnerText = sex;
            ndRequest.AppendChild(eleAge);

            XmlElement eleMobileNo = docRequest.CreateElement("MobileNo");
            eleMobileNo.InnerText = mobileNo;
            ndRequest.AppendChild(eleMobileNo);

            XmlElement eleIDCardNo = docRequest.CreateElement("IDCardNo");
            eleIDCardNo.InnerText = idCardNo;
            ndRequest.AppendChild(eleIDCardNo);

            XmlElement eleAddress = docRequest.CreateElement("Address");
            eleAddress.InnerText = address;
            ndRequest.AppendChild(eleAddress);

            XmlElement eleBankDate = docRequest.CreateElement("BankDate");
            eleBankDate.InnerText = DateTime.Now.ToString("yyyyMMddhhmmss");
            ndRequest.AppendChild(eleBankDate);

            XmlElement eleBankTradeNo = docRequest.CreateElement("BankTradeNo");
            eleBankTradeNo.InnerText = address;
            ndRequest.AppendChild(eleBankTradeNo);
            
            //========================================================



            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                XmlElement elePatid = docResponseXuan.CreateElement("patid");
                elePatid.InnerText = ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(elePatid);

                XmlElement eleblh = docResponseXuan.CreateElement("blh");
                eleblh.InnerText = "";
                ndResponseItemXuan.AppendChild(eleblh);

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("2134 无卡建档", ex);
                return -1;
            }
            return 0;
        }
        #endregion

    }
}
