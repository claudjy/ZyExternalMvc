using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.Remoting.Messaging;

namespace Zysoft.FrameWork.Database
{
    public class OleDB : ServiceBase, IDB
    {
        /// <summary>
        /// OleDb连接对象
        /// </summary>
        public OleDbConnection DBConnection
        {
            get;
            set;
        }

        /// <summary>
        /// OleDb事务
        /// </summary>
        public OleDbTransaction DBTransaction
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库连接配置
        /// </summary>
        public string ConnectString
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public OleDB()
        {

        }

        /// <summary>
        /// 查询：返回查询到的第一行第一列的值
        /// </summary>
        /// <typeparam name="T">返回值的类型</typeparam>
        /// <param name="sql">查询语句：如果多行，也只是返回第一行第一列的值</param>
        /// <returns></returns>
        public T Select<T>(string sql)
        {
            OleDbParameter[] parameters = { };
            return Select<T>(sql, parameters);
        }

        /// <summary>
        /// 查询：返回查询到的第一行第一列的值
        /// </summary>
        /// <typeparam name="T">返回值的类型</typeparam>
        /// <param name="sql">查询语句：如果多行，也只是返回第一行第一列的值</param>
        /// <param name="parameters">查询语句的参数列表：可为null值</param>
        /// <returns></returns>
        public T Select<T>(string sql, IDataParameter[] parameters)
        {
            return Select<T>(sql, parameters, string.Empty);
        }

        /// <summary>
        /// 查询：返回查询到的第一行第一列的值
        ///       (参数：checkNullTips有值传入时，会去检查空值)
        /// </summary>
        /// <typeparam name="T">返回值的类型</typeparam>
        /// <param name="sql">查询语句：如果多行，也只是返回第一行第一列的值</param>
        /// <param name="parameters">参数</param>
        /// <param name="checkNullTips">查询结果空值时出错提示信息</param>
        /// <returns></returns>
        public T Select<T>(string sql, IDataParameter[] parameters, string checkNullTips)
        {
            OleDbCommand command = GetCommand();
            command.CommandText = sql;
            OleDbCommandBuilder.DeriveParameters(command);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            object obj = command.ExecuteScalar();
            if (obj == null)
            {
                obj = "";
            }
            T t = obj.To<T>();

            //断开数据库连接, 使用外部事务时，不能关闭连接
            if (DBConnection == null)
            {
                command.Parameters.Clear();
                command.Connection.Close();
            }
            command.Dispose();

            //空值检查（有传入空值提示信息nullTips时，才去检查）
            if (t == null && checkNullTips != string.Empty)
            {
                throw new Exception(checkNullTips);
            }
            return t;
        }

        /// <summary>
        /// 查询返回Datatable
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <returns>返回Datatable</returns>
        public DataTable Select(string sql)
        {
            return Select(sql, null);
        }

        /// <summary>
        /// 查询返回Datatable
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回Datatable</returns>
        public DataTable Select(string sql, IDataParameter[] parameters)
        {
            return Select(sql, parameters, string.Empty);
        }

        /// <summary>
        /// 查询返回Datatable
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="tableName">Datatable名</param>
        /// <returns>返回Datatable</returns>
        public DataTable Select(string sql, IDataParameter[] parameters, string tableName)
        {
            DataTable dtSelectTable = new DataTable();

            OleDbDataAdapter adapter = this.GetDataAdapter();
            adapter.SelectCommand.CommandText = sql;
            if (parameters != null)
            {
                adapter.SelectCommand.Parameters.AddRange(parameters);
            }

            try
            {
                adapter.Fill(dtSelectTable);
            }
            catch (Exception ex)
            {
                if (DBConnection == null)
                {
                    if (adapter.SelectCommand.Connection.State != ConnectionState.Closed)
                    {
                        adapter.SelectCommand.Connection.Close();
                    }
                }
                throw new Exception(ex.Message + "\r\n【SQL】" + sql);
            }

            if (tableName.Length > 0)
            {
                dtSelectTable.TableName = tableName;
            }

            //使用外部事务时，不能关闭连接
            if (DBConnection == null)
            {
                if (adapter.SelectCommand.Connection.State != ConnectionState.Closed)
                {
                    adapter.SelectCommand.Connection.Close();
                }
            }
            //
            adapter.SelectCommand.Dispose();

            return dtSelectTable;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteStoredProcedure(string sql, IDataParameter[] parameters)
        {
            return ExecuteStoredProcedure(sql, parameters, true);
        }

        /// <summary>
        /// 执行存储过程
        ///     参数：IsCheckDBTransaction 如果调用其它外部系统的存储过程，事务不是由我们控制时传入： false
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="IsCheckDBTransaction"></param>
        /// <returns></returns>
        public int ExecuteStoredProcedure(string sql, IDataParameter[] parameters, bool IsCheckDBTransaction)
        {
            OleDbCommand command = GetCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            if (IsCheckDBTransaction)
            {
                //连接、事务统一外部传入，容错
                CheckDBTransInstantiate();
            }

            int row = command.ExecuteNonQuery();
            if (DBConnection == null)
            {
                command.Parameters.Clear();
                command.Connection.Close();
            }
            command.Dispose();

            return row;
        }

        /// <summary>
        /// 执行存储过程
        ///     参数：IsCheckDBTransaction 如果调用其它外部系统的存储过程，事务不是由我们控制时传入： false
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="IsCheckDBTransaction"></param>
        /// <returns></returns>
        public DataTable ExecuteStoredProcedure_Datatable(string sql, IDataParameter[] parameters)
        {
            DataTable dtSelectTable = new DataTable();

            OleDbDataAdapter adapter = this.GetDataAdapter();
            adapter.SelectCommand.CommandText = sql;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                adapter.SelectCommand.Parameters.AddRange(parameters);
            }

            try
            {
                adapter.Fill(dtSelectTable);
            }
            catch (Exception ex)
            {
                if (DBConnection == null)
                {
                    if (adapter.SelectCommand.Connection.State != ConnectionState.Closed)
                    {
                        adapter.SelectCommand.Connection.Close();
                    }
                }
                throw new Exception(ex.Message + "\r\n【SQL】" + sql);
            }

            //使用外部事务时，不能关闭连接
            if (DBConnection == null)
            {
                if (adapter.SelectCommand.Connection.State != ConnectionState.Closed)
                {
                    adapter.SelectCommand.Connection.Close();
                }
            }
            //
            adapter.SelectCommand.Dispose();

            return dtSelectTable;
        }

        /// <summary>
        /// 检索出表结构
        /// </summary>
        /// <param name="dataTableName"></param>
        /// <returns></returns>
        public DataTable GetDBTableStructure(string tableName)
        {
            DataTable dtGetDBTableDesc = Select("Select * from " + tableName + " where 1<> 1 ");
            dtGetDBTableDesc.TableName = tableName;
            //
            return dtGetDBTableDesc;
        }

        /// <summary>
        /// 检索出表数据
        /// </summary>
        /// <param name="dataTableName"></param>
        /// <returns></returns>
        public DataTable GetDBTableData(string tableName, string sqlAdd)
        {
            DataTable dtGetDBTableData = Select("Select * from " + tableName + " where 1 = 1 " + sqlAdd);
            dtGetDBTableData.TableName = tableName;
            //
            return dtGetDBTableData;
        }

        /// <summary>
        /// 获取OleDbCommand
        /// </summary>
        /// <returns></returns>
        private OleDbCommand GetCommand()
        {
            //参数校验
            CheckConnectionString();

            //更新数据(插入、删除、更新)
            OleDbCommand command = new OleDbCommand();
            if (this.DBConnection != null && this.DBTransaction != null)
            {
                command.Connection = DBConnection;
                command.Transaction = DBTransaction;
            }
            else
            {
                //从上下文中试图取得连接和事务 
                object obj = CallContext.GetData("ConnectionAOP");
                if (obj != null && obj is OleDbConnection)
                {
                    //当连接字符串与上下文中的不一致时(可能连其它库),须重连
                    if (!string.IsNullOrEmpty(this.ConnectString) && this.ConnectString != (obj as OleDbConnection).ConnectionString)
                    {
                    }
                    else
                    {
                        //2012-3-12.hjb.分步事务处理时(例如：先创建日志提交后，再处理其它)，
                        //              开始时上下文已传递连接和事务对象，处理完连接已经关闭，后面处理需要重新创建连接
                        DBConnection = obj as OleDbConnection;
                        if (DBConnection.State == ConnectionState.Closed)
                        {
                            DBConnection = null;
                        }
                        else
                        {         
                            obj = CallContext.GetData("TransactionAOP");
                            if (obj != null && obj is OleDbTransaction)
                            {
                                DBTransaction = obj as OleDbTransaction;
                            }
                        }
                    }
                }

                //连接数据库
                if (DBConnection == null || DBTransaction == null)
                {
                    OleDbConnection con = OleDBConnect.CustomConnect(this.ConnectString);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    command.Connection = con;
                    //command.Transaction = con.BeginTransaction(); //2010-1-26.hjb.这边创建事务无法提交，也不能覆值给:DBConnection、DBTransaction 否则外面查询无法自动断开连接
                }
                else
                {
                    command.Connection = DBConnection;
                    command.Transaction = DBTransaction;
                }
            }
            return command;
        }

        /// <summary>
        /// 获取OleDbDataAdapter
        /// </summary>
        /// <returns></returns>
        private OleDbDataAdapter GetDataAdapter()
        {
            return new OleDbDataAdapter(this.GetCommand());
        }

        /// <summary>
        /// 检查连接、事务对象外部是否有传入，更新数据库时容错判断
        /// </summary>
        private void CheckDBTransInstantiate()
        {
            //连接、事务统一外部传入，容错
            if (DBConnection == null || DBTransaction == null)
            {
                throw new Exception("更新失败，请先设置连接对象[DBConnection]和事务对象[DBTransaction]属性！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckConnectionString()
        {
            if (this.ConnectString == null)
            {
                throw new Exception("error:00000:没有设置OleDB连接字符串");
            }
        }

        public int Insert(string sql)
        {
            throw new NotImplementedException();
        }

        public int Update(string sql, IDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public int Update(string sql, IDataParameter[] parameters, bool isUpdateOneRow)
        {
            throw new NotImplementedException();
        }

        public int Delete(string sql, IDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public int Delete(string sql, IDataParameter[] parameters, bool isDeleteOneRow)
        {
            throw new NotImplementedException();
        }

        public int UpdateDataTable(DataTable updateDataTable)
        {
            throw new NotImplementedException();
        }

        public int UpdateDataSet(DataSet updateDataSet)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDBTableDataByPage(string sql, int start, int limit, ref int total)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 连其它外部系统数据库，由我们控制事务时，创建连接和事务对象
        /// </summary>
        public void BeginDBTransaction()
        {
            if (string.IsNullOrEmpty(this.ConnectString))
            {
                throw new Exception("连接失败，请先配置数据库连接字符串！");
            }

            this.DBConnection = new OleDbConnection(this.ConnectString);
            this.DBConnection.Open();
            this.DBTransaction = this.DBConnection.BeginTransaction();
        }

        /// <summary>
        /// 连其它外部系统数据库，由我们控制事务时，进行提交，提交完关闭连接
        /// </summary>
        public void DBCommit()
        {
            this.DBTransaction.Commit();
            //
            this.DBConnection.Close();
            this.DBConnection.Dispose();
        }

        /// <summary>
        /// 连其它外部系统数据库，由我们控制事务时，进行回滚，回滚完关闭连接
        /// </summary>
        public void DBRollback()
        {
            this.DBTransaction.Rollback();
            //
            this.DBConnection.Close();
            this.DBConnection.Dispose();
        }

    }
}
