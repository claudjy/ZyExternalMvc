using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zysoft.FrameWork.Database;

namespace Zysoft.ZyExternal.DAL.His
{
    public class SvrRmlis : ServiceBase
    {
        public DataTable GetDataTable(StringBuilder sql)
        {
            DataTable dtReqItemDic;
            try
            {
                using (SqlConnection dbCon = SqlConnect.Connect())
                {
                    SqlTransaction dbTran = dbCon.BeginTransaction();
                    CreateSqlDBTransaction(dbCon, dbTran);
                    try
                    {
                        SvrRmlisSqlDal svrRmlisSqlDal = new SvrRmlisSqlDal();
                        dtReqItemDic = svrRmlisSqlDal.GetDataTable(sql);
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
                return null;
            }
            return dtReqItemDic;
        }
    }
}
