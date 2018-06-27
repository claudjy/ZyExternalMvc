using System;
using System.Configuration;
using System.Data.OracleClient;
using Zysoft.FrameWork.Encode;

namespace Zysoft.FrameWork.Database
{
    /// <summary>
    /// Add by Sugar at 2012.3.14
    /// 策略类型
    /// </summary>
    public static class DBConnectArgument
    {
        /// <summary>
        /// 数据库
        /// </summary>
        public static string datasource;

        /// <summary>
        /// 用户
        /// </summary>
        public static string user;

        /// <summary>
        /// 密码
        /// </summary>
        public static string password;

        /// <summary>
        /// 分院标志
        /// </summary>
        public static string partFlag;

    }
    public class OracleConnect
    {
        public static OracleConnection Connect()
        {
            //连接缓冲池配置
            /* *
                Connection Lifetime  销毁时间，默认0 
                Connection Reset     是否复位，默认true
                Enlist               是否参与事务，默认true
                Max Pool Size        最大链接数，默认100
                Min Pool Size        最小链接数，默认0
                Pooling              是否启用链接缓冲，默认true
             * */
            string connectString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            connectString = DESHelper.Decrypt(connectString); //解密
            OracleConnection connect = new OracleConnection(connectString);
            //连接数据库
            connect.Open();
            

            return connect;
        }

        public static void Disconnect(OracleConnection connect)
        {
            //断开数据库
            connect.Close();
        }

        public static OracleConnection CustomConnect(string datasource, string user, string password)
        {
            string connectString = "user id=" + user + ";data source=" + datasource + ";password=" + password;
            OracleConnection connect = new OracleConnection(connectString);

            //连接数据库
            connect.Open();

            return connect;
        }

        public static OracleConnection CustomConnect(string connectString)
        {
            OracleConnection connect = new OracleConnection(connectString);

            //连接数据库
            connect.Open();
            return connect;
        }
    }
}
