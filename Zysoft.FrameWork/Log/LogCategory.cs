using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zysoft.FrameWork.Log
{
    /// <summary>
    /// Add by Sugar at 2012.3.14
    /// 策略类型
    /// </summary>
    public static class LogCategory
    {
        /// <summary>
        /// 异常日志
        /// </summary>
        public const string APP_ERROR = "AppError";

        /// <summary>
        /// 服务调用日志
        /// </summary>
        public const string SERVICE_CALL= "ServiceCall";

        /// <summary>
        /// 方法调用日志
        /// </summary>
        public const string METHOD_CALL = "MethodCall";
    }
}
