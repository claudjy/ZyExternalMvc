using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zysoft.ZyExternal.Common.AOP;

namespace Zysoft.ZyExternal.IBLL.His
{
    public interface IPreXuanchengCity
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

        #region 2113 通过身份证号， 获取病人的就诊卡信息
        /// <summary>
        /// 查询病人基本信息
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "2113 通过身份证号， 获取病人的就诊卡信息")]
        int GetSickCardByIdCard2113(XmlDocument docRequestPre, out string outParm);
        #endregion
        #region 1013 获取当前科室的所有医生列表
        /// <summary>
        /// 获取当前科室的所有医生列表(1013) 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "1013 获取当前科室的所有医生列表")]
        int GetDoctorInfo1013(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 1012 下载科室列表
        /// <summary>
        /// 1012 下载科室列表
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "1012 下载科室列表")]
        int GetDeptInfo1012(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 1004 获取排班信息
        /// <summary>
        /// 获取排班信息
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "1004 获取排班信息")]
        int GetWorkSchedule1004(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 2002 通过病人卡号， 反回病人预约列表
        /// <summary>
        /// 通过病人卡号， 反回病人预约列表 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns> 
        [Log(Introduction = "2002 通过病人卡号， 反回病人预约列表")]
        int GetSickQuene2002(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 2134 无卡建档
        /// <summary>
        /// 无卡建档
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = " 2134 无卡建档")]
        int CreatePatInfoNoCard2134(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 1051 预约排队(无卡)
        /// <summary>
        /// 预约排队(无卡)
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
         [Log(Introduction = "1051 预约排队(无卡)")]
        int SickQuene1051(XmlDocument docRequestPre, out string outParm);
        #endregion

        #region 1053 取消预约排队
        /// <summary>
        /// 取消预约排队(1053) 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
         int CancelSickQuene1053(XmlDocument docRequestPre, out string outParm);
        #endregion
    }
}
