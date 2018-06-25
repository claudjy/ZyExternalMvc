using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zysoft.FrameWork.Database;
using Zysoft.FrameWork;
using System.Data;
using System.Data.OracleClient;

namespace Zysoft.ZyExternal.DAL.His
{
    public class SvrRmlisSqlDal : SqlDB
    {

        #region 

        public DataTable GetDataTable(StringBuilder sql)
        {
            DataTable dt = Select(sql.ToString());
            return dt;
        }

        #endregion
    }
}
