using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;





namespace Zysoft.ZyExternal.IBLL.His
{
    public interface INjpkSelfService
    {
         #region 2131 办卡
        /// <summary>
        /// 办卡
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        int CreateCardPatInfo2131(XmlDocument docRequestPre, out string outParm);
        #endregion
    }
}
