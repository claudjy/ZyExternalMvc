using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Zysoft.ZyExternal.Common.AOP
{

    public class LogAttribute : HandlerAttribute
    {
        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduction { get; set; }

        public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
        {

            //创建具体Call Handler，并调用
            return new LogCallHandler(Introduction, Order);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="introduction">消息</param>
        public LogAttribute(string introduction = "")
        {
            Introduction = introduction;
        }

    }
}
