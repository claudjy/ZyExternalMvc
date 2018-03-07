using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zysoft.ZyExternal.Common.AOP;

namespace Zysoft.ZyExternal.IBLL.His
{
    public interface IDHCRis
    {
        #region ReportStatusInfo 

        /// <summary>
        /// RIS系统的报告信息返回
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "RIS系统的报告信息返回")]
        int ReportStatusInfo(string hisAppid, string affirmMan, string affirmDate, string status, out string outParm);
        #endregion

    }
}
