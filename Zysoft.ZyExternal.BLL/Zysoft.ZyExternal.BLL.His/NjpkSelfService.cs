using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zysoft.FrameWork.Database;
using Zysoft.ZyExternal.DAL.His;
using Zysoft.ZyExternal.IBLL.His;

namespace Zysoft.ZyExternal.BLL.His
{
    public class NjpkSelfService : ServiceBase, INjpkSelfService
    {
        public int CreateCardPatInfo2131(XmlDocument docRequestPre, out string outParm)
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
                        serviceDal.CreateCardPatInfo2131(docRequestPre, out outParm);
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
    }
}
