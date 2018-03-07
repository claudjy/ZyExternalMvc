using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Zysoft.FrameWork.Log
{
    public class LogAttribute : HandlerAttribute
    {
        /// <summary>
        /// 策略名称
        /// </summary>
        public string PolicyName { get; set; }

        public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
        {

            return new LogCallHandler(PolicyName, Order);

        }

        public LogAttribute(string policyName)
        {
            PolicyName = policyName;
        }

        public LogAttribute()
            : this(LogCategory.SERVICE_CALL)
        {
        }
    }
}
