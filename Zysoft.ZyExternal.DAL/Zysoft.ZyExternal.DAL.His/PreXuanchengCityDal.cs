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
    public class PreXuanchengCityDal : DB
    {
        string serviceURL = "http://localhost:4940/webservices/WSSelfService.asmx";

        public PreXuanchengCityDal()
        {
            serviceURL = WebConfigurationManager.AppSettings["SelfServiceURL"];
        }

       
        #region 2108 网络测试
        public int NetTest2108(XmlDocument docRequestPre, out string outParm)
        {
            UtilityDAL utilityDAL = new UtilityDAL();
            string nameEmployeNo, clientType;
            string tradeCode = "2108";
            string hospitalID;
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;


            //========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;
            ndRequest.SelectSingleNode("ClientType").InnerText = clientType;

            XmlElement eleisCheckFp = docRequest.CreateElement("isCheckFp");
            eleisCheckFp.InnerText = "";
            ndRequest.AppendChild(eleisCheckFp);
            ndRequest.SelectSingleNode("isCheckFp").InnerText = "0";
            //========================================================
             
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
           
            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("网络测试", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 2113 通过身份证号， 获取病人的就诊卡信息
        /// <summary>
        /// 查询病人基本信息
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int GetSickCardByIdCard2113(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");

            XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
            ndResponseResultXuan.AppendChild(ndResponseItemXuan);

            string nameEmployeNo, clientType;
            string tradeCode = "2113";
            string cardNo, cardType;
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            cardNo = ndParams.SelectSingleNode("cardno").InnerText.Trim();
            cardType = ndParams.SelectSingleNode("cardtype").InnerText;

            if (cardNo.IsNull())
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "卡号不能为空， 请重新录入！";
                outParm = ndResponseXuan.OuterXml;
                return -1;
            }
            string icCardNo, idCardNo;
            icCardNo = idCardNo = "";
            switch (cardType)
            {
                case "1":
                    cardType = "1";
                    icCardNo = cardNo;
                    break;
                case "4":
                    idCardNo = cardNo;
                    cardType = "0";
                    break;
                default:
                    ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                    ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "查询类型有误， 请重新录入！";
                    outParm = ndResponseXuan.OuterXml;
                    return -1;
            }
            //========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;

            XmlElement eleIDCardNo = docRequest.CreateElement("IDCardNo");
            eleIDCardNo.InnerText = idCardNo;
            ndRequest.AppendChild(eleIDCardNo);

            XmlElement elePayCardNo = docRequest.CreateElement("PayCardNo");
            elePayCardNo.InnerText = icCardNo;
            ndRequest.AppendChild(elePayCardNo);


            //========================================================

           

            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    ndResponseXuan.SelectSingleNode("resultCode").InnerText = "0000";
                    ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "交易成功！";
                    outParm = ndResponseXuan.OuterXml;
                    return -1;
                }

                XmlNodeList ndCardInfos = ndResponse.SelectNodes("CardInfos/CardInfo");
                foreach (XmlNode ndCardInfo in ndCardInfos)
                {
                    XmlElement elePatid = docResponseXuan.CreateElement("patid");
                    XmlElement elecardno = docResponseXuan.CreateElement("cardno");
                    XmlElement elecardtype = docResponseXuan.CreateElement("cardtype");
                    XmlElement elepzlx = docResponseXuan.CreateElement("pzlx");
                    XmlElement elehzxm = docResponseXuan.CreateElement("hzxm");
                    XmlElement elesex = docResponseXuan.CreateElement("sex");
                    XmlElement elesfzh = docResponseXuan.CreateElement("sfzh");
                    XmlElement elelxdz = docResponseXuan.CreateElement("lxdz");
                    XmlElement eleblh = docResponseXuan.CreateElement("blh");
                    XmlElement elebirth = docResponseXuan.CreateElement("birth");
                    XmlElement elezhye = docResponseXuan.CreateElement("zhye");

                    ndResponseItemXuan.AppendChild(elePatid);
                    ndResponseItemXuan.AppendChild(elecardno);                   
                    ndResponseItemXuan.AppendChild(elecardtype);                    
                    ndResponseItemXuan.AppendChild(elepzlx);
                    ndResponseItemXuan.AppendChild(elehzxm);
                    ndResponseItemXuan.AppendChild(elesex);
                    ndResponseItemXuan.AppendChild(elesfzh);
                    ndResponseItemXuan.AppendChild(elelxdz);
                    ndResponseItemXuan.AppendChild(eleblh);
                    ndResponseItemXuan.AppendChild(elebirth);
                    ndResponseItemXuan.AppendChild(elezhye);

                    elecardtype.InnerText = "1";
                    elepzlx.InnerText = "";
                    elePatid.InnerText = ndCardInfo.SelectSingleNode("PatientID").InnerText;
                    elecardno.InnerText = ndCardInfo.SelectSingleNode("PayCardNo").InnerText;
                    elehzxm.InnerText = ndCardInfo.SelectSingleNode("PatientName").InnerText;
                    elesex.InnerText = ndCardInfo.SelectSingleNode("Sex").InnerText;
                    elesfzh.InnerText = ndCardInfo.SelectSingleNode("IDCardNo").InnerText;
                    elelxdz.InnerText = ndCardInfo.SelectSingleNode("PhoneNo").InnerText;
                    eleblh.InnerText = ndCardInfo.SelectSingleNode("DispensaryNo").InnerText;
                    elebirth.InnerText = ndCardInfo.SelectSingleNode("Birthday").InnerText;
                    elezhye.InnerText ="";
                }

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("2113 通过身份证号， 获取病人的就诊卡信息", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 1013 获取当前科室的所有医生列表
        /// <summary>
        /// 获取当前科室的所有医生列表(1013) 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int GetDoctorInfo1013(XmlDocument docRequestPre, out string outParm)
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");

            string nameEmployeNo, clientType;
            string tradeCode = "1004";
            string ksrq, jsrq;
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            ksrq = ndParams.SelectSingleNode("ksrq").InnerText;
            jsrq = ndParams.SelectSingleNode("jsrq").InnerText;

            //========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;
            ndRequest.SelectSingleNode("ClientType").InnerText = clientType;

            XmlElement eleStartDate = docRequest.CreateElement("StartDate");
            eleStartDate.InnerText = ksrq;
            ndRequest.AppendChild(eleStartDate);

            XmlElement eleEndDate = docRequest.CreateElement("EndDate");
            eleEndDate.InnerText = jsrq;
            ndRequest.AppendChild(eleEndDate);

            XmlElement eleRBASSessionCode = docRequest.CreateElement("RBASSessionCode");
            eleRBASSessionCode.InnerText = "";
            ndRequest.AppendChild(eleRBASSessionCode);

            XmlElement eleDepartmentCode = docRequest.CreateElement("DepartmentCode");
            eleDepartmentCode.InnerText = "";
            ndRequest.AppendChild(eleDepartmentCode);

            XmlElement eleDoctorCode = docRequest.CreateElement("DoctorCode");
            eleDoctorCode.InnerText = "";
            ndRequest.AppendChild(eleDoctorCode);
            //========================================================



            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    ndResponseXuan.SelectSingleNode("resultCode").InnerText = "0000";
                    ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "交易成功！";
                    outParm = ndResponseXuan.OuterXml;
                    return -1;
                }

                string doctorTitleCode, doctorName;
                XmlNodeList ndSchedules = ndResponse.SelectNodes("Schedules/Schedule");
                foreach (XmlNode ndDepartment in ndSchedules)
                {
                    XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
                    XmlNode ndysdm = docResponseXuan.CreateElement("ysdm");
                    XmlNode ndysmc = docResponseXuan.CreateElement("ysmc");
                    XmlNode ndyszc = docResponseXuan.CreateElement("yszc");
                    XmlNode ndysjs = docResponseXuan.CreateElement("ysjs");
                    XmlNode ndksdm = docResponseXuan.CreateElement("ksdm");
                    XmlNode ndksmc = docResponseXuan.CreateElement("ksmc");
                    XmlNode ndzjbz = docResponseXuan.CreateElement("zjbz");
                    XmlNode ndpy = docResponseXuan.CreateElement("py");
                    XmlNode ndwb = docResponseXuan.CreateElement("wb");
                    XmlNode ndzxrq = docResponseXuan.CreateElement("zxrq");
                    XmlNode ndghf = docResponseXuan.CreateElement("ghf");
                    XmlNode ndzlf = docResponseXuan.CreateElement("zlf");
                    ndResponseItemXuan.AppendChild(ndysdm);
                    ndResponseItemXuan.AppendChild(ndysmc);
                    ndResponseItemXuan.AppendChild(ndyszc);
                    ndResponseItemXuan.AppendChild(ndysjs);
                    ndResponseItemXuan.AppendChild(ndksdm);
                    ndResponseItemXuan.AppendChild(ndksmc);
                    ndResponseItemXuan.AppendChild(ndzjbz);
                    ndResponseItemXuan.AppendChild(ndpy);
                    ndResponseItemXuan.AppendChild(ndwb);
                    ndResponseItemXuan.AppendChild(ndzxrq);
                    ndResponseItemXuan.AppendChild(ndghf);
                    ndResponseItemXuan.AppendChild(ndzlf);

                    doctorTitleCode = ndDepartment.SelectSingleNode("DoctorTitleCode").InnerText;

                    doctorName = ndDepartment.SelectSingleNode("DoctorName").InnerText;
                    ndysdm.InnerText = ndDepartment.SelectSingleNode("DoctorCode").InnerText;
                    ndysmc.InnerText = doctorName;
                    ndyszc.InnerText = ndDepartment.SelectSingleNode("DoctorTitle").InnerText;
                    ndysjs.InnerText = "";
                    ndksdm.InnerText = ndDepartment.SelectSingleNode("DepartmentCode").InnerText;
                    ndksmc.InnerText = ndDepartment.SelectSingleNode("DepartmentName").InnerText;
                    switch (doctorTitleCode)
                    {
                        case "025":
                        case "026":
                            ndzjbz.InnerText = "0";
                            break;
                        default:
                            ndzjbz.InnerText = "1";
                            break;
                    }
                    ndpy.InnerText = utilityDAL.GetSpellCode(doctorName);
                    ndwb.InnerText = utilityDAL.GetWbzxCode(doctorName);
                    ndzxrq.InnerText = ndDepartment.SelectSingleNode("ServiceDate").InnerText;
                    ndghf.InnerText = ndDepartment.SelectSingleNode("Fee").InnerText;
                    ndzlf.InnerText = ndDepartment.SelectSingleNode("CheckupFee").InnerText;
                    ndResponseResultXuan.AppendChild(ndResponseItemXuan);
                }

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("1004 获取排班信息", ex);
                return -1;
            }
            return 0;
        }
        //private int GetDoctorInfo(string nameEmployeNo, string clientType, string departmentCode,
        //    string ksrq, string jsrq, ref XmlNodeList ndDoctors)
        //{
        //    UtilityDAL utilityDAL = new UtilityDAL();
        //    XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
        //    XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
        //    XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");
            
        //    string tradeCode = "1013";

        //    //========================================================
        //    XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
        //    XmlNode ndRequest = docRequest.SelectSingleNode("Request");
        //    ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
        //    ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;

        //    XmlElement eleDepartmentCode = docRequest.CreateElement("DepartmentCode");
        //    eleDepartmentCode.InnerText = departmentCode;
        //    ndRequest.AppendChild(eleDepartmentCode);

        //    XmlElement eleBankDate = docRequest.CreateElement("BankDate");
        //    eleBankDate.InnerText = "";
        //    ndRequest.AppendChild(eleBankDate);

        //    XmlElement eleStartDate = docRequest.CreateElement("StartDate");
        //    eleStartDate.InnerText = ksrq;
        //    ndRequest.AppendChild(eleStartDate);

        //    XmlElement eleEndDate = docRequest.CreateElement("EndDate");
        //    eleEndDate.InnerText = jsrq;
        //    ndRequest.AppendChild(eleEndDate);

        //    XmlElement eleRBASSessionCode = docRequest.CreateElement("RBASSessionCode");
        //    eleRBASSessionCode.InnerText = "";
        //    ndRequest.AppendChild(eleRBASSessionCode);
        //    //========================================================

        //    try
        //    {
        //        string outParm;
        //        HisWSSelfService hisWSSelfService = new HisWSSelfService();
        //        hisWSSelfService.Url = serviceURL;
        //        outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
        //        XmlDocument docResponse = new XmlDocument();
        //        docResponse.LoadXml(outParm);
        //        XmlNode ndResponse = docResponse.SelectSingleNode("Response");

        //        long cycleNum;
        //        cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
        //        if (cycleNum <= 0) return 0;

        //        ndDoctors = ndResponse.SelectNodes("Doctors/Doctor");

                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return 0;
        //}
        #endregion

        #region 1012 下载科室列表
        /// <summary>
        /// 2.2.1下载科室列表(1012) 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int GetDeptInfo1012(XmlDocument docRequestPre, out string outParm)
        {
             
            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");

            string nameEmployeNo, clientType;
            string tradeCode = "1012";
            string ksrq, jsrq;
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            ksrq = ndParams.SelectSingleNode("ksrq").InnerText;
            jsrq = ndParams.SelectSingleNode("jsrq").InnerText;
            
            //========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;

            XmlElement eleStartDate = docRequest.CreateElement("StartDate");
            eleStartDate.InnerText = ksrq;
            ndRequest.AppendChild(eleStartDate);

            XmlElement eleEndDate = docRequest.CreateElement("EndDate");
            eleEndDate.InnerText = jsrq;
            ndRequest.AppendChild(eleEndDate);

            XmlElement eleRBASSessionCode = docRequest.CreateElement("RBASSessionCode");
            eleRBASSessionCode.InnerText = "";
            ndRequest.AppendChild(eleRBASSessionCode);
            //========================================================



            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <=0)
                {
                    ndResponseXuan.SelectSingleNode("resultCode").InnerText = "0000";
                    ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "交易成功！";
                    outParm = ndResponseXuan.OuterXml;
                    return -1;
                }

                string departmentName;
                XmlNodeList ndDepartments = ndResponse.SelectNodes("Departments/Department");
                foreach (XmlNode ndDepartment in ndDepartments)
                {
                    XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
                    XmlNode ndksdm = docResponseXuan.CreateElement("ksdm");
                    ndResponseItemXuan.AppendChild(ndksdm);
                    XmlNode ndksmc = docResponseXuan.CreateElement("ksmc");
                    ndResponseItemXuan.AppendChild(ndksmc);
                    XmlNode ndksjj = docResponseXuan.CreateElement("ksjj");
                    ndResponseItemXuan.AppendChild(ndksjj);
                    XmlNode ndpy = docResponseXuan.CreateElement("py");
                    ndResponseItemXuan.AppendChild(ndpy);
                    XmlNode ndwb = docResponseXuan.CreateElement("wb");
                    ndResponseItemXuan.AppendChild(ndwb);
                    XmlNode ndzxrq = docResponseXuan.CreateElement("zxrq");
                    ndResponseItemXuan.AppendChild(ndzxrq);
                    XmlNode ndghf = docResponseXuan.CreateElement("ghf");
                    ndResponseItemXuan.AppendChild(ndghf);
                    XmlNode ndzlf = docResponseXuan.CreateElement("zlf");
                    ndResponseItemXuan.AppendChild(ndzlf);

                    departmentName = ndDepartment.SelectSingleNode("DepartmentName").InnerText;
                    ndksdm.InnerText = ndDepartment.SelectSingleNode("DepartmentCode").InnerText;
                    ndksmc.InnerText = departmentName;
                    ndpy.InnerText = utilityDAL.GetSpellCode(departmentName);
                    ndwb.InnerText = utilityDAL.GetWbzxCode(departmentName);
                    ndResponseResultXuan.AppendChild(ndResponseItemXuan);
                }
                //XmlElement elePatid = docResponseXuan.CreateElement("patid");
                //elePatid.InnerText = ndResponse.SelectSingleNode("PatientID").InnerText;
                //ndResponseItemXuan.AppendChild(elePatid);               

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("1012 下载科室列表", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 1004 获取排班信息
        /// <summary>
        /// 获取排班信息
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int GetWorkSchedule1004(XmlDocument docRequestPre, out string outParm)
        {
            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");

            string nameEmployeNo, clientType;
            string tradeCode = "1004";
            string ysdm,ksrq, jsrq;
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            ysdm = ndParams.SelectSingleNode("ysdm").InnerText;
            ksrq = ndParams.SelectSingleNode("ksrq").InnerText;
            jsrq = ndParams.SelectSingleNode("jsrq").InnerText;

            //========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;
            ndRequest.SelectSingleNode("ClientType").InnerText = clientType;
            
            XmlElement eleStartDate = docRequest.CreateElement("StartDate");
            eleStartDate.InnerText = ksrq;
            ndRequest.AppendChild(eleStartDate);

            XmlElement eleEndDate = docRequest.CreateElement("EndDate");
            eleEndDate.InnerText = jsrq;
            ndRequest.AppendChild(eleEndDate);

            XmlElement eleRBASSessionCode = docRequest.CreateElement("RBASSessionCode");
            eleRBASSessionCode.InnerText = "";
            ndRequest.AppendChild(eleRBASSessionCode);

            XmlElement eleDepartmentCode = docRequest.CreateElement("DepartmentCode");
            eleDepartmentCode.InnerText = "";
            ndRequest.AppendChild(eleDepartmentCode);

            XmlElement eleDoctorCode = docRequest.CreateElement("DoctorCode");
            eleDoctorCode.InnerText = ysdm;
            ndRequest.AppendChild(eleDoctorCode);
            //========================================================



            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    ndResponseXuan.SelectSingleNode("resultCode").InnerText = "0000";
                    ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "交易成功！";
                    outParm = ndResponseXuan.OuterXml;
                    return -1;
                }

                XmlNodeList ndSchedules = ndResponse.SelectNodes("Schedules/Schedule");
                string sessionCode; 
                foreach (XmlNode ndDepartment in ndSchedules)
                {
                    XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
                    XmlNode ndpbmxid = docResponseXuan.CreateElement("pbmxid");
                    XmlNode ndyyrq = docResponseXuan.CreateElement("yyrq");
                    XmlNode ndzzlx = docResponseXuan.CreateElement("zzlx");
                    XmlNode ndzzlxmc = docResponseXuan.CreateElement("zzlxmc");
                    XmlNode ndhyzs = docResponseXuan.CreateElement("hyzs");
                    XmlNode ndyyyzs = docResponseXuan.CreateElement("yyyzs");
                    XmlNode ndwyyzs = docResponseXuan.CreateElement("wyyzs");
                    ndResponseItemXuan.AppendChild(ndpbmxid);
                    ndResponseItemXuan.AppendChild(ndyyrq);
                    ndResponseItemXuan.AppendChild(ndzzlx);
                    ndResponseItemXuan.AppendChild(ndzzlxmc);
                    ndResponseItemXuan.AppendChild(ndhyzs);
                    ndResponseItemXuan.AppendChild(ndyyyzs);
                    ndResponseItemXuan.AppendChild(ndwyyzs);

                    ndpbmxid.InnerText = ndDepartment.SelectSingleNode("ScheduleItemCode").InnerText;
                    ndyyrq.InnerText = ndDepartment.SelectSingleNode("ServiceDate").InnerText;
                    sessionCode = ndDepartment.SelectSingleNode("SessionCode").InnerText;
                    if (sessionCode == "S")
                        ndzzlx.InnerText = "0";
                    else
                        ndzzlx.InnerText = "1";
                    if (sessionCode == "S")
                        ndzzlxmc.InnerText = "上午";
                    else
                        ndzzlxmc.InnerText = "下午";
                    // sessionCode = ndDepartment.SelectSingleNode("SessionCode").InnerText;
                    //ndzzlxmc.InnerText = ndDepartment.SelectSingleNode("DoctorSessType").InnerText;
                    ndhyzs.InnerText = "";
                    ndyyyzs.InnerText = "";
                    ndwyyzs.InnerText = "";
                    ndResponseResultXuan.AppendChild(ndResponseItemXuan);
                }             

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("1004 获取排班信息", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 2002 通过病人卡号， 反回病人预约列表
        /// <summary>
        /// 通过病人卡号， 反回病人预约列表
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        public int GetSickQuene2002(XmlDocument docRequestPre, out string outParm)
        {
            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");

            string nameEmployeNo, clientType;
            string tradeCode = "2002";
            string patid, ksrq, jsrq;
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            patid = ndParams.SelectSingleNode("patid").InnerText;
            ksrq = ndParams.SelectSingleNode("ksrq").InnerText;
            jsrq = ndParams.SelectSingleNode("jsrq").InnerText;

            StringBuilder sql = new StringBuilder();
            sql.Clear();
            sql.Append(@"select ic_card_id
                           from sick_basic_info b
                          where b.sick_id =:arg_sick_id");
            OracleParameter[] paraSickBase = { new OracleParameter("arg_sick_id", patid)};
            DataTable dtSickBase = Select(sql.ToString(), paraSickBase);
            if (dtSickBase.Rows.Count == 0)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "病人ID有误， 请重新录入！";
                outParm = ndResponseXuan.OuterXml;
                return -1;
            }

            string payCardNo;
            payCardNo = dtSickBase.Rows[0]["ic_card_id"].ToString();
            //========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;
            ndRequest.SelectSingleNode("ClientType").InnerText = clientType;

            XmlElement elePayCardNo = docRequest.CreateElement("PayCardNo");
            elePayCardNo.InnerText = payCardNo;
            ndRequest.AppendChild(elePayCardNo);

            XmlElement eleIDCardNo = docRequest.CreateElement("IDCardNo");
            eleIDCardNo.InnerText = "";
            ndRequest.AppendChild(eleIDCardNo);

           
            //========================================================



            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    ndResponseXuan.SelectSingleNode("resultCode").InnerText = "0000";
                    ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "交易成功！";
                    outParm = ndResponseXuan.OuterXml;
                    return -1;
                }

                XmlNodeList ndCallQueues = ndResponse.SelectNodes("CallQueues/CallQueue");
                foreach (XmlNode ndCallQueue in ndCallQueues)
                {
                    XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
                    XmlNode ndyyxh = docResponseXuan.CreateElement("yyxh");
                    XmlNode ndksdm = docResponseXuan.CreateElement("ksdm");
                    XmlNode ndksmc = docResponseXuan.CreateElement("ksmc");
                    XmlNode ndysdm = docResponseXuan.CreateElement("ysdm");
                    XmlNode ndysmc = docResponseXuan.CreateElement("ysmc");
                    XmlNode ndghrq = docResponseXuan.CreateElement("ghrq");
                    XmlNode ndyyrq = docResponseXuan.CreateElement("yyrq");
                    XmlNode ndyyhx = docResponseXuan.CreateElement("yyhx");
                    XmlNode ndghf = docResponseXuan.CreateElement("ghf");
                    XmlNode ndysje = docResponseXuan.CreateElement("ysje");
                    XmlNode ndzje = docResponseXuan.CreateElement("zje");
                    XmlNode ndpaytype = docResponseXuan.CreateElement("paytype");
                    XmlNode ndjlzt = docResponseXuan.CreateElement("jlzt");
                    XmlNode ndzfzt = docResponseXuan.CreateElement("zfzt");
                    XmlNode ndzfjlzt = docResponseXuan.CreateElement("zfjlzt");
                    XmlNode ndbz = docResponseXuan.CreateElement("bz");
                    XmlNode ndhxsjd = docResponseXuan.CreateElement("hxsjd");
                    XmlNode ndjzdz = docResponseXuan.CreateElement("jzdz");
                    XmlNode ndjzxh = docResponseXuan.CreateElement("jzxh");
                    ndResponseItemXuan.AppendChild(ndyyxh);
                    ndResponseItemXuan.AppendChild(ndksdm);
                    ndResponseItemXuan.AppendChild(ndksmc);
                    ndResponseItemXuan.AppendChild(ndysdm);
                    ndResponseItemXuan.AppendChild(ndysmc);
                    ndResponseItemXuan.AppendChild(ndghrq);
                    ndResponseItemXuan.AppendChild(ndyyrq);
                    ndResponseItemXuan.AppendChild(ndyyhx);
                    ndResponseItemXuan.AppendChild(ndghf);
                    ndResponseItemXuan.AppendChild(ndysje);
                    ndResponseItemXuan.AppendChild(ndzje);
                    ndResponseItemXuan.AppendChild(ndpaytype);
                    ndResponseItemXuan.AppendChild(ndjlzt);
                    ndResponseItemXuan.AppendChild(ndzfzt);
                    ndResponseItemXuan.AppendChild(ndzfjlzt);
                    ndResponseItemXuan.AppendChild(ndbz);
                    ndResponseItemXuan.AppendChild(ndhxsjd);
                    ndResponseItemXuan.AppendChild(ndjzdz);
                    ndResponseItemXuan.AppendChild(ndjzxh);



                    ndyyxh.InnerText = ndCallQueue.SelectSingleNode("SequenceNo").InnerText;
                    ndksdm.InnerText = "";
                    ndksmc.InnerText = ndCallQueue.SelectSingleNode("DepartmentName").InnerText;
                    ndysdm.InnerText = "";
                    ndysmc.InnerText = ndCallQueue.SelectSingleNode("DoctorName").InnerText;
                    ndghrq.InnerText = ndCallQueue.SelectSingleNode("QueueTime").InnerText;
                    ndyyrq.InnerText = ndCallQueue.SelectSingleNode("OperateTime").InnerText;
                    ndyyhx.InnerText = ndCallQueue.SelectSingleNode("OrgOrderCode").InnerText;
                    ndghf.InnerText = "";
                    ndysje.InnerText = "";
                    ndzje.InnerText = "";
                    ndpaytype.InnerText = "";
                    ndjlzt.InnerText = "";
                    ndzfzt.InnerText = "";
                    ndzfjlzt.InnerText = "";
                    ndbz.InnerText = "";
                    ndhxsjd.InnerText = "";
                    ndjzdz.InnerText = "";
                    ndjzxh.InnerText = "";

                    ndResponseResultXuan.AppendChild(ndResponseItemXuan);
                }

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("2002 通过病人卡号， 反回病人预约列表", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 2134 无卡建档
        /// <summary>
        /// 无卡建档
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int CreatePatInfoNoCard2134(XmlDocument docRequestPre, out string outParm)
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

        #region 1051 预约排队(无卡)
        /// <summary>
        /// 预约排队(无卡)
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int SickQuene1051(XmlDocument docRequestPre, out string outParm)
        {
            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");
             
            XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
            ndResponseResultXuan.AppendChild(ndResponseItemXuan);

            string nameEmployeNo, clientType;
            string tradeCode = "1051";
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            string patientName, birthday, sex, mobileNo, address, idCardNo;
            string patientID, pbmxxh, yyhx;
            patientID = ndParams.SelectSingleNode("patid").InnerText;
            pbmxxh = ndParams.SelectSingleNode("pbmxxh").InnerText;
            yyhx = ndParams.SelectSingleNode("yyhx").InnerText;

            //=========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;
            ndRequest.SelectSingleNode("ClientType").InnerText = clientType;


            XmlElement eleScheduleItemCode = docRequest.CreateElement("ScheduleItemCode");
            eleScheduleItemCode.InnerText = pbmxxh;
            ndRequest.AppendChild(eleScheduleItemCode);

            XmlElement elePatientName = docRequest.CreateElement("PatientName");
            elePatientName.InnerText = "";
            ndRequest.AppendChild(elePatientName);

            XmlElement eleSex = docRequest.CreateElement("Sex");
            eleSex.InnerText = "";
            ndRequest.AppendChild(eleSex);
            
            XmlElement eleAge = docRequest.CreateElement("Age");
            eleAge.InnerText = "";
            ndRequest.AppendChild(eleAge);

            XmlElement elePhoneNo = docRequest.CreateElement("PhoneNo");
            elePhoneNo.InnerText = "";
            ndRequest.AppendChild(elePhoneNo);

            XmlElement eleIDCardNo = docRequest.CreateElement("IDCardNo");
            eleIDCardNo.InnerText = "";
            ndRequest.AppendChild(eleIDCardNo);

            XmlElement elePatientID = docRequest.CreateElement("PatientID");
            elePatientID.InnerText = patientID;
            ndRequest.AppendChild(elePatientID);

            XmlElement elePreFlag = docRequest.CreateElement("PreFlag");
            elePreFlag.InnerText = "0";
            ndRequest.AppendChild(elePreFlag);

            XmlElement eleBankCardNo = docRequest.CreateElement("BankCardNo");
            eleBankCardNo.InnerText = "";
            ndRequest.AppendChild(eleBankCardNo);

            XmlElement eleReserveCode = docRequest.CreateElement("ReserveCode");
            eleReserveCode.InnerText = "";
            ndRequest.AppendChild(eleReserveCode);

            XmlElement eleBankDate = docRequest.CreateElement("BankDate");
            eleBankDate.InnerText = DateTime.Now.ToString("yyyyMMddhhmmss");
            ndRequest.AppendChild(eleBankDate);

            XmlElement eleBankTradeNo = docRequest.CreateElement("BankTradeNo");
            eleBankTradeNo.InnerText = "";
            ndRequest.AppendChild(eleBankTradeNo);

            //========================================================



            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Clear();
                sql.Append(@"select * from sick_basic_info where sick_id = '"+patientID+"'");
                DataTable dtSickInfo = Select(sql.ToString());
                if(dtSickInfo.Rows.Count == 0)
                {
                    ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                    ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "病人ID有误， 请重新操作！";
                    outParm = ndResponseXuan.OuterXml;
                    return -1;
                }
                patientName = dtSickInfo.Rows[0]["NAME"].ToString();
                elePatientName.InnerText = patientName;

                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                XmlElement eleyyxh = docResponseXuan.CreateElement("yyxh");
                eleyyxh.InnerText = ndResponse.SelectSingleNode("HISTradeNo").InnerText;
                ndResponseItemXuan.AppendChild(eleyyxh);

                XmlElement eleksdm = docResponseXuan.CreateElement("ksdm");
                eleksdm.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(eleksdm);

                XmlElement eleksmc= docResponseXuan.CreateElement("ksmc");
                eleksmc.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(eleksmc);

                XmlElement eleysdm= docResponseXuan.CreateElement("ysdm");
                eleysdm.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(eleysdm);

                XmlElement eleysmc= docResponseXuan.CreateElement("ysmc");
                eleysmc.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(eleysmc);

                XmlElement eleghrq= docResponseXuan.CreateElement("ghrq");
                eleghrq.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(eleghrq);

                XmlElement eleyyhx= docResponseXuan.CreateElement("yyhx");
                eleyyhx.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(eleyyhx);

                XmlElement eleghf= docResponseXuan.CreateElement("ghf");
                eleghf.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(eleghf);

                XmlElement elezlf= docResponseXuan.CreateElement("zlf");
                elezlf.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(elezlf);

                XmlElement eleysje= docResponseXuan.CreateElement("ysje");
                eleysje.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(eleysje);

                XmlElement elezje= docResponseXuan.CreateElement("zje");
                elezje.InnerText = "" ;//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(elezje);

                XmlElement elebz = docResponseXuan.CreateElement("bz");
                elebz.InnerText = "";//ndResponse.SelectSingleNode("PatientID").InnerText;
                ndResponseItemXuan.AppendChild(elebz);

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("1051 预约排队(无卡)", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 1053 取消预约排队
        /// <summary>
        /// 取消预约排队(1053) 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int CancelSickQuene1053(XmlDocument docRequestPre, out string outParm)
        {
            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");

            XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
            ndResponseResultXuan.AppendChild(ndResponseItemXuan);

            string nameEmployeNo, clientType;
            string tradeCode = "1053";
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            string patientID, yyxh;
            patientID = ndParams.SelectSingleNode("patid").InnerText;
            yyxh = ndParams.SelectSingleNode("yyxh").InnerText;

            //=========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;
            ndRequest.SelectSingleNode("ClientType").InnerText = clientType;


            XmlElement eleOrgHISTradeNo = docRequest.CreateElement("OrgHISTradeNo");
            eleOrgHISTradeNo.InnerText = yyxh;
            ndRequest.AppendChild(eleOrgHISTradeNo);

            XmlElement eleOrgOrderCode = docRequest.CreateElement("OrgOrderCode");
            eleOrgOrderCode.InnerText = "";
            ndRequest.AppendChild(eleOrgOrderCode);

            XmlElement eleBankDate = docRequest.CreateElement("BankDate");
            eleBankDate.InnerText = DateTime.Now.ToString("yyyyMMddhhmmss");
            ndRequest.AppendChild(eleBankDate);

            XmlElement eleBankTradeNo = docRequest.CreateElement("BankTradeNo");
            eleBankTradeNo.InnerText = "";
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

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("1053 取消预约排队", ex);
                return -1;
            }
            return 0;
        }
        #endregion


        #region 2303 获取当前科室的所有医生列表
        /// <summary>
        /// 获取当前科室的所有医生列表(2303) 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int GetDoctorInfo2303(XmlDocument docRequestPre, out string outParm)
        { 

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");

            string nameEmployeNo, clientType;
            string tradeCode = "2305";
            string ksrq, jsrq;
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            ksrq = ndParams.SelectSingleNode("ksrq").InnerText;
            jsrq = ndParams.SelectSingleNode("jsrq").InnerText;

            //========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;
            ndRequest.SelectSingleNode("ClientType").InnerText = clientType;

            XmlElement eleStartDate = docRequest.CreateElement("StartDate");
            eleStartDate.InnerText = ksrq;
            ndRequest.AppendChild(eleStartDate);

            XmlElement eleEndDate = docRequest.CreateElement("EndDate");
            eleEndDate.InnerText = jsrq;
            ndRequest.AppendChild(eleEndDate);

            XmlElement eleSessionCode = docRequest.CreateElement("SessionCode");
            eleSessionCode.InnerText = "";
            ndRequest.AppendChild(eleSessionCode);

            XmlElement eleDepartmentCode = docRequest.CreateElement("DepartmentCode");
            eleDepartmentCode.InnerText = "";
            ndRequest.AppendChild(eleDepartmentCode);

            XmlElement eleDoctorCode = docRequest.CreateElement("DoctorCode");
            eleDoctorCode.InnerText = "";
            ndRequest.AppendChild(eleDoctorCode);

            XmlElement eleDoctor = docRequest.CreateElement("Doctor");
            eleDoctor.InnerText = "";
            ndRequest.AppendChild(eleDoctor);
            //========================================================



            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    ndResponseXuan.SelectSingleNode("resultCode").InnerText = "0000";
                    ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "交易成功！";
                    outParm = ndResponseXuan.OuterXml;
                    return -1;
                }

                string doctorTitleCode, doctorName;
                XmlNodeList ndSchedules = ndResponse.SelectNodes("Schedules/Schedule");
                foreach (XmlNode ndDepartment in ndSchedules)
                {
                    XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
                    XmlNode ndysdm = docResponseXuan.CreateElement("ysdm");
                    XmlNode ndysmc = docResponseXuan.CreateElement("ysmc");
                    XmlNode ndyszc = docResponseXuan.CreateElement("yszc");
                    XmlNode ndysjs = docResponseXuan.CreateElement("ysjs");
                    XmlNode ndksdm = docResponseXuan.CreateElement("ksdm");
                    XmlNode ndksmc = docResponseXuan.CreateElement("ksmc");
                    XmlNode ndzjbz = docResponseXuan.CreateElement("zjbz");
                    XmlNode ndpy = docResponseXuan.CreateElement("py");
                    XmlNode ndwb = docResponseXuan.CreateElement("wb");
                    XmlNode ndzxrq = docResponseXuan.CreateElement("zxrq");
                    XmlNode ndghf = docResponseXuan.CreateElement("ghf");
                    XmlNode ndzlf = docResponseXuan.CreateElement("zlf");
                    ndResponseItemXuan.AppendChild(ndysdm);
                    ndResponseItemXuan.AppendChild(ndysmc);
                    ndResponseItemXuan.AppendChild(ndyszc);
                    ndResponseItemXuan.AppendChild(ndysjs);
                    ndResponseItemXuan.AppendChild(ndksdm);
                    ndResponseItemXuan.AppendChild(ndksmc);
                    ndResponseItemXuan.AppendChild(ndzjbz);
                    ndResponseItemXuan.AppendChild(ndpy);
                    ndResponseItemXuan.AppendChild(ndwb);
                    ndResponseItemXuan.AppendChild(ndzxrq);
                    ndResponseItemXuan.AppendChild(ndghf);
                    ndResponseItemXuan.AppendChild(ndzlf);

                    doctorTitleCode = ndDepartment.SelectSingleNode("DoctorTitleCode").InnerText;

                    doctorName = ndDepartment.SelectSingleNode("DoctorName").InnerText;
                    ndysdm.InnerText = ndDepartment.SelectSingleNode("DoctorCode").InnerText;
                    ndysmc.InnerText = doctorName;
                    ndyszc.InnerText = ndDepartment.SelectSingleNode("DoctorTitle").InnerText;
                    ndysjs.InnerText = "";
                    ndksdm.InnerText = ndDepartment.SelectSingleNode("DepartmentCode").InnerText;
                    ndksmc.InnerText = ndDepartment.SelectSingleNode("DepartmentName").InnerText;
                    switch (doctorTitleCode)
                    {
                        case "025":
                        case "026":
                            ndzjbz.InnerText = "0";
                            break;
                        default:
                            ndzjbz.InnerText = "1";
                            break;
                    }
                    ndpy.InnerText = utilityDAL.GetSpellCode(doctorName);
                    ndwb.InnerText = utilityDAL.GetWbzxCode(doctorName);
                    ndzxrq.InnerText = ndDepartment.SelectSingleNode("ServiceDate").InnerText;
                    ndghf.InnerText = ndDepartment.SelectSingleNode("Fee").InnerText;
                    ndzlf.InnerText = ndDepartment.SelectSingleNode("CheckupFee").InnerText;
                    ndResponseResultXuan.AppendChild(ndResponseItemXuan);
                }

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("获取排班列表(2305)", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region 2302 下载科室列表
        /// <summary>
        /// 下载科室列表(2302) 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int GetDeptInfo2302(XmlDocument docRequestPre, out string outParm) 
        {

            UtilityDAL utilityDAL = new UtilityDAL();
            XmlDocument docResponseXuan = utilityDAL.GetResponseXuanQueryXmlDoc();
            XmlNode ndResponseXuan = docResponseXuan.SelectSingleNode("response");
            XmlNode ndResponseResultXuan = docResponseXuan.SelectSingleNode("response/result");

            string nameEmployeNo, clientType;
            string tradeCode = "2302";
            string ksrq, jsrq;
            nameEmployeNo = docRequestPre.SelectSingleNode("/request/operid").InnerText;
            clientType = docRequestPre.SelectSingleNode("/request/partner").InnerText;
            XmlNode ndParams = docRequestPre.SelectSingleNode("/request/params");

            ksrq = ndParams.SelectSingleNode("ksrq").InnerText;
            jsrq = ndParams.SelectSingleNode("jsrq").InnerText;

            //========================================================
            XmlDocument docRequest = utilityDAL.GetRequestXmlDoc();
            XmlNode ndRequest = docRequest.SelectSingleNode("Request");
            ndRequest.SelectSingleNode("TradeCode").InnerText = tradeCode;
            ndRequest.SelectSingleNode("ExtUserID").InnerText = nameEmployeNo;

            XmlElement eleStartDate = docRequest.CreateElement("StartDate");
            eleStartDate.InnerText = ksrq;
            ndRequest.AppendChild(eleStartDate);

            XmlElement eleEndDate = docRequest.CreateElement("EndDate");
            eleEndDate.InnerText = jsrq;
            ndRequest.AppendChild(eleEndDate);

            XmlElement eleRBASSessionCode = docRequest.CreateElement("SessionCode");
            eleRBASSessionCode.InnerText = "";
            ndRequest.AppendChild(eleRBASSessionCode);
            //========================================================



            try
            {
                HisWSSelfService hisWSSelfService = new HisWSSelfService();
                hisWSSelfService.Url = serviceURL;
                outParm = hisWSSelfService.BankService(ndRequest.OuterXml);
                XmlDocument docResponse = new XmlDocument();
                docResponse.LoadXml(outParm);
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");

                long cycleNum;
                cycleNum = long.Parse(docResponse.SelectSingleNode("Response/CycleNum").InnerText);
                if (cycleNum <= 0)
                {
                    ndResponseXuan.SelectSingleNode("resultCode").InnerText = "0000";
                    ndResponseXuan.SelectSingleNode("resultMessage").InnerText = "交易成功！";
                    outParm = ndResponseXuan.OuterXml;
                    return -1;
                }

                string departmentName;
                XmlNodeList ndDepartments = ndResponse.SelectNodes("Departments/Department");
                foreach (XmlNode ndDepartment in ndDepartments)
                {
                    XmlNode ndResponseItemXuan = docResponseXuan.CreateElement("item");
                    XmlNode ndksdm = docResponseXuan.CreateElement("ksdm");
                    ndResponseItemXuan.AppendChild(ndksdm);
                    XmlNode ndksmc = docResponseXuan.CreateElement("ksmc");
                    ndResponseItemXuan.AppendChild(ndksmc);
                    XmlNode ndksjj = docResponseXuan.CreateElement("ksjj");
                    ndResponseItemXuan.AppendChild(ndksjj);
                    XmlNode ndpy = docResponseXuan.CreateElement("py");
                    ndResponseItemXuan.AppendChild(ndpy);
                    XmlNode ndwb = docResponseXuan.CreateElement("wb");
                    ndResponseItemXuan.AppendChild(ndwb);
                    XmlNode ndzxrq = docResponseXuan.CreateElement("zxrq");
                    ndResponseItemXuan.AppendChild(ndzxrq);
                    XmlNode ndghf = docResponseXuan.CreateElement("ghf");
                    ndResponseItemXuan.AppendChild(ndghf);
                    XmlNode ndzlf = docResponseXuan.CreateElement("zlf");
                    ndResponseItemXuan.AppendChild(ndzlf);

                    departmentName = ndDepartment.SelectSingleNode("DepartmentName").InnerText;
                    ndksdm.InnerText = ndDepartment.SelectSingleNode("DepartmentCode").InnerText;
                    ndksmc.InnerText = departmentName;
                    ndpy.InnerText = utilityDAL.GetSpellCode(departmentName);
                    ndwb.InnerText = utilityDAL.GetWbzxCode(departmentName);
                    ndResponseResultXuan.AppendChild(ndResponseItemXuan);
                }
                //XmlElement elePatid = docResponseXuan.CreateElement("patid");
                //elePatid.InnerText = ndResponse.SelectSingleNode("PatientID").InnerText;
                //ndResponseItemXuan.AppendChild(elePatid);               

                ndResponseXuan.SelectSingleNode("resultCode").InnerText = ndResponse.SelectSingleNode("ResultCode").InnerText;
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ndResponse.SelectSingleNode("ResultContent").InnerText;

                outParm = ndResponseXuan.OuterXml;
            }
            catch (Exception ex)
            {
                ndResponseXuan.SelectSingleNode("resultCode").InnerText = "9999";
                ndResponseXuan.SelectSingleNode("resultMessage").InnerText = ex.Message;
                outParm = ndResponseXuan.OuterXml;
                Log4NetHelper.Error("2302 下载科室列表", ex);
                return -1;
            }
            return 0;
        }
        #endregion
    }
}
