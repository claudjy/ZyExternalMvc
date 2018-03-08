﻿using System;
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
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResponseRoot = docResponseRoot.SelectSingleNode("root");

            string nameEmployeNo, clientType, siType;
            string sMoney;
            string tradeCode = "2131";
            XmlNode ndroot = docRequestPre.SelectSingleNode("/root");
            nameEmployeNo = ndroot.SelectSingleNode("operName").InnerText;
            clientType = "25";

            string name, birthday, sexCode,sexName, mobileNo, address, idCardNo;
            string cardNo, cardNoType;
            try
            {
                cardNo = ndroot.SelectSingleNode("cardNo").InnerText;
                cardNoType = ndroot.SelectSingleNode("cardNoType").InnerText;
                name = ndroot.SelectSingleNode("name").InnerText;
                birthday = ndroot.SelectSingleNode("birthday").InnerText;
                sexCode = ndroot.SelectSingleNode("sexCode").InnerText;
                sexName = ndroot.SelectSingleNode("sexName").InnerText;

                sMoney = ndroot.SelectSingleNode("money").InnerText;
                if (!sMoney.IsFloat())
                {
                    ndResponseRoot.SelectSingleNode("appCode").InnerText = "9999";
                    ndResponseRoot.SelectSingleNode("errorMsg").InnerText = "金额必须为数字！";
                    outParm = ndResponseRoot.OuterXml;
                    return -1;
                }
                if (sMoney.Trim().IsNull()) sMoney = "0.0";
                double money;
                money = sMoney.To<double>();

                switch (cardNoType)
                {
                    case "01": //需要收费
                        if (money < 5)
                        {
                            ndResponseRoot.SelectSingleNode("appCode").InnerText = "0";
                            ndResponseRoot.SelectSingleNode("errorMsg").InnerText = "卡需要收费， 请录入要的金额！";
                            outParm = docResponseRoot.OuterXml;
                            return -1;
                        }
                        money = money - 5;
                        break;
                    default:
                        break;

                }
                if (sexCode == "M")
                    sexCode = "0";
                else
                    sexCode = "1";
                mobileNo = ndroot.SelectSingleNode("homeTel").InnerText;
                address = ndroot.SelectSingleNode("home").InnerText;
                idCardNo = ndroot.SelectSingleNode("idenNo").InnerText;
                siType = ndroot.SelectSingleNode("siType").InnerText;
                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;

                XmlElement elePayCardNo = docRequest.CreateElement("PayCardNo");
                elePayCardNo.InnerText = cardNo;
                ndRequest.AppendChild(elePayCardNo);

                XmlElement elePatientName = docRequest.CreateElement("PatientName");
                elePatientName.InnerText = name;
                ndRequest.AppendChild(elePatientName);

                XmlElement eleSex = docRequest.CreateElement("Sex");
                eleSex.InnerText = sexCode;
                ndRequest.AppendChild(eleSex);

                XmlElement eleBirthday = docRequest.CreateElement("Birthday");
                eleBirthday.InnerText = birthday;
                ndRequest.AppendChild(eleBirthday);

                XmlElement eleAge = docRequest.CreateElement("Age");
                eleAge.InnerText = "0";
                ndRequest.AppendChild(eleAge);

                XmlElement eleMobileNo = docRequest.CreateElement("MobileNo");
                eleMobileNo.InnerText = mobileNo;
                ndRequest.AppendChild(eleMobileNo);

                XmlElement eleAddress = docRequest.CreateElement("Address");
                eleAddress.InnerText = address;
                ndRequest.AppendChild(eleAddress);

                XmlElement eleIDCardNo = docRequest.CreateElement("IDCardNo");
                eleIDCardNo.InnerText = idCardNo;
                ndRequest.AppendChild(eleIDCardNo);

                XmlElement eleMoney = docRequest.CreateElement("Money");
                eleMoney.InnerText = money.ToString();
                ndRequest.AppendChild(eleMoney);

                XmlElement elePayType = docRequest.CreateElement("PayType");
                elePayType.InnerText = "1";
                ndRequest.AppendChild(elePayType);

                XmlElement eleBankCardNo = docRequest.CreateElement("BankCardNo");
                eleBankCardNo.InnerText = "";
                ndRequest.AppendChild(eleBankCardNo);

                XmlElement eleBankTradeNo = docRequest.CreateElement("BankTradeNo");
                eleBankTradeNo.InnerText = "";
                ndRequest.AppendChild(eleBankTradeNo);


                XmlElement eleBankDate = docRequest.CreateElement("BankDate");
                eleBankDate.InnerText = DateTime.Now.ToString("yyyyMMddhhmmss");
                ndRequest.AppendChild(eleBankDate);

                XmlElement eleNotes = docRequest.CreateElement("Notes");
                eleNotes.InnerText = "";
                ndRequest.AppendChild(eleNotes);

                XmlElement eleCaseDeductFee = docRequest.CreateElement("CaseDeductFee");
                eleCaseDeductFee.InnerText = "";
                ndRequest.AppendChild(eleCaseDeductFee);

                XmlElement eleRateType = docRequest.CreateElement("RateType");
                eleRateType.InnerText = siType;
                ndRequest.AppendChild(eleRateType);


                //========================================================




                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                string resultCode, resultMessage;

                resultCode = ndResponse.SelectSingleNode("ResultCode").InnerText;
                resultMessage = ndResponse.SelectSingleNode("ResultContent").InnerText;

                if (resultCode != "0000")
                {
                    ndResponseRoot.SelectSingleNode("appCode").InnerText = resultCode;
                    ndResponseRoot.SelectSingleNode("errorMsg").InnerText = resultMessage;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                XmlElement elepatientId = docResponseRoot.CreateElement("patientId");
                elepatientId.InnerText = ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseRoot.AppendChild(elepatientId);

                ndResponseRoot.SelectSingleNode("appCode").InnerText = resultCode;
                ndResponseRoot.SelectSingleNode("errorMsg").InnerText = resultMessage;

                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseRoot.SelectSingleNode("appCode").InnerText = "9999";
                ndResponseRoot.SelectSingleNode("errorMsg").InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("2134 无卡建档", ex);
                return -1;
            }
            return 0;
        }
        #endregion

    }
}