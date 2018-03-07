using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Zysoft.FrameWork.FaultException
{
    /// <summary>
    /// Add by Sugar at 2012.2.18
    /// Exception的特性定制
    /// </summary>
    public class ExceptionAttribute : HandlerAttribute
    {
        /// <summary>
        /// 错误消息模板
        /// </summary>
        public string MessageTemplate { get; set; }

        /// <summary>
        /// 策略名称
        /// </summary>
        public string PolicyName { get; set; }

        public ExceptionAttribute(string messageTemplate, string policyName)
        {
            MessageTemplate = messageTemplate;
            PolicyName = policyName;
        }

        public ExceptionAttribute(string messageTemplate)
            : this(messageTemplate, "ZysoftException")
        {
        }

        public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
        {

            return new ExceptionCallHandler(MessageTemplate, PolicyName, Order);

        }
    }
}
