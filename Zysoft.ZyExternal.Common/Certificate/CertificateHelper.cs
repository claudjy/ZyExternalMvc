using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Runtime.Remoting.Messaging;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Zysoft.FrameWork;
using Zysoft.FrameWork.Encode;
using Zysoft.FrameWork.FaultException;

namespace Zysoft.ZyExternal.Common.Certificate
{
    /// <summary>
    /// Add by Sugar at 2012.3.7
    /// 凭证验证类
    /// </summary>
    public class CertificateHelper
    {
        /// <summary>
        /// 凭证验证
        /// </summary>
        /// <param name="certificate">凭证字符串</param>
        /// <returns>凭证验证结果</returns>
        public static CertificateResult Verify(string certificate)
        {
            CertificateResult result = new CertificateResult();

            try
            {
                //1.DES解密
                string temp = certificate.Replace(' ', '+');
                string str = DESHelper.Decrypt(temp);
                string[] strs = str.Split('|');
                string systemCode = strs[0];
                string dbUser = strs[1];
                string dbPassword = strs[2];

                //2.数据库校验
                if (systemCode.IsNull()) throw new Exception();

                Database db = DatabaseFactory.CreateDatabase();
                DbCommand cmd = db.GetSqlStringCommand("select * from zydict.external_system_dict where system_code = :argSystemCode");
                db.AddInParameter(cmd, "argSystemCode", DbType.String, systemCode);

                DataTable table = db.ExecuteDataSet(cmd).Tables[0];
                if (table.Rows.Count <= 0) throw new Exception();

                string dbUserTrue = table.Rows[0]["DB_USER"].ToString().Trim();
                string dbPasswordTrue = table.Rows[0]["DB_PASSWORD"].ToString().Trim();

                if (dbUser != dbUserTrue || dbPassword != dbPasswordTrue) throw new Exception();

                result.Success = true;
                result.SystemCode = systemCode;
                result.OrgCode = table.Rows[0]["ORG_CODE"].ToString();
                result.DbConnectConfig = table.Rows[0]["DB_CONNECT_CONFIG"].ToString();
                result.DbUser = dbUser;
                result.DbPassword = dbPassword;
                result.DbType = table.Rows[0]["DB_TYPE"].ToString();

                return result;

            }
            catch(Exception ex)
            {
                throw new FaultException("00000", "验证的凭证无效！"+ex.Message);
            }
        }

        /// <summary>
        /// 获取特性上的凭证
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static CertificateResult GetCertificateResult()
        {
            return CallContext.GetData("Certificate") as CertificateResult;
        }
    }
}
