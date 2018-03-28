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
        #region 000 网络测试

        /// <summary>
        /// 000 网络测试
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "2108 网络测试")]
        int NetTest2108(XmlDocument docRequest, out string outParm);
        #endregion

        #region 001 用户HIS信息注册
        /// <summary>
        /// 001 用户HIS信息注册
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "用户HIS信息注册")]
        int RegisterCtznCard(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 003 同步医生排班信息接口
        /// <summary>
        /// 判断自助机当前是否可挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "同步医生排班信息接口", Order = 0)]
        int getSchedueInfo(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 004 判断当前号别是否可挂号
        /// <summary>
        /// 004 判断当前号别是否可挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "判断当前号别是否可挂号", Order = 0)]
        int CanRegisterType(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 005 挂号
        /// <summary>
        /// 005 挂号
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "挂号", Order = 1)]
        int Register(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 006 预约
        /// <summary>
        /// 006  预约
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "预约", Order = 1)]
        int reservateConfirm(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 007 预约取消
        /// <summary>
        /// 007  取消预约
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "预约取消", Order = 1)]
        int reservateCancle(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 008 用户院内帐户充值
        /// <summary>
        /// 008  用户院内帐户充值
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "用户院内帐户充值", Order = 1)]
        int hosAcctRecharge(XmlDocument docRequestPre, out string outParm);
        #endregion
    }
}
