using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Zysoft.FrameWork.Log
{
    /// <summary>
    /// Add by Sugar at 2012.3.14
    /// Log处理类
    /// </summary>
    public class LogCallHandler : ICallHandler
    {
        /// <summary>
        /// 策略名称
        /// </summary>
        public string PolicyName { get; set; }

        /// <summary>
        /// 拦截级别
        /// </summary>
        public int Order { get; set; }

        public LogCallHandler(string policyName, int order)
        {
            PolicyName = policyName;
            Order = order;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            PropertyInfo[] pros = input.Target.GetType().GetProperties();
            if (pros != null)
            {
                var result = getNext().Invoke(input, getNext);
                LogEntry log = new LogEntry();
                log.EventId = 100;
                log.Categories.Add(PolicyName);
                Logger.Write(log);
                return result;
            }
            else
            {
                return getNext().Invoke(input, getNext);
            }


        }
    }
}
