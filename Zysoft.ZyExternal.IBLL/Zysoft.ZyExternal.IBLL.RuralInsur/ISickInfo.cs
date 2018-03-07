using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scsoft.WeChat.Common.AOP;
using System.Xml;

namespace Scsoft.WeChat.IBLL.Sick
{         
    public interface ISickInfo
    {
        #region 2108 网络测试

        /// <summary>
        /// 2108 网络测试 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "2108 网络测试")]
        int NetTest2108(XmlDocument docRequest, out string outParm);
        #endregion
    }
}
