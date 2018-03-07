using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zysoft.FrameWork;
using Zysoft.FrameWork.Database;
using Zysoft.FrameWork.WebService;
using Zysoft.FrameWork.XML;
using Zysoft.ZyExternal.DAL.Common;

namespace Zysoft.ZyExternal.DAL.RuralInsur
{
    public class RuralResiDAL : DB
    {

        #region 调用外部webservice
        private int getRuralLoginInfo(string rateType, out string serviceUrl)
        {
            serviceUrl = "";

            StringBuilder sSql = new StringBuilder();
            sSql.Clear();
            sSql.Append(@"select * from hospital_vs_center_config where rate_type = :arg_rate_type");
            OracleParameter[] paraCenterConfig = { new OracleParameter("arg_rate_type", rateType) };
            DataTable dtCenterConfig = Select(sSql.ToString(), paraCenterConfig, "CenterConfig");
            if (dtCenterConfig.Rows.Count == 0)
            {
                return 0;
            }
            serviceUrl = dtCenterConfig.Rows[0]["CENTER_URL"].ToString().Trim();
            return 0;
        }
        private int tradeDataWebService(string rateType, string methodName, object[] obj, out string outPara)
        {
            string machineSvrId, serviceURL;
            UtilityDAL utilityDal = new UtilityDAL();
            machineSvrId = utilityDal.GetSysParm("machine_svr_id");
            serviceURL = "";
            getRuralLoginInfo(rateType, out serviceURL);
            
            if (serviceURL.IsNull())
            {
                outPara = "农合IP地址为空，不能进行操作！";
                return -1;
            }
            string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
            InvokeWebservice GetWebServiceMethod = new InvokeWebservice(serviceURL, @namespace, "GetPres");

            try
            {
                outPara = GetWebServiceMethod.GetWebserviceMethodData<string>(methodName, obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }
        #endregion

        #region B002 住院登记（扩展函数）
        /// <summary>
        /// B002 住院登记（扩展函数）
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="residenceNo"></param>
        /// <param name="bookNo"></param>
        /// <param name="safetyNo"></param>
        /// <param name="diagnosisCode"></param>
        /// <param name="diagnosisCode2"></param>
        /// <param name="admissionDept"></param>
        /// <param name="admissionTime"></param>
        /// <param name="registType"></param>
        /// <param name="admissionCondition"></param>
        /// <param name="doctor"></param>
        /// <param name="bedNo"></param>
        /// <param name="ward"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int inpatientRegister(string rateType, string centerCodeEx, string residenceNo, string bookNo, string safetyNo,
            string diagnosisCode, string diagnosisCode2, string admissionDept,
            string admissionTime, string registType, string admissionCondition, string doctor, string bedNo, string ward,
            string turnCode, out string outParm)
        {
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();


            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化
                StringBuilder sql = new StringBuilder();

                string operater, password, softwareFactory;
                string hospitalCode;
                string centerCode;
                string centerName, organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion

                string name, countryTeamCode, familyNo;
                string sex, idCardNo, age;
                string turnMode;

                sql.Clear();
                sql.Append(@"
                select trim(book_no) book_no,trim(member_no) member_no,trim(name) name,trim(country_team_code) country_team_code,
                       trim(family_sysno) family_sysno, trim(sex) sex,trim(id_cardno) id_cardno,trim(age) age
                  from family_member_record
	             where member_no = :as_member_no
                   and book_no = :arg_book_no");
                OracleParameter[] paraFamilyRecord = { new OracleParameter("as_member_no", safetyNo),
                                                     new OracleParameter("arg_book_no", bookNo)};
                DataTable dtFamilyRecord = Select(sql.ToString(), paraFamilyRecord, "FamilyRecord");
                if (dtFamilyRecord.Rows.Count == 0)
                {
                    outParm = "his获取成员信息失败！";
                    return -1;
                }
                bookNo = dtFamilyRecord.Rows[0]["book_no"].ToString().Trim();
                name = dtFamilyRecord.Rows[0]["name"].ToString().Trim();
                countryTeamCode = dtFamilyRecord.Rows[0]["country_team_code"].ToString().Trim();
                familyNo = dtFamilyRecord.Rows[0]["family_sysno"].ToString().Trim();
                sex = dtFamilyRecord.Rows[0]["sex"].ToString().Trim();
                idCardNo = dtFamilyRecord.Rows[0]["id_cardno"].ToString().Trim();
                age = dtFamilyRecord.Rows[0]["age"].ToString().Trim();

                if (residenceNo.IsNull())
                {
                    paraName = "本院信院号";
                    goto ErrorReturn;
                }
                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (safetyNo.IsNull())
                {
                    paraName = "个人编号";
                    goto ErrorReturn;
                }

                if (familyNo.IsNull())
                {
                    paraName = "家庭编号";
                    goto ErrorReturn;
                }

                if (diagnosisCode.IsNull())
                {
                    paraName = "农合诊断";
                    goto ErrorReturn;
                }

                if (admissionDept.IsNull())
                {
                    paraName = "就诊科室";
                    goto ErrorReturn;
                }

                if (admissionTime.IsNull())
                {
                    paraName = "就诊时间";
                    goto ErrorReturn;
                }

                if (doctor.IsNull())
                {
                    paraName = "经治医生";
                    goto ErrorReturn;
                }

                if (diagnosisCode2.IsNull()) diagnosisCode2 = "";
                if (bedNo.IsNull()) bedNo = "";
                if (ward.IsNull()) ward = "";
                if (turnCode.IsNull())
                {
                    turnMode = "0";
                    turnCode = "";
                }
                else
                {
                    turnMode = "1";
                }

                if (registType == "0")
                {
                    registType = "1";
                }
                else
                {
                    registType = "2";
                }
                switch (admissionCondition)
                {
                    case "1":
                    case "2":
                    case "3":
                        break;
                    default:
                        admissionCondition = "9";
                        break;
                }



                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                residenceNo = Base64.EncodingString(residenceNo);
                safetyNo = Base64.EncodingString(safetyNo);
                familyNo = Base64.EncodingString(familyNo);
                diagnosisCode = Base64.EncodingString(diagnosisCode);
                diagnosisCode2 = Base64.EncodingString(diagnosisCode2);
                admissionDept = Base64.EncodingString(admissionDept);
                registType = Base64.EncodingString(registType);
                admissionCondition = Base64.EncodingString(admissionCondition);
                doctor = Base64.EncodingString(doctor);
                bedNo = Base64.EncodingString(bedNo);
                ward = Base64.EncodingString(ward);
                admissionTime = Base64.EncodingString(admissionTime);
                turnMode = Base64.EncodingString(turnMode);
                turnCode = Base64.EncodingString(turnCode);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                inpatientRegisterResult inpRegisterResult;

                string inPara;
                inPara = "redeemWebService.inpatientRegister(" + operater + "," + password + "," + hospitalCode + "," + residenceNo + "," + centerCode + ", ";
                inPara += "                                " + familyNo + "," + safetyNo + ", \" \", \" \", " + diagnosisCode + "," + diagnosisCode2 + ", \" \",";
                inPara += "                                \" \"," + admissionDept + "," + admissionTime + "," + registType + ", \" \"," + admissionCondition + "," + doctor + "," + bedNo + ",";
                inPara += "                                 " + ward + "," + turnMode + "," + turnCode + ", \" \", \"\", \"\", \"\", \"\",";
                inPara += "                                  \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inPara);
                inpRegisterResult = redeemWebService.inpatientRegister(operater, password, hospitalCode, residenceNo, centerCode,
                                                                            familyNo, safetyNo, "", "", diagnosisCode, diagnosisCode2, "",
                                                                            "", admissionDept, admissionTime, registType, "", admissionCondition, doctor, bedNo,
                                                                             ward, turnMode, turnCode, "", "", "", "", "",
                                                                            "", "", "", "");
                if (inpRegisterResult.obligateOne.IsNull()) inpRegisterResult.obligateOne = "";
                if (inpRegisterResult.obligateTwo.IsNull()) inpRegisterResult.obligateTwo = "";
                if (inpRegisterResult.obligateThree.IsNull()) inpRegisterResult.obligateThree = "";
                if (inpRegisterResult.obligateFour.IsNull()) inpRegisterResult.obligateFour = "";
                if (inpRegisterResult.obligateFive.IsNull()) inpRegisterResult.obligateFive = "";
                inpRegisterResult.inpatientSn = Base64.DecodingString(inpRegisterResult.inpatientSn);
                inpRegisterResult.obligateOne = Base64.DecodingString(inpRegisterResult.obligateOne);
                inpRegisterResult.obligateTwo = Base64.DecodingString(inpRegisterResult.obligateTwo);
                inpRegisterResult.obligateThree = Base64.DecodingString(inpRegisterResult.obligateThree);
                inpRegisterResult.obligateFour = Base64.DecodingString(inpRegisterResult.obligateFour);
                inpRegisterResult.obligateFive = Base64.DecodingString(inpRegisterResult.obligateFive);

                outParm = inpRegisterResult.inpatientSn + "|" + inpRegisterResult.obligateOne + "|" + inpRegisterResult.obligateTwo + "|" +
                    inpRegisterResult.obligateThree + "|" + inpRegisterResult.obligateFour + "|" + inpRegisterResult.obligateFive + "|" +
                     "|";
                Log4NetHelper.Info(outParm);

            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B002 住院登记（扩展函数）", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B003 取消住院登记（扩展函数）cancelInpatientRegister
        /// <summary>
        /// B003 取消住院登记（扩展函数）cancelInpatientRegister
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int cancelInpatientRegister(string rateType, string centerCodeEx, string insuranceNo, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;
            paraName = serviceURL = "";

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化
                StringBuilder sql = new StringBuilder();

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode,
                    out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion


                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (insuranceNo.IsNull())
                {
                    paraName = "农合登记号";
                    goto ErrorReturn;
                }
                string inParm;
                inParm = "redeemWebService.cancelInpatientRegister(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + ", \"\", " + centerCode + ", \"\", \"\", \"\", \"\")";

                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                insuranceNo = Base64.EncodingString(insuranceNo);
                centerCode = Base64.EncodingString(centerCode);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                cancelInpatientRegisterResult cancelInpRegisterResult;

                inParm = "redeemWebService.cancelInpatientRegister(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + ", \"\", " + centerCode + ", \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inParm);
                cancelInpRegisterResult = redeemWebService.cancelInpatientRegister(operater, password, hospitalCode, insuranceNo, "", centerCode, "", "", "", "");
                if (cancelInpRegisterResult.sign.IsNull()) cancelInpRegisterResult.sign = "";
                if (cancelInpRegisterResult.obligateOne.IsNull()) cancelInpRegisterResult.obligateOne = "";
                if (cancelInpRegisterResult.obligateTwo.IsNull()) cancelInpRegisterResult.obligateTwo = "";
                if (cancelInpRegisterResult.obligateThree.IsNull()) cancelInpRegisterResult.obligateThree = "";
                if (cancelInpRegisterResult.obligateFour.IsNull()) cancelInpRegisterResult.obligateFour = "";
                if (cancelInpRegisterResult.obligateFive.IsNull()) cancelInpRegisterResult.obligateFive = "";
                cancelInpRegisterResult.sign = Base64.DecodingString(cancelInpRegisterResult.sign);
                cancelInpRegisterResult.obligateOne = Base64.DecodingString(cancelInpRegisterResult.obligateOne);
                cancelInpRegisterResult.obligateTwo = Base64.DecodingString(cancelInpRegisterResult.obligateTwo);
                cancelInpRegisterResult.obligateThree = Base64.DecodingString(cancelInpRegisterResult.obligateThree);
                cancelInpRegisterResult.obligateFour = Base64.DecodingString(cancelInpRegisterResult.obligateFour);
                cancelInpRegisterResult.obligateFive = Base64.DecodingString(cancelInpRegisterResult.obligateFive);

                outParm = cancelInpRegisterResult.obligateOne + "|" + cancelInpRegisterResult.obligateTwo + "|" + cancelInpRegisterResult.obligateThree + "|" +
                    cancelInpRegisterResult.obligateFour + "|" + cancelInpRegisterResult.obligateFive + "|";
                switch (cancelInpRegisterResult.sign)
                {
                    case "0":
                        cancelInpRegisterResult.sign = "操作失败";
                        outParm = cancelInpRegisterResult.sign + "|" + outParm;
                        Log4NetHelper.Info(outParm);
                        return -1;
                    case "1":
                        cancelInpRegisterResult.sign = "操作成功";
                        outParm = cancelInpRegisterResult.sign + "|" + outParm;
                        Log4NetHelper.Info(outParm);
                        return 0;
                    case "9":
                        cancelInpRegisterResult.sign = "未找到对应住院登记信息";
                        outParm = cancelInpRegisterResult.sign + "|" + outParm;
                        Log4NetHelper.Info(outParm);
                        return -1;
                    default:
                        cancelInpRegisterResult.sign = "未知操作失败";
                        outParm = cancelInpRegisterResult.sign + "|" + outParm;
                        Log4NetHelper.Info(outParm);
                        return -1;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B003 取消住院登记（扩展函数）", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B004 住院登记查询（扩展函数）inpatientRegisterSeek
        /// <summary>
        /// B004 住院登记查询（扩展函数）inpatientRegisterSeek
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="residenceNo"></param>
        /// <param name="safetyNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int inpatientRegisterSeek(string rateType, string centerCodeEx, string residenceNo, string safetyNo, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode,
                    out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion

                if (residenceNo.IsNull())
                {
                    paraName = "本院信院号";
                    goto ErrorReturn;
                }
                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (safetyNo.IsNull())
                {
                    paraName = "个人编号";
                    goto ErrorReturn;
                }

                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                residenceNo = Base64.EncodingString(residenceNo);
                safetyNo = Base64.EncodingString(safetyNo);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                inpatientRegisterSeekResult inpRegisterResult;

                string inParm;
                inParm = "inpRegisterResult = redeemWebService.inpatientRegisterSeek(" + operater + "," + password + "," + hospitalCode + ",";
                inParm += "        " + safetyNo + "," + centerCode + "," + residenceNo + ", \"\", \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inParm);
                inpRegisterResult = redeemWebService.inpatientRegisterSeek(operater, password, hospitalCode,
                                                                   safetyNo, centerCode, residenceNo, "", "", "", "", "");



                if (inpRegisterResult.obligateOne.IsNull()) inpRegisterResult.obligateOne = "";
                if (inpRegisterResult.obligateTwo.IsNull()) inpRegisterResult.obligateTwo = "";
                if (inpRegisterResult.obligateThree.IsNull()) inpRegisterResult.obligateThree = "";
                if (inpRegisterResult.obligateFour.IsNull()) inpRegisterResult.obligateFour = "";
                if (inpRegisterResult.obligateFive.IsNull()) inpRegisterResult.obligateFive = "";
                inpRegisterResult.inpatientSn = Base64.DecodingString(inpRegisterResult.inpatientSn);
                inpRegisterResult.obligateOne = Base64.DecodingString(inpRegisterResult.obligateOne);
                inpRegisterResult.obligateTwo = Base64.DecodingString(inpRegisterResult.obligateTwo);
                inpRegisterResult.obligateThree = Base64.DecodingString(inpRegisterResult.obligateThree);
                inpRegisterResult.obligateFour = Base64.DecodingString(inpRegisterResult.obligateFour);
                inpRegisterResult.obligateFive = Base64.DecodingString(inpRegisterResult.obligateFive);

                outParm = inpRegisterResult.inpatientSn + "|" + inpRegisterResult.obligateOne + "|" + inpRegisterResult.obligateTwo + "|" +
                    inpRegisterResult.obligateThree + "|" + inpRegisterResult.obligateFour + "|" + inpRegisterResult.obligateFive + "|";
                Log4NetHelper.Info(outParm);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B004 住院登记查询（扩展函数）inpatientRegisterSeek", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B005 住院费用明细录入函数inpDetailInput
        /// <summary>
        /// B005 住院费用明细录入函数inpDetailInput
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="applyNo"></param>
        /// <param name="hiscode"></param>
        /// <param name="insureId"></param>
        /// <param name="classId"></param>
        /// <param name="name"></param>
        /// <param name="spec"></param>
        /// <param name="unit"></param>
        /// <param name="conf"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <param name="money"></param>
        /// <param name="factMoney"></param>
        /// <param name="useDate"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int inpDetailInput(string rateType, string centerCodeEx, string insuranceNo,
                   string applyNo, string hiscode, string insureId,
                   string classId, string name, string spec, string unit, string conf, string price,
                   string quantity, string money, string factMoney, string useDate, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode;
                string centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode,
                    out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion



                if (insuranceNo.IsNull())
                {
                    paraName = "农合住院号";
                    goto ErrorReturn;
                }
                if (applyNo.IsNull())
                {
                    paraName = "住院处方流水号";
                    goto ErrorReturn;
                }
                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (hiscode.IsNull())
                {
                    paraName = "HIS药品编码";
                    goto ErrorReturn;
                }

                if (insureId.IsNull())
                {
                    paraName = "HIS农合药品编码";
                    goto ErrorReturn;
                }

                if (classId.IsNull())
                {
                    paraName = "HIS农合费用分类代码";
                    goto ErrorReturn;
                }

                if (name.IsNull())
                {
                    paraName = "HIS药品名称";
                    goto ErrorReturn;
                }

                if (spec.IsNull())
                {
                    paraName = "HIS药品规格";
                    goto ErrorReturn;
                }

                if (unit.IsNull())
                {
                    paraName = "HIS药品单位";
                    goto ErrorReturn;
                }

                if (conf.IsNull())
                {
                    paraName = "HIS药品剂型";
                    goto ErrorReturn;
                }

                if (price.IsNull())
                {
                    paraName = "HIS药品单价";
                    goto ErrorReturn;
                }

                if (quantity.IsNull())
                {
                    paraName = "HIS药品数量";
                    goto ErrorReturn;
                }

                if (money.IsNull())
                {
                    paraName = "金额";
                    goto ErrorReturn;
                }

                if (factMoney.IsNull())
                {
                    paraName = "实收金额";
                    goto ErrorReturn;
                }

                if (useDate.IsNull())
                {
                    paraName = "使用日期";
                    goto ErrorReturn;
                }
                string opType = "1";
                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                opType = Base64.EncodingString(opType);
                insuranceNo = Base64.EncodingString(insuranceNo);
                applyNo = Base64.EncodingString(applyNo);
                hiscode = Base64.EncodingString(hiscode);
                insureId = Base64.EncodingString(insureId);
                classId = Base64.EncodingString(classId);
                name = Base64.EncodingString(name);
                spec = Base64.EncodingString(spec);
                unit = Base64.EncodingString(unit);
                conf = Base64.EncodingString(conf);
                price = Base64.EncodingString(price);
                quantity = Base64.EncodingString(quantity);
                money = Base64.EncodingString(money);
                factMoney = Base64.EncodingString(factMoney);
                useDate = Base64.EncodingString(useDate);


                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;

                string inParm;
                inParm = "redeemWebService.inpDetailInput(" + opType + "," + insuranceNo + "," + centerCode + "," + applyNo + ", \"\"," + hiscode + "," + insureId + ", ";
                inParm += "                              " + classId + "," + name + "," + spec + "," + unit + "," + conf + "," + price + ",";
                inParm += "                             " + quantity + "," + money + "," + factMoney + "," + useDate + ", \"\", \"\")";
                Log4NetHelper.Info(inParm);
                string inpDetailResult = redeemWebService.inpDetailInput(opType, insuranceNo, centerCode, applyNo, "", hiscode, insureId,
                                                                                        classId, name, spec, unit, conf, price,
                                                                                        quantity, money, factMoney, useDate, "", "");


                if (inpDetailResult.IsNull()) inpDetailResult = "";
                inpDetailResult = Base64.DecodingString(inpDetailResult);

                outParm = inpDetailResult;
                Log4NetHelper.Info(outParm);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B005 住院费用明细录入函数inpDetailInput", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region  B006 住院所有明细取消函数inpCancelFee
        /// <summary>
        ///  B006 住院所有明细取消函数inpCancelFee
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int inpCancelFee(string rateType, string centerCodeEx, string insuranceNo, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion



                if (insuranceNo.IsNull())
                {
                    paraName = "农合住院号";
                    goto ErrorReturn;
                }

                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                insuranceNo = Base64.EncodingString(insuranceNo);


                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                string inParm;
                inParm = "redeemWebService.inpCancelFee(" + insuranceNo + "," + centerCode + ")";
                Log4NetHelper.Info(inParm);
                redeemWebService.inpCancelFee(insuranceNo, centerCode);


            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B006 住院所有明细取消函数inpCancelFee", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B007 住院批量费用明细录入函数（扩展函数）uploadInpatientDetails
        /// <summary>
        /// B007 住院批量费用明细录入函数（扩展函数）uploadInpatientDetails
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="sickId"></param>
        /// <param name="residenceNo"></param>
        /// <param name="rowCount"></param>
        /// <param name="xmlDetails"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int uploadInpatientDetails(string rateType, string centerCodeEx, string sickId,
            string residenceNo, string rowCount,
            string xmlDetails, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion
                string insuranceNo, insuranceCardNo, safetyNo, sickName;
                string familyNo;
                StringBuilder sql = new StringBuilder();
                sql.Clear();
                sql.Append(@"select * from sick_visit_info a  where sick_id = :arg_sick_id and residence_no = :arg_residence_no");
                OracleParameter[] paraVisitInfo = { new OracleParameter("arg_sick_id", sickId),
                                                            new OracleParameter("arg_residence_no",residenceNo)};
                DataTable dtVisitInfo = Select(sql.ToString(), paraVisitInfo, "VisitInfo");
                if (dtVisitInfo.Rows.Count == 0)
                {
                    outParm = "当前病人信息有误！";
                    return -1;
                }
                insuranceNo = dtVisitInfo.Rows[0]["insurance_no"].ToString();
                insuranceCardNo = dtVisitInfo.Rows[0]["insurance_card_no"].ToString();//BOOK_NO
                safetyNo = dtVisitInfo.Rows[0]["safety_no"].ToString();
                sickName = dtVisitInfo.Rows[0]["sick_name"].ToString();

                sql.Clear();
                sql.Append(@"select * from family_member_record a  where book_no = :arg_book_no and member_no = :arg_member_no");
                OracleParameter[] paraMemberRecord = { new OracleParameter("arg_book_no",insuranceCardNo ),
                                                            new OracleParameter("arg_member_no",safetyNo)};
                DataTable dtMemberRecord = Select(sql.ToString(), paraMemberRecord, "MemberRecord");
                if (dtMemberRecord.Rows.Count == 0)
                {
                    outParm = "当前病人家庭信息有误！";
                    return -1;
                }
                familyNo = dtMemberRecord.Rows[0]["family_sysno"].ToString();
                if (rowCount.IsNull()) rowCount = "0";
                if (long.Parse(rowCount) == 0) return 0; //没有数据就不进行传输
                string xml;
                XmlDocument docRequest = new XmlDocument();
                xml = "<?xml version=\"1.0\" encoding=\"GBK\"?>";
                xml += @"<business> 
                                <basic>
                                    <loginName>hnty</loginName> 
		                                <hospitalNo>21</hospitalNo> 
		                                <centerNo>4304210001</centerNo> 
	                                    <bookNo>43042100231217</bookNo> 
	                                    <name>李天</name> 
	                                    <familyNo>43042100231217</familyNo> 
	                                    <memberNo>4304210023121702</memberNo>
	                                    <inpatientSn>5621</inpatientSn> 
	                                    <rows>10</rows> 
                                    </basic>
                                <details></details>
                            </business>";
                docRequest.LoadXml(xml);
                XmlNode ndBasic = docRequest.SelectSingleNode("/business/basic");
                XmlNode nddetails = docRequest.SelectSingleNode("/business/details");

                XmlDocument docDetails = new XmlDocument();
                docDetails.LoadXml(xmlDetails);
                nddetails.InnerXml = docDetails.SelectSingleNode("details").InnerXml;

                if (insuranceNo.IsNull())
                {
                    paraName = "农合住院号";
                    goto ErrorReturn;
                }
                if (insuranceCardNo.IsNull())
                {
                    paraName = "医疗证卡号";
                    goto ErrorReturn;
                }
                if (safetyNo.IsNull())
                {
                    paraName = "个人编号";
                    goto ErrorReturn;
                }
                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (sickName.IsNull())
                {
                    paraName = "患者姓名";
                    goto ErrorReturn;
                }

                if (familyNo.IsNull())
                {
                    paraName = "家庭编号";
                    goto ErrorReturn;
                }

                if (familyNo.IsNull())
                {
                    paraName = "家庭编号";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (rowCount.IsNull())
                {
                    paraName = "记录数";
                    goto ErrorReturn;
                }


                ndBasic.SelectSingleNode("loginName").InnerText = operater;
                ndBasic.SelectSingleNode("hospitalNo").InnerText = hospitalCode;
                ndBasic.SelectSingleNode("centerNo").InnerText = centerCode;
                ndBasic.SelectSingleNode("bookNo").InnerText = insuranceCardNo;
                ndBasic.SelectSingleNode("name").InnerText = sickName;
                ndBasic.SelectSingleNode("familyNo").InnerText = familyNo;
                ndBasic.SelectSingleNode("memberNo").InnerText = safetyNo;
                ndBasic.SelectSingleNode("inpatientSn").InnerText = insuranceNo;
                ndBasic.SelectSingleNode("rows").InnerText = rowCount;

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                xml = docRequest.OuterXml;
                Log4NetHelper.Info(xml);
                xml = Base64.EncodingString(xml);

                string inParm;
                inParm = "redeemWebService.uploadInpatientDetails(" + xml + ")";
                Log4NetHelper.Info(inParm);

                string inpDetailsResult = redeemWebService.uploadInpatientDetails(xml);

                if (inpDetailsResult.IsNull()) inpDetailsResult = "";
                inpDetailsResult = Base64.DecodingString(inpDetailsResult);

                outParm = inpDetailsResult;
                Log4NetHelper.Info(outParm);

            }
            catch (Exception ex)
            {
                Log4NetHelper.Error(" B007 住院批量费用明细录入函数（扩展函数）", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B008 出院登记（扩展函数）leaveInpatientRegister
        /// <summary>
        /// B008 出院登记（扩展函数）leaveInpatientRegister
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="dischargeTime"></param>
        /// <param name="outDept"></param>
        /// <param name="diseaseStatus"></param>
        /// <param name="diagnosisCode"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int leaveInpatientRegister(string rateType, string centerCodeEx, string insuranceNo,
                                          string dischargeTime, string outDept, string doctorName, string doctorId,
                                          string diseaseStatus, string diagnosisCode, string treatCode, string turnCode,
                                          out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion

                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (insuranceNo.IsNull())
                {
                    paraName = "医保住院号";
                    goto ErrorReturn;
                }

                if (dischargeTime.IsNull())
                {
                    paraName = "出院日期";
                    goto ErrorReturn;
                }

                if (outDept.IsNull())
                {
                    paraName = "出院科室";
                    goto ErrorReturn;
                }

                if (doctorName.IsNull())
                {
                    paraName = "主管医生";
                    goto ErrorReturn;
                }

                if (doctorId.IsNull())
                {
                    paraName = "主管医生ID";
                    goto ErrorReturn;
                }


                if (diseaseStatus.IsNull())
                {
                    paraName = "出院状态";
                    goto ErrorReturn;
                }

                if (diagnosisCode.IsNull())
                {
                    paraName = "出院诊断";
                    goto ErrorReturn;
                }

                string turnMode;
                if (turnCode.IsNull())
                {
                    turnMode = "0";
                    turnCode = "";
                }
                else
                {
                    turnMode = "1";
                }

                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                insuranceNo = Base64.EncodingString(insuranceNo);
                dischargeTime = Base64.EncodingString(dischargeTime);
                outDept = Base64.EncodingString(outDept);
                diseaseStatus = Base64.EncodingString(diseaseStatus);
                diagnosisCode = Base64.EncodingString(diagnosisCode);
                treatCode = Base64.EncodingString(treatCode);
                turnMode = Base64.EncodingString(turnMode);
                turnCode = Base64.EncodingString(turnCode);
                doctorName = Base64.EncodingString(doctorName);
                doctorId = Base64.EncodingString(doctorId);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                leaveInpatientRegisterResult inpLeaveResult;

                string inParm;
                inParm = @"
                redeemWebService.leaveInpatientRegister(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + "," + dischargeTime + "," + outDept + ",";
                inParm += "                       " + diseaseStatus + "," + diagnosisCode + "," + turnMode + "," + turnCode + ", \"\"," +
                                                "," + centerCode + ", " + doctorName + ", " + doctorId + ", \"\", \"\")";
                Log4NetHelper.Info(inParm);
                inpLeaveResult = redeemWebService.leaveInpatientRegister(operater, password, hospitalCode, insuranceNo, dischargeTime, outDept,
                                                                         diseaseStatus, diagnosisCode, treatCode, turnMode, turnCode, "",
                                                                         centerCode, doctorName, doctorId, "", "");


                if (inpLeaveResult.obligateOne.IsNull()) inpLeaveResult.obligateOne = "";
                if (inpLeaveResult.obligateTwo.IsNull()) inpLeaveResult.obligateTwo = "";
                if (inpLeaveResult.obligateThree.IsNull()) inpLeaveResult.obligateThree = "";
                if (inpLeaveResult.obligateFour.IsNull()) inpLeaveResult.obligateFour = "";
                if (inpLeaveResult.obligateFive.IsNull()) inpLeaveResult.obligateFive = "";
                if (inpLeaveResult.totalCosts.IsNull()) inpLeaveResult.totalCosts = "";
                if (inpLeaveResult.enableMoney.IsNull()) inpLeaveResult.enableMoney = "";
                if (inpLeaveResult.medicineCosts.IsNull()) inpLeaveResult.medicineCosts = "";
                if (inpLeaveResult.enableMedicineMoney.IsNull()) inpLeaveResult.enableMedicineMoney = "";
                if (inpLeaveResult.essentialMedicineMoney.IsNull()) inpLeaveResult.essentialMedicineMoney = "";
                if (inpLeaveResult.provinceMedicineMoney.IsNull()) inpLeaveResult.provinceMedicineMoney = "";
                if (inpLeaveResult.cureCosts.IsNull()) inpLeaveResult.cureCosts = "";
                if (inpLeaveResult.operationCosts.IsNull()) inpLeaveResult.operationCosts = "";
                if (inpLeaveResult.materialCosts.IsNull()) inpLeaveResult.materialCosts = "";

                inpLeaveResult.sign = Base64.DecodingString(inpLeaveResult.sign);
                inpLeaveResult.obligateOne = Base64.DecodingString(inpLeaveResult.obligateOne);
                inpLeaveResult.obligateTwo = Base64.DecodingString(inpLeaveResult.obligateTwo);
                inpLeaveResult.obligateThree = Base64.DecodingString(inpLeaveResult.obligateThree);
                inpLeaveResult.obligateFour = Base64.DecodingString(inpLeaveResult.obligateFour);
                inpLeaveResult.obligateFive = Base64.DecodingString(inpLeaveResult.obligateFive);
                inpLeaveResult.totalCosts = Base64.DecodingString(inpLeaveResult.totalCosts);
                inpLeaveResult.enableMoney = Base64.DecodingString(inpLeaveResult.enableMoney);
                inpLeaveResult.medicineCosts = Base64.DecodingString(inpLeaveResult.medicineCosts);
                inpLeaveResult.enableMedicineMoney = Base64.DecodingString(inpLeaveResult.enableMedicineMoney);
                inpLeaveResult.essentialMedicineMoney = Base64.DecodingString(inpLeaveResult.essentialMedicineMoney);
                inpLeaveResult.provinceMedicineMoney = Base64.DecodingString(inpLeaveResult.provinceMedicineMoney);
                inpLeaveResult.cureCosts = Base64.DecodingString(inpLeaveResult.cureCosts);
                inpLeaveResult.operationCosts = Base64.DecodingString(inpLeaveResult.operationCosts);
                inpLeaveResult.materialCosts = Base64.DecodingString(inpLeaveResult.materialCosts);

                outParm = inpLeaveResult.sign + "|" + inpLeaveResult.totalCosts + "|" + inpLeaveResult.enableMoney + "|" +
                    inpLeaveResult.medicineCosts + "|" + inpLeaveResult.enableMedicineMoney + "|" + inpLeaveResult.essentialMedicineMoney + "|" +
                    inpLeaveResult.provinceMedicineMoney + "|" + inpLeaveResult.cureCosts + "|" + inpLeaveResult.operationCosts + "|" +
                    inpLeaveResult.materialCosts + "|" + inpLeaveResult.obligateOne + "|" + inpLeaveResult.obligateTwo + "|" +
                    inpLeaveResult.obligateThree + "|" + inpLeaveResult.obligateFour + "|" + inpLeaveResult.obligateFive + "|";
                Log4NetHelper.Info(outParm);

            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B008 出院登记（扩展函数）leaveInpatientRegister", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B009 取消出院登记（扩展函数）cancelLeaveInpatientRegister
        /// <summary>
        /// B009 取消出院登记（扩展函数）cancelLeaveInpatientRegister
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int cancelLeaveInpatientRegister(string rateType, string centerCodeEx, string insuranceNo, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion

                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (insuranceNo.IsNull())
                {
                    paraName = "医保住院号";
                    goto ErrorReturn;
                }




                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                insuranceNo = Base64.EncodingString(insuranceNo);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                cancelLeaveInpatientRegisterResult inpLeaveResult;

                string inParm;
                inParm = @"
                edeemWebService.cancelLeaveInpatientRegister(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + ", " + centerCode + ", \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inParm);
                inpLeaveResult = redeemWebService.cancelLeaveInpatientRegister(operater, password, hospitalCode, insuranceNo, centerCode, "", "", "", "");


                if (inpLeaveResult.obligateOne.IsNull()) inpLeaveResult.obligateOne = "";
                if (inpLeaveResult.obligateTwo.IsNull()) inpLeaveResult.obligateTwo = "";
                if (inpLeaveResult.obligateThree.IsNull()) inpLeaveResult.obligateThree = "";
                if (inpLeaveResult.obligateFour.IsNull()) inpLeaveResult.obligateFour = "";
                if (inpLeaveResult.obligateFive.IsNull()) inpLeaveResult.obligateFive = "";


                inpLeaveResult.sign = Base64.DecodingString(inpLeaveResult.sign);
                inpLeaveResult.obligateOne = Base64.DecodingString(inpLeaveResult.obligateOne);
                inpLeaveResult.obligateTwo = Base64.DecodingString(inpLeaveResult.obligateTwo);
                inpLeaveResult.obligateThree = Base64.DecodingString(inpLeaveResult.obligateThree);
                inpLeaveResult.obligateFour = Base64.DecodingString(inpLeaveResult.obligateFour);
                inpLeaveResult.obligateFive = Base64.DecodingString(inpLeaveResult.obligateFive);

                outParm = inpLeaveResult.sign + "|" + inpLeaveResult.obligateOne + "|" + inpLeaveResult.obligateTwo + "|" +
                    inpLeaveResult.obligateThree + "|" + inpLeaveResult.obligateFour + "|" + inpLeaveResult.obligateFive + "|";
                Log4NetHelper.Info(outParm);

            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B009 取消出院登记（扩展函数）cancelLeaveInpatientRegister", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B010 住院补偿核算（住院补偿单生成）（扩展函数）creareInpatientRedeem
        /// <summary>
        /// B010 住院补偿核算（住院补偿单生成）（扩展函数）creareInpatientRedeem
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="redeemNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int creareInpatientRedeem(string rateType, string centerCodeEx, string insuranceNo, string redeemNo, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion

                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (insuranceNo.IsNull())
                {
                    paraName = "医保住院号";
                    goto ErrorReturn;
                }

                if (redeemNo.IsNull())
                {
                    paraName = "补偿类型";
                    goto ErrorReturn;
                }

                string inParm;
                inParm = @"
                inpatientRedeemResult = redeemWebService.creareInpatientRedeem(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + "," + redeemNo + ", \"\", " + centerCode + ", \"\", \"\", \"\", \"\")";


                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                insuranceNo = Base64.EncodingString(insuranceNo);
                redeemNo = Base64.EncodingString(redeemNo);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                creareInpatientRedeemResult inpatientRedeemResult;

                inParm = @"
                inpatientRedeemResult = redeemWebService.creareInpatientRedeem(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + "," + redeemNo + ", \"\", " + centerCode + ", \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inParm);
                inpatientRedeemResult = redeemWebService.creareInpatientRedeem(operater, password, hospitalCode, insuranceNo, redeemNo, "", centerCode, "", "", "", "");


                if (inpatientRedeemResult.sign.IsNull()) inpatientRedeemResult.sign = "";
                if (inpatientRedeemResult.redeemno.IsNull()) inpatientRedeemResult.redeemno = "";
                if (inpatientRedeemResult.memberNo.IsNull()) inpatientRedeemResult.memberNo = "";
                if (inpatientRedeemResult.name.IsNull()) inpatientRedeemResult.name = "";
                if (inpatientRedeemResult.bookNo.IsNull()) inpatientRedeemResult.bookNo = "";
                if (inpatientRedeemResult.sexName.IsNull()) inpatientRedeemResult.sexName = "";
                if (inpatientRedeemResult.birthday.IsNull()) inpatientRedeemResult.birthday = "";
                if (inpatientRedeemResult.masterName.IsNull()) inpatientRedeemResult.masterName = "";
                if (inpatientRedeemResult.relationName.IsNull()) inpatientRedeemResult.relationName = "";
                if (inpatientRedeemResult.identityName.IsNull()) inpatientRedeemResult.identityName = "";
                if (inpatientRedeemResult.idCard.IsNull()) inpatientRedeemResult.idCard = "";
                if (inpatientRedeemResult.currYearRedeemCount.IsNull()) inpatientRedeemResult.currYearRedeemCount = "";
                if (inpatientRedeemResult.currYearTotal.IsNull()) inpatientRedeemResult.currYearTotal = "";
                if (inpatientRedeemResult.currYearEnableMoney.IsNull()) inpatientRedeemResult.currYearEnableMoney = "";
                if (inpatientRedeemResult.currYearReddemMoney.IsNull()) inpatientRedeemResult.currYearReddemMoney = "";
                if (inpatientRedeemResult.familyNo.IsNull()) inpatientRedeemResult.familyNo = "";
                if (inpatientRedeemResult.address.IsNull()) inpatientRedeemResult.address = "";
                if (inpatientRedeemResult.doorPropName.IsNull()) inpatientRedeemResult.doorPropName = "";
                if (inpatientRedeemResult.joinPropName.IsNull()) inpatientRedeemResult.joinPropName = "";
                if (inpatientRedeemResult.currFamilyRedeemCount.IsNull()) inpatientRedeemResult.currFamilyRedeemCount = "";
                if (inpatientRedeemResult.currFamilyTotal.IsNull()) inpatientRedeemResult.currFamilyTotal = "";
                if (inpatientRedeemResult.currFamilyEnableMoney.IsNull()) inpatientRedeemResult.currFamilyEnableMoney = "";
                if (inpatientRedeemResult.currFamilyReddemMoney.IsNull()) inpatientRedeemResult.currFamilyReddemMoney = "";
                if (inpatientRedeemResult.totalCosts.IsNull()) inpatientRedeemResult.totalCosts = "";
                if (inpatientRedeemResult.enableMoney.IsNull()) inpatientRedeemResult.enableMoney = "";
                if (inpatientRedeemResult.essentialMedicineMoney.IsNull()) inpatientRedeemResult.essentialMedicineMoney = "";
                if (inpatientRedeemResult.provinceMedicineMoney.IsNull()) inpatientRedeemResult.provinceMedicineMoney = "";
                if (inpatientRedeemResult.startMoney.IsNull()) inpatientRedeemResult.startMoney = "";
                if (inpatientRedeemResult.checkMoney.IsNull()) inpatientRedeemResult.checkMoney = "";
                if (inpatientRedeemResult.redeemTypeName.IsNull()) inpatientRedeemResult.redeemTypeName = "";
                if (inpatientRedeemResult.checkDate.IsNull()) inpatientRedeemResult.checkDate = "";
                if (inpatientRedeemResult.isSpecial.IsNull()) inpatientRedeemResult.isSpecial = "";
                if (inpatientRedeemResult.isPaul.IsNull()) inpatientRedeemResult.isPaul = "";
                if (inpatientRedeemResult.isAduit.IsNull()) inpatientRedeemResult.isAduit = "";
                //if (inpatientRedeemResult.feeList.IsNull()) inpatientRedeemResult.feeList = "";
                //if (inpatientRedeemResult.gradeList.IsNull()) inpatientRedeemResult.gradeList = "";
                if (inpatientRedeemResult.anlagernMoney.IsNull()) inpatientRedeemResult.anlagernMoney = "";
                if (inpatientRedeemResult.fundPayMoney.IsNull()) inpatientRedeemResult.fundPayMoney = "";
                if (inpatientRedeemResult.hospAssumeMoney.IsNull()) inpatientRedeemResult.hospAssumeMoney = "";
                if (inpatientRedeemResult.personalPayMoney.IsNull()) inpatientRedeemResult.personalPayMoney = "";
                if (inpatientRedeemResult.civilRedeemMoney.IsNull()) inpatientRedeemResult.civilRedeemMoney = "";
                if (inpatientRedeemResult.materialMoney.IsNull()) inpatientRedeemResult.materialMoney = "";

                if (inpatientRedeemResult.obligateOne.IsNull()) inpatientRedeemResult.obligateOne = "";
                if (inpatientRedeemResult.obligateTwo.IsNull()) inpatientRedeemResult.obligateTwo = "";
                if (inpatientRedeemResult.obligateThree.IsNull()) inpatientRedeemResult.obligateThree = "";
                if (inpatientRedeemResult.obligateFour.IsNull()) inpatientRedeemResult.obligateFour = "";
                if (inpatientRedeemResult.obligateFive.IsNull()) inpatientRedeemResult.obligateFive = "";
                if (centerName.IsNull()) centerName = "";


                inpatientRedeemResult.sign = Base64.DecodingString(inpatientRedeemResult.sign);
                inpatientRedeemResult.redeemno = Base64.DecodingString(inpatientRedeemResult.redeemno);
                inpatientRedeemResult.memberNo = Base64.DecodingString(inpatientRedeemResult.memberNo);
                inpatientRedeemResult.name = Base64.DecodingString(inpatientRedeemResult.name);
                inpatientRedeemResult.bookNo = Base64.DecodingString(inpatientRedeemResult.bookNo);
                inpatientRedeemResult.sexName = Base64.DecodingString(inpatientRedeemResult.sexName);
                inpatientRedeemResult.birthday = Base64.DecodingString(inpatientRedeemResult.birthday);
                inpatientRedeemResult.masterName = Base64.DecodingString(inpatientRedeemResult.masterName);
                inpatientRedeemResult.relationName = Base64.DecodingString(inpatientRedeemResult.relationName);
                inpatientRedeemResult.identityName = Base64.DecodingString(inpatientRedeemResult.identityName);
                inpatientRedeemResult.idCard = Base64.DecodingString(inpatientRedeemResult.idCard);
                inpatientRedeemResult.currYearRedeemCount = Base64.DecodingString(inpatientRedeemResult.currYearRedeemCount);
                inpatientRedeemResult.currYearTotal = Base64.DecodingString(inpatientRedeemResult.currYearTotal);
                inpatientRedeemResult.currYearEnableMoney = Base64.DecodingString(inpatientRedeemResult.currYearEnableMoney);
                inpatientRedeemResult.currYearReddemMoney = Base64.DecodingString(inpatientRedeemResult.currYearReddemMoney);
                inpatientRedeemResult.familyNo = Base64.DecodingString(inpatientRedeemResult.familyNo);
                inpatientRedeemResult.address = Base64.DecodingString(inpatientRedeemResult.address);
                inpatientRedeemResult.doorPropName = Base64.DecodingString(inpatientRedeemResult.doorPropName);
                inpatientRedeemResult.joinPropName = Base64.DecodingString(inpatientRedeemResult.joinPropName);
                inpatientRedeemResult.currFamilyRedeemCount = Base64.DecodingString(inpatientRedeemResult.currFamilyRedeemCount);
                inpatientRedeemResult.currFamilyTotal = Base64.DecodingString(inpatientRedeemResult.currFamilyTotal);
                inpatientRedeemResult.currFamilyEnableMoney = Base64.DecodingString(inpatientRedeemResult.currFamilyEnableMoney);
                inpatientRedeemResult.currFamilyReddemMoney = Base64.DecodingString(inpatientRedeemResult.currFamilyReddemMoney);
                inpatientRedeemResult.totalCosts = Base64.DecodingString(inpatientRedeemResult.totalCosts);
                inpatientRedeemResult.enableMoney = Base64.DecodingString(inpatientRedeemResult.enableMoney);
                inpatientRedeemResult.essentialMedicineMoney = Base64.DecodingString(inpatientRedeemResult.essentialMedicineMoney);
                inpatientRedeemResult.provinceMedicineMoney = Base64.DecodingString(inpatientRedeemResult.provinceMedicineMoney);
                inpatientRedeemResult.startMoney = Base64.DecodingString(inpatientRedeemResult.startMoney);
                inpatientRedeemResult.checkMoney = Base64.DecodingString(inpatientRedeemResult.checkMoney);
                inpatientRedeemResult.redeemTypeName = Base64.DecodingString(inpatientRedeemResult.redeemTypeName);
                inpatientRedeemResult.checkDate = Base64.DecodingString(inpatientRedeemResult.checkDate);
                inpatientRedeemResult.isSpecial = Base64.DecodingString(inpatientRedeemResult.isSpecial);
                inpatientRedeemResult.isPaul = Base64.DecodingString(inpatientRedeemResult.isPaul);
                inpatientRedeemResult.isAduit = Base64.DecodingString(inpatientRedeemResult.isAduit);
                inpatientRedeemResult.anlagernMoney = Base64.DecodingString(inpatientRedeemResult.anlagernMoney);
                inpatientRedeemResult.fundPayMoney = Base64.DecodingString(inpatientRedeemResult.fundPayMoney);
                inpatientRedeemResult.hospAssumeMoney = Base64.DecodingString(inpatientRedeemResult.hospAssumeMoney);
                inpatientRedeemResult.personalPayMoney = Base64.DecodingString(inpatientRedeemResult.personalPayMoney);
                inpatientRedeemResult.civilRedeemMoney = Base64.DecodingString(inpatientRedeemResult.civilRedeemMoney);
                inpatientRedeemResult.materialMoney = Base64.DecodingString(inpatientRedeemResult.materialMoney);
                inpatientRedeemResult.obligateOne = Base64.DecodingString(inpatientRedeemResult.obligateOne);
                inpatientRedeemResult.obligateTwo = Base64.DecodingString(inpatientRedeemResult.obligateTwo);
                inpatientRedeemResult.obligateThree = Base64.DecodingString(inpatientRedeemResult.obligateThree);
                inpatientRedeemResult.obligateFour = Base64.DecodingString(inpatientRedeemResult.obligateFour);
                inpatientRedeemResult.obligateFive = Base64.DecodingString(inpatientRedeemResult.obligateFive);

                //outParm = inpatientRedeemResult.sign + "|" + inpatientRedeemResult.redeemno + "|" + inpatientRedeemResult.memberNo + "|" +
                //    inpatientRedeemResult.name + "|" + inpatientRedeemResult.bookNo + "|" + inpatientRedeemResult.sexName + "|" +
                //    inpatientRedeemResult.birthday + "|" + inpatientRedeemResult.masterName + "|" + inpatientRedeemResult.relationName + "|" +
                //    inpatientRedeemResult.identityName + "|" + inpatientRedeemResult.idCard + "|" + inpatientRedeemResult.currYearRedeemCount + "|" +
                //    inpatientRedeemResult.currYearTotal + "|" + inpatientRedeemResult.currYearEnableMoney + "|" + inpatientRedeemResult.currYearReddemMoney + "|" +
                //    inpatientRedeemResult.familyNo + "|" + inpatientRedeemResult.address + "|" + inpatientRedeemResult.doorPropName + "|" +
                //    inpatientRedeemResult.joinPropName + "|" + inpatientRedeemResult.currFamilyRedeemCount + "|" + inpatientRedeemResult.currFamilyTotal + "|" +
                //    inpatientRedeemResult.currFamilyEnableMoney + "|" + inpatientRedeemResult.currFamilyReddemMoney + "|" + inpatientRedeemResult.totalCosts + "|" +
                //    inpatientRedeemResult.enableMoney + "|" + inpatientRedeemResult.essentialMedicineMoney + "|" + inpatientRedeemResult.provinceMedicineMoney + "|" +
                //    inpatientRedeemResult.startMoney + "|" + inpatientRedeemResult.checkMoney + "|" + inpatientRedeemResult.redeemTypeName + "|" +
                //    inpatientRedeemResult.checkDate + "|" + inpatientRedeemResult.isSpecial + "|" + inpatientRedeemResult.isPaul + "|" +
                //    /*inpatientRedeemResult.isAduit*/ "" + "|" + //inpatientRedeemResult.feeList + "|" + inpatientRedeemResult.gradeList + "|" +
                //    inpatientRedeemResult.anlagernMoney + "|" + inpatientRedeemResult.fundPayMoney + "|" + inpatientRedeemResult.hospAssumeMoney + "|" +
                //    inpatientRedeemResult.personalPayMoney + "|" + inpatientRedeemResult.civilRedeemMoney + "|" +
                //    inpatientRedeemResult.materialMoney + "|" + inpatientRedeemResult.obligateOne + "|" + inpatientRedeemResult.obligateTwo + "|" +
                //    inpatientRedeemResult.obligateThree + "|" + inpatientRedeemResult.obligateFour + "|" + inpatientRedeemResult.obligateFive + "|" +
                //    centerName + "|";
                outParm = inpatientRedeemResult.sign + "|" + inpatientRedeemResult.redeemno + "|" + inpatientRedeemResult.memberNo + "|" +
                    inpatientRedeemResult.name + "|" + inpatientRedeemResult.bookNo + "|" + inpatientRedeemResult.sexName + "|" +
                    inpatientRedeemResult.birthday + "|" + inpatientRedeemResult.masterName + "|" + inpatientRedeemResult.relationName + "|" +
                    inpatientRedeemResult.identityName + "|" + inpatientRedeemResult.idCard + "|" + inpatientRedeemResult.currYearRedeemCount + "|" +
                    inpatientRedeemResult.currYearTotal + "|" + inpatientRedeemResult.currYearEnableMoney + "|" + inpatientRedeemResult.currYearReddemMoney + "|" +
                    inpatientRedeemResult.familyNo + "|" + inpatientRedeemResult.address + "|" + inpatientRedeemResult.doorPropName + "|" +
                    inpatientRedeemResult.joinPropName + "|" + inpatientRedeemResult.currFamilyRedeemCount + "|" + inpatientRedeemResult.currFamilyTotal + "|" +
                    inpatientRedeemResult.currFamilyEnableMoney + "|" + inpatientRedeemResult.currFamilyReddemMoney + "|" + inpatientRedeemResult.totalCosts + "|" +
                    inpatientRedeemResult.enableMoney + "|" + inpatientRedeemResult.essentialMedicineMoney + "|" + inpatientRedeemResult.provinceMedicineMoney + "|" +
                    inpatientRedeemResult.startMoney + "|" + inpatientRedeemResult.checkMoney/*enableMoney*/ + "|" + inpatientRedeemResult.redeemTypeName + "|" +
                    inpatientRedeemResult.checkDate + "|" + inpatientRedeemResult.isSpecial + "|" + inpatientRedeemResult.isPaul + "|" +
                    "" + "|" + //inpatientRedeemResult.feeList + "|" + inpatientRedeemResult.gradeList + "|" +
                    inpatientRedeemResult.anlagernMoney + "|" + inpatientRedeemResult.fundPayMoney + "|" + inpatientRedeemResult.hospAssumeMoney + "|" +
                    inpatientRedeemResult.personalPayMoney + "|" + inpatientRedeemResult.civilRedeemMoney + "|" +
                    inpatientRedeemResult.materialMoney + "|" + inpatientRedeemResult.obligateOne + "|" + inpatientRedeemResult.obligateTwo + "|" +
                    inpatientRedeemResult.obligateThree + "|" + inpatientRedeemResult.obligateFour + "|" + inpatientRedeemResult.obligateFive + "|" +
                    centerName + "|";

                string resultXml;
                resultXml = XmlUtil.Serializer(typeof(creareInpatientRedeemResult), inpatientRedeemResult);
                Log4NetHelper.Info(resultXml);

                //outParm = inpatientRedeemResult.sign + "|" + inpatientRedeemResult.redeemno + "|" + inpatientRedeemResult.memberNo + "|" +
                //    inpatientRedeemResult.name + "|" + inpatientRedeemResult.bookNo + "|" + inpatientRedeemResult.sexName + "|" +
                //    inpatientRedeemResult.birthday + "|" + inpatientRedeemResult.masterName + "|" + inpatientRedeemResult.relationName + "|" +
                //    inpatientRedeemResult.identityName + "|" + inpatientRedeemResult.idCard + "|" + inpatientRedeemResult.currYearRedeemCount + "|" +
                //    inpatientRedeemResult.currYearTotal + "|" + inpatientRedeemResult.currYearEnableMoney + "|" + inpatientRedeemResult.currYearReddemMoney + "|" +
                //    inpatientRedeemResult.familyNo + "|" + inpatientRedeemResult.address + "|" + inpatientRedeemResult.doorPropName + "|" +
                //    inpatientRedeemResult.joinPropName + "|" + inpatientRedeemResult.currFamilyRedeemCount + "|" + inpatientRedeemResult.currFamilyTotal + "|" +
                //    inpatientRedeemResult.currFamilyEnableMoney + "|" + inpatientRedeemResult.currFamilyReddemMoney + "|" + inpatientRedeemResult.totalCosts + "|" +
                //    inpatientRedeemResult.enableMoney + "|" + inpatientRedeemResult.essentialMedicineMoney + "|" + inpatientRedeemResult.provinceMedicineMoney + "|" +
                //    inpatientRedeemResult.startMoney + "|" + inpatientRedeemResult.redeemMoney + "|" + inpatientRedeemResult.redeemTypeName + "|" +
                //    inpatientRedeemResult.redeemDate + "|" + inpatientRedeemResult.isSpecial + "|" + inpatientRedeemResult.isPaul + "|" +
                //    inpatientRedeemResult.phoneCode + "|" + //inpatientRedeemResult.feeList + "|" + inpatientRedeemResult.gradeList + "|" +
                //    inpatientRedeemResult.anlagernMoney + "|" + inpatientRedeemResult.fundPayMoney + "|" + inpatientRedeemResult.hospAssumeMoney + "|" +
                //    inpatientRedeemResult.personalPayMoney + "|" + inpatientRedeemResult.civilRedeemMoney + "|" +
                //    inpatientRedeemResult.materialMoney + "|" + inpatientRedeemResult.obligateOne + "|" + inpatientRedeemResult.obligateTwo + "|" +
                //    inpatientRedeemResult.obligateThree + "|" + inpatientRedeemResult.obligateFour + "|" + inpatientRedeemResult.obligateFive + "|" +
                //    centerName + "|";
                Log4NetHelper.Info(outParm);

            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B010 住院补偿核算（住院补偿单生成）（扩展函数）creareInpatientRedeem", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B011 住院补偿核算撤销(住院补偿单撤销)（扩展函数）cancelInpatientRedeem
        /// <summary>
        /// B011 住院补偿核算撤销(住院补偿单撤销)（扩展函数）cancelInpatientRedeem
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int cancelInpatientRedeem(string rateType, string centerCodeEx, string insuranceNo, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion

                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (insuranceNo.IsNull())
                {
                    paraName = "医保住院号";
                    goto ErrorReturn;
                }


                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                insuranceNo = Base64.EncodingString(insuranceNo);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                cancelInpatientRedeemResult inpatientRedeemResult;

                string inParm;
                inParm = @"
                 redeemWebService.cancelInpatientRedeem(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + "," + centerCode + ", \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inParm);
                inpatientRedeemResult = redeemWebService.cancelInpatientRedeem(operater, password, hospitalCode, insuranceNo, centerCode, "", "", "", "");


                if (inpatientRedeemResult.sign.IsNull()) inpatientRedeemResult.sign = "";
                if (inpatientRedeemResult.obligateOne.IsNull()) inpatientRedeemResult.obligateOne = "";
                if (inpatientRedeemResult.obligateTwo.IsNull()) inpatientRedeemResult.obligateTwo = "";
                if (inpatientRedeemResult.obligateThree.IsNull()) inpatientRedeemResult.obligateThree = "";
                if (inpatientRedeemResult.obligateFour.IsNull()) inpatientRedeemResult.obligateFour = "";
                if (inpatientRedeemResult.obligateFive.IsNull()) inpatientRedeemResult.obligateFive = "";


                inpatientRedeemResult.sign = Base64.DecodingString(inpatientRedeemResult.sign);
                inpatientRedeemResult.obligateOne = Base64.DecodingString(inpatientRedeemResult.obligateOne);
                inpatientRedeemResult.obligateTwo = Base64.DecodingString(inpatientRedeemResult.obligateTwo);
                inpatientRedeemResult.obligateThree = Base64.DecodingString(inpatientRedeemResult.obligateThree);
                inpatientRedeemResult.obligateFour = Base64.DecodingString(inpatientRedeemResult.obligateFour);
                inpatientRedeemResult.obligateFive = Base64.DecodingString(inpatientRedeemResult.obligateFive);

                outParm = inpatientRedeemResult.sign + "|" + inpatientRedeemResult.obligateOne + "|" + inpatientRedeemResult.obligateTwo + "|" +
                    inpatientRedeemResult.obligateThree + "|" + inpatientRedeemResult.obligateFour + "|" + inpatientRedeemResult.obligateFive + "|";
                Log4NetHelper.Info(outParm);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B011 住院补偿核算撤销(住院补偿单撤销)（扩展函数）cancelInpatientRedeem", ex);
                try
                {
                    outParm = ex.Message;
                    string errMsg = "";
                    if (Base64.IsBase64Formatted(outParm))
                    {
                        errMsg = Base64.DecodingString(outParm);
                    }
                    if (Base64.IsBase64Formatted(errMsg))
                    {
                        errMsg = Base64.DecodingString(errMsg);
                    }
                    if (errMsg.IsNull())
                    {
                        Log4NetHelper.Error(outParm);
                    }
                    else
                    {
                        Log4NetHelper.Error(errMsg);
                        outParm = errMsg;
                    }
                }
                catch (Exception eo)
                {
                    outParm = ex.Message;
                }

                return -1;
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B012 住院兑付（扩展函数）inpatientPay
        /// <summary>
        /// B012 住院兑付（扩展函数）inpatientPay
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="redeemNo"></param>
        /// <param name="phoneNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int inpatientPay(string rateType, string centerCodeEx, string insuranceNo, string redeemNo, string phoneNo,
            string obligateOne, string obligateTwo, string obligateThree,
            string obligateFour, string obligateFive, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion

                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (insuranceNo.IsNull())
                {
                    paraName = "医保住院号";
                    goto ErrorReturn;
                }

                if (redeemNo.IsNull())
                {
                    paraName = "补偿类型";
                    goto ErrorReturn;
                }
                if (phoneNo.IsNull()) phoneNo = "";

                if (obligateOne.IsNull()) obligateOne = "";
                if (obligateTwo.IsNull()) obligateTwo = "";
                if (obligateThree.IsNull()) obligateThree = "";
                if (obligateFour.IsNull()) obligateFour = "";
                if (obligateFive.IsNull()) obligateFive = "";

                //由于obligateOne参数 有可能被占用， 这里加一个容错处理
                //如果没有占用 即是省平台传入的 农合中心编码（省外6位县地区编码）
                //如果占用 即是 某个县平台传入的 特点参数
                if (obligateOne.IsNull())
                {
                    obligateOne = centerCode;
                }
                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                insuranceNo = Base64.EncodingString(insuranceNo);
                redeemNo = Base64.EncodingString(redeemNo);
                phoneNo = Base64.EncodingString(phoneNo);
                obligateOne = Base64.EncodingString(obligateOne);
                obligateTwo = Base64.EncodingString(obligateTwo);
                obligateThree = Base64.EncodingString(obligateThree);
                obligateFour = Base64.EncodingString(obligateFour);
                obligateFive = Base64.EncodingString(obligateFive);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                inpatientRedeemResult inpRedeemResult;

                string inParm;
                inParm = @"redeemWebService.inpatientPay(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + "," + redeemNo
                            + ", \"\", \"\"," + phoneNo + ", \"\"," + obligateOne + ", " + obligateTwo + "," + obligateThree + "," + obligateFour + "," + obligateFive + ")";
                Log4NetHelper.Info(inParm);
                inpRedeemResult = redeemWebService.inpatientPay(operater, password, hospitalCode, insuranceNo, redeemNo, "", "", phoneNo, "",
                                    obligateOne, obligateTwo, obligateThree, obligateFour, obligateFive);


                if (inpRedeemResult.sign.IsNull()) inpRedeemResult.sign = "";
                if (inpRedeemResult.redeemno.IsNull()) inpRedeemResult.redeemno = "";
                if (inpRedeemResult.memberNo.IsNull()) inpRedeemResult.memberNo = "";
                if (inpRedeemResult.name.IsNull()) inpRedeemResult.name = "";
                if (inpRedeemResult.bookNo.IsNull()) inpRedeemResult.bookNo = "";
                if (inpRedeemResult.sexName.IsNull()) inpRedeemResult.sexName = "";
                if (inpRedeemResult.birthday.IsNull()) inpRedeemResult.birthday = "";
                if (inpRedeemResult.masterName.IsNull()) inpRedeemResult.masterName = "";
                if (inpRedeemResult.relationName.IsNull()) inpRedeemResult.relationName = "";
                if (inpRedeemResult.identityName.IsNull()) inpRedeemResult.identityName = "";
                if (inpRedeemResult.idCard.IsNull()) inpRedeemResult.idCard = "";
                if (inpRedeemResult.currYearRedeemCount.IsNull()) inpRedeemResult.currYearRedeemCount = "";
                if (inpRedeemResult.currYearTotal.IsNull()) inpRedeemResult.currYearTotal = "";
                if (inpRedeemResult.currYearEnableMoney.IsNull()) inpRedeemResult.currYearEnableMoney = "";
                if (inpRedeemResult.currYearReddemMoney.IsNull()) inpRedeemResult.currYearReddemMoney = "";
                if (inpRedeemResult.familyNo.IsNull()) inpRedeemResult.familyNo = "";
                if (inpRedeemResult.address.IsNull()) inpRedeemResult.address = "";
                if (inpRedeemResult.doorPropName.IsNull()) inpRedeemResult.doorPropName = "";
                if (inpRedeemResult.joinPropName.IsNull()) inpRedeemResult.joinPropName = "";
                if (inpRedeemResult.currFamilyRedeemCount.IsNull()) inpRedeemResult.currFamilyRedeemCount = "";
                if (inpRedeemResult.currFamilyTotal.IsNull()) inpRedeemResult.currFamilyTotal = "";
                if (inpRedeemResult.currFamilyEnableMoney.IsNull()) inpRedeemResult.currFamilyEnableMoney = "";
                if (inpRedeemResult.currFamilyReddemMoney.IsNull()) inpRedeemResult.currFamilyReddemMoney = "";
                if (inpRedeemResult.totalCosts.IsNull()) inpRedeemResult.totalCosts = "";
                if (inpRedeemResult.enableMoney.IsNull()) inpRedeemResult.enableMoney = "";
                if (inpRedeemResult.essentialMedicineMoney.IsNull()) inpRedeemResult.essentialMedicineMoney = "";
                if (inpRedeemResult.provinceMedicineMoney.IsNull()) inpRedeemResult.provinceMedicineMoney = "";
                if (inpRedeemResult.startMoney.IsNull()) inpRedeemResult.startMoney = "";
                //if (inpRedeemResult.checkMoney.IsNull()) inpRedeemResult.checkMoney = "";
                if (inpRedeemResult.redeemMoney.IsNull()) inpRedeemResult.redeemMoney = "";
                if (inpRedeemResult.redeemTypeName.IsNull()) inpRedeemResult.redeemTypeName = "";
                //if (inpRedeemResult.checkDate.IsNull()) inpRedeemResult.checkDate = "";
                if (inpRedeemResult.redeemDate.IsNull()) inpRedeemResult.redeemDate = "";
                if (inpRedeemResult.isSpecial.IsNull()) inpRedeemResult.isSpecial = "";
                if (inpRedeemResult.isPaul.IsNull()) inpRedeemResult.isPaul = "";
                //if (inpRedeemResult.feeList.IsNull()) inpRedeemResult.feeList = "";
                //if (inpRedeemResult.gradeList.IsNull()) inpRedeemResult.gradeList = "";
                if (inpRedeemResult.anlagernMoney.IsNull()) inpRedeemResult.anlagernMoney = "";
                if (inpRedeemResult.fundPayMoney.IsNull()) inpRedeemResult.fundPayMoney = "";
                if (inpRedeemResult.hospAssumeMoney.IsNull()) inpRedeemResult.hospAssumeMoney = "";
                if (inpRedeemResult.personalPayMoney.IsNull()) inpRedeemResult.personalPayMoney = "";
                if (inpRedeemResult.civilRedeemMoney.IsNull()) inpRedeemResult.civilRedeemMoney = "";
                if (inpRedeemResult.materialMoney.IsNull()) inpRedeemResult.materialMoney = "";

                if (inpRedeemResult.obligateOne.IsNull()) inpRedeemResult.obligateOne = "";
                if (inpRedeemResult.obligateTwo.IsNull()) inpRedeemResult.obligateTwo = "";
                if (inpRedeemResult.obligateThree.IsNull()) inpRedeemResult.obligateThree = "";
                if (inpRedeemResult.obligateFour.IsNull()) inpRedeemResult.obligateFour = "";
                if (inpRedeemResult.obligateFive.IsNull()) inpRedeemResult.obligateFive = "";
                if (centerName.IsNull()) centerName = "";

                inpRedeemResult.sign = Base64.DecodingString(inpRedeemResult.sign);
                inpRedeemResult.redeemno = Base64.DecodingString(inpRedeemResult.redeemno);
                inpRedeemResult.memberNo = Base64.DecodingString(inpRedeemResult.memberNo);
                inpRedeemResult.name = Base64.DecodingString(inpRedeemResult.name);
                inpRedeemResult.bookNo = Base64.DecodingString(inpRedeemResult.bookNo);
                inpRedeemResult.sexName = Base64.DecodingString(inpRedeemResult.sexName);
                inpRedeemResult.birthday = Base64.DecodingString(inpRedeemResult.birthday);
                inpRedeemResult.masterName = Base64.DecodingString(inpRedeemResult.masterName);
                inpRedeemResult.relationName = Base64.DecodingString(inpRedeemResult.relationName);
                inpRedeemResult.identityName = Base64.DecodingString(inpRedeemResult.identityName);
                inpRedeemResult.idCard = Base64.DecodingString(inpRedeemResult.idCard);
                inpRedeemResult.currYearRedeemCount = Base64.DecodingString(inpRedeemResult.currYearRedeemCount);
                inpRedeemResult.currYearTotal = Base64.DecodingString(inpRedeemResult.currYearTotal);
                inpRedeemResult.currYearEnableMoney = Base64.DecodingString(inpRedeemResult.currYearEnableMoney);
                inpRedeemResult.currYearReddemMoney = Base64.DecodingString(inpRedeemResult.currYearReddemMoney);
                inpRedeemResult.familyNo = Base64.DecodingString(inpRedeemResult.familyNo);
                inpRedeemResult.address = Base64.DecodingString(inpRedeemResult.address);
                inpRedeemResult.doorPropName = Base64.DecodingString(inpRedeemResult.doorPropName);
                inpRedeemResult.joinPropName = Base64.DecodingString(inpRedeemResult.joinPropName);
                inpRedeemResult.currFamilyRedeemCount = Base64.DecodingString(inpRedeemResult.currFamilyRedeemCount);
                inpRedeemResult.currFamilyTotal = Base64.DecodingString(inpRedeemResult.currFamilyTotal);
                inpRedeemResult.currFamilyEnableMoney = Base64.DecodingString(inpRedeemResult.currFamilyEnableMoney);
                inpRedeemResult.currFamilyReddemMoney = Base64.DecodingString(inpRedeemResult.currFamilyReddemMoney);
                inpRedeemResult.totalCosts = Base64.DecodingString(inpRedeemResult.totalCosts);
                inpRedeemResult.enableMoney = Base64.DecodingString(inpRedeemResult.enableMoney);
                inpRedeemResult.essentialMedicineMoney = Base64.DecodingString(inpRedeemResult.essentialMedicineMoney);
                inpRedeemResult.provinceMedicineMoney = Base64.DecodingString(inpRedeemResult.provinceMedicineMoney);
                inpRedeemResult.startMoney = Base64.DecodingString(inpRedeemResult.startMoney);
                inpRedeemResult.redeemMoney = Base64.DecodingString(inpRedeemResult.redeemMoney);
                inpRedeemResult.redeemTypeName = Base64.DecodingString(inpRedeemResult.redeemTypeName);
                inpRedeemResult.redeemDate = Base64.DecodingString(inpRedeemResult.redeemDate);
                inpRedeemResult.isSpecial = Base64.DecodingString(inpRedeemResult.isSpecial);
                inpRedeemResult.isPaul = Base64.DecodingString(inpRedeemResult.isPaul);
                //inpRedeemResult.isAduit = Base64.DecodingString(inpRedeemResult.isAduit);
                inpRedeemResult.anlagernMoney = Base64.DecodingString(inpRedeemResult.anlagernMoney);
                inpRedeemResult.fundPayMoney = Base64.DecodingString(inpRedeemResult.fundPayMoney);
                inpRedeemResult.hospAssumeMoney = Base64.DecodingString(inpRedeemResult.hospAssumeMoney);
                inpRedeemResult.personalPayMoney = Base64.DecodingString(inpRedeemResult.personalPayMoney);
                inpRedeemResult.civilRedeemMoney = Base64.DecodingString(inpRedeemResult.civilRedeemMoney);
                inpRedeemResult.materialMoney = Base64.DecodingString(inpRedeemResult.materialMoney);
                inpRedeemResult.obligateOne = Base64.DecodingString(inpRedeemResult.obligateOne);
                inpRedeemResult.obligateTwo = Base64.DecodingString(inpRedeemResult.obligateTwo);
                inpRedeemResult.obligateThree = Base64.DecodingString(inpRedeemResult.obligateThree);
                inpRedeemResult.obligateFour = Base64.DecodingString(inpRedeemResult.obligateFour);
                inpRedeemResult.obligateFive = Base64.DecodingString(inpRedeemResult.obligateFive);

                outParm = inpRedeemResult.sign + "|" + inpRedeemResult.redeemno + "|" + inpRedeemResult.memberNo + "|" +
                    inpRedeemResult.name + "|" + inpRedeemResult.bookNo + "|" + inpRedeemResult.sexName + "|" +
                    inpRedeemResult.birthday + "|" + inpRedeemResult.masterName + "|" + inpRedeemResult.relationName + "|" +
                    inpRedeemResult.identityName + "|" + inpRedeemResult.idCard + "|" + inpRedeemResult.currYearRedeemCount + "|" +
                    inpRedeemResult.currYearTotal + "|" + inpRedeemResult.currYearEnableMoney + "|" + inpRedeemResult.currYearReddemMoney + "|" +
                    inpRedeemResult.familyNo + "|" + inpRedeemResult.address + "|" + inpRedeemResult.doorPropName + "|" +
                    inpRedeemResult.joinPropName + "|" + inpRedeemResult.currFamilyRedeemCount + "|" + inpRedeemResult.currFamilyTotal + "|" +
                    inpRedeemResult.currFamilyEnableMoney + "|" + inpRedeemResult.currFamilyReddemMoney + "|" + inpRedeemResult.totalCosts + "|" +
                    inpRedeemResult.enableMoney + "|" + inpRedeemResult.essentialMedicineMoney + "|" + inpRedeemResult.provinceMedicineMoney + "|" +
                    inpRedeemResult.startMoney + "|" + inpRedeemResult.redeemMoney + "|" + inpRedeemResult.redeemTypeName + "|" +
                    inpRedeemResult.redeemDate + "|" + inpRedeemResult.isSpecial + "|" + inpRedeemResult.isPaul + "|" +
                    inpRedeemResult.phoneCode + "|" + //inpRedeemResult.feeList + "|" + inpRedeemResult.gradeList + "|" +
                    inpRedeemResult.anlagernMoney + "|" + inpRedeemResult.fundPayMoney + "|" + inpRedeemResult.hospAssumeMoney + "|" +
                    inpRedeemResult.personalPayMoney + "|" + inpRedeemResult.civilRedeemMoney + "|" +
                    inpRedeemResult.materialMoney + "|" + inpRedeemResult.obligateOne + "|" + inpRedeemResult.obligateTwo + "|" +
                    inpRedeemResult.obligateThree + "|" + inpRedeemResult.obligateFour + "|" + inpRedeemResult.obligateFive + "|" +
                    centerName + "|";
                Log4NetHelper.Info(outParm);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B012 住院兑付（扩展函数）inpatientPay", ex);
                try
                {
                    outParm = ex.Message;
                    string errMsg = "";
                    if (Base64.IsBase64Formatted(outParm))
                    {
                        errMsg = Base64.DecodingString(outParm);
                    }
                    if (Base64.IsBase64Formatted(errMsg))
                    {
                        errMsg = Base64.DecodingString(errMsg);
                    }
                    if (errMsg.IsNull())
                    {
                        Log4NetHelper.Error(outParm);
                    }
                    else
                    {
                        Log4NetHelper.Error(errMsg);
                        outParm = errMsg;
                    }
                }
                catch (Exception eo)
                {
                    outParm = ex.Message;
                }

                return -1;
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B013 住院补偿冲红（取消兑付）（扩展函数）cancelInpatientPay
        /// <summary>
        /// B013 住院补偿冲红（取消兑付）（扩展函数）cancelInpatientPay
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int cancelInpatientPay(string rateType, string centerCodeEx, string insuranceNo, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }
                #endregion

                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (insuranceNo.IsNull())
                {
                    paraName = "医保住院号";
                    goto ErrorReturn;
                }


                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                insuranceNo = Base64.EncodingString(insuranceNo);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                cancelInpatientPayResult inpRedeemResult;

                string inParm;
                inParm = @"
                redeemWebService.cancelInpatientPay(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + ", \"\", \"\", \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inParm);
                inpRedeemResult = redeemWebService.cancelInpatientPay(operater, password, hospitalCode, insuranceNo, "", "", "", "", "", "");


                if (inpRedeemResult.sign.IsNull()) inpRedeemResult.sign = "";
                if (inpRedeemResult.obligateOne.IsNull()) inpRedeemResult.obligateOne = "";
                if (inpRedeemResult.obligateTwo.IsNull()) inpRedeemResult.obligateTwo = "";
                if (inpRedeemResult.obligateThree.IsNull()) inpRedeemResult.obligateThree = "";
                if (inpRedeemResult.obligateFour.IsNull()) inpRedeemResult.obligateFour = "";
                if (inpRedeemResult.obligateFive.IsNull()) inpRedeemResult.obligateFive = "";


                inpRedeemResult.sign = Base64.DecodingString(inpRedeemResult.sign);
                inpRedeemResult.obligateOne = Base64.DecodingString(inpRedeemResult.obligateOne);
                inpRedeemResult.obligateTwo = Base64.DecodingString(inpRedeemResult.obligateTwo);
                inpRedeemResult.obligateThree = Base64.DecodingString(inpRedeemResult.obligateThree);
                inpRedeemResult.obligateFour = Base64.DecodingString(inpRedeemResult.obligateFour);
                inpRedeemResult.obligateFive = Base64.DecodingString(inpRedeemResult.obligateFive);

                outParm = inpRedeemResult.sign + "|" + inpRedeemResult.obligateOne + "|" + inpRedeemResult.obligateTwo + "|" +
                    inpRedeemResult.obligateThree + "|" + inpRedeemResult.obligateFour + "|" + inpRedeemResult.obligateFive + "|";
                Log4NetHelper.Info(outParm);

            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B013 住院补偿冲红（取消兑付）（扩展函数）cancelInpatientPay", ex);
                try
                {
                    outParm = ex.Message;
                    string errMsg = "";
                    if (Base64.IsBase64Formatted(outParm))
                    {
                        errMsg = Base64.DecodingString(outParm);
                    }
                    if (Base64.IsBase64Formatted(errMsg))
                    {
                        errMsg = Base64.DecodingString(errMsg);
                    }
                    if (errMsg.IsNull())
                    {
                        Log4NetHelper.Error(outParm);
                    }
                    else
                    {
                        Log4NetHelper.Error(errMsg);
                        outParm = errMsg;
                    }
                }
                catch (Exception eo)
                {
                    outParm = ex.Message;
                }

                return -1;
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B014 住院补偿试算（扩展函数）inpatientCalculate
        /// <summary>
        /// B014 住院补偿试算（扩展函数）inpatientCalculate
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="insuranceNo"></param>
        /// <param name="redeemNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int inpatientCalculate(string rateType, string centerCodeEx, string insuranceNo, string redeemNo, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化

                StringBuilder sql = new StringBuilder();
                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                    redeemNo = "2101";
                }
                #endregion

                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }

                if (insuranceNo.IsNull())
                {
                    paraName = "医保住院号";
                    goto ErrorReturn;
                }

                if (redeemNo.IsNull())
                {
                    sql.Clear();
                    sql.Append(" select  id  from hospital_vs_center_config where rate_type = :arg_rate_type");
                    OracleParameter[] paraCenterConfig = { new OracleParameter("arg_rate_type", rateType) };
                    DataTable dtCenterConfig = Select(sql.ToString(), paraCenterConfig, "CenterConfig");
                    if (dtCenterConfig.Rows.Count == 0)
                    {

                        return 0;
                    }

                    string centerId;
                    centerId = dtCenterConfig.Rows[0]["id"].ToString();
                    sql.Clear();
                    sql.Append(" select code   from compensate_class_dict where code_comment = 'Y'and account_type = :arg_id and other_param = '2'");
                    OracleParameter[] paraClassDict = { new OracleParameter("arg_id", centerId) };
                    DataTable dtClassDict = Select(sql.ToString(), paraClassDict, "ClassDict");
                    if (dtClassDict.Rows.Count == 0)
                    {
                        outParm = "普通农合补偿类型没有设置， 请与系统管理员联系！";
                        return -1;
                    }

                    redeemNo = dtClassDict.Rows[0]["code"].ToString();
                }
                if (redeemNo.IsNull())
                {
                    paraName = "补偿类型";
                    goto ErrorReturn;
                }

                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                insuranceNo = Base64.EncodingString(insuranceNo);
                redeemNo = Base64.EncodingString(redeemNo);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                inpatientCalculateResult inpRedeemResult;

                string inParm;
                inParm = @"
                 redeemWebService.inpatientCalculate(" + operater + "," + password + "," + hospitalCode + "," + insuranceNo + "," + redeemNo + ", \"\", " + centerCode + ", \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inParm);
                inpRedeemResult = redeemWebService.inpatientCalculate(operater, password, hospitalCode, insuranceNo, redeemNo, "", centerCode, "", "", "", "");



                if (inpRedeemResult.sign.IsNull()) inpRedeemResult.sign = "";
                //if (inpRedeemResult.redeemno.IsNull()) inpRedeemResult.redeemno = "";
                if (inpRedeemResult.memberNo.IsNull()) inpRedeemResult.memberNo = "";
                if (inpRedeemResult.name.IsNull()) inpRedeemResult.name = "";
                if (inpRedeemResult.bookNo.IsNull()) inpRedeemResult.bookNo = "";
                if (inpRedeemResult.sexName.IsNull()) inpRedeemResult.sexName = "";
                if (inpRedeemResult.birthday.IsNull()) inpRedeemResult.birthday = "";
                if (inpRedeemResult.masterName.IsNull()) inpRedeemResult.masterName = "";
                if (inpRedeemResult.relationName.IsNull()) inpRedeemResult.relationName = "";
                if (inpRedeemResult.identityName.IsNull()) inpRedeemResult.identityName = "";
                if (inpRedeemResult.idCard.IsNull()) inpRedeemResult.idCard = "";
                if (inpRedeemResult.currYearRedeemCount.IsNull()) inpRedeemResult.currYearRedeemCount = "";
                if (inpRedeemResult.currYearTotal.IsNull()) inpRedeemResult.currYearTotal = "";
                if (inpRedeemResult.currYearEnableMoney.IsNull()) inpRedeemResult.currYearEnableMoney = "";
                if (inpRedeemResult.currYearReddemMoney.IsNull()) inpRedeemResult.currYearReddemMoney = "";
                if (inpRedeemResult.familyNo.IsNull()) inpRedeemResult.familyNo = "";
                if (inpRedeemResult.address.IsNull()) inpRedeemResult.address = "";
                if (inpRedeemResult.doorPropName.IsNull()) inpRedeemResult.doorPropName = "";
                if (inpRedeemResult.joinPropName.IsNull()) inpRedeemResult.joinPropName = "";
                if (inpRedeemResult.currFamilyRedeemCount.IsNull()) inpRedeemResult.currFamilyRedeemCount = "";
                if (inpRedeemResult.currFamilyTotal.IsNull()) inpRedeemResult.currFamilyTotal = "";
                if (inpRedeemResult.currFamilyEnableMoney.IsNull()) inpRedeemResult.currFamilyEnableMoney = "";
                if (inpRedeemResult.currFamilyReddemMoney.IsNull()) inpRedeemResult.currFamilyReddemMoney = "";
                if (inpRedeemResult.totalCosts.IsNull()) inpRedeemResult.totalCosts = "";
                if (inpRedeemResult.enableMoney.IsNull()) inpRedeemResult.enableMoney = "";
                if (inpRedeemResult.essentialMedicineMoney.IsNull()) inpRedeemResult.essentialMedicineMoney = "";
                if (inpRedeemResult.provinceMedicineMoney.IsNull()) inpRedeemResult.provinceMedicineMoney = "";
                if (inpRedeemResult.startMoney.IsNull()) inpRedeemResult.startMoney = "";
                //if (inpRedeemResult.checkMoney.IsNull()) inpRedeemResult.checkMoney = "";
                //if (inpRedeemResult.redeemMoney.IsNull()) inpRedeemResult.redeemMoney = "";
                if (inpRedeemResult.redeemTypeName.IsNull()) inpRedeemResult.redeemTypeName = "";
                //if (inpRedeemResult.checkDate.IsNull()) inpRedeemResult.checkDate = "";
                //if (inpRedeemResult.redeemDate.IsNull()) inpRedeemResult.redeemDate = "";
                if (inpRedeemResult.isSpecial.IsNull()) inpRedeemResult.isSpecial = "";
                if (inpRedeemResult.isPaul.IsNull()) inpRedeemResult.isPaul = "";
                //if (inpRedeemResult.feeList.IsNull()) inpRedeemResult.feeList = "";
                //if (inpRedeemResult.gradeList.IsNull()) inpRedeemResult.gradeList = "";
                if (inpRedeemResult.anlagernMoney.IsNull()) inpRedeemResult.anlagernMoney = "";
                if (inpRedeemResult.fundPayMoney.IsNull()) inpRedeemResult.fundPayMoney = "";
                if (inpRedeemResult.hospAssumeMoney.IsNull()) inpRedeemResult.hospAssumeMoney = "";
                if (inpRedeemResult.personalPayMoney.IsNull()) inpRedeemResult.personalPayMoney = "";
                if (inpRedeemResult.civilRedeemMoney.IsNull()) inpRedeemResult.civilRedeemMoney = "";
                if (inpRedeemResult.materialMoney.IsNull()) inpRedeemResult.materialMoney = "";

                if (inpRedeemResult.obligateOne.IsNull()) inpRedeemResult.obligateOne = "";
                if (inpRedeemResult.obligateTwo.IsNull()) inpRedeemResult.obligateTwo = "";
                if (inpRedeemResult.obligateThree.IsNull()) inpRedeemResult.obligateThree = "";
                if (inpRedeemResult.obligateFour.IsNull()) inpRedeemResult.obligateFour = "";
                if (inpRedeemResult.obligateFive.IsNull()) inpRedeemResult.obligateFive = "";
                if (centerName.IsNull()) centerName = "";

                inpRedeemResult.sign = Base64.DecodingString(inpRedeemResult.sign);
                //inpRedeemResult.redeemno = Base64.DecodingString(inpRedeemResult.redeemno);
                inpRedeemResult.memberNo = Base64.DecodingString(inpRedeemResult.memberNo);
                inpRedeemResult.name = Base64.DecodingString(inpRedeemResult.name);
                inpRedeemResult.bookNo = Base64.DecodingString(inpRedeemResult.bookNo);
                inpRedeemResult.sexName = Base64.DecodingString(inpRedeemResult.sexName);
                inpRedeemResult.birthday = Base64.DecodingString(inpRedeemResult.birthday);
                inpRedeemResult.masterName = Base64.DecodingString(inpRedeemResult.masterName);
                inpRedeemResult.relationName = Base64.DecodingString(inpRedeemResult.relationName);
                inpRedeemResult.identityName = Base64.DecodingString(inpRedeemResult.identityName);
                inpRedeemResult.idCard = Base64.DecodingString(inpRedeemResult.idCard);
                inpRedeemResult.currYearRedeemCount = Base64.DecodingString(inpRedeemResult.currYearRedeemCount);
                inpRedeemResult.currYearTotal = Base64.DecodingString(inpRedeemResult.currYearTotal);
                inpRedeemResult.currYearEnableMoney = Base64.DecodingString(inpRedeemResult.currYearEnableMoney);
                inpRedeemResult.currYearReddemMoney = Base64.DecodingString(inpRedeemResult.currYearReddemMoney);
                inpRedeemResult.familyNo = Base64.DecodingString(inpRedeemResult.familyNo);
                inpRedeemResult.address = Base64.DecodingString(inpRedeemResult.address);
                inpRedeemResult.doorPropName = Base64.DecodingString(inpRedeemResult.doorPropName);
                inpRedeemResult.joinPropName = Base64.DecodingString(inpRedeemResult.joinPropName);
                inpRedeemResult.currFamilyRedeemCount = Base64.DecodingString(inpRedeemResult.currFamilyRedeemCount);
                inpRedeemResult.currFamilyTotal = Base64.DecodingString(inpRedeemResult.currFamilyTotal);
                inpRedeemResult.currFamilyEnableMoney = Base64.DecodingString(inpRedeemResult.currFamilyEnableMoney);
                inpRedeemResult.currFamilyReddemMoney = Base64.DecodingString(inpRedeemResult.currFamilyReddemMoney);
                inpRedeemResult.totalCosts = Base64.DecodingString(inpRedeemResult.totalCosts);
                inpRedeemResult.enableMoney = Base64.DecodingString(inpRedeemResult.enableMoney);
                inpRedeemResult.essentialMedicineMoney = Base64.DecodingString(inpRedeemResult.essentialMedicineMoney);
                inpRedeemResult.provinceMedicineMoney = Base64.DecodingString(inpRedeemResult.provinceMedicineMoney);
                inpRedeemResult.startMoney = Base64.DecodingString(inpRedeemResult.startMoney);
                inpRedeemResult.calculateMoney = Base64.DecodingString(inpRedeemResult.calculateMoney);
                inpRedeemResult.redeemTypeName = Base64.DecodingString(inpRedeemResult.redeemTypeName);
                //inpRedeemResult.redeemDate = Base64.DecodingString(inpRedeemResult.redeemDate);
                inpRedeemResult.isSpecial = Base64.DecodingString(inpRedeemResult.isSpecial);
                inpRedeemResult.isPaul = Base64.DecodingString(inpRedeemResult.isPaul);
                //inpRedeemResult.isAduit = Base64.DecodingString(inpRedeemResult.isAduit);
                inpRedeemResult.anlagernMoney = Base64.DecodingString(inpRedeemResult.anlagernMoney);
                inpRedeemResult.fundPayMoney = Base64.DecodingString(inpRedeemResult.fundPayMoney);
                inpRedeemResult.hospAssumeMoney = Base64.DecodingString(inpRedeemResult.hospAssumeMoney);
                inpRedeemResult.personalPayMoney = Base64.DecodingString(inpRedeemResult.personalPayMoney);
                inpRedeemResult.civilRedeemMoney = Base64.DecodingString(inpRedeemResult.civilRedeemMoney);
                inpRedeemResult.materialMoney = Base64.DecodingString(inpRedeemResult.materialMoney);
                inpRedeemResult.obligateOne = Base64.DecodingString(inpRedeemResult.obligateOne);
                inpRedeemResult.obligateTwo = Base64.DecodingString(inpRedeemResult.obligateTwo);
                inpRedeemResult.obligateThree = Base64.DecodingString(inpRedeemResult.obligateThree);
                inpRedeemResult.obligateFour = Base64.DecodingString(inpRedeemResult.obligateFour);
                inpRedeemResult.obligateFive = Base64.DecodingString(inpRedeemResult.obligateFive);

                outParm = inpRedeemResult.sign + "|" /*+ inpRedeemResult.redeemno*/ + "|" + inpRedeemResult.memberNo + "|" +
                    inpRedeemResult.name + "|" + inpRedeemResult.bookNo + "|" + inpRedeemResult.sexName + "|" +
                    inpRedeemResult.birthday + "|" + inpRedeemResult.masterName + "|" + inpRedeemResult.relationName + "|" +
                    inpRedeemResult.identityName + "|" + inpRedeemResult.idCard + "|" + inpRedeemResult.currYearRedeemCount + "|" +
                    inpRedeemResult.currYearTotal + "|" + inpRedeemResult.currYearEnableMoney + "|" + inpRedeemResult.currYearReddemMoney + "|" +
                    inpRedeemResult.familyNo + "|" + inpRedeemResult.address + "|" + inpRedeemResult.doorPropName + "|" +
                    inpRedeemResult.joinPropName + "|" + inpRedeemResult.currFamilyRedeemCount + "|" + inpRedeemResult.currFamilyTotal + "|" +
                    inpRedeemResult.currFamilyEnableMoney + "|" + inpRedeemResult.currFamilyReddemMoney + "|" + inpRedeemResult.totalCosts + "|" +
                    inpRedeemResult.enableMoney + "|" + inpRedeemResult.essentialMedicineMoney + "|" + inpRedeemResult.provinceMedicineMoney + "|" +
                    inpRedeemResult.startMoney + "|" + inpRedeemResult.calculateMoney + "|" + inpRedeemResult.redeemTypeName + "|" +
                    /*inpRedeemResult.redeemDate*/  "|" + inpRedeemResult.isSpecial + "|" + inpRedeemResult.isPaul + "|" +
                    /*inpRedeemResult.isAduit*/  "|" + //inpRedeemResult.feeList + "|" + inpRedeemResult.gradeList + "|" +
                    inpRedeemResult.anlagernMoney + "|" + inpRedeemResult.fundPayMoney + "|" + inpRedeemResult.hospAssumeMoney + "|" +
                    inpRedeemResult.personalPayMoney + "|" + inpRedeemResult.civilRedeemMoney + "|" +
                    inpRedeemResult.materialMoney + "|" + inpRedeemResult.obligateOne + "|" + inpRedeemResult.obligateTwo + "|" +
                    inpRedeemResult.obligateThree + "|" + inpRedeemResult.obligateFour + "|" + inpRedeemResult.obligateFive + "|" +
                    centerName + "|";
                Log4NetHelper.Info(outParm);

            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B014 住院补偿试算（扩展函数）inpatientCalculate", ex);
                try
                {
                    outParm = ex.Message;
                    string errMsg = "";
                    if (Base64.IsBase64Formatted(outParm))
                    {
                        errMsg = Base64.DecodingString(outParm);
                    }
                    if (Base64.IsBase64Formatted(errMsg))
                    {
                        errMsg = Base64.DecodingString(errMsg);
                    }
                    if (errMsg.IsNull())
                    {
                        Log4NetHelper.Error(outParm);
                    }
                    else
                    {
                        Log4NetHelper.Error(errMsg);
                        outParm = errMsg;
                    }
                }
                catch (Exception eo)
                {
                    outParm = ex.Message;
                }

                return -1;
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region B015 住院登记修改（扩展函数）
        public int inpatientUpdate(string rateType, string centerCodeEx, string insuranceNo, string residenceNo, string diagnosisCode, string diagnosisCode2,
            string treatCode, string admissionDept,
            string admissionTime, string registType, string admissionCondition, string doctor, string bedNo, string ward, string turnCode, out string outParm)
        {
            BasicInformationDAL basicInfoDAL = new BasicInformationDAL();

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();

            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;

            try
            {
                //测试连接
                //basicInfoDAL.testConn(rateType);
                #region response初始化
                StringBuilder sql = new StringBuilder();

                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName;
                string organizationCode, organizationKey;
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password,
                    out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);
                string regionCode;
                regionCode = basicInfoDAL.getRateRegionCode(rateType);
                if (regionCode == "999999")
                {
                    centerCode = centerCodeEx;
                    hospitalCode = organizationCode;
                }

                #endregion
                string turnMode;

                if (residenceNo.IsNull())
                {
                    paraName = "本院信院号";
                    goto ErrorReturn;
                }
                if (operater.IsNull())
                {
                    paraName = "农合中心操作员";
                    goto ErrorReturn;
                }

                if (password.IsNull())
                {
                    paraName = "农合中心密码";
                    goto ErrorReturn;
                }

                if (hospitalCode.IsNull())
                {
                    paraName = "医疗机构编码";
                    goto ErrorReturn;
                }

                if (centerCode.IsNull())
                {
                    paraName = "农合中心编码";
                    goto ErrorReturn;
                }


                if (diagnosisCode.IsNull())
                {
                    paraName = "农合诊断";
                    goto ErrorReturn;
                }

                if (admissionDept.IsNull())
                {
                    paraName = "就诊科室";
                    goto ErrorReturn;
                }

                if (admissionTime.IsNull())
                {
                    paraName = "就诊时间";
                    goto ErrorReturn;
                }

                if (doctor.IsNull())
                {
                    paraName = "经治医生";
                    goto ErrorReturn;
                }

                if (diagnosisCode2.IsNull()) diagnosisCode2 = "";
                if (bedNo.IsNull()) bedNo = "";
                if (ward.IsNull()) ward = "";
                if (treatCode.IsNull()) treatCode = "";
                if (turnCode.IsNull())
                {
                    turnMode = "0";
                    turnCode = "";
                }
                else
                {
                    turnMode = "1";
                }

                if (registType == "0")
                {
                    registType = "1";
                }
                else
                {
                    registType = "2";
                }
                switch (admissionCondition)
                {
                    case "1":
                    case "2":
                    case "3":
                        break;
                    default:
                        admissionCondition = "9";
                        break;
                }

                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                insuranceNo = Base64.EncodingString(insuranceNo);
                hospitalCode = Base64.EncodingString(hospitalCode);
                residenceNo = Base64.EncodingString(residenceNo);
                diagnosisCode = Base64.EncodingString(diagnosisCode);
                diagnosisCode2 = Base64.EncodingString(diagnosisCode2);
                treatCode = Base64.EncodingString(treatCode);
                admissionDept = Base64.EncodingString(admissionDept);
                registType = Base64.EncodingString(registType);
                admissionCondition = Base64.EncodingString(admissionCondition);
                doctor = Base64.EncodingString(doctor);
                bedNo = Base64.EncodingString(bedNo);
                ward = Base64.EncodingString(ward);
                admissionTime = Base64.EncodingString(admissionTime);
                turnMode = Base64.EncodingString(turnMode);
                turnCode = Base64.EncodingString(turnCode);

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                inpatientRegisterResult inpRegisterResult;

                string inPara;
                inPara = "redeemWebService.inpatientUpdate(" + operater + "," + password + ", " + insuranceNo + ", " + hospitalCode + ", " + residenceNo + ", ";
                inPara += "                               \"\", \"\"," + diagnosisCode + "," + diagnosisCode2 + ", \"\",";
                inPara += "                               " + treatCode + "," + admissionDept + ", " + admissionTime + "," + registType + ", \"\"," + admissionCondition + "," + doctor + "," + bedNo + ",";
                inPara += "                               " + ward + "," + turnMode + "," + turnCode + ", \"\", \"\", \"\", \"\", \"\",";
                inPara += "                                                            \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inPara);
                inpRegisterResult = redeemWebService.inpatientUpdate(operater, password, insuranceNo, hospitalCode, residenceNo,
                                                                            "", "", diagnosisCode, diagnosisCode2, "",
                                                                            treatCode, admissionDept, admissionTime, registType, "", admissionCondition, doctor, bedNo,
                                                                             ward, turnMode, turnCode, "", "", "", "", "",
                                                                            "", "", "", "");
                if (inpRegisterResult.obligateOne.IsNull()) inpRegisterResult.obligateOne = "";
                if (inpRegisterResult.obligateTwo.IsNull()) inpRegisterResult.obligateTwo = "";
                if (inpRegisterResult.obligateThree.IsNull()) inpRegisterResult.obligateThree = "";
                if (inpRegisterResult.obligateFour.IsNull()) inpRegisterResult.obligateFour = "";
                if (inpRegisterResult.obligateFive.IsNull()) inpRegisterResult.obligateFive = "";
                inpRegisterResult.inpatientSn = Base64.DecodingString(inpRegisterResult.inpatientSn);
                inpRegisterResult.obligateOne = Base64.DecodingString(inpRegisterResult.obligateOne);
                inpRegisterResult.obligateTwo = Base64.DecodingString(inpRegisterResult.obligateTwo);
                inpRegisterResult.obligateThree = Base64.DecodingString(inpRegisterResult.obligateThree);
                inpRegisterResult.obligateFour = Base64.DecodingString(inpRegisterResult.obligateFour);
                inpRegisterResult.obligateFive = Base64.DecodingString(inpRegisterResult.obligateFive);

                outParm = inpRegisterResult.inpatientSn + "|" + inpRegisterResult.obligateOne + "|" + inpRegisterResult.obligateTwo + "|" +
                    inpRegisterResult.obligateThree + "|" + inpRegisterResult.obligateFour + "|" + inpRegisterResult.obligateFive + "|";
                Log4NetHelper.Info(outParm);

            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("B015 住院登记修改", ex);
                return basicInfoDAL.getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion
    }

}
