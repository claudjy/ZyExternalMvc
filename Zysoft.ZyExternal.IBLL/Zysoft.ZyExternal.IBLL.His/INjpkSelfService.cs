using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zysoft.ZyExternal.Common.AOP;





namespace Zysoft.ZyExternal.IBLL.His
{
    public interface INjpkSelfService
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

         #region 2131 办卡
        /// <summary>
        /// 办卡
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "2131 办卡")]
        int CreateCardPatInfo2131(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 同步医生排班信息接口
        /// <summary>
        /// 同步医生排班信息接口
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "同步医生排班信息接口", Order = 0)]
        int getSchedueInfo(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 2305 获取排班信息
        /// <summary>
        /// 2305 获取排班信息
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "判断当前号别是否可挂号", Order = 0)]
        int CanRegisterType(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 预约
        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "预约", Order = 1)]
        int reservateConfirm(XmlDocument docRequestPre, out string outParm);
        #endregion
        
        #region F  预约取消
        /// <summary>
        /// F  用户取消预约
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "预约取消", Order = 1)]
        int reservateCancle(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region D 挂号
        /// <summary>
        /// D 挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "挂号", Order = 1)]
        int Register(XmlDocument docRequestPre, out string outParm);
        #endregion
    }
}
