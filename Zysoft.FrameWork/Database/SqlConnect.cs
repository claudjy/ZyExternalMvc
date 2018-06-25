using System;
using System.Configuration;
using System.Data.SqlClient;
using Zysoft.FrameWork.Encode;

namespace Zysoft.FrameWork.Database
{
    public class SqlConnect
    {
        public static SqlConnection Connect()
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
            string connectString = ConfigurationManager.ConnectionStrings["SqlDatabase"].ConnectionString;
            //connectString = DESHelper.Decrypt(connectString); //解密
            SqlConnection connect = new SqlConnection(connectString);

            //连接数据库
            connect.Open();

            return connect;
        }

        public static void Disconnect(SqlConnection connect)
        {
            //断开数据库
            connect.Close();
        }

        public static SqlConnection CustomConnect(string datasource, string user, string password)
        {
            string connectString = "user id=" + user + ";data source=" + datasource + ";password=" + password;
            SqlConnection connect = new SqlConnection(connectString);

            //连接数据库
            connect.Open();

            return connect;
        }

        public static SqlConnection CustomConnect(string connectString)
        {
            SqlConnection connect = new SqlConnection(connectString);

            //连接数据库
            connect.Open();
            return connect;
        }
    }
}
