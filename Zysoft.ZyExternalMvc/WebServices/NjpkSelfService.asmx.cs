using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using Zysoft.FrameWork.Unity;
using Zysoft.ZyExternal.IBLL.His;
using Microsoft.Practices.Unity;



namespace Zysoft.ZyExternalMvc.WebServices
{
    /// <summary>
    /// NjpkSelfService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class NjpkSelfService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region 000 网络测试
        /// <summary>
        /// 000 网络测试
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "000 网络测试")]
        public string NetTest2108(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.NetTest2108(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 001 用户HIS信息注册
        /// <summary>
        /// 001 用户HIS信息注册
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "001 用户HIS信息注册")]
        public string RegisterCtznCard(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();

             
            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.RegisterCtznCard(docRequest, out outParm);

            return outParm;
        }
        #endregion
                
        #region 003 同步医生排班信息接口
        /// <summary>
        /// 003 医生排班视图 JKWY_VIEW_SCHEDULE
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "003 同步医生排班信息接口")]
        public string getSchedueInfo(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.getSchedueInfo(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 004 判断当前号别是否可挂号
        /// <summary>
        /// 判断当前号别是否可挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "004 判断当前号别是否可挂号")]
        public string CanRegisterType(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.CanRegisterType(docRequest, out outParm);

            return outParm;
        }
        #endregion
        
        #region 005 挂号
        /// <summary>
        /// 005 挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "005 挂号")]
        public string Register(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.Register(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 006 预约
        /// <summary>
        /// 006 预约
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "006 预约")]
        public string reservateConfirm(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.reservateConfirm(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 007  预约取消
        /// <summary>
        ///007  预约取消
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "007 预约取消")]
        public string reservateCancle(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.reservateCancle(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 008 用户院内帐户充值
        /// <summary>
        /// 008  用户院内帐户充值
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [WebMethod(Description = "008 用户院内帐户充值")]
        public string RechargeZYAcount(string InXml)
        {
            string outParm; 
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.RechargeZYAcount(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 009 院内帐户充值
        /// <summary>
        /// 009  院内帐户充值
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [WebMethod(Description = "009 院内帐户充值")]
        public string hosAcctRecharge(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.hosAcctRecharge(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 010 根据挂号类型， 获取费用明细
        /// <summary>
        /// 010 根据挂号类型， 获取费用明细
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [WebMethod(Description = "010 根据挂号类型， 获取费用明细")]
        public string GetCurrentRegisterType(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.GetCurrentRegisterType(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 011 获取划价单接口
        /// <summary>
        /// 011 获取划价单接口
        /// </summary>
        /// <param name="docRequest"></param> 
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [WebMethod(Description = "011 获取划价单接口")]
        public string getPreNosInfo(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.getPreNosInfo(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 012 获取划价单明细接口
        /// <summary>
        /// 012 获取划价单明细接口
        /// </summary>
        /// <param name="docRequestPre"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "012 获取划价单明细接口")]
        public string GetPreNosDetailInfo(string InXml)
        {
            string outParm; 
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.GetPreNosDetailInfo(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 013 单张划价单缴费
        /// <summary>
        /// 013 单张划价单缴费
        /// </summary>
        /// <param name="docRequestPre"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "013 单张划价单缴费")]
        public string SaveBillItems(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();


            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.SaveBillItems(docRequest, out outParm);

            return outParm;
        }
        #endregion



    }
}
