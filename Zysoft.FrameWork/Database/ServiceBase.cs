using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Runtime.Remoting.Messaging;

namespace Zysoft.FrameWork.Database
{
    public class ServiceBase
    {
        /// <事务传递>
        ///     将连接和事务对象存储在上下文, DB使用时直接获取
        /// </事务传递>
        /// <param name="dbConn"></param>
        /// <param name="dbTrans"></param>
        public void CreateDBTransaction(OracleConnection dbConnection, OracleTransaction dbTransaction)
        {
            if (dbConnection.State != System.Data.ConnectionState.Open)
            {
                dbConnection.Open();
            }
            //
            CallContext.SetData("ConnectionAOP", dbConnection);
            CallContext.SetData("TransactionAOP", dbTransaction);
        }

        public void CreateOleDBTransaction(OleDbConnection dbConnection, OleDbTransaction dbTransaction)
        {
            if (dbConnection.State != System.Data.ConnectionState.Open)
            {
                dbConnection.Open();
            }
            CallContext.SetData("ConnectionAOP", dbConnection);
            CallContext.SetData("TransactionAOP", dbTransaction);
        }
        
    }
}
