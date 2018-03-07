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


namespace Zysoft.ZyExternal.Common.AOP
{
    public class ServiceCallHandler : ICallHandler
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
        /// 构造方法
        /// 用于，接收从Attribute中传递过来的参数
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="order"></param>
        public ServiceCallHandler(string introduction, int order)
        {
            Introduction = introduction;
            Order = order;
        }

        /// <summary>
        /// 调用方法
        /// </summary>
        /// <param name="input"></param>
        /// <param name="getNext"></param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //1.证书
            CertificateResult certificateResult;
            for (int i = 0; i < input.Inputs.Count; i++)
            {
                ParameterInfo pi = input.Inputs.GetParameterInfo(i);
                if (pi.Name == "certificate" && pi.ParameterType == typeof(string)) //找到凭证参数
                {
                    string certificate = input.Inputs[i].ToString();
                    try
                    {
                        certificateResult = CertificateHelper.Verify(certificate);
                        CallContext.SetData("Certificate", certificateResult);
                    }
                    catch (Exception ex)
                    {
                        WriteAppErrorLog(ex);
                    }
                    break;
                }
            }
            
            //2.调用方法
            DateTime callTimeStart = DateTime.Now;
            var result = getNext().Invoke(input, getNext);
            DateTime callTimeEnd = DateTime.Now;
            string introduction = Introduction.IsNull() ? input.MethodBase.ToString() : Introduction;
            //2.记录日志
            if (result.Exception != null) //判断异常并记录异常日志
                WriteAppErrorLog(result.Exception);
            else //记录调用日志
                WriteServiceCallLog(introduction, callTimeStart, callTimeEnd);

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
        private void WriteServiceCallLog(string introduction, DateTime callTimeStart, DateTime callTimeEnd)
        {
            LogEntry log = new LogEntry();
            log.EventId = 100;
            log.Title = introduction;
            log.Categories.Add(LogCategory.SERVICE_CALL);
            log.ExtendedProperties.Add("category", LogCategory.SERVICE_CALL);
            log.ExtendedProperties.Add("callTimeStart", callTimeStart.ToTimeString());
            log.ExtendedProperties.Add("callTimeEnd", callTimeEnd.ToTimeString());
            log.ExtendedProperties.Add("callInterval", (callTimeEnd - callTimeStart).TotalMilliseconds);

            CertificateResult certificateResult = CallContext.GetData("Certificate") as CertificateResult;
            log.ExtendedProperties.Add("systemCode", certificateResult != null ? certificateResult.SystemCode : string.Empty);
            log.ExtendedProperties.Add("orgCode", certificateResult != null ? certificateResult.OrgCode : string.Empty);
            Logger.Write(log);
        }
    }
}
