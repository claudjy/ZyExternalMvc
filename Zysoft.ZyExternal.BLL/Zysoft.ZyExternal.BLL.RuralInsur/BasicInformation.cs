using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;
using Zysoft.FrameWork.Database;
using Zysoft.ZyExternal.DAL.RuralInsur;
using Zysoft.ZyExternal.IBLL.RuralInsur;

namespace Zysoft.ZyExternal.BLL.RuralInsur
{
    public class BasicInformation : ServiceBase, IBasicInformation
    {
        #region A001 获取病人信息函数获取病人信息函数
        /// <summary>
        ///  A001 获取病人信息函数获取病人信息函数
        /// </summary>
        /// <param name="bookno"></param>
        /// <param name="operater"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public virtual string getPersonInfo(string rateType, string bookno)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.getPersonInfo(rateType, bookno, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A002 获取医疗机构信息函数 getHospitalInfo
        /// <summary>
        /// A002 获取医疗机构信息函数 getHospitalInfo
        /// </summary>
        /// <param name="hospitalName"></param>
        /// <returns></returns>
        public virtual string getHospitalInfo(string hospitalName)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.getHospitalInfo(hospitalName, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A003 补偿类别字典下载redeemTypeDownLoad
        /// <summary>
        /// A003 补偿类别字典下载redeemTypeDownLoad
        /// </summary>
        /// <param name="rateType"></param>
        /// <returns></returns>
        public virtual string redeemTypeDownLoad(string rateType)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.redeemTypeDownLoad(rateType, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A004 科室信息下载officeCodeDown
        /// <summary>
        /// A004 科室信息下载officeCodeDown
        /// </summary>
        /// <param name="rateType"></param>
        /// <returns></returns>
        public virtual string getOfficeCodeDown(string rateType)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.getOfficeCodeDown(rateType, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A005 治疗方式下载treatmentModeUpdate
        /// <summary>
        /// A005 治疗方式下载treatmentModeUpdate
        /// </summary>
        /// <param name="rateType"></param>
        /// <returns></returns>
        public virtual string treatmentModeUpdate(string rateType)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.treatmentModeUpdate(rateType, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A006 上传/修改转诊单信息 uploadReferralsheet
        /// <summary>
        /// A006 上传/修改转诊单信息 uploadReferralsheet
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="infoType"></param>
        /// <param name="turnCode"></param>
        /// <param name="safetyNo"></param>
        /// <param name="idCardNo"></param>
        /// <param name="sickName"></param>
        /// <param name="birthday"></param>
        /// <param name="insurCardNo"></param>
        /// <param name="turnType"></param>
        /// <param name="icdCode"></param>
        /// <param name="icdName"></param>
        /// <param name="beginDate"></param>
        /// <param name="cityType"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public virtual string uploadReferralsheet(string rateType, string infoType, string turnCode, string safetyNo,
                                  string idCardNo, string sickName, string sexName, string birthday, string insurCardNo,
                                  string phoneNo, string turnType, string icdCode, string icdName, string beginDate,
                                  string fromHospCode, string fromHospName, string toHospCode, string toHospName,
                                  string cityType, string toHospLevel,
                                  string remark)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.uploadReferralsheet(rateType, infoType, turnCode, safetyNo, idCardNo, sickName,
                                       sexName, birthday, insurCardNo, phoneNo, turnType, icdCode, icdName, beginDate,
                                       fromHospCode, fromHospName, toHospCode, toHospName, cityType, toHospLevel, 
                                       remark, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A007 转诊单信息撤销cancelReferralsheet
        /// <summary>
        /// A007 转诊单信息撤销cancelReferralsheet
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="turnCode"></param>
        /// <param name="safetyNo"></param>
        /// <returns></returns>
        public virtual string cancelReferralsheet(string rateType, string turnCode, string safetyNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.cancelReferralsheet(rateType, turnCode, safetyNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A008 转诊单信息查询 downloadReferralsheet
        /// <summary>
        /// A008 转诊单信息查询 downloadReferralsheet
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="operateType"></param>
        /// <param name="turnCode"></param>
        /// <param name="safetyNo"></param>
        /// <returns></returns>
        public virtual string downloadReferralsheet(string rateType, string inoutType, string turnCode, string safetyNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.downloadReferralsheet(rateType, inoutType, turnCode, safetyNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A009 获取医疗机构列表getHospitalInfo_New
        /// <summary>
        /// A009 获取医疗机构列表getHospitalInfo_New
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="lastTime"></param>
        /// <returns></returns>
        public virtual string getHospitalInfo_New(string rateType, string lastTime)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.getHospitalInfo_New(rateType, lastTime, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region  A101 匹配药品数据上传函数 matchUpdate
        /// <summary>
        /// A101 匹配药品数据上传函数 matchUpdate
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public virtual string matchUpdate(string rateType, string insurancePriceItemCode, string itemCode, string itemName, string spec, string unit, string formName, string standardPrice)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.matchUpdate(rateType, insurancePriceItemCode, itemCode, itemName,
                            spec, unit, formName, standardPrice, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A102 药品匹配数据审核状态查询 matchSeek
        /// <summary>
        /// A102 药品匹配数据审核状态查询 matchSeek
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public virtual string matchSeek(string rateType, string insurancePriceItemCode, string itemCode)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.matchSeek(rateType, insurancePriceItemCode, itemCode, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region A113 获取病人信息函数 getPersonInfo_New
        /// <summary>
        /// A113 获取病人信息函数 getPersonInfo_New
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public virtual string getPersonInfo_New(string rateType, string centerCode, string cardNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                    if (basicInfoDAL.getPersonInfo_New( rateType,  centerCode,  cardNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    throw ex;
                }
            }
            return "success:" + outParm;
        }
        #endregion
    }
}
