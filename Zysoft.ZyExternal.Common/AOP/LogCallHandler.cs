using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Zysoft.ZyExternal.Common;
using Zysoft.ZyExternal.Common.Certificate;
using Zysoft.FrameWork;
using Zysoft.FrameWork.FaultException;
using System.Xml;

namespace Zysoft.ZyExternal.Common.AOP
{
    public class LogCallHandler : ICallHandler 
    {

        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 拦截级别
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 构造方法 此处不可省略，否则会导致异常
        /// 用于，接收从Attribute中传递过来的参数
        /// </summary>
        /// <param name="introduction">介绍</param>
        /// <param name="order">拦截级别</param>
        public LogCallHandler(string introduction, int order)
        {
            Introduction = introduction;
            Order = order;
        }

        /// <summary>
        /// 调用方法 实现ICallHandler.Invoke方法，用于对具体拦截方法做相应的处理
        /// </summary>
        /// <param name="input"></param>
        /// <param name="getNext"></param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {            
            string inParam, outParam;
            inParam = string.Empty;
            outParam = string.Empty;

            //检查参数是否存在
            if (input == null) throw new ArgumentNullException("input");
            if (getNext == null) throw new ArgumentNullException("getNext");

            string paramName, paramValue;
            //1.证书, 采用数据签名的方式
        
            //2.如果只有一个入参时， 则进行记录日志操作

            for (int i = 0; i < input.Inputs.Count; i++)
            {
                ParameterInfo pi = input.Inputs.GetParameterInfo(i);
                paramName = pi.Name;

                if (pi.ParameterType == typeof(string)) //找到凭证参数
                {
                    paramValue = input.Inputs[i].ToString();
                    if (paramValue.IsNotNull())
                    {
                        inParam = inParam + paramName + ":[" + paramValue + "] \r\n";
                    }
                }
                if (pi.ParameterType == typeof(XmlDocument))
                {
                    paramValue = ((XmlDocument)input.Inputs[i]).InnerXml;
                    if (paramValue.IsNotNull())
                    {
                        inParam = inParam + paramName + ":[" + paramValue + "] \r\n";
                    }                  
                }

            }


            //3.调用方法 开始拦截，此处可以根据需求编写具体业务逻辑代码
            DateTime callTimeStart = DateTime.Now;
            var result = getNext().Invoke(input, getNext);

            //4.记录日志
            if (inParam.IsNotNull())
            {
                if(result.Outputs.Count>0)
                {
                    paramName = "OutParam";
                    paramValue = result.Outputs[0].ToString();
                    outParam = outParam + paramName + ":[" + paramValue + "] \r\n";
                }
                
                DateTime callTimeEnd = DateTime.Now;
                string introduction = Introduction.IsNull() ? input.MethodBase.ToString() : Introduction;
                //2.记录日志
                if (result.Exception != null) //判断异常并记录异常日志
                    WriteAppErrorLog(result.Exception);
                else //如果调用方法没有出现异常则记录操作日志 
                    WriteServiceCallLog(introduction, callTimeStart, callTimeEnd, inParam, outParam);
            }
            //返回方法，拦截结束
            return result;

        }

        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="ex"></param>
        private void WriteAppErrorLog(Exception ex)
        {
            ex.Data.Add("category", LogCategory.APP_ERROR);
            if (ex is FaultException)
            {
                FaultException fault = ex as FaultException;
                ex.Data.Add("errorCode", fault.ErrorCode);
                ex.Data.Add("errorMessage", fault.ErrorMsg);
            }
            else
            {
                ex.Data.Add("errorCode", "99999");
                ex.Data.Add("errorMessage", "未定义的异常及错误！");
            }

            CertificateResult certificateResult = CallContext.GetData("Certificate") as CertificateResult;
            ex.Data.Add("systemCode", certificateResult != null ? certificateResult.SystemCode : string.Empty);
            ex.Data.Add("orgCode", certificateResult != null ? certificateResult.OrgCode : string.Empty);

            bool rethrow = ExceptionPolicy.HandleException(ex, "Zysoft Exception Policy");
            if (rethrow)
                throw ex;
        }

        /// <summary>
        /// 记录调用日志
        /// </summary>
        /// <param name="callTimeStart"></param>
        /// <param name="callTimeEnd"></param>
        private void WriteServiceCallLog(string introduction, DateTime callTimeStart, DateTime callTimeEnd, string inParam, string outParam)
        {
            LogEntry log = new LogEntry();
            log.EventId = 100;
            log.Title = introduction;
            log.Categories.Add(LogCategory.METHOD_CALL);
            log.ExtendedProperties.Add("category", LogCategory.METHOD_CALL);
            log.ExtendedProperties.Add("Title", introduction);
            log.ExtendedProperties.Add("callTimeStart", callTimeStart.ToTimeString());
            log.ExtendedProperties.Add("callTimeEnd", callTimeEnd.ToTimeString());
            log.ExtendedProperties.Add("callInterval", (callTimeEnd - callTimeStart).TotalMilliseconds);
            //将输出的字符串中，要注意XML值是否需要符合XML文档规范
            log.ExtendedProperties.Add("inParam", inParam != null ? inParam : string.Empty);
            log.ExtendedProperties.Add("outParam", outParam != null ? outParam : string.Empty);
            Logger.Write(log);
        }
    }
}
