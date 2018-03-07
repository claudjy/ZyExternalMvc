using System.Configuration;
using System.Data.OleDb;

namespace Zysoft.FrameWork.Database
{
    public class OleDBConnect
    {
        public static void Disconnect(OleDbConnection connect)
        {
            //断开数据库
            connect.Close();
        }

        public static OleDbConnection CustomConnect(string connectString)
        {
            OleDbConnection connect = new OleDbConnection(connectString);

            //连接数据库
            connect.Open();
            return connect;
        }
    }
}
