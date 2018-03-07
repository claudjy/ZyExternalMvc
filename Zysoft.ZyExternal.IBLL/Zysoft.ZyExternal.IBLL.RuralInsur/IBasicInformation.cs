using System;
using System.Collections.Generic;
using System.Text;
using Zysoft.ZyExternal.Common.AOP;

namespace Zysoft.ZyExternal.IBLL.RuralInsur 
{
    public interface IBasicInformation
    {
        #region A001 获取病人信息函数获取病人信息函数
        /// <summary>
        /// A001 获取病人信息函数获取病人信息函数
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        [Log(Introduction = "A001 获取病人信息函数获取病人信息函数")]          
        string getPersonInfo(string rateType, string bookno);
        #endregion

        #region A002 获取医疗机构信息函数 getHospitalInfo
        /// <summary>
        /// A002 获取医疗机构信息函数 getHospitalInfo
        /// </summary>
        /// <param name="hospitalName"></param>
        /// <returns></returns>
        string getHospitalInfo(string hospitalName);
        #endregion

        #region A003 补偿类别字典下载redeemTypeDownLoad
        /// <summary>
        ///  A003 补偿类别字典下载redeemTypeDownLoad
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        string redeemTypeDownLoad(string rateType);
        #endregion

        #region A004 科室信息下载officeCodeDown
        /// <summary>
        /// A004 科室信息下载officeCodeDown
        /// </summary>
        /// <param name="rateType"></param>
        /// <returns></returns>
        string getOfficeCodeDown(string rateType);
        #endregion

        #region A005 治疗方式下载treatmentModeUpdate
        /// <summary>
        ///   A005 治疗方式下载treatmentModeUpdate
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        string treatmentModeUpdate(string rateType); 
        #endregion

        #region A006 上传/修改转诊单信息 uploadReferralsheet
        /// <summary>
        /// A006 上传/修改转诊单信息 uploadReferralsheet
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="infoType"></param>
        /// <param name="turnCode"></param>
        /// <param name="safetyNo"></param>
        /// <param name="idCardNo"></param>
        /// <param name="sickName"></param>
        /// <param name="birthday"></param>
        /// <param name="insurCardNo"></param>
        /// <param name="turnType"></param>
        /// <param name="icdCode"></param>
        /// <param name="icdName"></param>
        /// <param name="beginDate"></param>
        /// <param name="cityType"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        string uploadReferralsheet(string rateType, string infoType, string turnCode, string safetyNo,
                                  string idCardNo, string sickName, string sexName, string birthday, string insurCardNo,
                                  string phoneNo, string turnType, string icdCode, string icdName, string beginDate,
                                  string fromHospCode, string fromHospName, string toHospCode, string toHospName,
                                  string cityType, string toHospLevel,
                                  string remark);
        #endregion

        #region A007 转诊单信息撤销cancelReferralsheet
        /// <summary>
        /// A007 转诊单信息撤销cancelReferralsheet
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="turnCode"></param>
        /// <param name="safetyNo"></param>
        /// <returns></returns>
        string cancelReferralsheet(string rateType, string turnCode, string safetyNo);
        #endregion

        #region A008 转诊单信息查询 downloadReferralsheet
        /// <summary>
        /// A008 转诊单信息查询 downloadReferralsheet
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="operateType"></param>
        /// <param name="turnCode"></param>
        /// <param name="safetyNo"></param>
        /// <returns></returns>
        string downloadReferralsheet(string rateType, string inoutType, string turnCode, string safetyNo); 
        #endregion

        #region A009 获取医疗机构列表getHospitalInfo_New
        /// <summary>
        /// A009 获取医疗机构列表getHospitalInfo_New
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="lastTime"></param>
        /// <returns></returns>
        string getHospitalInfo_New(string rateType, string lastTime);
        #endregion

        #region  A101 匹配药品数据上传函数 matchUpdate
        /// <summary>
        /// A101 匹配药品数据上传函数 matchUpdate
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        string matchUpdate(string rateType, string insurancePriceItemCode, string itemCode, string itemName, string spec, string unit, string formName, string standardPrice);
        #endregion

        #region A102 药品匹配数据审核状态查询 matchSeek
        /// <summary>
        /// A102 药品匹配数据审核状态查询 matchSeek
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        string matchSeek(string rateType, string insurancePriceItemCode, string itemCode);
        #endregion

        #region A113 获取病人信息函数 getPersonInfo_New
        /// <summary>
        /// A113 获取病人信息函数 getPersonInfo_New
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        string getPersonInfo_New(string rateType, string centerCode, string cardNo);
        #endregion

    }
}
