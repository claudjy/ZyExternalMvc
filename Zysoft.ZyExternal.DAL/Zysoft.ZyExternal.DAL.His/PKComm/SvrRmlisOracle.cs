using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zysoft.FrameWork.Database;

namespace Zysoft.ZyExternal.DAL.His
{
    public class SvrRmlisOracle : ServiceBase
    {
        public int SendLisBeforeSettle(XmlNode ndApplyItems, out string outParm)
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
                        if (serviceDal.SendLisBeforeSettle(ndApplyItems, out outParm) < 0)
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
    }
}
