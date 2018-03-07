using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using Zysoft.FrameWork.Unity;
using Zysoft.ZyExternal.IBLL.His;

namespace Zysoft.ZyExternalMvc.WebServices
{
    /// <summary>
    /// WSDHCRis1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WSDHCRis : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region RIS系统的报告信息返回
        [WebMethod(Description = "RIS系统的报告信息返回")]
        public string ReportStatusInfo(string hisAppid, string affirmMan, string affirmDate, string status)
        {
            string outParm = "";
            IDHCRis dhCRis = ContainerFactory.GetContainer().Resolve<IDHCRis>();
            if (dhCRis.ReportStatusInfo(hisAppid, affirmMan, affirmDate, status, out outParm) < 0)
            {
                return outParm;
            }
            return "success";
        }
        #endregion
    }
}
