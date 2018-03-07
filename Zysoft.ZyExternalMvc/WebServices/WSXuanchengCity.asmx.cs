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
    /// WSRuralInsur 的摘要说明 
    /// </summary>
    [WebService(Namespace = "http://www.zysoft.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WSXuanchengCity : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        #region 接口函数
        [WebMethod(Description = "接口函数")]
        public string WebBusiness(string TranCode, string InXml)
        {
            string strXML;
            string result = "";
            XmlDocument docRequest = new XmlDocument();
            strXML = "<?xml version=\"1.0\" encoding=\"gb2312\"?>" + InXml;
            docRequest.LoadXml(strXML);
            //门诊患者信息查询（C101）
            //预约科室查询（C301）
            //预约医生号源信息查询（C305）
            //预约医生号源号序信息查询（C306）
            //已预约信息查询（C307）
            //预约医生查询（全院）（C309）
            //首诊患者建档（B101）
            //门诊预约取消（B304）
            //门诊预约登记（B305）
            //3.交易处理
            switch (TranCode)
            {
                case "C001"://HIS网络测试接口
                    NetTest2108(docRequest, out result);
                    break;
                case "C101"://通过身份证号， 获取病人的就诊卡信息
                    GetSickCardByIdCard2113(docRequest, out result);
                    break;
                case "C301"://预约科室查询
                    GetDeptInfo1012(docRequest, out result);
                    break;
                case "C309"://预约医生查询（全院）
                    GetDoctorInfo1013(docRequest, out result);
                    break;
                case "C305"://获取排班信息
                    GetWorkSchedule1004(docRequest, out result);
                    break;
                case "B101"://无卡建档
                    CreatePatInfoNoCard2134(docRequest, out result);
                    break;
                case "B305"://预约排队(无卡)
                    SickQuene1051(docRequest, out result);
                    break;
                case "C307":// 通过病人卡号， 反回病人预约列表
                    GetSickQuene2002(docRequest, out result);
                    break;
                case "B304":// 取消预约排队
                    CancelSickQuene1053(docRequest, out result);
                    break;
            }
            return result;
        }

       
        #endregion

        #region 2108 网络测试
        /// <summary>
        /// 2108 网络测试
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        private int NetTest2108(XmlDocument docRequest, out string outParm)
        {
            IPreXuanchengCity preXuanchengCity = ContainerFactory.GetContainer().Resolve<IPreXuanchengCity>();
            return preXuanchengCity.NetTest2108(docRequest, out outParm);
        }
        #endregion

        #region 2113 通过身份证号， 获取病人的就诊卡信息
        /// <summary>
        /// 2113 通过身份证号， 获取病人的就诊卡信息
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        private int GetSickCardByIdCard2113(XmlDocument docRequest, out string outParm)
        {
            IPreXuanchengCity preXuanchengCity = ContainerFactory.GetContainer().Resolve<IPreXuanchengCity>();
            return preXuanchengCity.GetSickCardByIdCard2113(docRequest, out outParm);
        }
        #endregion

        #region 1012 下载科室列表
        /// <summary>
        /// 1012 下载科室列表
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        private int GetDeptInfo1012(XmlDocument docRequest, out string outParm)
        {
            IPreXuanchengCity preXuanchengCity = ContainerFactory.GetContainer().Resolve<IPreXuanchengCity>();
            return preXuanchengCity.GetDeptInfo1012(docRequest, out outParm);
        }
        #endregion

        #region 1012 下载科室列表
        /// <summary>
        /// 1012 下载科室列表
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        private int GetDoctorInfo1013(XmlDocument docRequest, out string outParm)
        {
            IPreXuanchengCity preXuanchengCity = ContainerFactory.GetContainer().Resolve<IPreXuanchengCity>();
            return preXuanchengCity.GetDoctorInfo1013(docRequest, out outParm);
        }
        #endregion

        #region 1004 获取排班信息
        /// <summary>
        /// 获取排班信息
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        private int GetWorkSchedule1004(XmlDocument docRequest, out string outParm)
        {
            IPreXuanchengCity preXuanchengCity = ContainerFactory.GetContainer().Resolve<IPreXuanchengCity>();
            return preXuanchengCity.GetWorkSchedule1004(docRequest, out outParm);
        }
        #endregion

        #region 2134 无卡建档
        /// <summary>
        /// 无卡建档
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        private int CreatePatInfoNoCard2134(XmlDocument docRequest, out string outParm)
        {
            IPreXuanchengCity preXuanchengCity = ContainerFactory.GetContainer().Resolve<IPreXuanchengCity>();
            return preXuanchengCity.CreatePatInfoNoCard2134(docRequest, out outParm);
        }
        #endregion

        #region 1051 预约排队(无卡)
        /// <summary>
        /// 预约排队(无卡)
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param> 
        /// <returns></returns>
        private int SickQuene1051(XmlDocument docRequest, out string outParm)
        {
            IPreXuanchengCity preXuanchengCity = ContainerFactory.GetContainer().Resolve<IPreXuanchengCity>();
            return preXuanchengCity.SickQuene1051(docRequest, out outParm);
        }
        #endregion

        #region 2002 通过病人卡号， 反回病人预约列表
        /// <summary>
        /// 通过病人卡号， 反回病人预约列表 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        private int GetSickQuene2002(XmlDocument docRequest, out string outParm)
        {
            IPreXuanchengCity preXuanchengCity = ContainerFactory.GetContainer().Resolve<IPreXuanchengCity>();
            return preXuanchengCity.GetSickQuene2002(docRequest, out outParm);
        }
        #endregion

        #region 1053 取消预约排队
        /// <summary>
        /// 取消预约排队(1053) 
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        private int CancelSickQuene1053(XmlDocument docRequest, out string outParm)
        {
            IPreXuanchengCity preXuanchengCity = ContainerFactory.GetContainer().Resolve<IPreXuanchengCity>();
            return preXuanchengCity.CancelSickQuene1053(docRequest, out outParm);
        }
        #endregion

    }
}
