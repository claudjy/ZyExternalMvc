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

namespace Zysoft.ZyExternal.DAL.His
{
    public class NjpkSelfServiceDal : DB
    {
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

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseRoot = utilityDAL.GetResponseNjpkQueryXmlDoc();
            XmlNode ndResRoot = docResponseRoot.SelectSingleNode("root");

            string nameEmployeNo, clientType, siType;
            string sMoney;
            string tradeCode = "2131";
            XmlNode ndReqRoot = docRequestPre.SelectSingleNode("/root");
            nameEmployeNo = ndReqRoot.SelectSingleNode("operName").InnerText;
            clientType = "25";

            string name, birthday, sexCode, sexName, mobileNo, address, idCardNo;
            string cardNo, cardNoType;
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
                siType = ndReqRoot.SelectSingleNode("siType").InnerText;
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
                    elerspCode.InnerText = "1";
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
                startDate = startDate.Substring(0, 4) + "-" + startDate.Substring(4, 2) + "-" + startDate.Substring(6, 2);
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
                eleDoctor.InnerText = "胡浩/04045";//胡浩/04045
                ndRequest.AppendChild(eleDoctor);

                XmlElement eleDoctorCode = docRequest.CreateElement("DoctorCode");
                eleDoctorCode.InnerText = doctorCode;
                ndRequest.AppendChild(eleDoctorCode);

                XmlElement eleServiceDate = docRequest.CreateElement("ServiceDate");
                eleServiceDate.InnerText = "";
                ndRequest.AppendChild(eleServiceDate);

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
                    eleseeTime.InnerText = sessionCode;
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
                ndResRoot.SelectSingleNode("appCode").InnerText = resultCode;
                ndResRoot.SelectSingleNode("errorMsg").InnerText = resultMessage;

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
                string seeTime, departmentCode, doctor;
                seeTime = ndReqRoot.SelectSingleNode("inSeeTime").InnerText;
                departmentCode = ndReqRoot.SelectSingleNode("inDepartmentId").InnerText;
                doctor = ndReqRoot.SelectSingleNode("inExpertId").InnerText;

                doctorSeq = ndReqRoot.SelectSingleNode("inSectionId").InnerText;



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
                        elerspCode.InnerText = "1";
                        elerspMsg.InnerText = "无有效号源";
                        outParm = docResponseRoot.OuterXml;
                        return 0;
                    }
                }
                //end ===========================查询可预约号==============================
                #endregion

                #region 002 挂号
                //begin ===========================预约==============================
                string inCardNo, machinelocation;
                empNameNo = ndReqRoot.SelectSingleNode("inReceiverNo").InnerText;
                inCardNo = ndReqRoot.SelectSingleNode("inCardNo").InnerText;
                machinelocation = ndReqRoot.SelectSingleNode("machineLocation").InnerText;

                string preHisTradeNo, admitAddress, admitRange;
                if (PreQuene2306(departmentCode, doctor, serviceDate, inCardNo, doctorSeq,
                    seeTime, empNameNo, machinelocation, out preHisTradeNo, out admitAddress, out admitRange,
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
                string insurAccountCharges; string insurHospCharges; string insurBalance;
                string insurSafe; string insurOfficialCharges; string insuranceNo;
                string safetyNo; string insuranceCardNo; string returnText;
                string businessNo; string insurApplyNo, cost;
                string inPersonnelType;
                string bankDate;
                string payType = "1";
                charges = insurFund = "0";
                insurAccountCharges = insurHospCharges = insurBalance = "0";
                insurSafe = insurOfficialCharges = insuranceNo = "0";
                safetyNo = insuranceCardNo = returnText = "0";
                businessNo = insurApplyNo = "0";

                string bankTradeNo, inReservatePayMethod;
                string inBankTraceDate, inBankTraceTime;
                charges = ndReqRoot.SelectSingleNode("inCashPay").InnerText;
                cost = ndReqRoot.SelectSingleNode("inJeAll").InnerText;
                bankTradeNo = ndReqRoot.SelectSingleNode("inRcptstreamno").InnerText;
                inPersonnelType = ndReqRoot.SelectSingleNode("inPersonnelType").InnerText;
                inBankTraceDate = ndReqRoot.SelectSingleNode("inBankTraceDate").InnerText;
                inBankTraceTime = ndReqRoot.SelectSingleNode("inBankTraceTime").InnerText;
                inReservatePayMethod = ndReqRoot.SelectSingleNode("inReservatePayMethod").InnerText;
                payType = inReservatePayMethod;

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

                switch (inPersonnelType)
                {
                    case "0":
                        inPersonnelType = "S";
                        break;
                    case "1":
                        inPersonnelType = "1";
                        break;

                }

                if (cardId != inCardNo)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = "录入的卡号， 与原卡号不一致！"; ;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                if (inPersonnelType != rateType)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = "费别不同， 不能结算！";
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }

                if (ChargeSettle2094(visitNo, charges, insurFund,
                      insurAccountCharges, insurHospCharges, insurBalance,
                      insurSafe, insurOfficialCharges, insuranceNo,
                      safetyNo, insuranceCardNo, returnText,
                      businessNo, insurApplyNo,
                      visitData, payType, bankTradeNo, empNameNo,
                      bankDate, out receiptNo, out errorMsg) < 0)
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

        private int ChargeSettle2094(string visitNo, string charges, string insurFund,
                     string insurAccountCharges, string insurHospCharges, string insurBalance,
                     string insurSafe, string insurOfficialCharges, string insuranceNo,
                     string safetyNo, string insuranceCardNo, string returnText,
                     string businessNo, string insurApplyNo,
                     string visitData, string payType, string bankTradeNo, string empNameNo,
                     string bankDate, out string receiptNo,
                     out string errorMsg)
        {
            UtilityDAL utilityDAL = new UtilityDAL();

            string clientType, tradeCode = "2094";
            clientType = "25";
            receiptNo = errorMsg = "";

            try
            {

                //=========================================================
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = empNameNo;
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
                ndRequest.SelectSingleNode("BankTradeNo").InnerText = StringExtension.GetRandomNext(9).ToString();


                if (ndRequest.SelectSingleNode("BankDate") == null)
                {
                    XmlElement eleBankDate = docRequest.CreateElement("BankDate");
                    ndRequest.AppendChild(eleBankDate);
                }
                if (bankDate.IsNull()) bankDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                ndRequest.SelectSingleNode("BankDate").InnerText = bankDate;

                XmlElement eleIoFlag = docRequest.CreateElement("IoFlag");
                eleIoFlag.InnerText = "0";
                ndRequest.AppendChild(eleIoFlag);

                XmlElement eleVisitNo = docRequest.CreateElement("VisitNo");
                eleVisitNo.InnerText = visitNo;
                ndRequest.AppendChild(eleVisitNo);

                XmlElement elePayType = docRequest.CreateElement("PayType");
                elePayType.InnerText = payType;
                ndRequest.AppendChild(elePayType);

                XmlElement eleCharges = docRequest.CreateElement("Charges");
                eleCharges.InnerText = charges;
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

                if (PreQuene2306(inDepartmentId, inExpertId, serviceDate, inCardNo, reserveCode,
                    inSeeTime, inReceiveNo, machinelocation, out orderCode, out admitAddress, out admitRange,
                    out outParm) < 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = outParm;
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }


                elesectionId.InnerText = admitRange;
                eleaddress.InnerText = admitAddress;
                elerreservateFlow.InnerText = orderCode;
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
                eleOrgOrderCode.InnerText = reservateFlow;
                ndRequest.AppendChild(eleOrgOrderCode);

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

        #region 008 用户院内帐户充值
        /// <summary>
        /// 008  用户院内帐户充值
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

            string clientType, tradeCode = "2151";
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

                StringBuilder sql = new StringBuilder();
                sql.Clear();
                sql.Append("select * from sick_basic_info where ic_card_id = :arg_card_id");
                OracleParameter[] paraSickBase = 
                                                {
                                                     new OracleParameter("arg_card_id",inCardNo)
                                                };
                DataTable dtSickBase = Select(sql.ToString(), paraSickBase);
                if(dtSickBase.Rows.Count == 0)
                {
                    elerspCode.InnerText = "0";
                    elerspMsg.InnerText = "录入的卡号不正确，请重新输入！ ";
                    outParm = docResponseRoot.OuterXml;
                    return -1;
                }
                //=========================================================

                string sickId;
                sickId = dtSickBase.Rows[0]["sick_id"].ToString();

                //if(inZyPatientid != sickId)
                //{
                //    elerspCode.InnerText = "0";
                //    elerspMsg.InnerText = "录入病人ID， 与HIS内的不一致！ ";
                //    outParm = docResponseRoot.OuterXml;
                //    return -1;
                //}
                XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
                XmlNode ndRequest = docRequest.SelectSingleNode("Request");
                ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
                ndRequest.SelectSingleNode("ExtUserID").InnerText = inReceiverNo;
                ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
                ndRequest.SelectSingleNode("BankTradeNo").InnerText = inRcptStreamNo;
                ndRequest.SelectSingleNode("TerminalID").InnerText = machineLocation;

                XmlElement elePatientID = docRequest.CreateElement("PatientID");
                elePatientID.InnerText = sickId;
                ndRequest.AppendChild(elePatientID);

                 XmlElement eleResidenceNo = docRequest.CreateElement("ResidenceNo");
                 eleResidenceNo.InnerText = "";
                 ndRequest.AppendChild(eleResidenceNo);

                 XmlElement eleMoney = docRequest.CreateElement("Money");
                 eleMoney.InnerText = inJe;
                 ndRequest.AppendChild(eleMoney);

                 XmlElement elePayType = docRequest.CreateElement("PayType");
                 elePayType.InnerText = inPaymethod;
                 ndRequest.AppendChild(elePayType);
                
                XmlElement eleBankCardNo = docRequest.CreateElement("BankCardNo");
                eleBankCardNo.InnerText = "";
                ndRequest.AppendChild(eleBankCardNo);

                XmlElement eleIoFlag = docRequest.CreateElement("IoFlag");
                eleIoFlag.InnerText = "0";
                ndRequest.AppendChild(eleIoFlag);

                XmlElement eleBankDate = docRequest.CreateElement("BankDate");
                eleBankDate.InnerText = DateTime.Now.ToString("yyyyMMddhhmmss");
                ndRequest.AppendChild(eleBankDate);

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
                elerspMsg.InnerText = "1";
                elerspMsg.InnerText = resultMessage;
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

        #region local funcation
        public int PreQuene2306(string inDepartmentId, string inExpertId, string serviceDate,
            string inCardNo, string reserveCode, string inSeeTime, string inReceiveNo,
            string machinelocation, out string preHisTradeNo, out  string admitAddress,
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
        #endregion

    }
}
