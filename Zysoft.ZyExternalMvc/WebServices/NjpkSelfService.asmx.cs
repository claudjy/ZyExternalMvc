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

    }
}
