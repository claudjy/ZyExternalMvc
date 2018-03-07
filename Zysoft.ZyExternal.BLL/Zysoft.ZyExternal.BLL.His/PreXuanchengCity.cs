
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zysoft.FrameWork.Database;
using Zysoft.ZyExternal.DAL.Common;
using Zysoft.ZyExternal.DAL.His;
using Zysoft.ZyExternal.IBLL.His;


namespace Zysoft.ZyExternal.BLL.His
{
    public class PreXuanchengCity : ServiceBase, IPreXuanchengCity 
    {

        #region 2108 网络测试
        /// <summary>
        /// 2108 网络测试
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int NetTest2108(XmlDocument docRequest, out string outParm)
        {
            outParm = "";
            try
            {
                using (OracleConnection dbCon = OracleConnect.Connect())
                {
                    OracleTransaction dbTran = dbCon.BeginTransaction();
                    CreateDBTransaction(dbCon, dbTran);
                    try
                    {
                        PreXuanchengCityDal ruralResiDal = new PreXuanchengCityDal();
                        ruralResiDal.NetTest2108(docRequest, out outParm);
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityDAL initXmlDoc = new UtilityDAL();
                XmlDocument docResponse = initXmlDoc.GetResponseXmlDoc();
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                ndResponse.SelectSingleNode("TradeCode").InnerText = "2108";
                ndResponse.SelectSingleNode("ResultCode").InnerText = "0004";
                ndResponse.SelectSingleNode("ResultContent").InnerText = ex.Message;
                outParm = docResponse.OuterXml;
                return -1;
            }
            return 0;


        }
        #endregion

        #region 2113 通过身份证号， 获取病人的就诊卡信息
        /// <summary>
        /// 2113 通过身份证号， 获取病人的就诊卡信息
        /// </summary>
        /// <param name="docRequestPre"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int GetSickCardByIdCard2113(XmlDocument docRequestPre, out string outParm)
        {
            outParm = "";
            try
            {
                using (OracleConnection dbCon = OracleConnect.Connect())
                {
                    OracleTransaction dbTran = dbCon.BeginTransaction();
                    CreateDBTransaction(dbCon, dbTran);
                    try
                    {
                        PreXuanchengCityDal ruralResiDal = new PreXuanchengCityDal();
                        ruralResiDal.GetSickCardByIdCard2113(docRequestPre, out outParm);
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityDAL initXmlDoc = new UtilityDAL();
                XmlDocument docResponse = initXmlDoc.GetResponseXmlDoc();
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                ndResponse.SelectSingleNode("TradeCode").InnerText = "2108";
                ndResponse.SelectSingleNode("ResultCode").InnerText = "0004";
                ndResponse.SelectSingleNode("ResultContent").InnerText = ex.Message;
                outParm = docResponse.OuterXml;
                return -1;
            }
            return 0;
            
        }
        #endregion

        #region 1012 下载科室列表
        /// <summary>
        /// 1012 下载科室列表
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int GetDeptInfo1012(XmlDocument docRequestPre, out string outParm)
        {
            outParm = "";
            try
            {
                using (OracleConnection dbCon = OracleConnect.Connect())
                {
                    OracleTransaction dbTran = dbCon.BeginTransaction();
                    CreateDBTransaction(dbCon, dbTran);
                    try
                    {
                        PreXuanchengCityDal ruralResiDal = new PreXuanchengCityDal();
                        ruralResiDal.GetDeptInfo1012(docRequestPre, out outParm);
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityDAL initXmlDoc = new UtilityDAL();
                XmlDocument docResponse = initXmlDoc.GetResponseXmlDoc();
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                ndResponse.SelectSingleNode("TradeCode").InnerText = "1012";
                ndResponse.SelectSingleNode("ResultCode").InnerText = "0004";
                ndResponse.SelectSingleNode("ResultContent").InnerText = ex.Message;
                outParm = docResponse.OuterXml;
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
            outParm = "";
            try
            {
                using (OracleConnection dbCon = OracleConnect.Connect())
                {
                    OracleTransaction dbTran = dbCon.BeginTransaction();
                    CreateDBTransaction(dbCon, dbTran);
                    try
                    {
                        PreXuanchengCityDal ruralResiDal = new PreXuanchengCityDal();
                        ruralResiDal.GetDoctorInfo1013(docRequestPre, out outParm);
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityDAL initXmlDoc = new UtilityDAL();
                XmlDocument docResponse = initXmlDoc.GetResponseXmlDoc();
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                ndResponse.SelectSingleNode("TradeCode").InnerText = "1012";
                ndResponse.SelectSingleNode("ResultCode").InnerText = "0004";
                ndResponse.SelectSingleNode("ResultContent").InnerText = ex.Message;
                outParm = docResponse.OuterXml;
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
            outParm = "";
            try
            {
                using (OracleConnection dbCon = OracleConnect.Connect())
                {
                    OracleTransaction dbTran = dbCon.BeginTransaction();
                    CreateDBTransaction(dbCon, dbTran);
                    try
                    {
                        PreXuanchengCityDal ruralResiDal = new PreXuanchengCityDal();
                        ruralResiDal.GetWorkSchedule1004(docRequestPre, out outParm);
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityDAL initXmlDoc = new UtilityDAL();
                XmlDocument docResponse = initXmlDoc.GetResponseXmlDoc();
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                ndResponse.SelectSingleNode("TradeCode").InnerText = "1004";
                ndResponse.SelectSingleNode("ResultCode").InnerText = "0004";
                ndResponse.SelectSingleNode("ResultContent").InnerText = ex.Message;
                outParm = docResponse.OuterXml;
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
            outParm = "";
            try
            {
                using (OracleConnection dbCon = OracleConnect.Connect())
                {
                    OracleTransaction dbTran = dbCon.BeginTransaction();
                    CreateDBTransaction(dbCon, dbTran);
                    try
                    {
                        PreXuanchengCityDal ruralResiDal = new PreXuanchengCityDal();
                        ruralResiDal.GetSickQuene2002(docRequestPre, out outParm);
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityDAL initXmlDoc = new UtilityDAL();
                XmlDocument docResponse = initXmlDoc.GetResponseXmlDoc();
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                ndResponse.SelectSingleNode("TradeCode").InnerText = "1004";
                ndResponse.SelectSingleNode("ResultCode").InnerText = "0004";
                ndResponse.SelectSingleNode("ResultContent").InnerText = ex.Message;
                outParm = docResponse.OuterXml;
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
            outParm = "";
            try
            {
                using (OracleConnection dbCon = OracleConnect.Connect())
                {
                    OracleTransaction dbTran = dbCon.BeginTransaction();
                    CreateDBTransaction(dbCon, dbTran);
                    try
                    {
                        PreXuanchengCityDal ruralResiDal = new PreXuanchengCityDal();
                        ruralResiDal.CreatePatInfoNoCard2134(docRequestPre, out outParm);
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityDAL initXmlDoc = new UtilityDAL();
                XmlDocument docResponse = initXmlDoc.GetResponseXmlDoc();
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                ndResponse.SelectSingleNode("TradeCode").InnerText = "1004";
                ndResponse.SelectSingleNode("ResultCode").InnerText = "0004";
                ndResponse.SelectSingleNode("ResultContent").InnerText = ex.Message;
                outParm = docResponse.OuterXml;
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
            outParm = "";
            try
            {
                using (OracleConnection dbCon = OracleConnect.Connect())
                {
                    OracleTransaction dbTran = dbCon.BeginTransaction();
                    CreateDBTransaction(dbCon, dbTran);
                    try
                    {
                        PreXuanchengCityDal ruralResiDal = new PreXuanchengCityDal();
                        ruralResiDal.SickQuene1051(docRequestPre, out outParm);
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityDAL initXmlDoc = new UtilityDAL();
                XmlDocument docResponse = initXmlDoc.GetResponseXmlDoc();
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                ndResponse.SelectSingleNode("TradeCode").InnerText = "1004";
                ndResponse.SelectSingleNode("ResultCode").InnerText = "0004";
                ndResponse.SelectSingleNode("ResultContent").InnerText = ex.Message;
                outParm = docResponse.OuterXml;
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
            outParm = "";
            try
            {
                using (OracleConnection dbCon = OracleConnect.Connect())
                {
                    OracleTransaction dbTran = dbCon.BeginTransaction();
                    CreateDBTransaction(dbCon, dbTran);
                    try
                    {
                        PreXuanchengCityDal ruralResiDal = new PreXuanchengCityDal();
                        ruralResiDal.CancelSickQuene1053(docRequestPre, out outParm);
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                UtilityDAL initXmlDoc = new UtilityDAL();
                XmlDocument docResponse = initXmlDoc.GetResponseXmlDoc();
                XmlNode ndResponse = docResponse.SelectSingleNode("Response");
                ndResponse.SelectSingleNode("TradeCode").InnerText = "1004";
                ndResponse.SelectSingleNode("ResultCode").InnerText = "0004";
                ndResponse.SelectSingleNode("ResultContent").InnerText = ex.Message;
                outParm = docResponse.OuterXml;
                return -1;
            }
            return 0;
        }
        #endregion


    }
}
