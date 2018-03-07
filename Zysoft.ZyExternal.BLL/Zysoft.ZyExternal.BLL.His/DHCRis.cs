
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
    public class DHCRis : ServiceBase, IDHCRis 
    {
        public int ReportStatusInfo(string hisAppid, string affirmMan, string affirmDate, string status, out string outParm)
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
                        DHCRisDal risDal = new DHCRisDal();
                        risDal.ReportStatusInfo(hisAppid, affirmMan, affirmDate, status, out outParm);
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
