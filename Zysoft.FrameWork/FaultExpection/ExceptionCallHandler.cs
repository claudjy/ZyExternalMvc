using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Zysoft.FrameWork.FaultException
{
    /// <summary>
    /// Add by Sugar at 2012.2.18
    /// Exception处理类
    /// </summary>
    public class ExceptionCallHandler : ICallHandler
    {
        /// <summary>
        /// 错误消息模板
        /// </summary>
        public string MessageTemplate { get; set; }

        /// <summary>
        /// 策略名称
        /// </summary>
        public string PolicyName { get; set; }

        /// <summary>
        /// 拦截级别
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="order"></param>
        public ExceptionCallHandler(string messageTemplate, string policyName, int order)
        {
            MessageTemplate = messageTemplate;
            PolicyName = policyName;
            Order = order;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {

            var result = getNext().Invoke(input, getNext);
            if (result.Exception != null)
            {
                string message = this.MessageTemplate.Replace("{Message}", result.Exception.Message)
                    .Replace("{Source}", result.Exception.Source)
                    .Replace("{StackTrace}", result.Exception.StackTrace)
                    .Replace("{HelpLink}", result.Exception.HelpLink)
                    .Replace("{TargetSite}", result.Exception.TargetSite.ToString());

                Exception ex = new Exception(message, result.Exception);

                bool rethrow = ExceptionPolicy.HandleException(ex, PolicyName);
                if (rethrow)
                    throw result.Exception;
            }
            return result;

        }
    }
}
