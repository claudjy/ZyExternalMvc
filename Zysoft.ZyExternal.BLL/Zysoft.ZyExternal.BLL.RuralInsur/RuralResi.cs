using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zysoft.FrameWork.Database;
      
using Zysoft.ZyExternal.DAL.RuralInsur;
using Zysoft.ZyExternal.IBLL.RuralInsur;

namespace Zysoft.ZyExternal.BLL.RuralInsur
{
    public class RuralResi : ServiceBase, IRuralResi
    {

        #region B002 住院登记（扩展函数）
        /// <summary>
        /// B002 住院登记（扩展函数）7
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
        public virtual string inpatientRegister(string rateType, string centerCodeEx, string residenceNo, string bookNo, string safetyNo,
                                                string diagnosisCode, string diagnosisCode2, string admissionDept, string admissionTime,
                                                string registType, string admissionCondition, string doctor, string bedNo, string ward,
                                                string turnCode)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.inpatientRegister(rateType, centerCodeEx, residenceNo, bookNo, safetyNo,
                        diagnosisCode, diagnosisCode2, admissionDept, admissionTime, registType,
                        admissionCondition, doctor, bedNo, ward, turnCode, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B003 取消住院登记（扩展函数）cancelInpatientRegister
        /// <summary>
        ///  B003 取消住院登记（扩展函数）cancelInpatientRegister
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <returns></returns>
        public virtual string cancelInpatientRegister(string rateType, string centerCodeEx, string insuranceNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.cancelInpatientRegister(rateType, centerCodeEx, insuranceNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B004 住院登记查询（扩展函数）inpatientRegisterSeek
        /// <summary>
        /// B004 住院登记查询（扩展函数）inpatientRegisterSeek
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="residenceNo"></param>
        /// <param name="safetyNo"></param>
        /// <returns></returns>
        public virtual string inpatientRegisterSeek(string rateType, string centerCodeEx, string residenceNo, string safetyNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.inpatientRegisterSeek(rateType, centerCodeEx, residenceNo, safetyNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B005 住院费用明细录入函数inpDetailInput
        /// <summary>
        /// B005 住院费用明细录入函数inpDetailInput
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="applyNo"></param>
        /// <param name="hiscode"></param>
        /// <param name="insureId"></param>
        /// <param name="classId"></param>
        /// <param name="name"></param>
        /// <param name="spec"></param>
        /// <param name="unit"></param>
        /// <param name="conf"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <param name="money"></param>
        /// <param name="factMoney"></param>
        /// <param name="useDate"></param>
        /// <returns></returns>
        public virtual string inpDetailInput(string rateType, string centerCodeEx, string insuranceNo, string applyNo, string hiscode, string insureId, string classId, string name, string spec, string unit, string conf, string price, string quantity, string money, string factMoney, string useDate)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.inpDetailInput(rateType, centerCodeEx, insuranceNo, applyNo, hiscode, insureId,
                                                    classId, name, spec, unit, conf, price, quantity,
                                                    money, factMoney, useDate, out  outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B006 住院所有明细取消函数inpCancelFee
        /// <summary>
        /// B006 住院所有明细取消函数inpCancelFee
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <returns></returns>
        public virtual string inpCancelFee(string rateType, string centerCodeEx, string insuranceNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.inpCancelFee(rateType, centerCodeEx, insuranceNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B007 住院批量费用明细录入函数（扩展函数）uploadInpatientDetails
        /// <summary>
        /// B007 住院批量费用明细录入函数（扩展函数）uploadInpatientDetails
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="sickId"></param>
        /// <param name="residenceNo"></param>
        /// <param name="rowCount"></param>
        /// <param name="xmlDetails"></param>
        /// <returns></returns>
        public virtual string uploadInpatientDetails(string rateType, string centerCodeEx, string sickId, string residenceNo, string rowCount, string xmlDetails)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.uploadInpatientDetails(rateType, centerCodeEx, sickId, residenceNo, rowCount, xmlDetails, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B008 出院登记（扩展函数）leaveInpatientRegister
        /// <summary>
        /// B008 出院登记（扩展函数）leaveInpatientRegister
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="dischargeTime"></param>
        /// <param name="outDept"></param>
        /// <param name="diseaseStatus"></param>
        /// <param name="diagnosisCode"></param>
        /// <returns></returns>
        public virtual string leaveInpatientRegister(string rateType, string centerCodeEx, string insuranceNo, string dischargeTime,
                string outDept, string doctorName, string doctorId,
                string diseaseStatus, string diagnosisCode, string treatCode, string turnCode)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.leaveInpatientRegister(rateType, centerCodeEx, insuranceNo, dischargeTime,
                        outDept, doctorName, doctorId,
                        diseaseStatus, diagnosisCode, treatCode, turnCode, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B009 取消出院登记（扩展函数）cancelLeaveInpatientRegister
        /// <summary>
        /// B009 取消出院登记（扩展函数）cancelLeaveInpatientRegister
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <returns></returns>
        public virtual string cancelLeaveInpatientRegister(string rateType, string centerCodeEx, string insuranceNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.cancelLeaveInpatientRegister(rateType, centerCodeEx, insuranceNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B010 住院补偿核算（住院补偿单生成）（扩展函数）creareInpatientRedeem
        /// <summary>
        /// B010 住院补偿核算（住院补偿单生成）（扩展函数）creareInpatientRedeem
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="redeemNo"></param>
        /// <returns></returns>
        public virtual string creareInpatientRedeem(string rateType, string centerCodeEx, string insuranceNo, string redeemNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.creareInpatientRedeem(rateType, centerCodeEx, insuranceNo, redeemNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B011 住院补偿核算撤销(住院补偿单撤销)（扩展函数）cancelInpatientRedeem
        /// <summary>
        ///  B011 住院补偿核算撤销(住院补偿单撤销)（扩展函数）cancelInpatientRedeem
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <returns></returns>
        public virtual string cancelInpatientRedeem(string rateType, string centerCodeEx, string insuranceNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.cancelInpatientRedeem(rateType, centerCodeEx, insuranceNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B012 住院兑付（扩展函数）inpatientPay
        /// <summary>
        /// B012 住院兑付（扩展函数）inpatientPay
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="redeemNo"></param>
        /// <param name="phoneNo"></param>
        /// <returns></returns>
        public virtual string inpatientPay(string rateType, string centerCodeEx, string insuranceNo, string redeemNo, string phoneNo,
            string obligateOne, string obligateTwo, string obligateThree,
            string obligateFour, string obligateFive)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.inpatientPay(rateType, centerCodeEx, insuranceNo, redeemNo, phoneNo,
                        obligateOne, obligateTwo, obligateThree, obligateFour, obligateFive, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B013 住院补偿冲红（取消兑付）（扩展函数）cancelInpatientPay
        /// <summary>
        /// B013 住院补偿冲红（取消兑付）（扩展函数）cancelInpatientPay
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <returns></returns>
        public virtual string cancelInpatientPay(string rateType, string centerCodeEx, string insuranceNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.cancelInpatientPay(rateType, centerCodeEx, insuranceNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B014 住院补偿试算（扩展函数）inpatientCalculate
        /// <summary>
        /// B014 住院补偿试算（扩展函数）inpatientCalculate
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="redeemNo"></param>
        /// <returns></returns>
        public virtual string inpatientCalculate(string rateType, string centerCodeEx, string insuranceNo, string redeemNo)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.inpatientCalculate(rateType, centerCodeEx, insuranceNo, redeemNo, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

        #region B015 住院登记修改（扩展函数）
        public virtual string inpatientUpdate(string rateType, string centerCodeEx, string insuranceNo, string residenceNo, string diagnosisCode, string diagnosisCode2, string treatCode, string admissionDept, string admissionTime, string registType, string admissionCondition, string doctor, string bedNo, string ward, string turnCode)
        {
            string outParm;
            using (OracleConnection dbCon = OracleConnect.Connect())
            {
                OracleTransaction dbTran = dbCon.BeginTransaction();
                CreateDBTransaction(dbCon, dbTran);
                try
                {

                    RuralResiDAL ruralResiDal = new RuralResiDAL();
                    if (ruralResiDal.inpatientUpdate(rateType, centerCodeEx, insuranceNo, residenceNo, diagnosisCode,
                                                     diagnosisCode2, treatCode, admissionDept, admissionTime, registType,
                                                     admissionCondition, doctor, bedNo, ward, turnCode, out outParm) < 0)
                    {
                        dbTran.Rollback();
                        return "error:" + outParm;
                    }

                    dbTran.Commit();

                }
                catch (Exception ex)
                {
                    dbTran.Rollback();
                    return "error:" + ex.Message;
                }
            }
            return "success:" + outParm;
        }
        #endregion

       
    }
}
