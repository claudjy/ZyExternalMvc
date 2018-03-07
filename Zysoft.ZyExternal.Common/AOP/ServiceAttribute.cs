using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Zysoft.ZyExternal.Common.AOP
{

    public class ServiceAttribute : HandlerAttribute
    {
        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduction { get; set; }

        public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
        {
            //创建具体Call Handler，并调用
            return new ServiceCallHandler(Introduction, Order);

        }

        public ServiceAttribute(string introduction = "")
        {
            Introduction = introduction;
        }

    }
}
