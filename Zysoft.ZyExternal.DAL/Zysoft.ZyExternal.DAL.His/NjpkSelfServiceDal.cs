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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Zysoft.ZyExternal.DAL.His
{
    public class NjpkSelfServiceDal : DB
    {
        private const string publicKey = "sbAY2hSUbjpJOb67oaiqbg==";
        private const string signature = "/sWSwSZx2KR8mOFTUdOqqTRXj+pI4H42ueEcqlwc0jjqx9Rl23LDAA==";
        string serviceURL = "http://localhost:4940/webservices/WSSelfService.asmx";

        public NjpkSelfServiceDal()
        {
            serviceURL = WebConfigurationManager.AppSettings["SelfServiceURL"];
        }

        #region 000 网络测试
        public int NetTest2108(XmlDocument docRequestPre, out string outParm)
        {
            outParm = "";
            UtilityDAL utilityDAL = new UtilityDAL();
            outParm = "";
            string nameEmployeNo, clientType;
            string tradeCode = "2108";
            //nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            //clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;


            //========================================================
            //XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            //XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            //ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            //ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;
            //ndRequest.SelectSingleNode("ClientType").InnerText = clientType;

            //XmlElement eleisCheckFp = docRequest.CreateElement("isCheckFp");
            //eleisCheckFp.InnerText = "";
            //ndRequest.AppendChild(eleisCheckFp);
            //ndRequest.SelectSingleNode("isCheckFp").InnerText = "0";
            //========================================================

            //XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            //XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");

            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(docRequestPre.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                //ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                //ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = docResponse.OuterXml;
            }
            catch (Exception ex)
            {
                //docResponse.SelectSingleNode("resultCode").InnerText = "9999";
                //docResponse.SelectSingleNode("resultMessage").InnerText = ex.Message;
                //outParm = docResponse.OuterXml;
                Log4NetHelper.Error("网络测试", ex);
            }
            return 0;
        }
        #endregion

        #region 001 用户HIS信息注册
        /// <summary>
        /// 001 用户HIS信息注册
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int RegisterCtznCard(XmlDocument docRequestPre, out string outParm)
        {
            outParm = "";
            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");

            string nameEmployeNo, clientType, personalType;
            string sMoney;
            string tradeCode = "2131";
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("/root");
            nameEmployeNo = ndReqRoot.SelectSingleNode("operCode").InnerText;
            clientType = "25";

            string name, birthday, sexCode, sexName, mobileNo, address, idCardNo;
            string cardNo, cardNoType;
            string machineCode;
            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            ndResRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResRoot.AppendChild(elerspMsg);

            try
            {


                cardNo = ndReqRoot.SelectSingleNode("cardNo").InnerText;
                cardNoType = ndReqRoot.SelectSingleNode("cardNoType").InnerText;
                name = ndReqRoot.SelectSingleNode("name").InnerText;
                birthday = ndReqRoot.SelectSingleNode("birthday").InnerText;
                sexCode = ndReqRoot.SelectSingleNode("sexCode").InnerText;
                sexName = ndReqRoot.SelectSingleNode("sexName").InnerText;
                machineCode = ndReqRoot.SelectSingleNode("machineCode").InnerText;

                sMoney = ndReqRoot.SelectSingleNode("money").InnerText;
                if (!sMoney.IsFloat())
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = "金额必须为数字！";
                    outParm = ndResRoot.OuterXml;
                    return -1;
                }
                if (sMoney.Trim().IsNull()) sMoney = "0.0";
                double money;
                money = sMoney.To<double>();


                if (sexCode == "M")
                    sexCode = "0";
                else
                    sexCode = "1";
                mobileNo = ndReqRoot.SelectSingleNode("homeTel").InnerText;
                address = ndReqRoot.SelectSingleNode("home").InnerText;
                idCardNo = ndReqRoot.SelectSingleNode("idenNo").InnerText;
                personalType = ndReqRoot.SelectSingleNode("personalType").InnerText;
                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;
                ndRequest.SelectSingleNode("TerminalID").InnerText = machineCode;


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

                //XmlElement eleBankTradeNo = docRequest.CreateElement("BankTradeNo");
                //eleBankTradeNo.InnerText = "";
                //ndRequest.AppendChild(eleBankTradeNo);


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
                eleRateType.InnerText = personalType;
                ndRequest.AppendChild(eleRateType);

                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;

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
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = resultMessage;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                XmlElement elepatientId = docResponseRoot.CreateElement("patientId");
                elepatientId.InnerText = ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResRoot.AppendChild(elepatientId);



                elerspCode.InnerText = "1";
                elerspMsg.InnerText = resultMessage;

                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("用户HIS信息注册", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 002 判断自助机当前是否可挂号
        /// <summary>
        /// 判断自助机当前是否可挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        public int CanRegister(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("/root");

            string clientType, tradeCode = "2305";
            clientType = "25";
            string cardNo, registerTypeId;
            string seeTime, machineLocation, speciDisea, typeId;

            string departmentCode, doctorCode;
            string startDate, endDate, sessionCode;

            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            ndResRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResRoot.AppendChild(elerspMsg);

            try
            {

                cardNo = ndReqRoot.SelectSingleNode("cardNo").InnerText;
                departmentCode = ndReqRoot.SelectSingleNode("departmentId").InnerText;
                doctorCode = ndReqRoot.SelectSingleNode("expertId").InnerText;
                seeTime = ndReqRoot.SelectSingleNode("seeTime").InnerText;
                speciDisea = ndReqRoot.SelectSingleNode("speciDisea").InnerText;
                typeId = ndReqRoot.SelectSingleNode("typeId").InnerText;
                machineLocation = ndReqRoot.SelectSingleNode("machineLocation").InnerText;
                registerTypeId = ndReqRoot.SelectSingleNode("registerTypeId").InnerText;

                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = "";
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;

                DateTime dtNow;
                dtNow = DateTime.Now;


                startDate = dtNow.ToString("yyyy-mm-dd");
                endDate = dtNow.ToString("yyyy-mm-dd");
                if (seeTime == "1")
                {
                    sessionCode = "S";
                }
                else
                {
                    sessionCode = "X";
                }

                XmlElement eleStartDate = docRequest.CreateElement("StartDate");
                eleStartDate.InnerText = startDate;
                ndRequest.AppendChild(eleStartDate);

                XmlElement eleEndDate = docRequest.CreateElement("EndDate");
                eleEndDate.InnerText = endDate;
                ndRequest.AppendChild(eleEndDate);

                XmlElement eleSessionCode = docRequest.CreateElement("SessionCode");
                eleSessionCode.InnerText = sessionCode;
                ndRequest.AppendChild(eleSessionCode);

                XmlElement eleDepartmentCode = docRequest.CreateElement("DepartmentCode");
                eleDepartmentCode.InnerText = departmentCode;
                ndRequest.AppendChild(eleDepartmentCode);

                XmlElement eleDoctor = docRequest.CreateElement("Doctor");
                eleDoctor.InnerText = "";
                ndRequest.AppendChild(eleDoctor);

                XmlElement eleDoctorCode = docRequest.CreateElement("DoctorCode");
                eleDoctorCode.InnerText = doctorCode;
                ndRequest.AppendChild(eleDoctorCode);

                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;

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

                XmlElement eleoutRegister = docResponseRoot.CreateElement("outRegister");
                eleoutRegister.InnerText = "0";
                ndReqRoot.AppendChild(eleoutRegister);

                if (resultCode != "0000")
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = resultMessage;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }


                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = resultMessage;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                eleoutRegister.InnerText = "1";
                elerspCode.InnerText = "1";
                elerspMsg.InnerText = resultMessage;

                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("002 判断自助机当前是否可挂号", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 003 同步医生排班信息接口
        /// <summary>
        /// 判断自助机当前是否可挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        public int getSchedueInfo(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("/root");

            string clientType, tradeCode = "2305";
            clientType = "25";
            //string cardNo, departmentId, expertId, registerClassId, registerTypeId;
            //string seeTime, machineLocation, speciDisea, typeId;

            string departmentCode = "", doctorCode = "", schedueType = "";
            string startDate, endDate, sessionCode = "A";
            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            ndResRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResRoot.AppendChild(elerspMsg);

            try
            {
                startDate = ndReqRoot.SelectSingleNode("clinicDate").InnerText;
                //startDate = startDate.Substring(0, 4) + "-" + startDate.Substring(4, 2) + "-" + startDate.Substring(6, 2);
                endDate = startDate;
                schedueType = ndReqRoot.SelectSingleNode("SchedueType").InnerText;


                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = "";
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;


                XmlElement eleStartDate = docRequest.CreateElement("StartDate");
                eleStartDate.InnerText = startDate;
                ndRequest.AppendChild(eleStartDate);

                XmlElement eleEndDate = docRequest.CreateElement("EndDate");
                eleEndDate.InnerText = endDate;
                ndRequest.AppendChild(eleEndDate);

                XmlElement eleSessionCode = docRequest.CreateElement("SessionCode");
                eleSessionCode.InnerText = sessionCode;
                ndRequest.AppendChild(eleSessionCode);

                XmlElement eleDepartmentCode = docRequest.CreateElement("DepartmentCode");
                eleDepartmentCode.InnerText = departmentCode;
                ndRequest.AppendChild(eleDepartmentCode);

                XmlElement eleDoctor = docRequest.CreateElement("Doctor");
                eleDoctor.InnerText = "";//胡浩/04045 李小冬/1044
                ndRequest.AppendChild(eleDoctor);

                XmlElement eleDoctorCode = docRequest.CreateElement("DoctorCode");
                eleDoctorCode.InnerText = doctorCode;
                ndRequest.AppendChild(eleDoctorCode);

                XmlElement eleServiceDate = docRequest.CreateElement("ServiceDate");
                eleServiceDate.InnerText = "";
                ndRequest.AppendChild(eleServiceDate);

                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;
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

                XmlElement eleoutRegister = docResponseRoot.CreateElement("outRegister");
                eleoutRegister.InnerText = "0";
                ndResRoot.AppendChild(eleoutRegister);



                if (resultCode != "0000")
                {
                    elerspMsg.InnerText = resultMessage;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    elerspMsg.InnerText = "交易成功！";
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                string deptName, doctorName, sexCode, titleName, eduName;
                string doctorIntroduce;
                string preLimit, availableNum, queueType, doctor, registName, fee;
                string employeNo, serviceDate, deptCode, registCode;
                string operatorTime, seeTime;

                string outRegister = "0";
                foreach (XmlNode ndSchedule in ndResponse.SelectNodes("Schedules/Schedule"))
                {

                    doctorCode = ndSchedule.SelectSingleNode("DoctorCode").InnerText;
                    doctorName = ndSchedule.SelectSingleNode("DoctorName").InnerText;
                    deptCode = ndSchedule.SelectSingleNode("DepartmentCode").InnerText;
                    deptName = ndSchedule.SelectSingleNode("DepartmentName").InnerText;
                    queueType = ndSchedule.SelectSingleNode("QueueType").InnerText;
                    sexCode = ndSchedule.SelectSingleNode("SexCode").InnerText;
                    titleName = ndSchedule.SelectSingleNode("DoctorTitle").InnerText;
                    eduName = ndSchedule.SelectSingleNode("EduName").InnerText;
                    doctorIntroduce = ndSchedule.SelectSingleNode("DoctorIntroduce").InnerText;
                    doctor = ndSchedule.SelectSingleNode("Doctor").InnerText;
                    preLimit = ndSchedule.SelectSingleNode("PreLimit").InnerText;
                    availableNum = ndSchedule.SelectSingleNode("AvailableNum").InnerText;
                    sessionCode = ndSchedule.SelectSingleNode("SessionCode").InnerText;
                    registName = ndSchedule.SelectSingleNode("DoctorSessType").InnerText;
                    registCode = ndSchedule.SelectSingleNode("DoctorSessTypeCode").InnerText;
                    fee = ndSchedule.SelectSingleNode("Fee").InnerText;
                    employeNo = ndSchedule.SelectSingleNode("OtherCode").InnerText.Trim();
                    serviceDate = ndSchedule.SelectSingleNode("ServiceDate").InnerText;
                    operatorTime = ndSchedule.SelectSingleNode("OperatorTime").InnerText;

                    //pt-普通，zj-专家，jz-急诊，zk-专科，zb-专病，lh-联合门诊
                    switch (registCode)
                    {
                        case "81":
                            registCode = "pt";
                            break;
                        case "":
                            registCode = "zj";
                            break;
                    }

                    if (sessionCode == "S")
                    {
                        seeTime = "1";
                    }
                    else
                    {
                        seeTime = "3";
                    }

                    string registerFlag, startTime, endTime, doctorSeq;
                    eleServiceDate.InnerText = serviceDate;
                    docRequest.SelectSingleNode("Request/SessionCode").InnerText = sessionCode;
                    docRequest.SelectSingleNode("Request/DepartmentCode").InnerText = deptCode;
                    docRequest.SelectSingleNode("Request/Doctor").InnerText = doctor;

                    XmlNode ndTimeInfos;
                    if (GetPreTime2304(docRequest, out registerFlag,
                                    out cycleNum, out ndTimeInfos, out outParm) < 0)
                    {
                        //ndResRoot.SelectSingleNode("appCode").InnerText = "0";
                        //ndResRoot.SelectSingleNode("errorMsg").InnerText = outParm;
                        //outParm = docResponseRoot.OuterXml;
                        continue;
                    }
                    XmlElement elePreSchedule = docResponseRoot.CreateElement("Schedule");


                    outRegister = "1";

                    XmlElement eleclinicDate = docResponseRoot.CreateElement("clinicDate");
                    XmlElement eledepartmentId = docResponseRoot.CreateElement("departmentId");
                    XmlElement eledepartmentName = docResponseRoot.CreateElement("departmentName");
                    XmlElement eleexpertId = docResponseRoot.CreateElement("expertId");
                    XmlElement eleexpertName = docResponseRoot.CreateElement("expertName");
                    XmlElement eleregisterClassId = docResponseRoot.CreateElement("registerClassId");
                    XmlElement eleregisterTypeId = docResponseRoot.CreateElement("registerTypeId");
                    XmlElement eleregisterCount = docResponseRoot.CreateElement("registerCount");
                    XmlElement eleremainCount = docResponseRoot.CreateElement("remainCount");
                    XmlElement elewaitNo = docResponseRoot.CreateElement("waitNo");
                    XmlElement eleseeTime = docResponseRoot.CreateElement("seeTime");
                    XmlElement eletotalFee = docResponseRoot.CreateElement("totalFee");
                    XmlElement eleregisterFee = docResponseRoot.CreateElement("registerFee");
                    XmlElement elediagnoseFee = docResponseRoot.CreateElement("diagnoseFee");
                    XmlElement eleadditionalFee = docResponseRoot.CreateElement("additionalFee");



                    XmlElement elecrtTime = docResponseRoot.CreateElement("crtTime");
                    XmlElement eleupdTime = docResponseRoot.CreateElement("updTime");



                    eleclinicDate.InnerText = serviceDate;
                    eledepartmentId.InnerText = deptCode;
                    eledepartmentName.InnerText = deptName;
                    eleexpertId.InnerText = doctor;
                    eleexpertName.InnerText = doctorName;
                    eleregisterClassId.InnerText = registCode;
                    eleregisterTypeId.InnerText = "0";
                    eleregisterCount.InnerText = (preLimit.To<long>() - availableNum.To<long>()).ToString();
                    eleremainCount.InnerText = availableNum;
                    elewaitNo.InnerText = "";
                    eleseeTime.InnerText = seeTime;
                    eletotalFee.InnerText = fee;
                    eleregisterFee.InnerText = fee;
                    elediagnoseFee.InnerText = "0";
                    eleadditionalFee.InnerText = "0";

                    elecrtTime.InnerText = operatorTime;
                    eleupdTime.InnerText = operatorTime;

                    elePreSchedule.AppendChild(eleclinicDate);
                    elePreSchedule.AppendChild(eledepartmentId);
                    elePreSchedule.AppendChild(eledepartmentName);
                    elePreSchedule.AppendChild(eleexpertId);
                    elePreSchedule.AppendChild(eleexpertName);
                    elePreSchedule.AppendChild(eleregisterClassId);
                    elePreSchedule.AppendChild(eleregisterTypeId);
                    elePreSchedule.AppendChild(eleregisterCount);
                    elePreSchedule.AppendChild(eleremainCount);
                    elePreSchedule.AppendChild(elewaitNo);
                    elePreSchedule.AppendChild(eleseeTime);
                    elePreSchedule.AppendChild(eletotalFee);
                    elePreSchedule.AppendChild(eleregisterFee);
                    elePreSchedule.AppendChild(elediagnoseFee);
                    elePreSchedule.AppendChild(eleadditionalFee);

                    elePreSchedule.AppendChild(elecrtTime);
                    elePreSchedule.AppendChild(eleupdTime);

                    if (cycleNum > 0)
                    {
                        foreach (XmlNode ndTimeInfo in ndTimeInfos)
                        {
                            startTime = ndTimeInfo.SelectSingleNode("StartTime").InnerText;
                            endTime = ndTimeInfo.SelectSingleNode("EndTime").InnerText;
                            doctorSeq = ndTimeInfo.SelectSingleNode("DoctorSeq").InnerText;
                            XmlElement eleTimeInfo = docResponseRoot.CreateElement("TimeInfo");

                            XmlElement elesectionId = docResponseRoot.CreateElement("sectionId");
                            XmlElement elesectionStartTime = docResponseRoot.CreateElement("sectionStartTime");
                            XmlElement elesectionEndTime = docResponseRoot.CreateElement("sectionEndTime");
                            XmlElement elestopFlag = docResponseRoot.CreateElement("stopFlag");
                            XmlElement elereservateFlag = docResponseRoot.CreateElement("reservateFlag");
                            XmlElement eleschedueFlow = docResponseRoot.CreateElement("schedueFlow");

                            elesectionId.InnerText = doctorSeq;
                            elesectionStartTime.InnerText = startTime;
                            elesectionEndTime.InnerText = endTime;
                            elestopFlag.InnerText = "0";
                            elereservateFlag.InnerText = "";
                            eleschedueFlow.InnerText = "";

                            eleTimeInfo.AppendChild(elesectionId);
                            eleTimeInfo.AppendChild(elesectionStartTime);
                            eleTimeInfo.AppendChild(elesectionEndTime);
                            eleTimeInfo.AppendChild(elestopFlag);
                            eleTimeInfo.AppendChild(elereservateFlag);
                            eleTimeInfo.AppendChild(eleschedueFlow);

                            elePreSchedule.AppendChild(eleTimeInfo);
                        }
                    }
                    ndResRoot.AppendChild(elePreSchedule);
                }

                eleoutRegister.InnerText = "1";
                elerspCode.InnerText = "1";
                elerspMsg.InnerText = resultMessage;

                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("003 同步医生排班信息接口", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 004 判断当前号别是否可挂号
        /// <summary>
        /// 004 判断当前号别是否可挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        public int CanRegisterType(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("/root");

            string clientType, tradeCode = "2314";
            outParm = "";
            clientType = "25";
            string seeTime;
            string departmentCode, doctor;
            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            ndResRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResRoot.AppendChild(elerspMsg);

            try
            {
                seeTime = ndReqRoot.SelectSingleNode("seeTime").InnerText;
                departmentCode = ndReqRoot.SelectSingleNode("departmentId").InnerText;
                doctor = ndReqRoot.SelectSingleNode("expertId").InnerText;
                XmlElement eleregisterFlag = docResponseRoot.CreateElement("registerFlag");
                ndResRoot.AppendChild(eleregisterFlag);

                string resultMessage = "";
                string registerFlag, startTime, endTime, doctorSeq, errorMsg;
                registerFlag = "0";
                string serviceDate;
                DateTime dtNow = DateTime.Now;
                serviceDate = dtNow.ToString("yyyy-MM-dd");
                if (GetRegisterType(serviceDate, seeTime, departmentCode, doctor, out startTime, out endTime,
                    out doctorSeq, out registerFlag, out errorMsg) < 0)
                {
                    eleregisterFlag.InnerText = registerFlag;
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = errorMsg;
                    return -1;
                }

                if (registerFlag == "0")
                {
                    eleregisterFlag.InnerText = "0";
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = "无有效号源";
                    return 0;
                }

                eleregisterFlag.InnerText = registerFlag;
                elerspCode.InnerText = "1";
                elerspMsg.InnerText = resultMessage;

                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("判断当前号别是否可挂号", ex);
                return -1;
            }
            return 0;
        }

        private int GetRegisterType(string serviceDate, string seeTime, string departmentCode, string doctor,
            out string startTime, out string endTime, out string doctorSeq,
            out string registerFlag, out string errorMsg
            )
        {
            UtilityDAL utilityDAL = new UtilityDAL();
            startTime = endTime = doctorSeq = registerFlag = errorMsg = "0";
            try
            {
                string clientType, tradeCode = "2314";
                clientType = "25";
                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = "";
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;

                //DateTime dtNow;
                //dtNow = DateTime.Now;

                string startDate, endDate, sessionCode;
                startDate = serviceDate;
                endDate = serviceDate;

                switch (seeTime)
                {
                    case "1":
                        sessionCode = "S";
                        break;
                    case "3":
                        sessionCode = "X";
                        break;
                    default:
                        sessionCode = "S";
                        break;

                }

                XmlElement eleStartDate = docRequest.CreateElement("StartDate");
                eleStartDate.InnerText = startDate;
                ndRequest.AppendChild(eleStartDate);

                XmlElement eleEndDate = docRequest.CreateElement("EndDate");
                eleEndDate.InnerText = endDate;
                ndRequest.AppendChild(eleEndDate);

                XmlElement eleSessionCode = docRequest.CreateElement("SessionCode");
                eleSessionCode.InnerText = sessionCode;
                ndRequest.AppendChild(eleSessionCode);

                XmlElement eleDepartmentCode = docRequest.CreateElement("DepartmentCode");
                eleDepartmentCode.InnerText = departmentCode;
                ndRequest.AppendChild(eleDepartmentCode);

                XmlElement eleDoctor = docRequest.CreateElement("Doctor");
                eleDoctor.InnerText = doctor;
                ndRequest.AppendChild(eleDoctor);

                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;

                //========================================================


                string outParm;

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
                    errorMsg = resultMessage;
                    return -1;
                }


                long cycleNum;
                cycleNum = long.Parse(ndResponse.SelectSingleNode("CycleNum").InnerText);
                registerFlag = "0";
                if (cycleNum <= 0)
                {
                    errorMsg = "无有效号！";
                    registerFlag = "0";
                    return 0;
                }

                string doctorSessTypeCode;
                doctorSessTypeCode = ndResponse.SelectSingleNode("DoctorInfos/DoctorInfo").Attributes["DoctorSessTypeCode"].Value;

                for (int i = 0; i < cycleNum; i++)
                {
                    if (ndResponse.SelectSingleNode("DoctorInfos/DoctorInfo").Attributes["Doctor"].Value == doctor)
                    {
                        if (docResponse.SelectSingleNode("Response/DoctorInfos/DoctorInfo").FirstChild == null)
                        {
                            errorMsg = "无有效号！";
                            registerFlag = "0";
                            return 0;
                        }
                        startTime = docResponse.SelectSingleNode("Response/DoctorInfos/DoctorInfo").FirstChild.Attributes["StartTime"].Value;
                        endTime = docResponse.SelectSingleNode("Response/DoctorInfos/DoctorInfo").FirstChild.Attributes["EndTime"].Value;
                        doctorSeq = docResponse.SelectSingleNode("Response/DoctorInfos/DoctorInfo").FirstChild.Attributes["DoctorSeq"].Value;
                        registerFlag = "1";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return -1;
            }
            return 0;
        }



        private int GetPreTime2304(XmlDocument docRequest, out string registerFlag,
               out long cycleNum, out XmlNode ndTimeInfos, out string outParm)
        {

            outParm = "";
            registerFlag = "0";
            cycleNum = 0;
            docRequest.SelectSingleNode("/Request/TradeCode").InnerText = "2304";

            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndTimeInfos = null;
            ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
            ndRequest.SelectSingleNode("Signature").InnerText = signature;


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
                outParm = resultMessage;
                return -1;
            }


            cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
            if (cycleNum <= 0)
            {
                return 0;
            }

            ndTimeInfos = docResponse.SelectSingleNode("Response/TimeInfos");
            if (ndTimeInfos.SelectNodes("TimeInfo").Count == 0)
            {
                return 0;
            }

            registerFlag = "1";
            return 0;
        }
        #endregion

        #region 005 挂号
        /// <summary>
        /// 005 挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        public int Register(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("root");

            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            ndResRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResRoot.AppendChild(elerspMsg);

            string visitNo, empNameNo, visitData;
            empNameNo = "system";

            try
            {
                #region 001 查询可预约号
                string resultCode = "0", resultMessage = "";
                string registerFlag, startTime, endTime, doctorSeq, errorMsg;
                registerFlag = "0";
                //begin ===========================查询可预约号==============================
                string seeTime, departmentCode, doctor, machineCode;
                seeTime = ndReqRoot.SelectSingleNode("inSeeTime").InnerText;
                departmentCode = ndReqRoot.SelectSingleNode("inDepartmentId").InnerText;
                doctor = ndReqRoot.SelectSingleNode("inExpertId").InnerText;
                if (doctor.IsNull()) doctor = "*";

                doctorSeq = ndReqRoot.SelectSingleNode("inSectionId").InnerText;

                string inCardNo, inBankRefcode, inReservatePayJe, inReservatePayMethod;
                string payType = "1";
                empNameNo = ndReqRoot.SelectSingleNode("inReceiverNo").InnerText;
                inCardNo = ndReqRoot.SelectSingleNode("inCardNo").InnerText;
                machineCode = ndReqRoot.SelectSingleNode("machineCode").InnerText;

                inBankRefcode = ndReqRoot.SelectSingleNode("inBankRefcode").InnerText;
                inReservatePayJe = ndReqRoot.SelectSingleNode("inReservatePayJe").InnerText;

                inReservatePayMethod = ndReqRoot.SelectSingleNode("inReservatePayMethod").InnerText;
                payType = inReservatePayMethod;

                if (inReservatePayJe.IsFloat())
                {
                    if (inReservatePayJe.To<decimal>() > 0)
                    {
                        if (CreatePrepayment2151(inCardNo, empNameNo, inBankRefcode, machineCode, inReservatePayJe, "0", payType, out errorMsg) < 0)
                        {
                            elerspCode.InnerText = "0";
                            elerspMsg.InnerText = errorMsg;
                            outParm = docResponseRoot.OuterXml;
                            return -1;
                        }
                    }
                }

                string serviceDate;
                DateTime dtNow = DateTime.Now;
                serviceDate = dtNow.ToString("yyyy-MM-dd");
                if (doctorSeq.IsNull())
                {
                    if (GetRegisterType(serviceDate, seeTime, departmentCode, doctor, out startTime, out endTime,
                        out doctorSeq, out registerFlag, out errorMsg) < 0)
                    {
                        elerspCode.InnerText = "0";
                        elerspMsg.InnerText = errorMsg;
                        outParm = docResponseRoot.OuterXml;
                        return -1;
                    }

                    if (registerFlag == "0")
                    {
                        elerspCode.InnerText = "0";
                        elerspMsg.InnerText = "无有效号源";
                        outParm = docResponseRoot.OuterXml;
                        return 0;
                    }
                }
                //end ===========================查询可预约号==============================
                #endregion

                #region 002 挂号
                //begin ===========================预约==============================


                string preHisTradeNo, admitAddress, admitRange;
                if (PreQuene2306(departmentCode, doctor, serviceDate, inCardNo, doctorSeq,
                    seeTime, empNameNo, machineCode, out preHisTradeNo, out admitAddress, out admitRange,
                    out errorMsg) < 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = errorMsg;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                //end =========================================================
                //begin ===========================挂号确认==============================
                if (Regcost2058(preHisTradeNo, empNameNo, out visitNo, out errorMsg) < 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = errorMsg;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                //end =========================================================
                #endregion
                if (GetPatientVisitInfo2090(visitNo, empNameNo, out visitData, out errorMsg) < 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = errorMsg;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                string charges; string insurFund;
                string money;
                string insurAccountCharges; string insurHospCharges; string insurBalance;
                string insurSafe; string insurOfficialCharges; string insuranceNo;
                string safetyNo; string insuranceCardNo; string returnText;
                string businessNo; string insurApplyNo, cost;
                string inPersonnelType;
                string bankDate;
                charges = insurFund = "0";
                insurAccountCharges = insurHospCharges = insurBalance = "0";
                insurSafe = insurOfficialCharges = insuranceNo = "0";
                safetyNo = insuranceCardNo = returnText = "0";
                businessNo = insurApplyNo = "0";

                string bankTradeNo, tradeText, registerInparm;
                string inBankTraceDate, inBankTraceTime;
                money = ndReqRoot.SelectSingleNode("inCashPay").InnerText;
                cost = ndReqRoot.SelectSingleNode("inJeAll").InnerText;
                bankTradeNo = ndReqRoot.SelectSingleNode("inRcptstreamno").InnerText;
                inPersonnelType = ndReqRoot.SelectSingleNode("inPersonnelType").InnerText;
                inBankTraceDate = ndReqRoot.SelectSingleNode("inBankTraceDate").InnerText;
                inBankTraceTime = ndReqRoot.SelectSingleNode("inBankTraceTime").InnerText;

                tradeText = ndReqRoot.SelectSingleNode("siInParam").InnerText;
                returnText = ndReqRoot.SelectSingleNode("siOutParam").InnerText;
                registerInparm = ndReqRoot.SelectSingleNode("siDjParam").InnerText;

                charges = money;

                bankDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                insurFund = (decimal.Parse(cost) - decimal.Parse(charges)).ToString();

                string rateType, cardId, admitDate, applyDeptName;
                string patientID, receiptNo;
                JObject joVisitData = JObject.Parse(visitData);
                cardId = joVisitData["PayCardNo"].ToString();
                rateType = joVisitData["RateType"].ToString();
                admitDate = joVisitData["AdmitDate"].ToString();
                applyDeptName = joVisitData["ApplyDeptName"].ToString();
                patientID = joVisitData["PatientID"].ToString();

                //switch (inPersonnelType)
                //{
                //    case "0":
                //        inPersonnelType = "S";
                //        break;
                //    case "1":
                //        inPersonnelType = "1";
                //        break;

                //}

                if (cardId != inCardNo)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = "录入的卡号， 与原卡号不一致！"; ;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                //if (inPersonnelType != rateType)
                //{
                //    elerspCode.InnerText = "0";
                //    elerspMsg.InnerText = "费别不同， 不能结算！";
                //    outParm = docResponseRoot.OuterXml;
                //    return -1;
                //}

                //string siOutParam = "0095-20180502083441-982^1.0|0.5|0.0|0.0|0.0|0.5|0.0|0.0|0.5|0.0|0.0|0.5|786.6|||0.0|1.0|0.00|13||^^";
                string[] settleList1 = returnText.Split('^');
                if (settleList1.Length > 2)
                {
                    string[] settleList2 = settleList1[1].Split('|');
                    string insur1, insur2, insur3, insur4;
                    if (settleList2.Length > 18)
                    {

                        insur1 = settleList2[1];
                        insur2 = settleList2[2];
                        insur3 = settleList2[3];
                        insur4 = settleList2[4];
                        insurFund = (decimal.Parse(insur1) + decimal.Parse(insur2)
                            + decimal.Parse(insur3) + decimal.Parse(insur4)).ToString();
                        insurAccountCharges = settleList2[5];
                        charges = settleList2[6];
                        insurBalance = settleList2[12];

                    }
                }

                string[] inList1 = tradeText.Split('^');
                if (inList1.Length > 8)
                {
                    businessNo = inList1[3];

                    string[] regList = inList1[7].Split('|');
                    insuranceNo = regList[0];
                    safetyNo = regList[13];
                    insuranceCardNo = safetyNo;
                }

                string settleNo;
                if (ChargeSettle2094(visitNo, money, "0", charges, insurFund,
                      insurAccountCharges, insurHospCharges, insurBalance,
                      insurSafe, insurOfficialCharges, insuranceNo,
                      safetyNo, insuranceCardNo, tradeText, returnText,
                      businessNo, insurApplyNo, "1",
                      visitData, "", payType, bankTradeNo, empNameNo,
                      bankDate, machineCode, out receiptNo, out settleNo, out errorMsg) < 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = errorMsg;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                XmlElement eleoutFlowId = docResponseRoot.CreateElement("outFlowId");
                eleoutFlowId.InnerText = visitNo;
                ndResRoot.AppendChild(eleoutFlowId);

                XmlElement eleoutRcptStreamNo = docResponseRoot.CreateElement("outRcptStreamNo");
                eleoutRcptStreamNo.InnerText = preHisTradeNo;
                ndResRoot.AppendChild(eleoutRcptStreamNo);

                XmlElement eleoutRegisterTime = docResponseRoot.CreateElement("outRegisterTime");
                eleoutRegisterTime.InnerText = admitDate;
                ndResRoot.AppendChild(eleoutRegisterTime);

                XmlElement eleoutAddress = docResponseRoot.CreateElement("outAddress");
                eleoutAddress.InnerText = applyDeptName;
                ndResRoot.AppendChild(eleoutAddress);


                XmlElement eleoutOrderNo = docResponseRoot.CreateElement("outOrderNo");
                eleoutOrderNo.InnerText = doctorSeq.Substring(2);
                ndResRoot.AppendChild(eleoutOrderNo);

                XmlElement eleoutReceiverNo = docResponseRoot.CreateElement("outReceiverNo");
                eleoutReceiverNo.InnerText = empNameNo.Substring(0, empNameNo.IndexOf('/'));
                ndResRoot.AppendChild(eleoutReceiverNo);

                XmlElement eleoutReceiver = docResponseRoot.CreateElement("outReceiver");
                eleoutReceiver.InnerText = empNameNo.Substring(empNameNo.IndexOf('/'));
                ndResRoot.AppendChild(eleoutReceiver);

                XmlElement eleoutPatientId = docResponseRoot.CreateElement("outPatientId");
                eleoutPatientId.InnerText = patientID;
                ndResRoot.AppendChild(eleoutPatientId);

                XmlElement eleoutHspNo = docResponseRoot.CreateElement("outHspNo");
                eleoutHspNo.InnerText = "";
                ndResRoot.AppendChild(eleoutHspNo);

                XmlElement eleoutMzNo = docResponseRoot.CreateElement("outMzNo");
                eleoutMzNo.InnerText = "";
                ndResRoot.AppendChild(eleoutMzNo);

                XmlElement eleoutPreNo = docResponseRoot.CreateElement("outPreNo");
                eleoutPreNo.InnerText = receiptNo;
                ndResRoot.AppendChild(eleoutPreNo);

                elerspCode.InnerText = "1";
                elerspMsg.InnerText = resultMessage;

                outParm = docResponseRoot.OuterXml;

                if (rateType == "F")
                {
                    BankTradeLogDal bankTradeLogDal = new BankTradeLogDal();
                    decimal lostCash = 0;
                    lostCash = decimal.Parse(cost) - (decimal.Parse(charges) + decimal.Parse(insurFund) +
                     decimal.Parse(insurAccountCharges) + decimal.Parse(insurHospCharges) +
                     decimal.Parse(insurSafe) + decimal.Parse(insurOfficialCharges));
                    Log4NetHelper.Info("插入医保日志中间表开始！！");
                    bankTradeLogDal.CreateSettleInfo(registerInparm, tradeText, returnText, patientID, visitNo, rateType, lostCash);
                }
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("挂号", ex);
                return -1;
            }
            return 0;
        }

        private int ChargeSettle2094(string visitNo, string money, string preCharge, string charge,
                     string insurFund, string insurAccountCharges, string insurHospCharges, string insurBalance,
                     string insurSafe, string insurOfficialCharges, string insuranceNo,
                     string safetyNo, string insuranceCardNo, string tradeText, string returnText,
                     string businessNo, string insurApplyNo, string feeType,
                     string visitData, string sequenceNos, string payType,
                     string bankTradeNo, string empNameNo,
                     string bankDate, string machineCode,
                     out string receiptNo, out string outParmXml,
                     out string errorMsg)
        {
            UtilityDAL utilityDAL = new UtilityDAL();

            string clientType, tradeCode = "2094";
            clientType = "25";
            outParmXml = receiptNo = errorMsg = "";

            try
            {

                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = empNameNo;
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
                ndRequest.SelectSingleNode("BankTradeNo").InnerText = bankTradeNo;
                ndRequest.SelectSingleNode("TerminalID").InnerText = machineCode;

                if (ndRequest.SelectSingleNode("BankDate") == null)
                {
                    XmlElement eleBankDate = docRequest.CreateElement("BankDate");
                    ndRequest.AppendChild(eleBankDate);
                }
                if (bankDate.IsNull()) bankDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                ndRequest.SelectSingleNode("BankDate").InnerText = bankDate;
                ndRequest.SelectSingleNode("HISDate").InnerText = DateTime.Now.ToString("yyyyMMddHHmmss");

                XmlElement eleIoFlag = docRequest.CreateElement("IoFlag");
                eleIoFlag.InnerText = "0";
                ndRequest.AppendChild(eleIoFlag);

                XmlElement eleVisitNo = docRequest.CreateElement("VisitNo");
                eleVisitNo.InnerText = visitNo;
                ndRequest.AppendChild(eleVisitNo);

                XmlElement eleFeeType = docRequest.CreateElement("FeeType");
                eleFeeType.InnerText = feeType;
                ndRequest.AppendChild(eleFeeType);

                XmlElement elePayType = docRequest.CreateElement("PayType");
                elePayType.InnerText = payType;
                ndRequest.AppendChild(elePayType);

                XmlElement eleMoney = docRequest.CreateElement("Money");
                eleMoney.InnerText = money;
                ndRequest.AppendChild(eleMoney);

                XmlElement eleCharges = docRequest.CreateElement("Charges");
                eleCharges.InnerText = charge;
                ndRequest.AppendChild(eleCharges);

                XmlElement eleInsurFund = docRequest.CreateElement("InsurFund");
                eleInsurFund.InnerText = insurFund;
                ndRequest.AppendChild(eleInsurFund);

                XmlElement eleInsurAccountCharges = docRequest.CreateElement("InsurAccountCharges");
                eleInsurAccountCharges.InnerText = insurAccountCharges;
                ndRequest.AppendChild(eleInsurAccountCharges);

                XmlElement eleInsurHospCharges = docRequest.CreateElement("InsurHospCharges");
                eleInsurHospCharges.InnerText = insurHospCharges;
                ndRequest.AppendChild(eleInsurHospCharges);

                XmlElement eleInsurBalance = docRequest.CreateElement("InsurBalance");
                eleInsurBalance.InnerText = insurBalance;
                ndRequest.AppendChild(eleInsurBalance);

                XmlElement eleInsurSafe = docRequest.CreateElement("InsurSafe");
                eleInsurSafe.InnerText = insurSafe;
                ndRequest.AppendChild(eleInsurSafe);

                XmlElement eleInsurOfficialCharges = docRequest.CreateElement("InsurOfficialCharges");
                eleInsurOfficialCharges.InnerText = insurOfficialCharges;
                ndRequest.AppendChild(eleInsurOfficialCharges);

                XmlElement eleInsuranceNo = docRequest.CreateElement("InsuranceNo");
                eleInsuranceNo.InnerText = insuranceNo;
                ndRequest.AppendChild(eleInsuranceNo);

                XmlElement eleSafetyNo = docRequest.CreateElement("SafetyNo");
                eleSafetyNo.InnerText = safetyNo;
                ndRequest.AppendChild(eleSafetyNo);

                XmlElement eleInsuranceCardNo = docRequest.CreateElement("InsuranceCardNo");
                eleInsuranceCardNo.InnerText = insuranceCardNo;
                ndRequest.AppendChild(eleInsuranceCardNo);

                XmlElement eleReturnText = docRequest.CreateElement("ReturnText");
                eleReturnText.InnerText = returnText;
                ndRequest.AppendChild(eleReturnText);

                XmlElement eleBusinessNo = docRequest.CreateElement("BusinessNo");
                eleBusinessNo.InnerText = businessNo;
                ndRequest.AppendChild(eleBusinessNo);

                XmlElement eleInsurApplyNo = docRequest.CreateElement("InsurApplyNo");
                eleInsurApplyNo.InnerText = insurApplyNo;
                ndRequest.AppendChild(eleInsurApplyNo);

                XmlElement eleVisitData = docRequest.CreateElement("VisitData");
                eleVisitData.InnerText = visitData;
                ndRequest.AppendChild(eleVisitData);

                XmlElement elePreCharge = docRequest.CreateElement("PreCharge");
                elePreCharge.InnerText = preCharge;
                ndRequest.AppendChild(elePreCharge);

                XmlElement elePreCost = docRequest.CreateElement("PreCost");
                elePreCost.InnerText = preCharge;
                ndRequest.AppendChild(elePreCost);

                XmlElement eleTradeText = docRequest.CreateElement("TradeText");
                eleTradeText.InnerText = tradeText;
                ndRequest.AppendChild(eleTradeText);



                XmlElement elePreDerate = docRequest.CreateElement("PreDerate");
                elePreDerate.InnerText = "0";
                ndRequest.AppendChild(elePreDerate);

                XmlElement eleSequenceNos = docRequest.CreateElement("SequenceNos");
                eleSequenceNos.InnerXml = sequenceNos;
                ndRequest.AppendChild(eleSequenceNos);

                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;

                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParmXml = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParmXml);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                string resultCode, resultMessage;

                resultCode = ndResponse.SelectSingleNode("ResultCode").InnerText;
                resultMessage = ndResponse.SelectSingleNode("ResultContent").InnerText;

                if (resultCode != "0000")
                {
                    errorMsg = resultMessage;
                    return -1;
                }
                receiptNo = ndResponse.SelectSingleNode("ReceiptNo").InnerText;

            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("结算", ex);
                errorMsg = ex.Message;
                return -1;
            }
            return 0;
        }

        private int GetPatientVisitInfo2090(string visitNo, string empName, out string visitData, out string errorMsg)
        {
            UtilityDAL utilityDAL = new UtilityDAL();

            string clientType, tradeCode = "2090";
            clientType = "25";
            visitData = errorMsg = "";

            try
            {

                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = empName;
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
                ndRequest.SelectSingleNode("BankTradeNo").InnerText = StringExtension.GetRandomNext(9).ToString();

                if (ndRequest.SelectSingleNode("BankDate") == null)
                {
                    XmlElement eleBankDate = docRequest.CreateElement("BankDate");
                    ndRequest.AppendChild(eleBankDate);
                }
                ndRequest.SelectSingleNode("BankDate").InnerText = DateTime.Now.ToString("yyyyMMddHHmmss");

                XmlElement eleIoFlag = docRequest.CreateElement("IoFlag");
                eleIoFlag.InnerText = "0";
                ndRequest.AppendChild(eleIoFlag);

                XmlElement eleVisitNo = docRequest.CreateElement("VisitNo");
                eleVisitNo.InnerText = visitNo;
                ndRequest.AppendChild(eleVisitNo);

                XmlElement eleVisitType = docRequest.CreateElement("VisitType");
                eleVisitType.InnerText = "2";
                ndRequest.AppendChild(eleVisitType);

                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;

                string outParm;
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
                    outParm = resultMessage;
                    return -1;
                }
                visitData = ndResponse.SelectSingleNode("VisitInfos/VisitInfo/VisitData").InnerText;
            }
            catch (Exception ex)
            {
                //ndResponseRoot.SelectSingleNode("appCode").InnerText = "9999";
                //ndResponseRoot.SelectSingleNode("errorMsg").InnerText = ex.Message;
                //outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("获取结算信息", ex);
                errorMsg = ex.Message;
                return -1;
            }
            return 0;
        }

        private int Regcost2058(string orgHISTradeNo, string empName, out string visitNo, out string errorMsg)
        {
            UtilityDAL utilityDAL = new UtilityDAL();

            string clientType, tradeCode = "2058";
            clientType = "25";
            visitNo = errorMsg = "";

            try
            {

                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = empName;
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
                ndRequest.SelectSingleNode("BankTradeNo").InnerText = StringExtension.GetRandomNext(9).ToString();

                XmlElement eleOrgHISTradeNo = docRequest.CreateElement("OrgHISTradeNo");
                eleOrgHISTradeNo.InnerText = orgHISTradeNo;
                ndRequest.AppendChild(eleOrgHISTradeNo);


                if (ndRequest.SelectSingleNode("BankDate") == null)
                {
                    XmlElement eleBankDate = docRequest.CreateElement("BankDate");
                    ndRequest.AppendChild(eleBankDate);
                }
                ndRequest.SelectSingleNode("BankDate").InnerText = DateTime.Now.ToString("yyyyMMddHHmmss");
                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;

                string outParm;
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
                    errorMsg = resultMessage;
                    return -1;
                }
                visitNo = ndResponse.SelectSingleNode("VisitNo").InnerText;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("挂号确认", ex);
                errorMsg = ex.Message;
                return -1;
            }
            return 0;
        }
        #endregion

        #region 006 预约
        /// <summary>
        /// 006  预约
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        public int reservateConfirm(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResponseRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndroot = docRequestPre.SelectSingleNode("/root");

            string clientType, tradeCode = "2306";
            clientType = "25";
            string serviceDate, reserveCode, inSeeTime;
            string machinelocation;


            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            elerspCode.InnerText = "1";
            ndResponseRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResponseRoot.AppendChild(elerspMsg);


            try
            {
                string inReceiveNo, inCardNo, inDepartmentId, inExpertId;
                inDepartmentId = ndroot.SelectSingleNode("inDeptId").InnerText;
                inExpertId = ndroot.SelectSingleNode("inExpertId").InnerText;
                serviceDate = ndroot.SelectSingleNode("inClinicDate").InnerText;
                inCardNo = ndroot.SelectSingleNode("inCardNo").InnerText;
                reserveCode = ndroot.SelectSingleNode("sectionId").InnerText;
                inSeeTime = ndroot.SelectSingleNode("inSeeTime").InnerText;
                inReceiveNo = ndroot.SelectSingleNode("inReceiveNo").InnerText;
                machinelocation = ndroot.SelectSingleNode("machinelocation").InnerText;

                string orderCode, admitAddress, admitRange;



                XmlElement elerreservateFlow = docResponseRoot.CreateElement("reservateFlow");
                ndResponseRoot.AppendChild(elerreservateFlow);


                XmlElement eleverifyCode = docResponseRoot.CreateElement("verifyCode");
                ndResponseRoot.AppendChild(eleverifyCode);

                XmlElement eleaddress = docResponseRoot.CreateElement("address");
                ndResponseRoot.AppendChild(eleaddress);

                XmlElement elesectionId = docResponseRoot.CreateElement("sectionId");
                ndResponseRoot.AppendChild(elesectionId);


                string preHisTradeNo;
                if (PreQuene2306(inDepartmentId, inExpertId, serviceDate, inCardNo, reserveCode,
                    inSeeTime, inReceiveNo, machinelocation, out preHisTradeNo, out admitAddress, out admitRange,
                    out outParm) < 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = outParm;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }


                elesectionId.InnerText = admitRange;
                eleaddress.InnerText = admitAddress;
                elerreservateFlow.InnerText = preHisTradeNo;
                elerspMsg.InnerText = "1";
                elerspMsg.InnerText = "";
                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspMsg.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("预约", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 007 预约取消
        /// <summary>
        /// 007  取消预约
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        public int reservateCancle(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResponseRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndroot = docRequestPre.SelectSingleNode("/root");

            string clientType, tradeCode = "2309";
            clientType = "25";

            try
            {
                string inReceiveNo, reservateFlow;
                reservateFlow = ndroot.SelectSingleNode("reservateFlow").InnerText;



                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = "";
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
                ndRequest.SelectSingleNode("BankTradeNo").InnerText = StringExtension.GetRandomNext(9).ToString();

                XmlElement eleOrgOrderCode = docRequest.CreateElement("OrgOrderCode");
                eleOrgOrderCode.InnerText = "";
                ndRequest.AppendChild(eleOrgOrderCode);

                XmlElement eleOrgHISTradeNo = docRequest.CreateElement("OrgHISTradeNo");
                eleOrgHISTradeNo.InnerText = reservateFlow;
                ndRequest.AppendChild(eleOrgHISTradeNo);

                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;

                //XmlElement eleBankTradeNo = docRequest.CreateElement("BankTradeNo");
                //eleBankTradeNo.InnerText = StringExtension.GetRandomNext(9).ToString();
                //ndRequest.AppendChild(eleBankTradeNo);
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

                XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
                elerspCode.InnerText = "1";
                ndResponseRoot.AppendChild(elerspCode);

                XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
                ndResponseRoot.AppendChild(elerspMsg);


                if (resultCode != "0000")
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = resultMessage;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                elerspMsg.InnerText = "1";
                elerspMsg.InnerText = resultMessage;
                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseRoot.SelectSingleNode("appCode").InnerText = "9999";
                ndResponseRoot.SelectSingleNode("errorMsg").InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("预约取消", ex);
                return -1;
            }
            return 0;
        }
        #endregion 

        #region 008 住院预交金充值
        /// <summary>
        /// 008  住院预交金充值
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        public int RechargeZYAcount(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResponseRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndroot = docRequestPre.SelectSingleNode("/root");

            string clientType = "10", tradeCode = "2151";
            clientType = "25";


            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            elerspCode.InnerText = "1";
            ndResponseRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResponseRoot.AppendChild(elerspMsg);


            try
            {
                string inRcptStreamNo;
                string inCardNo, inCardNoType, inZyPatientid, inzypatientFlow, inJe;
                string inPaymethod, inReceiverNo, inBankReturnCode, inBankpay, inBankCard, inBankCardType;
                string inBankSearchCode, inBankRefCode, inBankBizCode, inBankTermCode, inBanktraceDate;
                string inBanktraceTime, inBankcardCompay, inSpecialKinddesc, machineLocation;
                inRcptStreamNo = ndroot.SelectSingleNode("inRcptStreamNo").InnerText;
                inCardNo = ndroot.SelectSingleNode("inCardNo").InnerText;
                inCardNoType = ndroot.SelectSingleNode("inCardNoType").InnerText;
                inZyPatientid = ndroot.SelectSingleNode("inZyPatientid").InnerText;
                inzypatientFlow = ndroot.SelectSingleNode("inzypatientFlow").InnerText;
                inJe = ndroot.SelectSingleNode("inJe").InnerText;
                inPaymethod = ndroot.SelectSingleNode("inPaymethod").InnerText;
                inReceiverNo = ndroot.SelectSingleNode("inReceiverNo").InnerText;
                inBankReturnCode = ndroot.SelectSingleNode("inBankReturnCode").InnerText;
                inBankpay = ndroot.SelectSingleNode("inBankpay").InnerText;
                inBankCard = ndroot.SelectSingleNode("inBankCard").InnerText;
                inBankCardType = ndroot.SelectSingleNode("inBankCardType").InnerText;
                inBankSearchCode = ndroot.SelectSingleNode("inBankSearchCode").InnerText;
                inBankRefCode = ndroot.SelectSingleNode("inBankRefCode").InnerText;
                inBankBizCode = ndroot.SelectSingleNode("inBankBizCode").InnerText;
                inBankTermCode = ndroot.SelectSingleNode("inBankTermCode").InnerText;
                inBanktraceDate = ndroot.SelectSingleNode("inBanktraceDate").InnerText;
                inBanktraceTime = ndroot.SelectSingleNode("inBanktraceTime").InnerText;
                inBankcardCompay = ndroot.SelectSingleNode("inBankcardCompay").InnerText;
                inSpecialKinddesc = ndroot.SelectSingleNode("inSpecialKinddesc").InnerText;
                machineLocation = ndroot.SelectSingleNode("machineLocation").InnerText;

                string errorMsg;
                if (CreatePrepayment2151(inCardNo, inReceiverNo, inRcptStreamNo, machineLocation, inJe, "1", "1", out errorMsg) < 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = errorMsg;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                //StringBuilder sql = new StringBuilder();
                //sql.Clear();
                //sql.Append("select * from sick_basic_info where ic_card_id = :arg_card_id");
                //OracleParameter[] paraSickBase = 
                //                                {
                //                                     new OracleParameter("arg_card_id",inCardNo)
                //                                };
                //DataTable dtSickBase = Select(sql.ToString(), paraSickBase);
                //if(dtSickBase.Rows.Count == 0)
                //{
                //    elerspCode.InnerText = "0";
                //    elerspMsg.InnerText = "录入的卡号不正确，请重新输入！ ";
                //    outParm = docResponseRoot.OuterXml;
                //    return -1;
                //}
                ////=========================================================

                //string sickId;
                //sickId = dtSickBase.Rows[0]["sick_id"].ToString();

                ////if(inZyPatientid != sickId)
                ////{
                ////    elerspCode.InnerText = "0";
                ////    elerspMsg.InnerText = "录入病人ID， 与HIS内的不一致！ ";
                ////    outParm = docResponseRoot.OuterXml;
                ////    return -1;
                ////}
                //XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                //XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                //ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                //ndRequest.SelectSingleNode("ExtUserID").InnerText = inReceiverNo;
                //ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
                //ndRequest.SelectSingleNode("BankTradeNo").InnerText = inRcptStreamNo;
                //ndRequest.SelectSingleNode("TerminalID").InnerText = machineLocation;

                //XmlElement elePatientID = docRequest.CreateElement("PatientID");
                //elePatientID.InnerText = sickId;
                //ndRequest.AppendChild(elePatientID);

                // XmlElement eleResidenceNo = docRequest.CreateElement("ResidenceNo");
                // eleResidenceNo.InnerText = "";
                // ndRequest.AppendChild(eleResidenceNo);

                // XmlElement eleMoney = docRequest.CreateElement("Money");
                // eleMoney.InnerText = inJe;
                // ndRequest.AppendChild(eleMoney);

                // XmlElement elePayType = docRequest.CreateElement("PayType");
                // elePayType.InnerText = inPaymethod;
                // ndRequest.AppendChild(elePayType);

                //XmlElement eleBankCardNo = docRequest.CreateElement("BankCardNo");
                //eleBankCardNo.InnerText = "";
                //ndRequest.AppendChild(eleBankCardNo);

                //XmlElement eleIoFlag = docRequest.CreateElement("IoFlag");
                //eleIoFlag.InnerText = "0";
                //ndRequest.AppendChild(eleIoFlag);

                //XmlElement eleBankDate = docRequest.CreateElement("BankDate");
                //eleBankDate.InnerText = DateTime.Now.ToString("yyyyMMddhhmmss");
                //ndRequest.AppendChild(eleBankDate);

                //HisWSSelfService hisWSSelfService = new HisWSSelfService();
                //hisWSSelfService.Url = serviceURL;
                //outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                //XmlDocument docResponse = new XmlDocument();
                //docResponse.LoadXml(outParm);
                //XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                //string resultCode, resultMessage;

                //resultCode = ndResponse.SelectSingleNode("ResultCode").InnerText;
                //resultMessage = ndResponse.SelectSingleNode("ResultContent").InnerText;

                //if (resultCode != "0000")
                //{
                //    elerspCode.InnerText = "0";
                //    elerspMsg.InnerText = resultMessage;
                //    outParm = docResponseRoot.OuterXml;
                //    return -1;
                //}
                elerspMsg.InnerText = "1";
                elerspMsg.InnerText = "交易成功";
                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("用户院内帐户充值", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 009 院内帐户充值
        /// <summary>
        /// 009 院内帐户充值
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        public int hosAcctRecharge(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResponseRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndroot = docRequestPre.SelectSingleNode("/root");

            string clientType = "10", tradeCode = "2151";
            clientType = "25";
            string machineCode, payType;


            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            elerspCode.InnerText = "1";
            ndResponseRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResponseRoot.AppendChild(elerspMsg);


            try
            {
                string inRcptStreamNo;
                string inCardNo, inCardNoType, inZyPatientid, inzypatientFlow, inJe;
                string inPaymethod, inReceiverNo, inBankReturnCode, inBankpay, inBankCard, inBankCardType;
                string inBankSearchCode, inBankRefCode, inBankBizCode, inBankTermCode, inBanktraceDate;
                string inBanktraceTime, inBankcardCompay, inSpecialKinddesc, machineLocation;
                inRcptStreamNo = ndroot.SelectSingleNode("PosTranFlow").InnerText;
                inCardNo = ndroot.SelectSingleNode("CCardNo").InnerText;
                inReceiverNo = ndroot.SelectSingleNode("Tid").InnerText;
                machineCode = ndroot.SelectSingleNode("machineCode").InnerText;
                inJe = ndroot.SelectSingleNode("TranAmt").InnerText;
                payType = ndroot.SelectSingleNode("FEETYPE").InnerText;
                string errorMsg;
                if (CreatePrepayment2151(inCardNo, inReceiverNo, inRcptStreamNo, machineCode, inJe, "0", payType, out errorMsg) < 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = errorMsg;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                elerspMsg.InnerText = "1";
                elerspMsg.InnerText = "交易成功";
                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("用户院内帐户充值", ex);
                return -1;
            }
            return 0;
        }
        #endregion   

        #region 010 根据挂号类型， 获取费用明细
        public int GetCurrentRegisterType(XmlDocument docRequestPre, out string outParm)
        {
            string nameEmployeNo;
            string tradeCode;
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("/root");

            string inPersonnelType, inRegisterTypeId;
            inPersonnelType = ndReqRoot.SelectSingleNode("inPersonnelType").InnerText;
            inRegisterTypeId = ndReqRoot.SelectSingleNode("inRegisterTypeId").InnerText;


            dtSysDatetime = utilityDAL.GetSysDateTime();

            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            ndResRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResRoot.AppendChild(elerspMsg);

            XmlElement eleoutFee = docResponseRoot.CreateElement("outFee");
            ndResRoot.AppendChild(eleoutFee);

            XmlElement eleoutRegisterFee = docResponseRoot.CreateElement("outRegisterFee");
            eleoutRegisterFee.InnerText = "";
            ndResRoot.AppendChild(eleoutRegisterFee);

            XmlElement eleroutDiagnoseFee = docResponseRoot.CreateElement("outDiagnoseFee");
            eleroutDiagnoseFee.InnerText = "";
            ndResRoot.AppendChild(eleroutDiagnoseFee);

            XmlElement eleoutAdditionalFeeFlag = docResponseRoot.CreateElement("outAdditionalFeeFlag");
            eleoutAdditionalFeeFlag.InnerText = "";
            ndResRoot.AppendChild(eleoutAdditionalFeeFlag);

            XmlElement eleItemInfos = docResponseRoot.CreateElement("ItemInfos");
            eleItemInfos.InnerText = "";
            ndResRoot.AppendChild(eleItemInfos);
            string itemCode;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Clear();
                sql.Append(" select *from register_type a where a.code = :arg_code");
                OracleParameter[] parmRegisterType =
                       {
                            new OracleParameter("arg_code",inRegisterTypeId)
                        };
                DataTable dtRegisterType = Select(sql.ToString(), parmRegisterType);
                if (dtRegisterType.Rows.Count == 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = "未查询到当前挂号号别的配置信息！";
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                itemCode = dtRegisterType.Rows[0]["clinic_Code"].ToString().Trim();

                sql.Clear();
                sql.Append(" select * from rate_type_dict a where a.rate_type_code = :arg_code");
                OracleParameter[] parmratetype =
                       {
                            new OracleParameter("arg_code",inPersonnelType)
                        };
                DataTable dtRateType = Select(sql.ToString(), parmratetype);

                string balanceinterface;
                balanceinterface = dtRateType.Rows[0]["BALANCE_INTERFACE"].ToString().Trim();
                if (string.IsNullOrEmpty(balanceinterface))
                {
                    balanceinterface = "0";
                }

                sql.Clear();
                if (balanceinterface != "0")
                {
                    if (balanceinterface == "H")
                    {
                        sql.Append(@"select ' ' djh,
                                        ' ' cfh,
                                        ' ' cflsh,
                                        '2' xmzl,
                                        e.insur_price_name price_item_name,
                                        decode(f.rate_type,'F',f.temp_item_code,f.insurance_price_item_code) insurance_price_item_code,
                                        ' ' mzlsh,
                                        ' ' yllb,
                                        ' ' ksbm,
                                        ' ' ysbm,
                                        ' ' zdjbbm,
                                        c.standard_price * nvl(b.pricelist_item_number, 1) clinic_price,
                                        e.insur_price_name OCODE,
                                        f.item_code ICODE,
                                        ' ' FPHM,
                                        ' ' LB,
                                        e.mzzfbl ZFBL,
                                        '10095' YYBH,
                                        ' ' ICD10,
                                        ' ' JBMC
                                   from clinic_pricelist_collate_dict b, 
                                        clinic_item_dict c,
                                        rate_type_dict     d,
                                        v_jsxnh_price_item_code     e,
                                        pricelist_dict_detail         f
                                  where b.valid_flag = 'Y'
                                    and b.clinic_item_code = c.item_code 
                                    and f.item_code = c.item_code
                                    and e.physic_flag = 'N'
                                    and e.insur_price_code = decode(f.rate_type,'F',f.temp_item_code,f.insurance_price_item_code)
                                    and f.rate_type = d.rate_type_code
                                    and b.item_code = :arg_item_code
                                    and f.rate_type = :arg_rate_type");
                    }
                    else
                    {
                        sql.Append(@"select ' ' djh,
                                    ' ' cfh,
                                    ' ' cflsh,
                                    '2' xmzl,
                                    e.price_item_name,
                                    decode(f.rate_type,'F',f.temp_item_code,f.insurance_price_item_code) insurance_price_item_code,
                                    ' ' mzlsh,
                                    ' ' yllb,
                                    ' ' ksbm,
                                    ' ' ysbm,
                                    ' ' zdjbbm,
                                    c.standard_price * nvl(b.pricelist_item_number, 1) clinic_price
                               from clinic_pricelist_collate_dict b, 
                                    clinic_item_dict c,
                                    rate_type_dict     d,
                                    insurance_price_item_dict     e,
                                    pricelist_dict_detail         f
                              where b.valid_flag = 'Y'
                                and b.clinic_item_code = c.item_code 
                                and f.item_code = c.item_code
                                and e.price_item_code = decode(f.rate_type,'F',f.temp_item_code,f.insurance_price_item_code)
                                and f.rate_type = d.rate_type_code
                                and d.insur_rate_type = e.rate_type
                                and b.item_code = :arg_item_code
                                and f.rate_type = :arg_rate_type");
                    }
                }
                else
                {
                    sql.Append(@"select ' ' djh,
                                    ' ' cfh,
                                    ' ' cflsh,
                                    '2' xmzl,
                                    '' price_item_name,
                                    '' insurance_price_item_code,
                                    ' ' mzlsh,
                                    ' ' yllb,
                                    ' ' ksbm,
                                    ' ' ysbm,
                                    ' ' zdjbbm,
                                    c.standard_price * nvl(b.pricelist_item_number, 1) clinic_price
                               from clinic_pricelist_collate_dict b, 
                                    clinic_item_dict c
                              where b.valid_flag = 'Y'
                                and b.clinic_item_code = c.item_code 
                                and b.item_code = :arg_item_code
                                and :arg_rate_type = :arg_rate_type");
                }

                OracleParameter[] parmClinicPrice =
                       {
                                new OracleParameter("arg_item_code", itemCode),
                                new OracleParameter("arg_rate_type", inPersonnelType)
                        };
                DataTable dtClinicPrice = Select(sql.ToString(), parmClinicPrice, "ItemInfo");
                if (dtClinicPrice.Rows.Count == 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = "未查询到当前挂号号别的配置费用信息！";
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                decimal clinicCost = 0;

                foreach (DataRow dr in dtClinicPrice.Rows)
                {
                    clinicCost += decimal.Parse(dr["clinic_price"].ToString()); ;
                }
                DataSet dsItemInfos = new DataSet("ItemInfos");
                dsItemInfos.Tables.Add(dtClinicPrice);

                string itemInfoXml = dsItemInfos.GetXml();
                itemInfoXml = itemInfoXml.Replace("DJH", "djh");
                itemInfoXml = itemInfoXml.Replace("CFH", "cfh");
                itemInfoXml = itemInfoXml.Replace("CFLSH", "cflsh");
                itemInfoXml = itemInfoXml.Replace("XMZL", "xmzl");
                itemInfoXml = itemInfoXml.Replace("PRICE_ITEM_NAME", "xmmc");
                itemInfoXml = itemInfoXml.Replace("INSURANCE_PRICE_ITEM_CODE", "xmzbm");
                itemInfoXml = itemInfoXml.Replace("MZLSH", "mzlsh");
                itemInfoXml = itemInfoXml.Replace("YLLB", "yllb");
                itemInfoXml = itemInfoXml.Replace("KSBM", "ksbm");
                itemInfoXml = itemInfoXml.Replace("YSBM", "ysbm");
                itemInfoXml = itemInfoXml.Replace("ZDJBBM", "zdjbbm");
                itemInfoXml = itemInfoXml.Replace("CLINIC_PRICE", "price");

                if (balanceinterface == "H")
                {
                    itemInfoXml = itemInfoXml.Replace("OCODE", "ocode");
                    itemInfoXml = itemInfoXml.Replace("ICODE", "icode");
                    itemInfoXml = itemInfoXml.Replace("FPHM", "fphm");
                    itemInfoXml = itemInfoXml.Replace("LB", "lb");
                    itemInfoXml = itemInfoXml.Replace("ZFBL", "zfbl");
                    itemInfoXml = itemInfoXml.Replace("YYBH", "yybh");
                    itemInfoXml = itemInfoXml.Replace("ICD10", "icd10");
                    itemInfoXml = itemInfoXml.Replace("JBMC", "jbmc");

                }

                XmlDocument docItemInfos = new XmlDocument();
                docItemInfos.LoadXml(itemInfoXml);

                XmlNode ndItemInfos = docItemInfos.SelectSingleNode("ItemInfos");
                eleItemInfos.InnerXml = ndItemInfos.InnerXml;

                string clinicPrice, insurance_price_item_code, price_item_name;

                clinicPrice = dtClinicPrice.Rows[0]["clinic_price"].ToString();
                eleoutFee.InnerText = clinicCost.ToString();
                //insurance_price_item_code = dtClinicPrice.Rows[0]["insurance_price_item_code"].ToString();
                //eleoutFee.InnerText = insurance_price_item_code;
                //price_item_name = dtClinicPrice.Rows[0]["price_item_name"].ToString();
                //eleoutFee.InnerText = price_item_name;


                eleoutFee.InnerText = clinicPrice.ToString();
                eleoutRegisterFee.InnerText = "";
                eleroutDiagnoseFee.InnerText = "";





                elerspCode.InnerText = "1";
                elerspMsg.InnerText = "交易成功";
                outParm = docResponseRoot.OuterXml;
                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("根据挂号类型， 获取费用明细", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 011 获取划价单接口
        public int getPreNosInfo(XmlDocument docRequestPre, out string outParm)
        {
            ;

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("/root");

            string cardNo, cardNoType;
            cardNo = ndReqRoot.SelectSingleNode("cardNo").InnerText;
            cardNoType = ndReqRoot.SelectSingleNode("cardNoType").InnerText;

            string clientType, tradeCode = "2090";
            clientType = "25";

            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            ndResRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResRoot.AppendChild(elerspMsg);

            try
            {

                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = "";
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;


                XmlElement eleIoFlag = docRequest.CreateElement("IoFlag");
                eleIoFlag.InnerText = "0";
                ndRequest.AppendChild(eleIoFlag);

                XmlElement eleVisitNo = docRequest.CreateElement("VisitNo");
                eleVisitNo.InnerText = cardNo;
                ndRequest.AppendChild(eleVisitNo);

                XmlElement eleVisitType = docRequest.CreateElement("VisitType");
                eleVisitType.InnerText = "1";
                ndRequest.AppendChild(eleVisitType);

                XmlElement eleBankDate = docRequest.CreateElement("BankDate");
                eleBankDate.InnerText = DateTime.Now.ToString("yyyyMMddhhmmss");
                ndRequest.AppendChild(eleBankDate);

                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;
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
                    elerspMsg.InnerText = resultMessage;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    elerspMsg.InnerText = "交易失败！";
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                //第二次调用
                XmlNode ndApplyItems = ndResponse.SelectSingleNode("ApplyItems");
                if (SendLisBeforeSettle(ndApplyItems, out outParm) < 0)
                {
                    elerspMsg.InnerText = outParm;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                #region 

                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                docResponse.LoadXml(outParm);
                ndResponse = docResponse.SelectSingleNode("Response");

                resultCode = ndResponse.SelectSingleNode("ResultCode").InnerText;
                resultMessage = ndResponse.SelectSingleNode("ResultContent").InnerText;

                if (resultCode != "0000")
                {
                    elerspMsg.InnerText = resultMessage;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    elerspMsg.InnerText = "交易成功！";
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                #endregion

                XmlElement eleItems = docResponseRoot.CreateElement("items");
                ndResRoot.AppendChild(eleItems);

                string residenceNo, sickId, sickName, idCardNo, admitDate;
                string applyDept, applyDeptName;
                string diagnosisName, doctor;
                string preNo, djh;

                string errorMsg, visitData, insurApplyNo;
                string sequenceNos, diagnosisCode, insuranceDiseas;
                string balanceInterface = "";
                string ICD10 = "";
                string JBMC = "";
                decimal preCost;
                StringBuilder sql = new StringBuilder();
                foreach (XmlNode ndVisitInfo in ndResponse.SelectNodes("VisitInfos/VisitInfo"))
                {

                    insuranceDiseas = sequenceNos = djh = preNo = "";
                    preCost = 0;
                    insurApplyNo = utilityDAL.GetSequenceNO("zhiydba.jssyb_apply_no_seq").ToString();
                    residenceNo = ndVisitInfo.SelectSingleNode("ResidenceNo").InnerText;
                    sickId = ndVisitInfo.SelectSingleNode("PatientID").InnerText;
                    sickName = ndVisitInfo.SelectSingleNode("PatientName").InnerText;
                    cardNo = ndVisitInfo.SelectSingleNode("PayCardNo").InnerText;
                    doctor = ndVisitInfo.SelectSingleNode("ApplyDoctor").InnerText;
                    idCardNo = ""; // ndVisitInfo.SelectSingleNode("IDCardNo").InnerText;
                    admitDate = ndVisitInfo.SelectSingleNode("AdmitDate").InnerText;
                    applyDept = ndVisitInfo.SelectSingleNode("ApplyDept").InnerText;
                    applyDeptName = ndVisitInfo.SelectSingleNode("ApplyDeptName").InnerText;
                    diagnosisCode = ndVisitInfo.SelectSingleNode("DiagnosisCode").InnerText;
                    diagnosisName = ndVisitInfo.SelectSingleNode("DiagnosisName").InnerText;
                    visitData = ndVisitInfo.SelectSingleNode("VisitData").InnerText;
                    if (diagnosisCode.IsNull()) diagnosisCode = "Z00.001";

                    sql.Clear();
                    sql.Append(@"select t.balance_interface balance_interface
                                   from dispensary_sick_cure_info s , rate_type_dict t
                                  where s.rate_type = t.rate_type_code
                                    and s.sick_id = :arg_sick_id
                                    and s.nullah_number = :arg_nullah_number
                                    and rownum = 1 ");
                    OracleParameter[] paraBalanceInterface = {
                                              new OracleParameter("arg_sick_id", sickId),
                                              new OracleParameter("arg_nullah_number", residenceNo)
                                                 };
                    DataTable dtBalanceInterface = Select(sql.ToString(), paraBalanceInterface);
                    if (dtBalanceInterface.Rows.Count > 0)
                    {
                        balanceInterface = dtBalanceInterface.Rows[0]["balance_interface"].ToString();
                    }

                    sql.Clear();
                    sql.Append(@"select city_insurance_code
                                   from ICD10_DICT
                                  where ICD10_CODE = :arg_diagnosis_code
                                    and city_insurance_code is not null
                                    and rownum = 1 ");
                    OracleParameter[] paraIcd10Dict = {
                                              new OracleParameter("arg_diagnosis_code", diagnosisCode)
                                                 };
                    DataTable dtIcd10Dict = Select(sql.ToString(), paraIcd10Dict);
                    if (dtIcd10Dict.Rows.Count > 0)
                    {
                        insuranceDiseas = dtIcd10Dict.Rows[0]["city_insurance_code"].ToString();
                    }
                    if (insuranceDiseas.IsNull()) insuranceDiseas = "Z00.001";

                    //农合
                    if (balanceInterface == "H")
                    {
                        ICD10 = diagnosisCode;
                        JBMC = diagnosisName;
                    }

                    sql.Clear();
                    sql.Append(@"");

                    ndApplyItems = ndResponse.SelectSingleNode("ApplyItems");
                    XmlElement ndApplyItemPara = docResponse.CreateElement("ApplyItems");

                    foreach (XmlNode ndTemp in ndApplyItems.SelectNodes("ApplyItem"))
                    {
                        if (ndTemp.SelectSingleNode("ResidenceNo").InnerText == residenceNo)
                            ndApplyItemPara.AppendChild(ndTemp);

                    }
                    if (ndApplyItemPara.SelectNodes("ApplyItem").Count == 0) continue;

                    XmlNode ndSequenceNos;
                    if (PreCost2095(residenceNo, sickId, ndApplyItemPara, out ndSequenceNos, // out sequenceNos, out djh,
                        out preCost, out errorMsg) < 0)
                    {
                        elerspCode.InnerText = "0";
                        elerspMsg.InnerText = errorMsg;
                        outParm = docResponseRoot.OuterXml;
                        return -1;
                    }

                    string applyNo = "", ybchf = "001";
                    foreach (XmlNode ndSequenceNo in ndSequenceNos.SelectNodes("SequenceNo"))
                    {
                        applyNo = ndSequenceNo.Attributes["ApplyNo"].Value;
                        if (("," + djh).IndexOf("" + applyNo + ",") < 0)  //判断单据号不能重复
                        {
                            djh += applyNo + ",";
                        }
                        sequenceNos += ndSequenceNo.InnerText + ",";
                        ybchf = ndSequenceNo.InnerText;
                    }
                    XmlElement eleItem = docResponseRoot.CreateElement("item");


                    XmlElement elepreNo = docResponseRoot.CreateElement("preNo");
                    XmlElement eleregisterFlow = docResponseRoot.CreateElement("registerFlow");
                    XmlElement elepatientId = docResponseRoot.CreateElement("patientId");
                    XmlElement elepatientName = docResponseRoot.CreateElement("patientName");
                    XmlElement elecardNo = docResponseRoot.CreateElement("cardNo");
                    XmlElement elecardNoType = docResponseRoot.CreateElement("cardNoType");
                    XmlElement eleidenNo = docResponseRoot.CreateElement("idenNo");
                    XmlElement eleclinicDate = docResponseRoot.CreateElement("clinicDate");
                    XmlElement eledepartmentId = docResponseRoot.CreateElement("departmentId");
                    XmlElement eleDepartmentName = docResponseRoot.CreateElement("DepartmentName");
                    XmlElement eleexpertId = docResponseRoot.CreateElement("expertId");
                    XmlElement eleExpertName = docResponseRoot.CreateElement("ExpertName");
                    XmlElement eleDiagnoseName = docResponseRoot.CreateElement("DiagnoseName");
                    XmlElement eleTotalFee = docResponseRoot.CreateElement("TotalFee");
                    XmlElement elepaymentStatus = docResponseRoot.CreateElement("paymentStatus");
                    XmlElement eleybcfh = docResponseRoot.CreateElement("ybcfh");
                    XmlElement eleybksbm = docResponseRoot.CreateElement("ybksbm");
                    XmlElement eleybysbm = docResponseRoot.CreateElement("ybysbm");
                    XmlElement eleybbzm = docResponseRoot.CreateElement("ybbzm");
                    XmlElement eledjh = docResponseRoot.CreateElement("djh");
                    XmlElement eleksbm = docResponseRoot.CreateElement("ksbm");
                    XmlElement elemzlsh = docResponseRoot.CreateElement("mzlsh");
                    XmlElement elebzbm = docResponseRoot.CreateElement("bzbm");
                    XmlElement elezdjbbm = docResponseRoot.CreateElement("zdjbbm");

                    XmlElement elevisitData = docResponseRoot.CreateElement("visitData");
                    XmlElement eleSequenceNos = docResponseRoot.CreateElement("SequenceNos");

                    XmlElement eleicd10 = docResponseRoot.CreateElement("icd10");
                    XmlElement eleNhJbmc = docResponseRoot.CreateElement("jbmc");

                    elepreNo.InnerText = applyNo;// djh;
                    eleregisterFlow.InnerText = residenceNo;
                    elepatientId.InnerText = sickId;
                    elepatientName.InnerText = sickName;
                    elecardNo.InnerText = cardNo;
                    elecardNoType.InnerText = "";
                    eleidenNo.InnerText = idCardNo;
                    eleclinicDate.InnerText = admitDate;
                    eledepartmentId.InnerText = applyDept;
                    eleDepartmentName.InnerText = applyDeptName;
                    eleexpertId.InnerText = doctor;
                    eleExpertName.InnerText = doctor.Substring(0, doctor.IndexOf('/'));
                    eleDiagnoseName.InnerText = diagnosisName;
                    eleTotalFee.InnerText = preCost.ToString();
                    elepaymentStatus.InnerText = "1";
                    eleybcfh.InnerText = ybchf;
                    eleybksbm.InnerText = applyDept;
                    eleksbm.InnerText = applyDept;
                    eleybysbm.InnerText = doctor;
                    eleybbzm.InnerText = insuranceDiseas;
                    eledjh.InnerText = insurApplyNo;
                    elemzlsh.InnerText = residenceNo;
                    elevisitData.InnerText = visitData;
                    eleSequenceNos.InnerXml = JsonConvert.SerializeXmlNode(ndSequenceNos);

                    eleicd10.InnerText = ICD10;
                    eleNhJbmc.InnerText = JBMC;

                    eleItem.AppendChild(elepreNo);
                    eleItem.AppendChild(eleregisterFlow);
                    eleItem.AppendChild(elepatientId);
                    eleItem.AppendChild(elepatientName);
                    eleItem.AppendChild(elecardNo);
                    eleItem.AppendChild(elecardNoType);
                    eleItem.AppendChild(eleidenNo);
                    eleItem.AppendChild(eleclinicDate);
                    eleItem.AppendChild(eledepartmentId);
                    eleItem.AppendChild(eleDepartmentName);
                    eleItem.AppendChild(eleexpertId);
                    eleItem.AppendChild(eleExpertName);
                    eleItem.AppendChild(eleDiagnoseName);
                    eleItem.AppendChild(eleTotalFee);
                    eleItem.AppendChild(elepaymentStatus);
                    eleItem.AppendChild(eleybcfh);
                    eleItem.AppendChild(eleybksbm);
                    eleItem.AppendChild(eleybysbm);
                    eleItem.AppendChild(eleybbzm);
                    eleItem.AppendChild(eledjh);
                    eleItem.AppendChild(elemzlsh);
                    eleItem.AppendChild(eleksbm);
                    eleItem.AppendChild(elevisitData);
                    eleItem.AppendChild(eleSequenceNos);

                    eleItem.AppendChild(eleicd10);
                    eleItem.AppendChild(eleNhJbmc);

                    eleItems.AppendChild(eleItem);
                }

                elerspCode.InnerText = "1";
                elerspMsg.InnerText = resultMessage;

                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("011 获取划价单接口", ex);
                return -1;
            }
            return 0;
        }


        private int PreCost2095(string residenceNo, string patientID, XmlNode ndApplyItems,
            // out string sequenceNos, out string applyNos,
            out XmlNode ndSequenceNos, out decimal preCost,
            out string errorMsg)
        {
            UtilityDAL utilityDAL = new UtilityDAL();
            ndSequenceNos = null;
            string tradeCode = "2095", clientType = "25";
            preCost = 0;
            errorMsg = "";
            //applyNos = sequenceNos = "";
            //=========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = "";
            ndRequest.SelectSingleNode("ClientType").InnerText = clientType;


            XmlElement eleIoFlag = docRequest.CreateElement("IoFlag");
            eleIoFlag.InnerText = "0";
            ndRequest.AppendChild(eleIoFlag);

            XmlElement eleResidenceNo = docRequest.CreateElement("ResidenceNo");
            eleResidenceNo.InnerText = residenceNo;
            ndRequest.AppendChild(eleResidenceNo);

            XmlElement elePatientID = docRequest.CreateElement("PatientID");
            elePatientID.InnerText = patientID;
            ndRequest.AppendChild(elePatientID);


            XmlElement eleApplyItems = docRequest.CreateElement("ApplyItems");
            eleApplyItems.InnerXml = ndApplyItems.InnerXml;
            ndRequest.AppendChild(eleApplyItems);

            XmlElement eleBankDate = docRequest.CreateElement("BankDate");
            eleBankDate.InnerText = DateTime.Now.ToString("yyyyMMddhhmmss");
            ndRequest.AppendChild(eleBankDate);

            ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
            ndRequest.SelectSingleNode("Signature").InnerText = signature;
            //========================================================

            string outParm;
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
                errorMsg = resultMessage;
                return -1;
            }
            long cycleNum;
            cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
            if (cycleNum <= 0)
            {
                errorMsg = "预结算数据为空！";
                return -1;
            }
            ndSequenceNos = ndResponse.SelectSingleNode("SequenceNos");

            preCost = decimal.Parse(ndResponse.SelectSingleNode("PreCost").InnerText);
            return 0;

        }
        #endregion

        #region 012 获取划价单明细接口
        /// <summary>
        /// 012 获取划价单明细接口
        /// </summary>
        /// <param name="docRequestPre"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int GetPreNosDetailInfo(XmlDocument docRequestPre, out string outParm)
        {
            StringBuilder sql = new StringBuilder();
            string sequenceNos;
            UtilityDAL utilityDAL = new UtilityDAL();
            //XmlDocument docResponse = utilityDAL.GetResponseXmlDoc();
            //XmlNode ndResponse = docResponse.SelectSingleNode("Response");

            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("/root");

            XmlElement elePriceItems = docResponseRoot.CreateElement("PriceItems");
            ndResRoot.AppendChild(elePriceItems);

            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            ndResRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResRoot.AppendChild(elerspMsg);

            sequenceNos = ndReqRoot.SelectSingleNode("ybcfh").InnerText;

            string sequenceNoJson;
            sequenceNoJson = ndReqRoot.SelectSingleNode("SequenceNos").InnerText;           
            XmlDocument docXml = JsonConvert.DeserializeXmlNode(sequenceNoJson);
            XmlNodeList ndSequenceNos = docXml.SelectNodes("SequenceNos/SequenceNo");
            sequenceNos = "";
            foreach (XmlNode ndSequenceNo in ndSequenceNos)
            {
                sequenceNos += ndSequenceNo.InnerText + ",";
            }

                sql.Clear();
            sql.Append(@"
                select s.sequence_no preNo,
                       decode(upper(substr(s.item_class, 1, 1)),
                              'A',
                              '0',
                              'B',
                              '0',
                              'C',
                              '0',
                              '1') item_Class,
                       s.item_name itemName,
                       s.item_code itemCode,
                       s.spec itemSpec,
                       s.quantity itemAmount,
                       s.unit itemUnit,
                       decode(upper(substr(s.item_class, 1, 1)),
                              'A',
                              round(s.price / (select m.pack_spec
                                                 from physic_dict_table m
                                                where m.physic_code = s.item_code),
                                    4),
                              'B',
                              round(s.price / (select m.pack_spec
                                                 from physic_dict_table m
                                                where m.physic_code = s.item_code),
                                    4),
                              'C',
                              round(s.price / (select m.pack_spec
                                                 from physic_dict_table m
                                                where m.physic_code = s.item_code),
                                    4),
                              s.price) itemPrice,
                       decode(upper(substr(s.item_class, 1, 1)),
                              'A',
                              (round(s.price /
                                     (select m.pack_spec
                                        from physic_dict_table m
                                       where m.physic_code = s.item_code),
                                     4) * s.quantity),
                              'B',
                              (round(s.price /
                                     (select m.pack_spec
                                        from physic_dict_table m
                                       where m.physic_code = s.item_code),
                                     4) * s.quantity),
                              'C',
                              (round(s.price /
                                     (select m.pack_spec
                                        from physic_dict_table m
                                       where m.physic_code = s.item_code),
                                     4) * s.quantity),
                              s.cost) itemCharges,
                       '' dupInvoiceCode,
                       '' dupInvoiceName,
                       '' excDeptID,
                       '' excDeptName,
                       '' price,
                       '' orderNo,
                       '' windowNo,
                       decode(s.receipt_class,
                              '01',
                              '1',
                              '02',
                              '1',
                              '03',
                              '1',
                              '20',
                              '3',
                              '2') xmzl,
                       (select a.price_item_name
                          from insurance_price_item_dict a, rate_type_dict b
                         where a.rate_type = b.insur_rate_type
                           and b.rate_type_code = t.rate_type
                           and a.price_item_code = r.insurance_price_item_code) xmmc,
                       r.insurance_price_item_code xmzbm,
                       s.quantity count,
                       s.price price,
                       s.cost amount,
                       (decode(s.item_class,
                               'C02',
                               (select c.lay_physic_days
                                  from v_lay_physic_union c
                                 where c.apply_no = s.apply_no),
                               '')) zyypfs,
                       '1' zxjjbs,
                       (nvl((select d.city_insurance_code
                              from ICD10_DICT d
                             where d.icd10_code = 'Z00.001'
                               and d.city_insurance_code is not null
                               and rownum = 1),
                            'Z00.001')) bzbm

                  from dispensary_sick_price_item s,
                       dispensary_sick_cure_info  t,
                       pricelist_dict_detail      r
                 where s.residence_no = t.nullah_number
                   and s.sick_id = t.sick_id
                   and s.rate_type = r.rate_type(+)
                   and s.item_code = r.item_code(+)
                   and s.sequence_no in (" + "'" + string.Join("','", sequenceNos.Split(',')) + "'" + ")"
                 );
            DataTable dtPriceItem = Select(sql.ToString(), null, "PriceItem");
            DataSet dsPriceItems = new DataSet("PriceItems");

            dsPriceItems.Tables.Add(dtPriceItem);
            string priceItemsXml = dsPriceItems.GetXml();
            priceItemsXml = priceItemsXml.Replace("PRENO", "preNo");
            priceItemsXml = priceItemsXml.Replace("ITEM_CLASS", "itemClass");
            priceItemsXml = priceItemsXml.Replace("ITEMNAME", "itemName");
            priceItemsXml = priceItemsXml.Replace("ITEMCODE", "itemCode");
            priceItemsXml = priceItemsXml.Replace("ITEMSPEC", "itemSpec");
            priceItemsXml = priceItemsXml.Replace("ITEMAMOUNT", "itemAmount");
            priceItemsXml = priceItemsXml.Replace("ITEMUNIT", "itemUnit");
            priceItemsXml = priceItemsXml.Replace("ITEMPRICE", "itemPrice");
            priceItemsXml = priceItemsXml.Replace("ITEMCHARGES", "itemCharges");
            priceItemsXml = priceItemsXml.Replace("DUPINVOICECODE", "dupInvoiceCode");
            priceItemsXml = priceItemsXml.Replace("DUPINVOICENAME", "dupInvoiceName");
            priceItemsXml = priceItemsXml.Replace("EXCDEPTID", "excDeptID");
            priceItemsXml = priceItemsXml.Replace("EXCDEPTNAME", "excDeptName");
            priceItemsXml = priceItemsXml.Replace("PRICE", "price");
            priceItemsXml = priceItemsXml.Replace("ORDERNO", "orderNo");
            priceItemsXml = priceItemsXml.Replace("WINDOWNO", "windowNo");
            priceItemsXml = priceItemsXml.Replace("XMZL", "xmzl");
            priceItemsXml = priceItemsXml.Replace("XMMC", "xmmc");
            priceItemsXml = priceItemsXml.Replace("XMZBM", "xmzbm");
            priceItemsXml = priceItemsXml.Replace("COUNT", "count");
            priceItemsXml = priceItemsXml.Replace("PRICE", "price");
            priceItemsXml = priceItemsXml.Replace("AMOUNT", "amount");
            priceItemsXml = priceItemsXml.Replace("ZYYPFS", "zyypfs");
            priceItemsXml = priceItemsXml.Replace("ZXJJBS", "zxjjbs");
            priceItemsXml = priceItemsXml.Replace("BZBM", "bzbm");

            XmlDocument docPriceItems = new XmlDocument();
            docPriceItems.LoadXml(priceItemsXml);

            XmlNode ndVisitInfos = docPriceItems.SelectSingleNode("PriceItems");
            elePriceItems.InnerXml = ndVisitInfos.InnerXml;

            elerspCode.InnerText = "0000";
            elerspMsg.InnerText = "交易成功";
            outParm = ndResRoot.OuterXml;
            return 0;
        }
        #endregion

        #region 013 单张划价单缴费
        /// <summary>
        /// 013 单张划价单缴费
        /// </summary>
        /// <param name="docRequestPre"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int SaveBillItems(XmlDocument docRequestPre, out string outParm)
        {
            ;
            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("root");

            XmlElement elerspCode = docResponseRoot.CreateElement("rspCode");
            ndResRoot.AppendChild(elerspCode);

            XmlElement elerspMsg = docResponseRoot.CreateElement("rspMsg");
            ndResRoot.AppendChild(elerspMsg);

            string visitNo, empNameNo, visitData, sequenceNos, sequenceNoJson;
            empNameNo = "system";
            string preCharge;

            try
            {
                visitData = ndReqRoot.SelectSingleNode("visitData").InnerText;
                sequenceNoJson = ndReqRoot.SelectSingleNode("SequenceNos").InnerText;
                JObject joVisitData = JObject.Parse(visitData);
                visitNo = joVisitData["ResidenceNo"].ToString();
                XmlDocument docXml = JsonConvert.DeserializeXmlNode(sequenceNoJson);
                sequenceNos = docXml.SelectSingleNode("SequenceNos").InnerXml;

                string charges; string insurFund;
                string insurAccountCharges; string insurHospCharges; string insurBalance;
                string insurSafe; string insurOfficialCharges; string insuranceNo;
                string safetyNo; string insuranceCardNo; string returnText;
                string businessNo; string insurApplyNo, cost;
                string payType, rateType;
                string bankDate, inCardNo;
                charges = insurFund = "0";
                insurAccountCharges = insurHospCharges = insurBalance = "0";
                insurSafe = insurOfficialCharges = insuranceNo = "0";
                safetyNo = insuranceCardNo = returnText = "0";
                businessNo = insurApplyNo = "0";

                string bankTradeNo;
                string siOutParam, machineCode;
                bankTradeNo = ndReqRoot.SelectSingleNode("inJfStreamNo").InnerText;
                inCardNo = ndReqRoot.SelectSingleNode("inCardNo").InnerText;
                siOutParam = ndReqRoot.SelectSingleNode("siOutParam").InnerText;
                machineCode = "";
                if (ndReqRoot.SelectSingleNode("machineCode") != null)
                    machineCode = ndReqRoot.SelectSingleNode("machineCode").InnerText;

                string money, inBankReturnCode, inBankcard;

                inBankReturnCode = ndReqRoot.SelectSingleNode("inBankReturnCode").InnerText.Trim();
                inBankcard = ndReqRoot.SelectSingleNode("inBankcard").InnerText.Trim();
                money = ndReqRoot.SelectSingleNode("inCashPay").InnerText.Trim();
                rateType = ndReqRoot.SelectSingleNode("inPersonnelType").InnerText;
                payType = ndReqRoot.SelectSingleNode("inPayMethod").InnerText;
                empNameNo = ndReqRoot.SelectSingleNode("inReceiverNo").InnerText;
                preCharge = ndReqRoot.SelectSingleNode("inJeall").InnerText;

                string tradeText, registerInparm;
                tradeText = ndReqRoot.SelectSingleNode("siInParam").InnerText;
                returnText = ndReqRoot.SelectSingleNode("siOutParam").InnerText;
                registerInparm = ndReqRoot.SelectSingleNode("siDjParam").InnerText;

                bankTradeNo = bankTradeNo + "|" + inBankReturnCode;//缴费订单号+银行返回码



                string[] outArray;
                switch (rateType)
                {
                    case "H": //农合
                        break;
                    case "F"://医保
                        outArray = returnText.Split('^');
                        if (outArray.Length > 2)
                        {
                            string[] settleList2 = outArray[1].Split('|');
                            string insur1, insur2, insur3, insur4;
                            if (settleList2.Length > 18)
                            {

                                insur1 = settleList2[1];
                                insur2 = settleList2[2];
                                insur3 = settleList2[3];
                                insur4 = settleList2[4];
                                insurFund = (decimal.Parse(insur1) + decimal.Parse(insur2)
                                    + decimal.Parse(insur3) + decimal.Parse(insur4)).ToString();
                                insurAccountCharges = settleList2[5];
                                charges = settleList2[6];
                                insurBalance = settleList2[12];

                            }
                        }
                        string[] inList1 = tradeText.Split('^');
                        if (inList1.Length > 8)
                        {
                            businessNo = inList1[3];

                            string[] regList = inList1[7].Split('|');
                            insuranceNo = regList[0];
                            safetyNo = regList[13];
                            insuranceCardNo = safetyNo;
                        }

                        break;
                    default://
                        break;
                }


                bankDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                //insurFund = (decimal.Parse(cost) - decimal.Parse(charges)).ToString();

                string cardId, admitDate, applyDeptName;
                string patientID, receiptNo;
                cardId = joVisitData["PayCardNo"].ToString();
                rateType = joVisitData["RateType"].ToString();
                admitDate = joVisitData["AdmitDate"].ToString();
                applyDeptName = joVisitData["ApplyDeptName"].ToString();
                patientID = joVisitData["PatientID"].ToString();



                if (cardId != inCardNo)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = "录入的卡号， 与原卡号不一致！"; ;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }





                if (rateType == "F")
                {
                    BankTradeLogDal bankTradeLogDal = new BankTradeLogDal();
                    decimal lostCash = 0;
                    lostCash = decimal.Parse(preCharge) - (decimal.Parse(charges) + decimal.Parse(insurFund) +
                     decimal.Parse(insurAccountCharges) + decimal.Parse(insurHospCharges) +
                     decimal.Parse(insurSafe) + decimal.Parse(insurOfficialCharges));
                     Log4NetHelper.Info("插入医保日志中间表开始！！");
                    bankTradeLogDal.CreateSettleInfo(registerInparm, tradeText, returnText, patientID, visitNo, rateType, lostCash);
                }

                string errorMsg;
                if (ChargeSettle2094(visitNo, money, preCharge, charges, insurFund,
                      insurAccountCharges, insurHospCharges, insurBalance,
                      insurSafe, insurOfficialCharges, insuranceNo,
                      safetyNo, insuranceCardNo, tradeText, returnText,
                      businessNo, insurApplyNo, "2"/*仅结算未扣费项目*/,
                      visitData, sequenceNos, payType, bankTradeNo, empNameNo,
                      bankDate, machineCode, out receiptNo, out string outParmXml,
                      out errorMsg) < 0)
                {
                    elerspCode.InnerText = "0";
                    if (errorMsg.IndexOf("不等于请求总金额") > 0) errorMsg = "医保金额与实际金额不一致！";
                    elerspMsg.InnerText = errorMsg;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParmXml);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                string resultCode, settleNo;

                resultCode = ndResponse.SelectSingleNode("ResultCode").InnerText;
                settleNo = ndResponse.SelectSingleNode("SettleNo").InnerText;

                XmlElement eleitems = docResponseRoot.CreateElement("items");
                ndResRoot.AppendChild(eleitems);

                XmlElement eleooutJfStreamno = docResponseRoot.CreateElement("outJfStreamno");
                eleooutJfStreamno.InnerText = bankTradeNo;
                ndResRoot.AppendChild(eleooutJfStreamno);

                XmlElement eleooutFlowJfid = docResponseRoot.CreateElement("outFlowJfid");
                eleooutFlowJfid.InnerText = settleNo;
                ndResRoot.AppendChild(eleooutFlowJfid);

                XmlElement eleoutRcptno = docResponseRoot.CreateElement("outRcptno");
                eleoutRcptno.InnerText = receiptNo;
                ndResRoot.AppendChild(eleoutRcptno);

                elerspCode.InnerText = "1";
                elerspMsg.InnerText = "交易成功！";

                outParm = docResponseRoot.OuterXml;
            }
            catch (Exception ex)
            {
                elerspCode.InnerText = "0";
                elerspMsg.InnerText = ex.Message;
                outParm = docResponseRoot.OuterXml;
                Log4NetHelper.Error("挂号", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region local funcation

        private int CreatePrepayment2151(string inCardNo, string empNameNo, string bankTradeNo,
                string terminalID, string money, string ioFlag, string payType,
            out string errorMsg)
        {
            errorMsg = "";
            StringBuilder sql = new StringBuilder();
            UtilityDAL utilityDAL = new UtilityDAL();
            sql.Clear();
            sql.Append("select * from sick_basic_info where ic_card_id = :arg_card_id");
            OracleParameter[] paraSickBase =
                                                {
                                                     new OracleParameter("arg_card_id",inCardNo)
                                                };
            DataTable dtSickBase = Select(sql.ToString(), paraSickBase);
            if (dtSickBase.Rows.Count == 0)
            {
                errorMsg = "录入的卡号不正确，请重新输入！ ";
                return -1;
            }
            //=========================================================

            string sickId;
            sickId = dtSickBase.Rows[0]["sick_id"].ToString();

            string clientType, tradeCode = "2151";
            clientType = "25";
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = empNameNo;
            ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
            ndRequest.SelectSingleNode("BankTradeNo").InnerText = bankTradeNo;
            ndRequest.SelectSingleNode("TerminalID").InnerText = terminalID;

            XmlElement elePatientID = docRequest.CreateElement("PatientID");
            elePatientID.InnerText = sickId;
            ndRequest.AppendChild(elePatientID);

            XmlElement eleResidenceNo = docRequest.CreateElement("ResidenceNo");
            eleResidenceNo.InnerText = "";
            ndRequest.AppendChild(eleResidenceNo);

            XmlElement eleMoney = docRequest.CreateElement("Money");
            eleMoney.InnerText = money;
            ndRequest.AppendChild(eleMoney);

            XmlElement elePayType = docRequest.CreateElement("PayType");
            elePayType.InnerText = payType;
            ndRequest.AppendChild(elePayType);

            XmlElement eleBankCardNo = docRequest.CreateElement("BankCardNo");
            eleBankCardNo.InnerText = "";
            ndRequest.AppendChild(eleBankCardNo);

            XmlElement eleIoFlag = docRequest.CreateElement("IoFlag");
            eleIoFlag.InnerText = ioFlag;
            ndRequest.AppendChild(eleIoFlag);

            XmlElement eleBankDate = docRequest.CreateElement("BankDate");
            eleBankDate.InnerText = DateTime.Now.ToString("yyyyMMddhhmmss");
            ndRequest.AppendChild(eleBankDate);

            ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
            ndRequest.SelectSingleNode("Signature").InnerText = signature;

            string outParm;
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
                errorMsg = resultMessage;
                return -1;
            }
            return 0;
        }
        public int PreQuene2306(string inDepartmentId, string inExpertId, string serviceDate,
            string inCardNo, string reserveCode, string inSeeTime, string inReceiveNo,
            string machinelocation, out string preHisTradeNo, out string admitAddress,
            out string admitRange, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();

            string clientType, tradeCode = "2306";
            clientType = "25";
            preHisTradeNo = admitAddress = admitRange = outParm = "";
            try
            {


                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = inReceiveNo;
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
                ndRequest.SelectSingleNode("BankTradeNo").InnerText = StringExtension.GetRandomNext(9).ToString();


                string sessionCode;
                if (inSeeTime == "1")
                {
                    sessionCode = "S";
                }
                else
                {
                    sessionCode = "X";
                }

                XmlElement eleServiceDate = docRequest.CreateElement("ServiceDate");
                eleServiceDate.InnerText = serviceDate;
                ndRequest.AppendChild(eleServiceDate);

                XmlElement eleSessionCode = docRequest.CreateElement("SessionCode");
                eleSessionCode.InnerText = sessionCode;
                ndRequest.AppendChild(eleSessionCode);

                XmlElement eleDepartmentCode = docRequest.CreateElement("DepartmentCode");
                eleDepartmentCode.InnerText = inDepartmentId;
                ndRequest.AppendChild(eleDepartmentCode);

                XmlElement eleDoctor = docRequest.CreateElement("Doctor");
                eleDoctor.InnerText = inExpertId;
                ndRequest.AppendChild(eleDoctor);

                XmlElement eleDoctorCode = docRequest.CreateElement("DoctorCode");
                eleDoctorCode.InnerText = "";
                ndRequest.AppendChild(eleDoctorCode);

                XmlElement eleStartDate = docRequest.CreateElement("StartTime");
                eleStartDate.InnerText = "";
                ndRequest.AppendChild(eleStartDate);

                XmlElement eleEndDate = docRequest.CreateElement("EndTime");
                eleEndDate.InnerText = "";
                ndRequest.AppendChild(eleEndDate);

                XmlElement eleReserveCode = docRequest.CreateElement("ReserveCode");
                eleReserveCode.InnerText = reserveCode;
                ndRequest.AppendChild(eleReserveCode);

                XmlElement elePhoneNo = docRequest.CreateElement("PhoneNo");
                elePhoneNo.InnerText = "";
                ndRequest.AppendChild(elePhoneNo);

                XmlElement elePayCardNo = docRequest.CreateElement("PayCardNo");
                elePayCardNo.InnerText = inCardNo;
                ndRequest.AppendChild(elePayCardNo);

                //XmlElement eleBankTradeNo = docRequest.CreateElement("BankTradeNo");
                //eleBankTradeNo.InnerText = StringExtension.GetRandomNext(9).ToString();
                //ndRequest.AppendChild(eleBankTradeNo);

                XmlElement elePreFlag = docRequest.CreateElement("PreFlag");
                elePreFlag.InnerText = "1";
                ndRequest.AppendChild(elePreFlag);

                docRequest.SelectSingleNode("Request/TerminalID").InnerText = machinelocation;

                ndRequest.SelectSingleNode("PublicKey").InnerText = publicKey;
                ndRequest.SelectSingleNode("Signature").InnerText = signature;

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
                    outParm = resultMessage;
                    return -1; 
                }
                preHisTradeNo = ndResponse.SelectSingleNode("HISTradeNo").InnerText;
                //orderCode = ndResponse.SelectSingleNode("OrderCode").InnerText;
                admitAddress = ndResponse.SelectSingleNode("AdmitAddress").InnerText;
                admitRange = ndResponse.SelectSingleNode("AdmitRange").InnerText;
                return 0;
            }
            catch (Exception ex)
            {
                outParm = ex.Message;
                Log4NetHelper.Error("PreQuene2306", ex);
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 瑞美lis 生成管子费用
        /// </summary>
        /// <param name="ndApplyItems"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public int SendLisBeforeSettle(XmlNode ndApplyItems, out string outParm)
        {
            outParm = "";
            StringBuilder sql = new StringBuilder();
            bool canSendLis;
            string applyNo, itemClass, executeDeptCode, costMode;
            DateTime applyTime;
            string itemCode, applyClassCode;
            long visitNumber;
            string lisCreateBarcodeDeptCode;
            UtilityDAL utilityDAL = new UtilityDAL();
            lisCreateBarcodeDeptCode = utilityDAL.GetSysParm("lis_create_barcode_dept_code");
            try
            {


                DataTable dt = new DataTable();

                dt.Columns.Add("apply_time", typeof(System.DateTime));
                dt.Columns.Add("apply_no", typeof(System.String));
                DataRow dr;
                string expectedFormats = "yyyyMMddHHmmss";

                foreach (XmlNode ndApplyItem in ndApplyItems.SelectNodes("ApplyItem"))
                {
                    canSendLis = false;
                    applyNo = ndApplyItem.SelectSingleNode("ApplyNo").InnerText;
                    itemCode = ndApplyItem.SelectSingleNode("ItemCost").InnerText;
                    applyTime = DateTime.ParseExact((ndApplyItem.SelectSingleNode("AppleTime").InnerText), expectedFormats, System.Globalization.CultureInfo.InvariantCulture);

                    executeDeptCode = ndApplyItem.SelectSingleNode("ExecuteDeptCode").InnerText;
                    costMode = ndApplyItem.SelectSingleNode("CostMode").InnerText;
                    sql.Clear();
                    sql.Append(@"select a.APPLY_CLASS_CODE apply_class_code, 
                                    a.item_code item_code, 
                                    a.visit_number visit_number
  		                      from V_APPLY_SHEET_UNION a
 		                     where a.APPLY_NO = :arg_apply_no");
                    OracleParameter[] parmApplySheet =
                          {
                            new OracleParameter("arg_apply_no",applyNo)
                        };
                    DataTable dtApplySheet = Select(sql.ToString(), parmApplySheet);
                    if (dtApplySheet.Rows.Count == 0) continue;
                    applyClassCode = dtApplySheet.Rows[0]["apply_class_code"].ToString();
                    itemCode = dtApplySheet.Rows[0]["item_code"].ToString();
                    visitNumber = long.Parse(dtApplySheet.Rows[0]["visit_number"].ToString());
                    if (applyClassCode == "0041") continue;

                    if (visitNumber > 0) continue; //只有门诊单据才发送
                                                   //只有检验单据才发送
                    sql.Clear();
                    sql.Append(@"select  substr( item_class, 0,1) item_class, item_code from clinic_item_dict where item_code = '" + itemCode + "'");
                    DataTable dtItemDict = Select(sql.ToString());
                    if (dtItemDict.Rows.Count == 0) continue;
                    itemClass = dtItemDict.Rows[0]["item_class"].ToString();
                    if (itemClass != "D") continue;
                    if (lisCreateBarcodeDeptCode.IsNull()) break;
                    lisCreateBarcodeDeptCode = ";" + lisCreateBarcodeDeptCode + ";";
                    if (executeDeptCode.IsNull()) executeDeptCode = "abc";
                    if (lisCreateBarcodeDeptCode.IndexOf(executeDeptCode) >= 0)
                    {
                        canSendLis = true;
                    }

                    if (!canSendLis) continue;

                    dr = dt.NewRow();
                    dr["apply_time"] = applyTime;
                    dr["apply_no"] = applyNo;
                    dt.Rows.Add(dr);
                }

                DataView dv = dt.DefaultView;
                dv.Sort = "apply_time";
                DataTable dtCreateList = dv.ToTable();

                SvrRmlisDal svrRmlisDal = new SvrRmlisDal(DBConnection, DBTransaction);
                DateTime applyTimeOld = utilityDAL.GetSysDateTime().Date;
                List<string> applyNos = new List<string>();
                int ireturn;
                if (dtCreateList.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCreateList.Rows.Count; i++)
                    {
                        applyTime = dtCreateList.Rows[i]["apply_time"].ToString().ToDateTime().Date;
                        applyNo = dtCreateList.Rows[i]["apply_no"].ToString();
                        if (i == 0) applyTimeOld = applyTime;

                        if (applyTimeOld != applyTime)
                        {
                            //不同天先将前面的单据生成条码
                            ireturn = svrRmlisDal.ChargeTube(applyNos, out outParm);

                            applyNos.Clear();
                            applyTimeOld = applyTime;
                            applyNos.Add(applyNo);
                        }
                        else
                        {
                            applyNos.Add(applyNo);
                        }
                    }
                   
                }
                if (applyNos.Count > 0)
                {
                    ireturn = svrRmlisDal.ChargeTube(applyNos, out outParm);
                }
                else
                {
                    ireturn = 0;
                }
                return ireturn;
            }
            catch (Exception ex)
            {
                outParm = ex.Message;
                Log4NetHelper.Error("瑞美lis 生成管子费用", ex);
                return -1;
            }
        }
        #endregion


    }
}
