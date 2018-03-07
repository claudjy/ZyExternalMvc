using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using log4net;

namespace Zysoft.FrameWork
{
    /// <summary>
    /// Log4Net日志记录辅助类
    /// </summary>
    public class Log4NetHelper
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);   //选择<logger name="loginfo">的配置


        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="ex">信息</param>
        public static void Debug(object ex)
        {
            log.Debug(ex);
        }

        /// <summary>
        /// 记录警告信息
        /// </summary>
        /// <param name="ex">信息</param>
        public static void Warn(object ex)
        {
            log.Warn(ex);
        }

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="ex">信息</param>
        public static void Error(object ex)
        {
            log.Error(ex);
        }

        /// <summary>
        /// 记录重要提示信息
        /// </summary>
        /// <param name="ex">信息</param>
        public static void Info(object ex)
        {
            log.Info(ex);
        }

        /// <summary>
        /// 记录信息和异常信息
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="ex">异常对象</param>
        public static void Debug(object message, Exception ex)
        {
            log.Debug(message, ex);
        }

        /// <summary>
        /// 记录信息和异常信息
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="ex">异常对象</param>
        public static void Warn(object message, Exception ex)
        {
            log.Warn(message, ex);
        }

        /// <summary>
        /// 记录信息和异常信息
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="ex">异常对象</param>
        public static void Error(object message, Exception ex)
        {
            log.Error(message, ex);
        }

        /// <summary>
        /// 记录信息和异常信息
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="ex">异常对象</param>
        public static void Info(object message, Exception ex)
        {
            log.Info(message, ex);
        }
    }

}
