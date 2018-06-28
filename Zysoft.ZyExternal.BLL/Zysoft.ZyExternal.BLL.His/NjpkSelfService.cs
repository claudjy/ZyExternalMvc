using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Zysoft.FrameWork.Database;
using Zysoft.ZyExternal.DAL.His;
using Zysoft.ZyExternal.IBLL.His;

namespace Zysoft.ZyExternal.BLL.His
{
    public class NjpkSelfService : ServiceBase, INjpkSelfService
    {
        public int RegisterCtznCard(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        serviceDal.RegisterCtznCard(docRequestPre, out outParm);
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
                return -1;
            }
            return 0;
        }

        public int NetTest2108(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        serviceDal.NetTest2108(docRequestPre, out outParm);
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
                return -1;
            }
            return 0;
        }

        public int getSchedueInfo(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        serviceDal.getSchedueInfo(docRequestPre, out outParm);
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
                return -1;
            }
            return 0;
        }


        public int CanRegisterType(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        serviceDal.CanRegisterType(docRequestPre, out outParm);
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
                return -1;
            }
            return 0;
        }


        public int reservateConfirm(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        serviceDal.reservateConfirm(docRequestPre, out outParm);
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
                return -1;
            }
            return 0;
        }


        public int reservateCancle(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        serviceDal.reservateCancle(docRequestPre, out outParm);
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
                return -1;
            }
            return 0;
        }


        public int Register(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        if(serviceDal.Register(docRequestPre, out outParm)<0)
                        {                            
                            dbTran.Rollback();
                        }
                        else
                        {
                            dbTran.Commit();
                        }
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
                return -1;
            }
            return 0;
        }


        public int RechargeZYAcount(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        if (serviceDal.RechargeZYAcount(docRequestPre, out outParm) < 0)
                        {
                            dbTran.Rollback();
                        }
                        else
                        {
                            dbTran.Commit();
                        }
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
                return -1;
            }
            return 0;
        }

        public int hosAcctRecharge(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        if (serviceDal.hosAcctRecharge(docRequestPre, out outParm) < 0)
                        {
                            dbTran.Rollback();
                        }
                        else
                        {
                            dbTran.Commit();
                        }
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
                return -1;
            }
            return 0;
        }

        public int GetCurrentRegisterType(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        if (serviceDal.GetCurrentRegisterType(docRequestPre, out outParm) < 0)
                        {
                            dbTran.Rollback();
                        }
                        else
                        {
                            dbTran.Commit();
                        }
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
                return -1;
            }
            return 0;
        }

        public int getPreNosInfo(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        if (serviceDal.getPreNosInfo(docRequestPre, out outParm) < 0)
                        {
                            dbTran.Rollback();
                        }
                        else
                        {
                            dbTran.Commit();
                        }
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
                return -1;
            }
            return 0;
        }

        public int GetPreNosDetailInfo(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        if (serviceDal.GetPreNosDetailInfo(docRequestPre, out outParm) < 0)
                        {
                            dbTran.Rollback();
                        }
                        else
                        {
                            dbTran.Commit();
                        }
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
                return -1;
            }
            return 0;
        }


        #region 013 单张划价单缴费
        /// <summary>
        /// 013 单张划价单缴费
        /// </summary>
        /// <param name="docRequestPre"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int SaveBillItems(XmlDocument docRequestPre, out string outParm)
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
                        NjpkSelfServiceDal serviceDal = new NjpkSelfServiceDal();
                        if (serviceDal.SaveBillItems(docRequestPre, out outParm) < 0)
                        {
                            dbTran.Rollback();
                        }
                        else
                        {
                            dbTran.Commit();
                        }
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
                return -1;
            }
            return 0;
        }
        #endregion
    }
}
