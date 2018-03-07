using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Zysoft.FrameWork.Database;
using Zysoft.FrameWork;
using Zysoft.FrameWork.XML;

namespace Zysoft.ZyExternal.DAL.RuralInsur
{
    public class BasicInformationDAL : DB
    {
        #region 获取异常
        public int getException(out string outParm, Exception ex)
        {
            try
            {
                outParm = ex.Message;
                string errMsg = "";
                if (Base64.IsBase64Formatted(outParm))
                {
                    errMsg = Base64.DecodingString(outParm);
                }
                if (errMsg.IsNotNull())
                {
                    if (Base64.IsBase64Formatted(errMsg))
                    {
                        errMsg = Base64.DecodingString(errMsg);
                    }
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
        #endregion

        #region 调用外部webservice

        public string getRateRegionCode(string rateType)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Clear();
            sSql.Append(@"select nvl(region_code, '00000') region_code
                            from rate_type_dict 
                           where rate_type_code = :arg_rate_type");
            OracleParameter[] paraCenterConfig = { new OracleParameter("arg_rate_type", rateType) };
            DataTable dtCenterConfig = Select(sSql.ToString(), paraCenterConfig, "CenterConfig");
            if (dtCenterConfig.Rows.Count == 0)
            {

                return "";
            }
            string regionCode;
            regionCode = dtCenterConfig.Rows[0]["region_code"].ToString().Trim();

            return regionCode;
        }

        public int getRuralLoginInfo(string rateType, out string serviceUrl, out string organizationCode, out string organizationKey)
        {
            string centerName;
            string centerCode;
            string softwareFactory, operater, password, hospitalCode, hospitalName;

            return getRuralLoginInfo(rateType, out serviceUrl, out  softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName,
                                      out organizationCode, out organizationKey, out hospitalName);
        }

        public int getRuralLoginInfo(string rateType, out string serviceUrl, out string softwareFactory, out string operater, out string password,
            out string hospitalCode, out string centerCode)
        {
            string centerName;

            return getRuralLoginInfo(rateType, out serviceUrl, out  softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName);
        }

        public int getRuralLoginInfo(string rateType, out string serviceUrl, out string softwareFactory, out string operater, out string password,
            out string hospitalCode, out string centerCode, out string centerName)
        {
            string organizationCode, organizationKey;
            return getRuralLoginInfo(rateType, out serviceUrl, out  softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName,
                                      out organizationCode, out organizationKey);

        }

        public int getRuralLoginInfo(string rateType, out string serviceUrl, out string softwareFactory, out string operater, out string password,
            out string hospitalCode, out string centerCode, out string centerName, out string organizationCode, out string organizationKey)
        {
            string hospitalName;
            return getRuralLoginInfo(rateType, out serviceUrl, out  softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName,
                                      out organizationCode, out organizationKey, out hospitalName);
        }

        public int getRuralLoginInfo(string rateType, out string serviceUrl, out string softwareFactory, out string operater, out string password,
            out string hospitalCode, out string centerCode, out string centerName, out string organizationCode,
            out string organizationKey, out string hospitalName)
        {
            password = operater = serviceUrl = hospitalCode = centerCode = centerName = organizationCode = organizationKey = "";
            softwareFactory = hospitalName = "";

            StringBuilder sSql = new StringBuilder();
            sSql.Clear();
            sSql.Append(@"select * from hospital_vs_center_config where rate_type = :arg_rate_type");
            OracleParameter[] paraCenterConfig = { new OracleParameter("arg_rate_type", rateType) };
            DataTable dtCenterConfig = Select(sSql.ToString(), paraCenterConfig, "CenterConfig");
            if (dtCenterConfig.Rows.Count == 0)
            {

                return -1;
            }
            serviceUrl = dtCenterConfig.Rows[0]["CENTER_URL"].ToString().Trim();
            centerCode = dtCenterConfig.Rows[0]["CENTER_CODE"].ToString().Trim();
            centerName = dtCenterConfig.Rows[0]["CENTER_NAME"].ToString().Trim();
            softwareFactory = dtCenterConfig.Rows[0]["SOFTWARE_FACTORY"].ToString().Trim();
            if (DBConnectArgument.partFlag == "B")
            {
                operater = dtCenterConfig.Rows[0]["CENTER_USER_2"].ToString().Trim();
                password = dtCenterConfig.Rows[0]["CENTER_PASSWORD_2"].ToString().Trim();
                hospitalCode = dtCenterConfig.Rows[0]["HOSPITAL_CODE_2"].ToString().Trim();
                hospitalName = dtCenterConfig.Rows[0]["HOSPITAL_NAME_2"].ToString().Trim();

                organizationCode = dtCenterConfig.Rows[0]["ORGANIZATION_CODE_2"].ToString().Trim();
                organizationKey = dtCenterConfig.Rows[0]["ORGANIZATION_KEY_2"].ToString().Trim();
            }
            else
            {
                operater = dtCenterConfig.Rows[0]["CENTER_USER"].ToString().Trim();
                password = dtCenterConfig.Rows[0]["CENTER_PASSWORD"].ToString().Trim();
                hospitalCode = dtCenterConfig.Rows[0]["HOSPITAL_CODE"].ToString().Trim();
                hospitalName = dtCenterConfig.Rows[0]["HOSPITAL_NAME"].ToString().Trim();

                organizationCode = dtCenterConfig.Rows[0]["ORGANIZATION_CODE"].ToString().Trim();
                organizationKey = dtCenterConfig.Rows[0]["ORGANIZATION_KEY"].ToString().Trim();
            }

            return 0;
        }
        #endregion

        #region A001 获取病人信息函数获取病人信息函数 getPersonInfo
        /// <summary>
        ///  A001 获取病人信息函数获取病人信息函数
        /// </summary>
        /// <param name="bookno"></param>
        /// <param name="operater"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int getPersonInfo(string rateType, string bookno, out string outParm)
        {

            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;
            string operater;

            try
            {

                //测试连接
                testConn(rateType);

                #region response初始化
                StringBuilder sql = new StringBuilder();

                string password, softwareFactory;
                string hospitalCode, centerCode;
                getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode);

                #endregion
                if (bookno.IsNull())
                {
                    paraName = "家庭编号";
                    goto ErrorReturn;
                }
                if (operater.IsNull())
                {
                    paraName = "操作员";
                    goto ErrorReturn;
                }

                sql.Clear();
                sql.Append(@"delete from family_member_record
				                where book_no = :arg_id_cardno 
				                    or id_cardno = :arg_id_cardno
				                    or card_no = :arg_id_cardno");
                OracleParameter[] paraDelFamily = { new OracleParameter("arg_id_cardno", bookno) };
                Insert(sql.ToString(), paraDelFamily);

                bookno = Base64.EncodingString(bookno);
                operater = Base64.EncodingString(operater);
                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                string inPara;
                inPara = "redeemWebService.getPersonInfo(" + bookno + ", " + operater + ")";
                Member[] members;
                Log4NetHelper.Info(inPara);
                members = redeemWebService.getPersonInfo(bookno, operater);

               

                foreach (Member member in members)
                {
                    member.memberNO = Base64.DecodingString(member.memberNO);
                    member.name = Base64.DecodingString(member.name);
                    member.countryTeamCode = Base64.DecodingString(member.countryTeamCode);
                    member.familySysno = Base64.DecodingString(member.familySysno);
                    member.idcardNo = Base64.DecodingString(member.idcardNo);
                    member.age = Base64.DecodingString(member.age);
                    member.birthday = Base64.DecodingString(member.birthday);
                    member.bookNo = Base64.DecodingString(member.bookNo);
                    member.cardNo = Base64.DecodingString(member.cardNo);
                    member.familyAddress = Base64.DecodingString(member.familyAddress);
                    member.tel = Base64.DecodingString(member.tel);
                    member.sexId = Base64.DecodingString(member.sexId);
                    member.ideName = Base64.DecodingString(member.ideName);
                }

                long count = 0;

                foreach (Member member in members)
                {
                    sql.Clear();
                    sql.Append(@"delete from family_member_record
				                where member_no = :arg_member_no 
				                    or id_cardno = :arg_id_cardno");
                    OracleParameter[] paraDelMember = { new OracleParameter("arg_member_no", member.memberNO),
                                                            new OracleParameter("arg_id_cardno", member.idcardNo)};
                    Insert(sql.ToString(), paraDelMember);
                    sql.Clear();
                    sql.Append(@"insert into
                                  family_member_record
                                    (
                                    member_no        	,
                                    name             	,
                                    country_team_code	,
                                    family_sysno     	,
                                    sex              	,
                                    id_cardno        	,
                                    age              	,
                                    birthday         	,
                                    book_no          	,
                                    card_no          	,
                                    family_address   	,
                                    tel              	,
                                    ide_name )
                                  values(
                                    :arg_member_no        	,
                                    :arg_name             	,
                                    :arg_country_team_code	,
                                    :arg_family_sysno     	,
                                    :arg_sex              	,
                                    :arg_id_cardno        	,
                                    :arg_age              	,
                                    :arg_birthday         	,
                                    :arg_book_no          	,
                                    :arg_card_no          	,
                                    :arg_family_address   	,
                                    :arg_tel              	,
                                    :arg_ide_name )");
                    OracleParameter[] paraAddMember = { new OracleParameter("arg_member_no", member.memberNO),
                                                            new OracleParameter("arg_name", member.name),
                                                            new OracleParameter("arg_country_team_code", member.countryTeamCode),
                                                            new OracleParameter("arg_family_sysno", member.familySysno),
                                                            new OracleParameter("arg_sex", member.sexId),
                                                            new OracleParameter("arg_id_cardno", member.idcardNo),
                                                            new OracleParameter("arg_age", member.age),
                                                            new OracleParameter("arg_birthday", member.birthday),
                                                            new OracleParameter("arg_book_no", member.bookNo),
                                                            new OracleParameter("arg_card_no", member.cardNo),
                                                            new OracleParameter("arg_family_address", member.familyAddress),
                                                            new OracleParameter("arg_tel", member.tel),
                                                            new OracleParameter("arg_ide_name", member.ideName)};
                    Insert(sql.ToString(), paraAddMember);
                    count++;
                    outParm = member.bookNo;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("A001 获取病人信息函数获取病人信息函数 getPersonInfo", ex);
                return getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }

  
        #endregion

        #region A002 获取医疗机构信息函数 getHospitalInfo
        /// <summary>
        /// A002 获取医疗机构信息函数 getHospitalInfo
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int getHospitalInfo(string rateType, out string outParm)
        {

            outParm = "";
            try
            {
                StringBuilder sql = new StringBuilder();


                string password, softwareFactory;
                string hospitalCode, centerCode, serviceURL, operater;
                string centerName, organizationCode, organizationKey, hospitalName;
                getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, 
                    out centerCode,out centerName, out organizationCode, out organizationKey,
                    out hospitalName);


                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                //Zysoft.ZyExternal.DAL1.InpatientRedeemWebServiceImpPort redeemWebService = new Zysoft.ZyExternal.DAL1.InpatientRedeemWebServiceImpPort();

                redeemWebService.Url = serviceURL;
               
                hospitalName = Base64.EncodingString(hospitalName);

                string inParm;
                inParm = "redeemWebService.getHospitalInfo(" + hospitalName + ")";
                Log4NetHelper.Info(inParm);
                hospitalResult[] hospitalResults = redeemWebService.getHospitalInfo(hospitalName);
            
                foreach (hospitalResult hospResult in hospitalResults)
                {
                    hospResult.hospCode = Base64.DecodingString(hospResult.hospCode);
                    hospResult.hospLevel = Base64.DecodingString(hospResult.hospLevel);
                    hospResult.hospName = Base64.DecodingString(hospResult.hospName);
                    outParm += hospResult.hospCode + "^" + hospResult.hospLevel + "^" + hospResult.hospName + "|";
                }

                //outParm = Base64.DecodingString(outParm);
                //Log4NetHelper.Info(outParm);
            }
            catch (Exception ex)
            {

                Log4NetHelper.Error("A002 获取医疗机构信息函数 getHospitalInfo）", ex);
                return getException(out outParm, ex);
            }
            return 0;

        }
        #endregion

        #region A003 补偿类别字典下载redeemTypeDownLoad
        /// <summary>
        ///  A003 补偿类别字典下载redeemTypeDownLoad
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int redeemTypeDownLoad(string rateType, out string outParm)
        {
            try
            {
                //测试连接
                //testConn(rateType);
                outParm = "";
                StringBuilder sql = new StringBuilder();
                UtilityDAL utilityDAL = new UtilityDAL();

                string password, softwareFactory;
                string hospitalCode, centerCode, serviceURL, operater;
                getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode);
                string accountType;
                sql.Clear();
                sql.Append(@"select * from hospital_vs_center_config where rate_type = :arg_rate_type");
                OracleParameter[] paraCenterConfig = { new OracleParameter("arg_rate_type", rateType)};
                DataTable dtCenterConfig = Select(sql.ToString(), paraCenterConfig, "CenterConfig");
                if (dtCenterConfig.Rows.Count == 0)
                {
                    outParm = "费别无效,没有记录!";
                    return -1;
                }
                accountType = dtCenterConfig.Rows[0]["ID"].ToString();

                string year;
                year = DateTime.Now.ToString("yyyy");

                string code, name;
                string otherParam, codeComment, parentCode; 
                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                string inPara;
                inPara = "redeemWebService.redeemTypeDownLoad(" + hospitalCode + "," + operater + "," + year + ", \"\", \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inPara);
                LogTextHelper.Info(inPara);

                hospitalCode = Base64.EncodingString(hospitalCode);
                operater = Base64.EncodingString(operater);

                inPara = "redeemWebService.redeemTypeDownLoad(" + hospitalCode + "," + operater + ", " + year + ", \"\", \"\", \"\", \"\", \"\")";
                Log4NetHelper.Info(inPara);
                LogTextHelper.Info(inPara);

                redeemTypeDownLoadResult[] redeemTypeResults = redeemWebService.redeemTypeDownLoad(hospitalCode, operater, year, "", "", "", "", "");
                if (redeemTypeResults.Length == 0)
                {
                    outParm = "下载记录数为0！";
                    return -1;
                }

                sql.Clear();
                sql.Append(@"delete from compensate_class_dict
				                where account_type = :arg_account_type");
                OracleParameter[] paraIcdDict = { new OracleParameter("arg_account_type", accountType) };
                Insert(sql.ToString(), paraIcdDict);

                long count = 0;
                foreach (redeemTypeDownLoadResult redeemTypeResult in redeemTypeResults)
                {
                    code = redeemTypeResult.code;
                    name = redeemTypeResult.name;
                    otherParam = redeemTypeResult.otherParam;
                    codeComment = redeemTypeResult.comment;
                    parentCode = redeemTypeResult.otherParam;

                    code = Base64.DecodingString(code);
                    name = Base64.DecodingString(name);
                    otherParam = Base64.DecodingString(otherParam);
                    codeComment = Base64.DecodingString(codeComment);
                    parentCode = Base64.DecodingString(parentCode);


                    sql.Clear();
                    sql.Append(@"insert into
                                  compensate_class_dict
                                    (
                                    code	            ,
                                    name     	        ,
                                    other_param         ,
                                    code_comment        ,
                                    account_type        ,
                                    parent_code  )
                                  values(
                                    :arg_code	            ,
                                    :arg_name     	        ,
                                    :arg_other_param         ,
                                    :arg_code_comment        ,
                                    :arg_account_type        ,
                                    :arg_parent_code )");
                    OracleParameter[] paraClassDict = { 
                                                            new OracleParameter("arg_code",code.Trim()), 
                                                            new OracleParameter("arg_name", name.Trim()),
                                                            new OracleParameter("arg_other_param", otherParam.Trim()),
                                                            new OracleParameter("arg_code_comment", codeComment.Trim()),
                                                            new OracleParameter("arg_account_type", accountType.Trim()),
                                                            new OracleParameter("arg_parent_code",parentCode.Trim())};
                    Insert(sql.ToString(), paraClassDict);
                    count++;
                }

                outParm = "共完成" + count.ToString() + "条记录的下载";
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error(" A003 补偿类别字典下载redeemTypeDownLoad", ex);
                return getException(out outParm, ex);
            }
            return 0;
        }
        #endregion

        #region A004 科室信息下载officeCodeDown
        /// <summary>
        /// A004 科室信息下载officeCodeDown
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="updateTime"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int getOfficeCodeDown(string rateType, out string outParm)
        {


            try
            {
                //测试连接
                testConn(rateType);
                outParm = "";
                StringBuilder sql = new StringBuilder();
                UtilityDAL utilityDAL = new UtilityDAL();

                string password, softwareFactory;
                string hospitalCode, centerCode, serviceURL, operater;
                getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode);

                string code, name;

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;

                officeResult[] officeCodes = redeemWebService.officeCodeDown(hospitalCode, operater);
                if (officeCodes.Length == 0)
                {
                    outParm = "下载记录数为0！";
                    return -1;
                }

                string presRateType;
                presRateType = "0"; //写死为省农合对照！
                long count = 0;
                foreach (officeResult officeDict in officeCodes)
                {
                    code = officeDict.code;
                    name = officeDict.name;
                    code = Base64.DecodingString(code);
                    name = Base64.DecodingString(name);
                    sql.Clear();
                    sql.Append(@"delete from insur_base_dict
				                where dict_type = '1' 
				                  and insur_rate_type = :arg_rate_type
                                  and code = :agr_dept_code");
                    OracleParameter[] paraIcdDict = { new OracleParameter("arg_rate_type", presRateType),
                                                            new OracleParameter("agr_dept_code", code)};
                    Insert(sql.ToString(), paraIcdDict);
                    sql.Clear();
                    sql.Append(@"insert into
                                  insur_base_dict
                                    (
                                    dict_type        	,
                                    insur_rate_type     ,
                                    code	            ,
                                    name     	        ,
                                    valid_flag          ,
                                    spell_code        	,
                                    memo              	,
                                    wbzx_code  )
                                  values(
                                    '1'        	,
                                    :arg_insur_rate_type     ,
                                    :arg_code	            ,
                                    :arg_name     	        ,
                                    'Y'          ,
                                    :arg_spell_code        	,
                                    :arg_memo              	,
                                    :arg_wbzx_code )");
                    OracleParameter[] paraAddMember = { 
                                                            new OracleParameter("arg_insur_rate_type", presRateType),
                                                            new OracleParameter("arg_code",code),
                                                            new OracleParameter("arg_name", name),
                                                            new OracleParameter("arg_spell_code", utilityDAL.GetSpellCode(name)),
                                                            new OracleParameter("arg_memo",  Base64.DecodingString(officeDict.comment)),
                                                            new OracleParameter("arg_wbzx_code",utilityDAL.GetWbzxCode(name))};
                    Insert(sql.ToString(), paraAddMember);
                    count++;
                }

                outParm = "共完成" + count.ToString() + "条记录的下载";
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("A004 科室信息下载officeCodeDown", ex);
                return getException(out outParm, ex);
            }
            return 0;
        }
        #endregion

        #region A005 治疗方式下载treatmentModeUpdate
        /// <summary>
        /// A005 治疗方式下载treatmentModeUpdate
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int treatmentModeUpdate(string rateType, out string outParm)
        {
            try
            {
                //测试连接
                testConn(rateType);
                outParm = "";
                StringBuilder sql = new StringBuilder();
                UtilityDAL utilityDAL = new UtilityDAL();

                string password, softwareFactory;
                string hospitalCode, centerCode, serviceURL, operater;
                getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode);
               
                string code, name, nameSpell;
                string runYear;
                runYear = DateTime.Now.Year.ToString();
                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;

                hospitalCode = Base64.EncodingString(hospitalCode);
                operater = Base64.EncodingString(operater);
                password = Base64.EncodingString(password);
                runYear = Base64.EncodingString(runYear);
                string inParm;
                inParm = @"redeemWebService.treatmentModeUpdate(" + operater + ", " + password + ", " + hospitalCode + ", " + runYear + ", \"\", \"\", \"\", \"\", \"\")";

                treatmentModeResult[] treatmentModeResults = redeemWebService.treatmentModeUpdate(operater, password, hospitalCode, runYear, "", "", "", "", "");
                if (treatmentModeResults.Length == 0)
                {
                    outParm = "下载记录数为0！";
                    return -1;
                }

                rateType = "0";

                sql.Clear();
                sql.Append(@"delete  INSURANCE_DISEAS_DICT 
                              where rate_type = :arg_rate_type");
                OracleParameter[] paraIcdDict = { new OracleParameter("arg_rate_type", rateType)};
                Insert(sql.ToString(), paraIcdDict);

                string remark, diseaseCode, diseaseName, diseaseNameSpell;
                long count=0;
                foreach (treatmentModeResult treaModeResult in treatmentModeResults)
                {
                    code = treaModeResult.code;
                    name = treaModeResult.name;
                    remark = treaModeResult.remark;
                    code = Base64.DecodingString(code);
                    name = Base64.DecodingString(name);
                    remark = Base64.DecodingString(remark);

                    nameSpell = utilityDAL.GetSpellCode(name);
                    foreach (treatmentDiseaseResult treadisResult in treaModeResult.diseaseList)
                    {
                        diseaseCode = treadisResult.diseaseCode;
                        diseaseName = treadisResult.diseaseName;
                        diseaseCode = Base64.DecodingString(diseaseCode);
                        diseaseName = Base64.DecodingString(diseaseName);
                        diseaseNameSpell = utilityDAL.GetSpellCode(diseaseName);

                        sql.Clear();
                        sql.Append(@"insert into
                                        insurance_diseas_dict
                                        (
                                        insurance_diseas_code	            ,
                                        insurance_diseas_name     	        ,
                                        spell_code         ,
                                        valid_flag        ,
                                        rate_type ,
                                        insur_regist_type,
                                        io_flag)
                                        values(
                                        :arg_insurance_diseas_code	            ,
                                        :arg_insurance_diseas_name    	        ,
                                        :arg_spell_code         ,
                                        :arg_valid_flag       ,
                                        :arg_rate_type ,
                                        '13',
                                        '0')");
                        OracleParameter[] paraClassDict = { 
                                                    new OracleParameter("arg_insurance_diseas_code",diseaseCode+"^"+code),
                                                    new OracleParameter("arg_insurance_diseas_name",diseaseName+"^"+name), 
                                                    new OracleParameter("arg_spell_code", diseaseNameSpell),
                                                    new OracleParameter("arg_valid_flag", "Y"),
                                                    new OracleParameter("arg_rate_type", rateType)};
                        Insert(sql.ToString(), paraClassDict);
                        count++;
                    }
//                    foreach (treatmentDiseaseResult treadisResult in treaModeResult.diseaseList)
//                    {
//                        diseaseCode = treadisResult.diseaseCode;
//                        diseaseName = treadisResult.diseaseName;
//                        diseaseCode = Base64.DecodingString(diseaseCode);
//                        diseaseName = Base64.DecodingString(diseaseName);
//                        diseaseNameSpell = utilityDAL.GetSpellCode(diseaseName);

//                        sql.Clear();
//                        sql.Append(@"insert into
//                                                  treatment_mode_dict
//                                                    (
//                                                    treatcode	            ,
//                                                    treatname     	        ,
//                                                    icdno         ,
//                                                    icdname        ,
//                                                    spell_code_1        ,
//                                                    spell_code_2        ,
//                                                    codecomment ,
//                                                    rate_type)
//                                                  values(
//                                                    :arg_treatcode	            ,
//                                                    :arg_treatname     	        ,
//                                                    :arg_icdno         ,
//                                                    :arg_icdname        ,
//                                                    :arg_spell_code_1        ,
//                                                    :arg_spell_code_2   ,
//                                                    :arg_codecomment ,
//                                                    :arg_rate_type )");
//                        OracleParameter[] paraClassDict = { 
//                                                                            new OracleParameter("arg_rate_type",rateType),
//                                                                            new OracleParameter("arg_treatcode",code), 
//                                                                            new OracleParameter("arg_treatname", name),
//                                                                            new OracleParameter("arg_icdno", diseaseCode),
//                                                                            new OracleParameter("arg_icdname", diseaseName),
//                                                                            new OracleParameter("arg_spell_code_1", nameSpell),
//                                                                            new OracleParameter("arg_spell_code_2",diseaseNameSpell),
//                                                                            new OracleParameter("arg_codecomment",remark)};
//                        Insert(sql.ToString(), paraClassDict);
//                        count++;
//                    }
                }

                outParm = "共完成" + count.ToString() + "条记录的下载到insurance_diseas_dict表";
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("A005 治疗方式下载treatmentModeUpdate", ex);
                return getException(out outParm, ex);
            }
            return 0;
        }
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
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int uploadReferralsheet(string rateType, string infoType, string turnCode, string safetyNo,
                                  string idCardNo, string sickName, string sexName, string birthday, string insurCardNo,
                                  string phoneNo, string turnType, string icdCode, string icdName, string beginDate,
                                  string fromHospCode, string fromHospName, string toHospCode, string toHospName,
                                  string cityType, string toHospLevel,
                                  string remark, out string outParm)
        {


            try
            {
                //测试连接
                //testConn(rateType);
                outParm = "";
                StringBuilder sql = new StringBuilder();
                UtilityDAL utilityDAL = new UtilityDAL();

                string password, softwareFactory;
                string hospitalCode, centerCode, centerName, serviceURL, operater;
                string organizationCode, organizationKey;
                getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName, out organizationCode, out organizationKey);


                string sType = "1";
                if (turnCode.IsNotNull()) sType = "2";  //不为空， 则进行修改

                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                //Zysoft.ZyExternal.DAL1.InpatientRedeemWebServiceImpPort redeemWebService = new Zysoft.ZyExternal.DAL1.InpatientRedeemWebServiceImpPort();

                redeemWebService.Url = serviceURL;
                string temp, tempDate;
                temp = "1";
                tempDate = DateTime.Now.ToString("yyyy-MM-dd");
                string inParm;
                inParm = "redeemWebService.uploadReferralsheet(" + hospitalCode + "," + centerCode + "," + turnCode + "," + sType + "," + safetyNo + "," + idCardNo + ",";
                inParm += "                                     " + sickName + "," + sexName + "," + birthday + "," + insurCardNo + "," + phoneNo + "," + turnType + "," + icdCode + ",";
                inParm += "                                     " + icdName + "," + beginDate + "," + fromHospCode + "," + fromHospName + "," + toHospCode + ",";
                inParm += "                                     " + toHospName + "," + cityType + "," + toHospLevel + "," + tempDate + "," + temp + ",";
                inParm += "                                     " + temp + "," + temp + "," + temp + "," + remark + ",";
                inParm += "                                     " + temp + "," + temp + "," + temp + "," + temp + "," + temp + ")";
                
                Log4NetHelper.Info(inParm);
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                turnCode = Base64.EncodingString(turnCode);
                sType = Base64.EncodingString(sType);
                safetyNo = Base64.EncodingString(safetyNo);
                idCardNo = Base64.EncodingString(idCardNo);
                sickName = Base64.EncodingString(sickName);
                birthday = Base64.EncodingString(birthday);
                insurCardNo = Base64.EncodingString(insurCardNo);
                turnType = Base64.EncodingString(turnType);
                icdCode = Base64.EncodingString(icdCode);
                icdName = Base64.EncodingString(icdName);
                beginDate = Base64.EncodingString(beginDate);
                cityType = Base64.EncodingString(cityType);
                toHospLevel = Base64.EncodingString(toHospLevel);
                remark = Base64.EncodingString(remark);
                fromHospCode = Base64.EncodingString(fromHospCode);
                fromHospName = Base64.EncodingString(fromHospName);
                toHospCode = Base64.EncodingString(toHospCode);
                toHospName = Base64.EncodingString(toHospName);
                sexName = Base64.EncodingString(sexName);
                phoneNo = Base64.EncodingString(phoneNo);

                temp = Base64.EncodingString(temp);
                tempDate = Base64.EncodingString(tempDate);
               
                inParm = "redeemWebService.uploadReferralsheet("+hospitalCode+","+ centerCode+","+ turnCode+","+ sType+","+ safetyNo+","+ idCardNo+",";
                inParm += "                                     " + sickName + "," + sexName + "," + birthday + "," + insurCardNo + "," + phoneNo + "," + turnType + "," + icdCode + ",";
                inParm += "                                     "    +    icdName+","+ beginDate+","+ fromHospCode+","+ fromHospName+","+ toHospCode+",";
                inParm += "                                     "    +     toHospName+","+ cityType+","+ toHospLevel+","+ tempDate+","+temp+",";
                inParm += "                                     "    +         temp+","+ temp+","+ temp+","+ remark+",";
                inParm += "                                     "    +           temp+","+temp+","+ temp+","+ temp+","+ temp+")";
                Log4NetHelper.Info(inParm);

                
                
                outParm = redeemWebService.uploadReferralsheet(hospitalCode, centerCode, turnCode, sType, safetyNo, idCardNo,
                                                                                 sickName, sexName, birthday, insurCardNo, phoneNo, turnType, icdCode,
                                                                                 icdName, beginDate, fromHospCode, fromHospName, toHospCode,
                                                                                 toHospName, cityType, toHospLevel, tempDate, temp,
                                                                                 temp, temp, temp, remark,
                                                                                 temp, temp, temp, temp, temp);
              
                outParm = Base64.DecodingString(outParm);
                centerCode = Base64.DecodingString(centerCode);
                outParm += "|" + centerCode;
                Log4NetHelper.Info(outParm);
            }
            catch (Exception ex)
            {

                Log4NetHelper.Error("A006 上传/修改转诊单信息 uploadReferralsheet）", ex);
                return getException(out outParm, ex);
            }
            return 0;

        }
        #endregion

        #region A007 转诊单信息撤销cancelReferralsheet
        /// <summary>
        /// A007 转诊单信息撤销cancelReferralsheet
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="turnCode"></param>
        /// <param name="safetyNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int cancelReferralsheet(string rateType, string turnCode, string safetyNo, out string outParm)
        {


            try
            {
                //测试连接
                testConn(rateType);
                outParm = "";
                StringBuilder sql = new StringBuilder();
                UtilityDAL utilityDAL = new UtilityDAL();

                string password, softwareFactory;
                string hospitalCode, centerCode, centerName, serviceURL, operater;
                string organizationCode, organizationKey;
                getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName,
                              out organizationCode, out organizationKey);

             
                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                //Zysoft.ZyExternal.DAL1.InpatientRedeemWebServiceImpPort redeemWebService = new Zysoft.ZyExternal.DAL1.InpatientRedeemWebServiceImpPort();
                string inParm;
                inParm = "redeemWebService.cancelReferralsheet(" + hospitalCode + "," + centerCode + "," + turnCode + "," + safetyNo + ");";
               
                redeemWebService.Url = serviceURL;
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                turnCode = Base64.EncodingString(turnCode);
                safetyNo = Base64.EncodingString(safetyNo);
                organizationCode = Base64.EncodingString(organizationCode);


                inParm = "redeemWebService.cancelReferralsheet(" + hospitalCode + "," + centerCode + "," + turnCode + "," + safetyNo + ");";
                Log4NetHelper.Info(inParm);
                redeemWebService.cancelReferralsheet(hospitalCode, centerCode, turnCode, safetyNo);

            }
            catch (Exception ex)
            {

                Log4NetHelper.Error("A007 转诊单信息撤销cancelReferralsheet）", ex);
                return getException(out outParm, ex);
            }
            return 0;

        }
        #endregion

        #region A008 转诊单信息查询 downloadReferralsheet
        /// <summary>
        /// A008 转诊单信息查询 downloadReferralsheet
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="operateType"></param>
        /// <param name="turnCode"></param>
        /// <param name="safetyNo"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int downloadReferralsheet(string rateType, string inoutType, string turnCode, string safetyNo, out string outParm)
        {

            string paraName;
            try
            {
                //测试连接
                testConn(rateType);
                outParm = "";
                string checkSheet = "0";

                StringBuilder sql = new StringBuilder();
                UtilityDAL utilityDAL = new UtilityDAL();

                string password, softwareFactory;
                string hospitalCode, centerCode, centerName, serviceURL, operater;
                string organizationCode, organizationKey;
                getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName, 
                                 out organizationCode, out organizationKey);
                string startDate, endDate;
                startDate = endDate = "";
                startDate = utilityDAL.GetSysDateTime().AddDays(-60.0).ToString("yyyy-MM-dd");
                endDate = utilityDAL.GetSysDateTime().ToString("yyyy-MM-dd");


                if (rateType.IsNull())
                {
                    paraName = "费别";
                    goto ErrorReturn;
                }

                if (inoutType.IsNull())
                {
                    paraName = "转诊流向";
                    goto ErrorReturn;
                }

                
                string inParm;
                inParm = "redeemWebService.downloadReferralsheet(" + hospitalCode + "," + centerCode + "," + inoutType + "," + turnCode + "," + safetyNo + "," + startDate + "," + endDate + ");";

               
                hospitalCode = Base64.EncodingString(hospitalCode);
                centerCode = Base64.EncodingString(centerCode);
                turnCode = Base64.EncodingString(turnCode);
                inoutType = Base64.EncodingString(inoutType);
                safetyNo = Base64.EncodingString(safetyNo);
                startDate = Base64.EncodingString(startDate);
                endDate = Base64.EncodingString(endDate);
                organizationCode = Base64.EncodingString(organizationCode);
                inParm = "redeemWebService.downloadReferralsheet(" + hospitalCode + "," + centerCode + "," + inoutType + "," + turnCode + "," + safetyNo + "," + startDate + "," + endDate + ");";
                Log4NetHelper.Info(inParm);


                ReferralResult[] referralResults;

                //inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                //redeemWebService.Url = serviceURL;
                //referralResults = redeemWebService.downloadReferralsheet(hospitalCode, centerCode, inoutType, turnCode, safetyNo, startDate, endDate);

                //==============================================================
                //晶奇	1/泰阳	2/创业	3/至诚	4/汉思	5/兴宇	6/好友	7/明软	8/中卫	9/拓思	10/强鸿	11/南陵	12
                //switch (softwareFactory)
                //{
                //    case "2": //泰阳
                RedeemWSTY redeemWSTY = new RedeemWSTY();
                redeemWSTY.Url = serviceURL;
                referralResults = redeemWSTY.downloadReferralsheet(hospitalCode, centerCode, inoutType, turnCode, safetyNo, startDate, endDate);

                //        break;
                //    default:
                //        RedeemWSJQ redeemWSJQ = new RedeemWSJQ();
                //        redeemWSJQ.Url = serviceURL;
                //        referralResults = redeemWSJQ.downloadReferralsheet(hospitalCode, centerCode, inoutType, turnCode, safetyNo, startDate, endDate);

                //        break;
                //}
                //=============================================================================
               
                if (referralResults == null)
                {
                    outParm = "没有数据返回！";
                    return -1;
                }

                if (referralResults.Length == 0)
                {
                    outParm = "没有数据返回！";
                    return -1;
                }

                if (referralResults.Length > 0)
                {
                    if (turnCode.IsNotNull() || safetyNo.IsNotNull())
                    {
                        checkSheet = "1";
                    }
                }
                centerCode = Base64.DecodingString(centerCode);
                foreach (ReferralResult referralResult in referralResults)
                {

                    referralResult.centerno = Base64.DecodingString(referralResult.centerno);
                    referralResult.truncode = Base64.DecodingString(referralResult.truncode);
                    referralResult.stype = Base64.DecodingString(referralResult.stype);
                    referralResult.memberno = Base64.DecodingString(referralResult.memberno);
                    referralResult.idcardno = Base64.DecodingString(referralResult.idcardno);
                    referralResult.name = Base64.DecodingString(referralResult.name);
                    referralResult.sex = Base64.DecodingString(referralResult.sex);
                    referralResult.birthday = Base64.DecodingString(referralResult.birthday);
                    referralResult.bookno = Base64.DecodingString(referralResult.bookno);
                    referralResult.telphone = Base64.DecodingString(referralResult.telphone);
                    referralResult.turntype = Base64.DecodingString(referralResult.turntype);
                    referralResult.icdcode = Base64.DecodingString(referralResult.icdcode);
                    referralResult.icdname = Base64.DecodingString(referralResult.icdname);
                    referralResult.turndate = Base64.DecodingString(referralResult.turndate);
                    referralResult.fromhospitalcode = Base64.DecodingString(referralResult.fromhospitalcode);
                    referralResult.fromhospitalname = Base64.DecodingString(referralResult.fromhospitalname);
                    referralResult.tohospitalcode = Base64.DecodingString(referralResult.tohospitalcode);
                    referralResult.tohospitalname = Base64.DecodingString(referralResult.tohospitalname);
                    referralResult.tohospitallevel = Base64.DecodingString(referralResult.tohospitallevel);
                    referralResult.tohospitalteclevel = Base64.DecodingString(referralResult.tohospitalteclevel);
                    referralResult.leavedateoflasttime = Base64.DecodingString(referralResult.leavedateoflasttime);
                    referralResult.outofficeoflasttime = Base64.DecodingString(referralResult.outofficeoflasttime);
                    referralResult.icdcodeoflasttime = Base64.DecodingString(referralResult.icdcodeoflasttime);
                    referralResult.icdnameoflasttime = Base64.DecodingString(referralResult.icdnameoflasttime);
                    referralResult.doctorname = Base64.DecodingString(referralResult.doctorname);
                    referralResult.remark = Base64.DecodingString(referralResult.remark);
                    referralResult.obligateOne = Base64.DecodingString(referralResult.obligateOne);
                    referralResult.obligateTwo = Base64.DecodingString(referralResult.obligateTwo);
                    referralResult.obligateThree = Base64.DecodingString(referralResult.obligateThree);
                    referralResult.obligateFour = Base64.DecodingString(referralResult.obligateFour);
                    referralResult.obligateFive = Base64.DecodingString(referralResult.obligateFive);
                }

                string infoType = "201";
                DateTime dtSys;
                dtSys = utilityDAL.GetSysDateTime();
                string tohospitallevelName, resultXml;

                inoutType = Base64.DecodingString(inoutType);
                foreach (ReferralResult referralResult in referralResults)
                {
                    resultXml = XmlUtil.Serializer(typeof(ReferralResult), referralResult);
                    Log4NetHelper.Info(resultXml);
                    if (inoutType == "1")//本院转出， 则不更新数据库
                    {
                        sql.Clear();
                        sql.Append(@"select 1 from insur_audit_info
				                where center_code = :arg_center_code 
				                  and turn_code = :arg_turn_code");
                        OracleParameter[] paraSelMember = { new OracleParameter("arg_center_code", centerCode),
                                                            new OracleParameter("arg_turn_code", referralResult.truncode)};
                        DataTable dtSelMember = Select(sql.ToString(), paraSelMember);
                        if (dtSelMember.Rows.Count == 1) continue;
                        infoType = "201";

                    }
                    else
                    {
                        infoType = "202";
                        sql.Clear();
                        sql.Append(@"delete from insur_audit_info
				                where center_code = :arg_center_code 
				                  and turn_code = :arg_turn_code");
                        OracleParameter[] paraDelMember = { new OracleParameter("arg_center_code", centerCode),
                                                            new OracleParameter("arg_turn_code", referralResult.truncode)};
                        Insert(sql.ToString(), paraDelMember);
                    }
                    tohospitallevelName = "9";
                    DateTime birthday;
                    if (referralResult.birthday.IsNull())
                    {
                        birthday = DateTime.MinValue;
                    }
                    else
                    {
                        birthday = referralResult.birthday.ToDateTime();
                    }
                    switch (referralResult.tohospitallevel)
                    {
                        case "5":
                            tohospitallevelName = "省级";
                            break;
                        case "4":
                            tohospitallevelName = "市级";
                            break;
                        case "3":
                            tohospitallevelName = "县级";
                            break;
                        case "2":
                            tohospitallevelName = "乡镇级";
                            break;
                        case "9":
                            tohospitallevelName = "省外";
                            break;
                    }
                    sql.Clear();
                    sql.Append(@"insert into
                                  insur_audit_info
                                    (
                                    info_type          		,
                                    residence_no       		,
                                    sick_id            		,
                                    sick_name         		,
                                    safety_no          		,
                                    cure_hospital_code 		,
                                    cure_hospital_name 		,
                                    hospital_code      		,
                                    hospital_name      		,
                                    audit_type         		,
                                    operator           		,
                                    operation_date     		,
                                    status             		,
                                    icd10_code         		,
                                    icd10_name         		,
                                    city_type          		,
                                    city_name          		,
                                    begin_date         		,
                                    end_date           		,
                                    hospital_opinion   		,
                                    insur_opinion      		,
                                    memo               		,
                                    sequence_no        		,
                                    cure_doctor        		,
                                    turn_code        		,
                                    cure_doctor_code   		,
                                    insur_card_no      		,
                                    id_card_no         		,
                                    birthday           		,
                                    rate_type          		,
                                    turn_type          		,
                                    to_hosp_level          		,
                                    center_code        		
                                        )
                                  values(
                                    :arg_info_type          		,
                                    null       		,
                                    null            		,
                                    :arg_sick_name          		,
                                    :arg_safety_no          		,
                                    :arg_cure_hospital_code 		,
                                    :arg_cure_hospital_name 		,
                                    :arg_hospital_code      		,
                                    :arg_hospital_name      		,
                                    :arg_audit_type      		,
                                    null           		,
                                    :arg_operation_date     		,
                                    '-1'             		,
                                    :arg_icd10_code         		,
                                    :arg_icd10_name         		,
                                    :arg_city_type          		,
                                    :arg_city_name          		,
                                    :arg_begin_date         		,
                                    :arg_end_date           		,
                                    null   		,
                                    null      		,
                                    :arg_memo               		,
                                    :arg_sequence_no        		,
                                    :arg_cure_doctor        		,
                                    :arg_turn_code        		,
                                    null   		,
                                    :arg_insur_card_no      		,
                                    :arg_id_card_no         		,
                                    :arg_birthday           		,
                                    :arg_rate_type          		,
                                    :arg_turn_type          		,
                                    :arg_toHospLevel          		,
                                    :arg_center_code        		
                                 )");
                    OracleParameter[] paraAddMember = { new OracleParameter("arg_info_type", infoType),
                                                            new OracleParameter("arg_sick_name", referralResult.name),
                                                            new OracleParameter("arg_safety_no", referralResult.memberno),
                                                            new OracleParameter("arg_cure_hospital_code", referralResult.tohospitalcode),
                                                            new OracleParameter("arg_cure_hospital_name", referralResult.tohospitalname),
                                                            new OracleParameter("arg_hospital_code", referralResult.fromhospitalcode),
                                                            new OracleParameter("arg_hospital_name", referralResult.fromhospitalname),
                                                            new OracleParameter("arg_audit_type", infoType),
                                                            new OracleParameter("arg_operation_date",referralResult.turndate.ToDateTime()),
                                                            new OracleParameter("arg_icd10_code", referralResult.icdcode),
                                                            new OracleParameter("arg_icd10_name", referralResult.icdname),
                                                            new OracleParameter("arg_city_type", referralResult.tohospitallevel),
                                                            new OracleParameter("arg_city_name", tohospitallevelName),
                                                            new OracleParameter("arg_begin_date", dtSys),
                                                            new OracleParameter("arg_end_date", dtSys),
                                                            new OracleParameter("arg_memo",referralResult.remark),
                                                            new OracleParameter("arg_sequence_no",Guid.NewGuid().ToString("N")),
                                                            new OracleParameter("arg_cure_doctor",referralResult.doctorname),
                                                            new OracleParameter("arg_turn_code",referralResult.truncode),
                                                            new OracleParameter("arg_insur_card_no",referralResult.bookno),
                                                            new OracleParameter("arg_id_card_no",referralResult.idcardno),
                                                            new OracleParameter("arg_birthday",birthday),
                                                            new OracleParameter("arg_rate_type", rateType),
                                                            new OracleParameter("arg_turn_type",referralResult.turntype),
                                                            new OracleParameter("arg_toHospLevel",referralResult.tohospitallevel),
                                                            new OracleParameter("arg_center_code",centerCode)};
                    Insert(sql.ToString(), paraAddMember);

                    outParm = checkSheet + "|" + referralResults[0].truncode;
                }

            }
            catch (Exception ex)
            {

                Log4NetHelper.Error(" A008 转诊单信息查询 downloadReferralsheet）", ex);
                return getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }
        #endregion

        #region A009 获取医疗机构列表getHospitalInfo_New
        /// <summary>
        /// A009 获取医疗机构列表getHospitalInfo_New
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="lastTime"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int getHospitalInfo_New(string rateType, string lastTime, out string outParm)
        {
            try
            {
                //测试连接
                testConn(rateType);
                outParm = "";
                StringBuilder sql = new StringBuilder();
                UtilityDAL utilityDAL = new UtilityDAL();

                string password, softwareFactory;
                string hospitalCode, centerCode, centerName, serviceURL, operater;
                string organizationCode, organizationKey;

                getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName,
                                 out organizationCode, out organizationKey);
               
                string code, name, nameSpell;
                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;

                hospitalCode = Base64.EncodingString(hospitalCode);
                lastTime = Base64.EncodingString(lastTime);
                centerCode = Base64.EncodingString(centerCode);
                string hospitalInfoXml = redeemWebService.getHospitalInfo_New(lastTime, centerCode, hospitalCode);
                if (hospitalInfoXml.IsNull())
                {
                    outParm = "下载记录数为0！";
                    return -1;
                }


                sql.Clear();
                sql.Append(@"delete organ_dict");
                Insert(sql.ToString());



                hospitalInfoXml = Base64.DecodingString(hospitalInfoXml);

                XmlDocument docHospitalInfo = new XmlDocument();
                docHospitalInfo.LoadXml(hospitalInfoXml);

                XmlNode ndBusiness = docHospitalInfo.SelectSingleNode("business");
                long rowCount;
                rowCount = (ndBusiness.SelectSingleNode("RowCount").InnerText).To<long>();
                if (rowCount == 0) return 0;

                string organCode, organName, manageUnit, grader, orgLevel, address;
                string phoneNo, authType, protocol, quality, graderLevel, flag;
                string orgType, spellCode;
                sql.Clear();
                sql.Append(@"insert into organ_dict
                                            (organ_code  	,
                                                organ_name  	,
                                                manage_unit 	,
                                                grader      	,
                                                org_level   	,
                                                address     	,
                                                phone_no    	,
                                                auth_type   	,
                                                protocol    	,
                                                quality     	,
                                                grader_level	,
                                                flag        	,
                                                org_type    	,
                                                spell_code  	
                                            )
                                            values(
                                                :arg_organ_code  	,
                                                :arg_organ_name  	,
                                                :arg_manage_unit 	,
                                                :arg_grader      	,
                                                :arg_org_level   	,
                                                :arg_address     	,
                                                :arg_phone_no    	,
                                                :arg_auth_type   	,
                                                :arg_protocol    	,
                                                :arg_quality     	,
                                                :arg_grader_level	,
                                                :arg_flag        	,
                                                :arg_org_type    	,
                                                :arg_spell_code  	 )");

                long count = 0;
                foreach (XmlNode ndRow in ndBusiness.ChildNodes)
                {
                    if (ndRow.Name == "RowCount") continue;
                    if (ndRow.SelectSingleNode("organCode") == null) continue;

                    organCode = ndRow.SelectSingleNode("organCode").InnerText;
                    organName = ndRow.SelectSingleNode("hospName").InnerText;
                    manageUnit = ndRow.SelectSingleNode("manageUnit").InnerText;
                    grader = ndRow.SelectSingleNode("grader").InnerText;
                    orgLevel = ndRow.SelectSingleNode("orgLevel").InnerText;
                    address = ndRow.SelectSingleNode("address").InnerText;
                    phoneNo = ndRow.SelectSingleNode("phoneCode").InnerText;
                    authType = ndRow.SelectSingleNode("authType").InnerText;
                    protocol = ndRow.SelectSingleNode("protocol").InnerText;
                    quality = ndRow.SelectSingleNode("quality").InnerText;
                    graderLevel = ndRow.SelectSingleNode("graderLevel").InnerText;
                    flag = ndRow.SelectSingleNode("Flag").InnerText;
                    orgType = ndRow.SelectSingleNode("type").InnerText;
                    spellCode = utilityDAL.GetSpellCode(organName);
                    if (flag == "1")
                        flag = "0";
                    else
                        flag = "1";

                    OracleParameter[] paraOrganDict = { 
                                                    new OracleParameter("arg_organ_code",organCode),
                                                    new OracleParameter("arg_organ_name",organName), 
                                                    new OracleParameter("arg_manage_unit", manageUnit),
                                                    new OracleParameter("arg_grader", grader),
                                                    new OracleParameter("arg_org_level", orgLevel),
                                                    new OracleParameter("arg_address", address),
                                                    new OracleParameter("arg_phone_no",phoneNo),
                                                    new OracleParameter("arg_auth_type",authType),
                                                    new OracleParameter("arg_protocol",protocol),
                                                    new OracleParameter("arg_quality",quality),
                                                    new OracleParameter("arg_grader_level",graderLevel),
                                                    new OracleParameter("arg_flag",flag),
                                                    new OracleParameter("arg_org_type",orgType),
                                                    new OracleParameter("arg_spell_code",spellCode)};
                    Insert(sql.ToString(), paraOrganDict);
                    count++;
                }

                outParm = "共完成" + count.ToString() + "条记录的下载";
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("A009 获取医疗机构列表getHospitalInfo_New", ex);
                return getException(out outParm, ex);

            }
            return 0;
        }
        #endregion

        #region A010 测试连接
        /// <summary>
        /// A010 测试连接
        /// </summary>
        /// <param name="rateType"></param>
        /// <returns></returns>
        public int testConn(string rateType)
        {
            string outParm;
            int connTime;
            connTime = 0;

        ErrorReturn:
            if (getHospitalInfo(rateType, out outParm) < 0)
            {
                connTime++;
                if (connTime >= 3) throw new Exception("无法建立联建， 请与医院农合办联系！");
                goto ErrorReturn;
            }
            return 0;
        }
        #endregion
        
        #region  A111 匹配药品数据上传函数 matchUpdate
        /// <summary>
        /// A101 匹配药品数据上传函数 matchUpdate
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int matchUpdate(string rateType, string insurancePriceItemCode, string itemCode,
                                    string itemName, string spec, string unit, string formName,
                                   string standardPrice, out string outParm)
        {
            try
            {
                outParm = "";
                StringBuilder sql = new StringBuilder();
                string organizationCode;
                string organizationKey;
                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName, serviceURL;
                BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName,
                    out organizationCode, out organizationKey);

                inpatientRedeemWebService inpatientWebService = new inpatientRedeemWebService();
                inpatientWebService.Url = serviceURL;

                centerCode = Base64.EncodingString(centerCode);
                hospitalCode = Base64.EncodingString(hospitalCode);
                organizationCode = Base64.EncodingString(organizationCode);
                insurancePriceItemCode = Base64.EncodingString(insurancePriceItemCode);
                itemCode = Base64.EncodingString(itemCode);
                itemName = Base64.EncodingString(itemName);
                spec = Base64.EncodingString(spec);
                unit = Base64.EncodingString(unit);
                formName = Base64.EncodingString(formName);
                standardPrice = Base64.EncodingString(standardPrice);

                inpatientWebService.matchUpdate(centerCode, hospitalCode,
                                      insurancePriceItemCode, itemCode,
                                    itemName, spec, unit, formName, standardPrice);

            }
            catch (Exception ex)
            {
                outParm = ex.Message;
                outParm = Base64.DecodingString(outParm);
                Log4NetHelper.Error("D003 匹配药品数据上传函数 matchUpdate", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region A112 药品匹配数据审核状态查询 matchSeek
        /// <summary>
        /// A102 药品匹配数据审核状态查询 matchSeek
        /// </summary>
        /// <param name="rateType"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int matchSeek(string rateType, string insurancePriceItemCode, string itemCode, out string outParm)
        {
            try
            {
                outParm = "";
                StringBuilder sql = new StringBuilder();
                string organizationCode;
                string organizationKey;
                string operater, password, softwareFactory;
                string hospitalCode, centerCode, centerName, serviceURL;
                BasicInformationDAL basicInfoDAL = new BasicInformationDAL();
                basicInfoDAL.getRuralLoginInfo(rateType, out serviceURL, out softwareFactory, out operater, out password, out hospitalCode, out centerCode, out centerName,
                    out organizationCode, out organizationKey);

                //DrugInterfacesRemoteService drugInterfacesRemoteService = new DrugInterfacesRemoteService();
                inpatientRedeemWebService inpatientWebService = new inpatientRedeemWebService();
                inpatientWebService.Url = serviceURL;

                centerCode = Base64.EncodingString(centerCode);
                hospitalCode = Base64.EncodingString(hospitalCode);
                organizationCode = Base64.EncodingString(organizationCode);
                insurancePriceItemCode = Base64.EncodingString(insurancePriceItemCode);
                itemCode = Base64.EncodingString(itemCode);

                outParm = inpatientWebService.matchSeek(centerCode, insurancePriceItemCode, itemCode, hospitalCode);
                outParm = Base64.DecodingString(outParm);
                Log4NetHelper.Info(outParm);

            }
            catch (Exception ex)
            {
                outParm = ex.Message;
                outParm = Base64.DecodingString(outParm);
                Log4NetHelper.Error("A102 药品匹配数据审核状态查询 matchSeek", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        #region A113 获取病人信息函数 getPersonInfo_New
        /// <summary>
        ///  A113 获取病人信息函数获取病人信息函数
        /// </summary>
        /// <param name="bookno"></param>
        /// <param name="operater"></param>
        /// <param name="outParm"></param>
        /// <returns></returns>
        public int getPersonInfo_New(string rateType, string centerCode, string cardNo, out string outParm)
        {
             
            outParm = "";
            DateTime dtSysDatetime;
            UtilityDAL utilityDAL = new UtilityDAL();
            dtSysDatetime = utilityDAL.GetSysDateTime();
            string paraName, serviceURL;
            string operater;

            try
            {

                //测试连接
                //testConn(rateType);

                #region response初始化
                StringBuilder sql = new StringBuilder();

                string organizationKey, organizationCode;
                string hospitalCode;
                getRuralLoginInfo(rateType, out serviceURL, out organizationCode, out organizationKey);

                #endregion
                if (cardNo.IsNull())
                {
                    paraName = "家庭编号";
                    goto ErrorReturn;
                }
                if (organizationCode.IsNull())
                {
                    paraName = "机构代码";
                    goto ErrorReturn;
                }

                sql.Clear();
                sql.Append(@"delete from family_member_record
				                where book_no = :arg_id_cardno 
				                    or id_cardno = :arg_id_cardno
				                    or card_no = :arg_id_cardno");
                OracleParameter[] paraDelFamily = { new OracleParameter("arg_id_cardno", cardNo) };
                Insert(sql.ToString(), paraDelFamily);

                string year;
                year = DateTime.Now.ToString("yyyy");
                cardNo = Base64.EncodingString(cardNo);
                organizationCode = Base64.EncodingString(organizationCode);
                centerCode = Base64.EncodingString(centerCode);
                year = Base64.EncodingString(year);
                inpatientRedeemWebService redeemWebService = new inpatientRedeemWebService();
                redeemWebService.Url = serviceURL;
                string inPara;
                inPara = "redeemWebService.getPersonInfo_New(" + cardNo + ", " + organizationCode + ", " + centerCode + ", " + year + ", \"\", \"\", \"\", \"\" ,\"\")";
               
                Member[] members;
                Log4NetHelper.Info(inPara);
                members = redeemWebService.getPersonInfo_New(cardNo, organizationCode, centerCode, year,"", "", "", "", "");



                foreach (Member member in members)
                {
                    member.memberNO = Base64.DecodingString(member.memberNO);
                    member.name = Base64.DecodingString(member.name);
                    member.countryTeamCode = Base64.DecodingString(member.countryTeamCode);
                    member.familySysno = Base64.DecodingString(member.familySysno);
                    member.idcardNo = Base64.DecodingString(member.idcardNo);
                    member.age = Base64.DecodingString(member.age);
                    member.birthday = Base64.DecodingString(member.birthday);
                    member.bookNo = Base64.DecodingString(member.bookNo);
                    member.cardNo = Base64.DecodingString(member.cardNo);
                    member.familyAddress = Base64.DecodingString(member.familyAddress);
                    member.tel = Base64.DecodingString(member.tel);
                    member.sexId = Base64.DecodingString(member.sexId);
                    member.ideName = Base64.DecodingString(member.ideName);
                    member.transCode = Base64.DecodingString(member.transCode);
                }

                long count = 0;

                foreach (Member member in members)
                {
                    sql.Clear();
                    sql.Append(@"delete from family_member_record
				                where member_no = :arg_member_no 
				                    or id_cardno = :arg_id_cardno");
                    OracleParameter[] paraDelMember = { new OracleParameter("arg_member_no", member.memberNO),
                                                            new OracleParameter("arg_id_cardno", member.idcardNo)};
                    Insert(sql.ToString(), paraDelMember);
                    sql.Clear();
                    sql.Append(@"insert into
                                  family_member_record
                                    (
                                    member_no        	,
                                    name             	,
                                    country_team_code	,
                                    family_sysno     	,
                                    sex              	,
                                    id_cardno        	,
                                    age              	,
                                    birthday         	,
                                    book_no          	,
                                    card_no          	,
                                    family_address   	,
                                    tel              	,
                                    ide_name            ,
                                    turn_code)
                                  values(
                                    :arg_member_no        	,
                                    :arg_name             	,
                                    :arg_country_team_code	,
                                    :arg_family_sysno     	,
                                    :arg_sex              	,
                                    :arg_id_cardno        	,
                                    :arg_age              	,
                                    :arg_birthday         	,
                                    :arg_book_no          	,
                                    :arg_card_no          	,
                                    :arg_family_address   	,
                                    :arg_tel              	,
                                    :arg_ide_name           ,
                                    :arg_turn_code)");
                    OracleParameter[] paraAddMember = { new OracleParameter("arg_member_no", member.memberNO),
                                                            new OracleParameter("arg_name", member.name),
                                                            new OracleParameter("arg_country_team_code", member.countryTeamCode),
                                                            new OracleParameter("arg_family_sysno", member.familySysno),
                                                            new OracleParameter("arg_sex", member.sexId),
                                                            new OracleParameter("arg_id_cardno", member.idcardNo),
                                                            new OracleParameter("arg_age", member.age),
                                                            new OracleParameter("arg_birthday", member.birthday),
                                                            new OracleParameter("arg_book_no", member.bookNo),
                                                            new OracleParameter("arg_card_no", member.cardNo),
                                                            new OracleParameter("arg_family_address", member.familyAddress),
                                                            new OracleParameter("arg_tel", member.tel),
                                                            new OracleParameter("arg_ide_name", member.ideName),
                                                            new OracleParameter("arg_turn_code", member.transCode)};
                    Insert(sql.ToString(), paraAddMember);
                    count++;
                    outParm = member.bookNo;
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("A113 获取病人信息函数 getPersonInfo_New", ex);
                return getException(out outParm, ex);
            }
            return 0;
        ErrorReturn:
            outParm = paraName + "不能为空！";
            return -1;
        }


        #endregion





    }
}
