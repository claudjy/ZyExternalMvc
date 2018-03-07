using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Zysoft.FrameWork.Database
{
    public interface IDB
    {        
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        string ConnectString
        {
            get;
            set;
        }

        /// <summary>
       /// 创建连接事务对象
       /// </summary>
        void BeginDBTransaction();

        /// <summary>
        /// 提取事务
        /// </summary>
        /// <returns></returns>
        void DBCommit();

        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <returns></returns>
        void DBRollback();

        T Select<T>(string sql);
        T Select<T>(string sql, IDataParameter[] parameters);
        T Select<T>(string sql, IDataParameter[] parameters, string checkNullTips);
        DataTable Select(string sql);
        DataTable Select(string sql, IDataParameter[] parameters);
        DataTable Select(string sql, IDataParameter[] parameters, string tableName);
        int Insert(string sql);
        int Update(string sql, IDataParameter[] parameters);
        int Update(string sql, IDataParameter[] parameters, bool isUpdateOneRow);
        int Delete(string sql, IDataParameter[] parameters);
        int Delete(string sql, IDataParameter[] parameters, bool isDeleteOneRow);
        int ExecuteStoredProcedure(string sql, IDataParameter[] parameters);
        int ExecuteStoredProcedure(string sql, IDataParameter[] parameters, bool IsCheckDBTransaction);
        int UpdateDataTable(DataTable updateDataTable);
        int UpdateDataSet(DataSet updateDataSet);
        DataTable GetDBTableStructure(string tableName);
        DataTable GetDBTableData(string tableName, string sqlAdd);
        DataTable GetDBTableDataByPage(string sql, int start, int limit, ref int total);     
    }
}
