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

        #region 008 住院预交金充值
        /// <summary>
        /// 008  住院预交金充值
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "住院预交金充值", Order = 1)]
        int RechargeZYAcount(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 009 院内帐户充值
        /// <summary>
        /// 009 院内帐户充值
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "院内帐户充值", Order = 1)]
        int hosAcctRecharge(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 010 根据挂号类型， 获取费用明细
        /// <summary>
        /// 010 根据挂号类型， 获取费用明细
        /// </summary>
        /// <param name="docRequest"></param> 
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "根据挂号类型， 获取费用明细", Order = 1)]
        int GetCurrentRegisterType(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 011 获取划价单接口
        /// <summary>
        /// 011 获取划价单接口
        /// </summary>
        /// <param name="docRequest"></param> 
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "011 获取划价单接口", Order = 1)]
        int getPreNosInfo(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 012 获取划价单明细接口
        /// <summary>
        /// 012 获取划价单明细接口
        /// </summary>
        /// <param name="docRequestPre"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        int GetPreNosDetailInfo(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 013 单张划价单缴费
        /// <summary>
        /// 013 单张划价单缴费
        /// </summary>
        /// <param name="docRequestPre"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        int SaveBillItems(XmlDocument docRequestPre, out string outParm);
        #endregion

    }
}
