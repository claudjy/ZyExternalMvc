using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zysoft.ZyExternal.Common.Certificate
{
    /// <summary>
    /// Add by Sugar at 2012.3.7
    /// 凭证验证结果
    /// </summary>
    public class CertificateResult
    {
        /// <summary>
        /// 验证成功标志
        /// </summary>
        public bool Success
        {
            get 
            {
                return _success;
            }
            set
            {
                _success = value;
            }
        }

        /// <summary>
        /// 系统编码
        /// </summary>
        public string SystemCode
        {
            get;
            set;
        }

        /// <summary>
        /// 机构代码
        /// </summary>
        public string OrgCode
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库连接配置
        /// </summary>
        public string DbConnectConfig
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库用户名
        /// </summary>
        public string DbUser
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库密码
        /// </summary>
        public string DbPassword
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库类别
        /// </summary>
        public string DbType
        {
            get;
            set;
        }

        private bool _success = false;
    }
}
