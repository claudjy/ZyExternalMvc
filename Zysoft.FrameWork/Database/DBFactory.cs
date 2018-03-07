using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.Unity;
using Zysoft.FrameWork.Unity;
namespace Zysoft.FrameWork.Database
{
    public class DBFactory
    {        
        public static IDB GetDB(string dbType,string connectString)
        {
            IDB db = null;

            switch (dbType)
            {
                case "O":   //ORACLE 数据库
                    db = new DB();
                    break;

                case "S":   //MSsqlserver 数据库
                    db = new OleDB();
                    break;

                default:    
                    db = new DB();
                    break;
            }

            db.ConnectString = connectString;       
            //
            return db;
        }

    }
}
