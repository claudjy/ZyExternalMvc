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

        #region 2131 办卡
        /// <summary>
        /// 办卡
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "2131 办卡")]
        public string RegisterCtznCard(string InXml)
        {
            string outParm;
            outParm = "";
            INjpkSelfService selfService = ContainerFactory.GetContainer().Resolve<INjpkSelfService>();

             
            XmlDocument docRequest = new XmlDocument();
            docRequest.LoadXml(InXml);

            selfService.CreateCardPatInfo2131(docRequest, out outParm);

            return outParm;
        }
        #endregion

        #region 2108 网络测试
        /// <summary>
        /// 2108 网络测试
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "2108 网络测试")]
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

        #region 判断当前号别是否可挂号
        /// <summary>
        /// 判断当前号别是否可挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "判断当前号别是否可挂号")]
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

        #region A 同步医生排班信息接口
        /// <summary>
        /// A 医生排班视图 JKWY_VIEW_SCHEDULE
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "同步医生排班信息接口")]
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
        
        #region D 挂号
        /// <summary>
        /// D 挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "挂号")]
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

        #region E 预约
        /// <summary>
        /// E 预约
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "预约")]
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

        #region F  预约取消
        /// <summary>
        ///F  预约取消
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [WebMethod(Description = "预约取消")]
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

    }
}
