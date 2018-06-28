using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zysoft.FrameWork;
using Zysoft.FrameWork.Database;
using Zysoft.ZyExternal.DAL.Common;

namespace Zysoft.ZyExternal.DAL.His
{
    /// <summary>
    /// 产生、更新银行交易日志
    /// </summary>
    public class BankTradeLogDal:DB
    {
        public BankTradeLogDal()
        {
        }
        
        public int CreateSettleInfo(string insurApplyNo, string tradeText, string sickId, string insuranceNo,
            string registerType, string residenceNo, string icdCode, string safetyNO, string RateType,
            decimal LostCash, string settleNo)
        {
            
                using (OracleConnection con = OracleConnect.Connect())
                {
                    if (con.State != ConnectionState.Open) con.Open();

                    OracleCommand orcCmd = new OracleCommand();
                    orcCmd.Connection = con;
                    OracleTransaction orcTr = con.BeginTransaction();
                    orcCmd.Transaction = orcTr;

                string insure_out_paramm1, insure_out_paramm2, insure_out_paramm3, insure_out_paramm4, insure_out_paramm5,
                       insure_out_paramm6, insure_out_paramm7, insure_out_paramm8, insure_out_paramm9, insure_out_paramm10,
                       insure_out_paramm11, insure_out_paramm12, insure_out_paramm13, insure_out_paramm14, insure_out_paramm15,
                       insure_out_paramm16, insure_out_paramm17, insure_out_paramm18, insure_out_paramm19, insure_out_paramm20;

                insure_out_paramm1 = insure_out_paramm2 = insure_out_paramm3 = insure_out_paramm4 = insure_out_paramm5 = "";
                insure_out_paramm6 = insure_out_paramm7 = insure_out_paramm8 = insure_out_paramm9 = insure_out_paramm10 = "";
                insure_out_paramm11 = insure_out_paramm12 = insure_out_paramm13 = insure_out_paramm14 = insure_out_paramm15 = "";
                insure_out_paramm16 = insure_out_paramm17 = insure_out_paramm18 = insure_out_paramm19 = insure_out_paramm20 = "";
                Log4NetHelper.Info("插入医保日志中间表执行！！");
                string[] settleList1 = tradeText.Split('^');
                if (settleList1.Length >= 2)
                {
                    string[] settleList = settleList1[1].Split('|');
                    insure_out_paramm1 = settleList[0];
                    insure_out_paramm2 = settleList[1];
                    insure_out_paramm3 = settleList[2];
                    insure_out_paramm4 = settleList[3];
                    insure_out_paramm5 = settleList[4];
                    insure_out_paramm6 = settleList[5];
                    insure_out_paramm7 = settleList[6];
                    insure_out_paramm8 = settleList[7];
                    insure_out_paramm9 = settleList[8];
                    insure_out_paramm10 = settleList[9];
                    insure_out_paramm11 = settleList[10];
                    insure_out_paramm12 = settleList[11];
                    insure_out_paramm13 = settleList[12];
                    insure_out_paramm14 = settleList[13];
                    insure_out_paramm15 = settleList[14];
                    insure_out_paramm16 = settleList[15];
                    insure_out_paramm17 = settleList[16];
                    insure_out_paramm18 = settleList[17];
                    insure_out_paramm19 = settleList[18];
                    insure_out_paramm20 = settleList[19];
                }

                try
                    {
                        orcCmd.CommandText = @"
                                        insert into insur.insur_trade_log_jssyb(
			                                          apply_no,
			                                          temp1,
			                                          temp2,
			                                          temp3,
			                                          temp4,
			                                          temp5,
			                                          temp6,
			                                          temp7,
			                                          temp8,
			                                          temp9,
			                                          temp10,
			                                          temp11,
			                                          temp12,
			                                          temp13,
			                                          temp14,
			                                          temp15,
			                                          temp16,
			                                          temp17,
			                                          temp18,
			                                          temp19,
			                                          temp20,
			                                          sick_id,
			                                          cost_mode,
			                                          settle_flag,
			                                          insur_register_no,
			                                          insurance_bill_no,
			                                          operator_date,
			                                          insur_cure_type,
			                                          visit_number,
			                                          residence_no,
			                                          icd_code,
			                                          insurance_card_no,
			                                          rate_type,
			                                          lost_cash,
                                                      settle_no)
                                            values(
			                                          :ls_insur_apply_no  							/*医保单据号*/,
			                                          :ls_insure_out_paramm1						/*本次医疗费总额*/,
			                                          :ls_insure_out_paramm2						/*本次统筹支付金额*/,
			                                          :ls_insure_out_paramm3						/*本次大病救助支付*/,
			                                          :ls_insure_out_paramm4						/*本次大病保险支付*/,
			                                          :ls_insure_out_paramm5						/*本次民政补助支付*/,
			                                          :ls_insure_out_paramm6						/*本次帐户支付总额*/,
			                                          :ls_insure_out_paramm7						/*本次现金支付总额*/,
			                                          :ls_insure_out_paramm8						/*本次帐户支付自付*/,
			                                          :ls_insure_out_paramm9						/*本次帐户支付自理*/,
			                                          :ls_insure_out_paramm10						/*本次现金支付自付*/,
			                                          :ls_insure_out_paramm11						/*本次现金支付自理*/,
			                                          :ls_insure_out_paramm12					    /*医保范围内费用*/,
			                                          :ls_insure_out_paramm13						/*帐户消费后余额*/,
			                                          :ls_insure_out_paramm14						/*单病种病种编码*/,
			                                          :ls_insure_out_paramm15					    /*说明信息*/,
			                                          :ls_insure_out_paramm16						/*药费合计*/,
			                                          :ls_insure_out_paramm17						/*诊疗项目费合计*/,
			                                          :ls_insure_out_paramm18						/*补保支付*/,
			                                          :ls_insure_out_paramm19						/*医疗类别*/,
			                                          :ls_insure_out_paramm20						/*备用6*/,
			                                          :ls_sick_id					                    /*HIS病人ID*/,
			                                          '0'											/*0、门诊 1、住院*/,
			                                          '1'											/*0、HIS未结算 1、HIS已结算 9、作废*/,
			                                          :ls_insur_disp_register_no		                /*医保 门诊/住院流水号*/,
			                                          :ls_insur_resi_register_no		                /*医保 门诊/住院流水号*/,
			                                          sysdate									    /*操作日期*/,
			                                          :ls_cure_type									/*医疗类别*/,
			                                          0												/*HIS住院序号 门诊传0*/,
			                                          :ls_residence_no				                    /*HIS门诊挂号号*/,
			                                          :ls_icd_code									    /*病种编码*/,
			                                          :ls_insurance_card_no			                /*医保卡号*/,
			                                          :ls_rate_type					                /*HIS费别*/,
			                                          :ls_lost_cash								    /*HIS总费用与医保总费用结算尾差*/,
                                                      :arg_settle_no)
                                        ";
                        OracleParameter[] parameters = {
                                        new OracleParameter("ls_insur_apply_no", insurApplyNo),
                                        new OracleParameter("ls_insure_out_paramm1", insure_out_paramm1),
                                        new OracleParameter("ls_insure_out_paramm2", insure_out_paramm2),
                                        new OracleParameter("ls_insure_out_paramm3", insure_out_paramm3),
                                        new OracleParameter("ls_insure_out_paramm4", insure_out_paramm4),
                                        new OracleParameter("ls_insure_out_paramm5", insure_out_paramm5),
                                        new OracleParameter("ls_insure_out_paramm6", insure_out_paramm6),
                                        new OracleParameter("ls_insure_out_paramm7", insure_out_paramm7),
                                        new OracleParameter("ls_insure_out_paramm8", insure_out_paramm8),
                                        new OracleParameter("ls_insure_out_paramm9", insure_out_paramm9),
                                        new OracleParameter("ls_insure_out_paramm10", insure_out_paramm10),
                                        new OracleParameter("ls_insure_out_paramm11", insure_out_paramm11),
                                        new OracleParameter("ls_insure_out_paramm12", insure_out_paramm12),
                                        new OracleParameter("ls_insure_out_paramm13", insure_out_paramm13),
                                        new OracleParameter("ls_insure_out_paramm14", insure_out_paramm14),
                                        new OracleParameter("ls_insure_out_paramm15", insure_out_paramm15),
                                        new OracleParameter("ls_insure_out_paramm16", insure_out_paramm16),
                                        new OracleParameter("ls_insure_out_paramm17", insure_out_paramm17),
                                        new OracleParameter("ls_insure_out_paramm18", insure_out_paramm18),
                                        new OracleParameter("ls_insure_out_paramm19", insure_out_paramm19),
                                        new OracleParameter("ls_insure_out_paramm20", insure_out_paramm20),
                                        new OracleParameter("ls_sick_id", sickId),
                                        new OracleParameter("ls_insur_disp_register_no", insuranceNo),
                                        new OracleParameter("ls_insur_resi_register_no", insuranceNo),
                                        new OracleParameter("ls_cure_type", registerType),
                                        new OracleParameter("ls_residence_no", residenceNo),
                                        new OracleParameter("ls_icd_code", icdCode),
                                        new OracleParameter("ls_insurance_card_no", safetyNO),
                                        new OracleParameter("ls_rate_type", RateType),
                                        new OracleParameter("ls_lost_cash", LostCash),
                                        new OracleParameter("arg_settle_no", settleNo)
            };

                        orcCmd.Parameters.AddRange(parameters);
                        orcCmd.ExecuteNonQuery();
                        orcTr.Commit();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        orcTr.Rollback();
                        con.Close();
                        Log4NetHelper.Error("生成医保交易日志", ex);
                        return -1;
                    }
                }
        }
        public int CreateSettleInfo(string registerInparm, string settleInParm, string settleOutParm, string sickId,
                    string residenceNo, string RateType, decimal LostCash, string settleNo)
        {
            string insuranceNo,insurApplyNo,registerType, icdCode, safetyNo, insuranceCardNo;
            insuranceNo=insurApplyNo=registerType=icdCode=safetyNo=insuranceCardNo="";
            string[] regList1 = registerInparm.Split('^');
            if (regList1.Length > 8)
            {
                string[] regList = regList1[7].Split('|');
                insuranceNo = regList[0];
                registerType = regList[1];
                icdCode = regList[3];
                safetyNo = regList[10];
                insuranceCardNo = safetyNo;
            }
            string[] settleList1 = settleInParm.Split('^');
            if (settleList1.Length > 8)
            {
                string[] settleList = settleList1[7].Split('|');
                insurApplyNo = settleList[1];
            }
            Log4NetHelper.Info("插入医保日志中间表继续！！");
            return CreateSettleInfo(insurApplyNo, settleOutParm, sickId, insuranceNo, registerType, 
                residenceNo, icdCode, safetyNo, RateType, LostCash, settleNo);
        }

        #region 生成交易日志
        public int CreateInsurTradeLog(string sickId, string residenceNo, string operater, string returnText,
            string deptCode, string insuranceNo, string safetyNo, string insuranceCardNo,
            string rateType, string registType,
            out string errorMsg, string tradeType, string businessNo = "",
            string hisSettleFlag = "", string settleNo = "", string insuranceBillNumber = "",
            string tradeText = ""
            )
        {
            string tradeNo;
            errorMsg = "";
            StringBuilder sql = new StringBuilder();
            UtilityDAL utilityDAL = new UtilityDAL();
            string balanceInterface;
            sql.Clear();
            sql.Append(@"select balance_interface from rate_type_dict where rate_type_code = '" + rateType + "'");
            DataTable dtRateType = Select(sql.ToString());
            if (dtRateType.Rows.Count == 0)
            {
                errorMsg = "所录入费别不在字典中， 请重新录入";
                return -1;
            }
            balanceInterface = dtRateType.Rows[0]["balance_interface"].ToString();

            tradeNo = utilityDAL.GetSequenceNO("comm.insur_trade_seq").ToString();

            sql.Clear();
            sql.Append(@"
                        insert into insur_trade_log
                        (
                            trade_no,
                            residence_no,
                            sick_id,
                            trade_text,
                            trade_type,
                            settle_mode,
                            operator,
                            operation_date,
                            status,
                            business_cycle_no,
                            balance_interface,
                            return_text,
                            return_date, 
                            regist_type,
                            insurance_no,
                            safety_no,
                            dept_code,
                            insurance_card_no,
                            settle_no,
                            his_settle_flag,
                            insurance_bill_number
                        )
                        values
                        (
                            :arg_trade_no,
                            :arg_residence_no,
                            :arg_sick_id,
                            :arg_trade_text,
                            :arg_trade_type,
                            :arg_settle_mode,
                            :arg_operator,
                            sysdate,
                            '2'/*完成*/,
                            :arg_business_no,
                            :arg_balance_interface/*医保接口类型*/,
                            :arg_return_text,
                            sysdate,
                            :arg_regist_type,
                            :arg_insurance_no,
                            :arg_safety_no,
                            :arg_dept_code,
                            :arg_insurance_card_no,
                            :arg_settle_no,
                            :arg_his_settle_flag,
                            :arg_insurance_bill_number
                        )
                        ");
            using (OracleConnection con = OracleConnect.Connect())
            {
                if (con.State != ConnectionState.Open) con.Open();

                OracleCommand orcCmd = new OracleCommand();
                orcCmd.Connection = con;
                OracleTransaction orcTr = con.BeginTransaction();
                orcCmd.Transaction = orcTr;

                try
                {
                    orcCmd.CommandText = sql.ToString();
                    OracleParameter[] parInTradeLog = {
                                      new OracleParameter("arg_trade_no", tradeNo),
                                      new OracleParameter("arg_sick_id", sickId),
                                      new OracleParameter("arg_residence_no", residenceNo),
                                      new OracleParameter("arg_trade_text", ""),
                                      new OracleParameter("arg_trade_type", tradeType),
                                      new OracleParameter("arg_settle_mode", "1"),
                                      new OracleParameter("arg_operator", operater),
                                      new OracleParameter("arg_business_no", businessNo),
                                      new OracleParameter("arg_return_text", returnText),
                                      new OracleParameter("arg_regist_type", registType),
                                      new OracleParameter("arg_insurance_no", insuranceNo),
                                      new OracleParameter("arg_safety_no", safetyNo),
                                      new OracleParameter("arg_balance_interface", balanceInterface),
                                      new OracleParameter("arg_dept_code", deptCode),
                                      new OracleParameter("arg_insurance_card_no", insuranceCardNo),
                                      new OracleParameter("arg_settle_no", settleNo),
                                      new OracleParameter("arg_his_settle_flag", hisSettleFlag),
                                      new OracleParameter("arg_insurance_bill_number", insuranceBillNumber)
                                                      };
                    orcCmd.Parameters.AddRange(parInTradeLog);
                    orcCmd.ExecuteNonQuery();
                    orcTr.Commit();
                }
                catch (Exception ex)
                {
                    orcTr.Rollback();
                    con.Close();
                    errorMsg = ex.Message;
                    Log4NetHelper.Error("生成银行交易日志", ex);
                    return -1;
                }
            }
            return 0;
        }
        #endregion

        #region 更新交易日志
        public int UpdateInsurTradeLog(string tradeNo, string status)
        {
            StringBuilder sql = new StringBuilder();
            UtilityDAL utilityDAL = new UtilityDAL();


            sql.Clear();
            sql.Append(@"
            update insur_trade_log set status = :arg_status
             where trade_no = :arg_trade_no");
            using (OracleConnection con = OracleConnect.Connect())
            {
                if (con.State != ConnectionState.Open) con.Open();

                OracleCommand orcCmd = new OracleCommand();
                orcCmd.Connection = con;
                OracleTransaction orcTr = con.BeginTransaction();
                orcCmd.Transaction = orcTr;

                try
                {
                    orcCmd.CommandText = sql.ToString();
                    OracleParameter[] parInTradeLog = {
                                      new OracleParameter("arg_trade_no", tradeNo),
                                      new OracleParameter("arg_status", status)
                                                      };
                    orcCmd.Parameters.AddRange(parInTradeLog);
                    orcCmd.ExecuteNonQuery();
                    orcTr.Commit();
                    return 0;
                }
                catch (Exception ex)
                {
                    orcTr.Rollback();
                    con.Close();
                    Log4NetHelper.Error("生成银行交易日志", ex);
                    return -1;
                }
            }
        }
        #endregion

        public int CompleteLog(string tradeNo, string returnText, DateTime bankTradeDate, string bankTradeNo)
        {
            string prepayNo = "";
            return CompleteLog(tradeNo, returnText, bankTradeDate, bankTradeNo, prepayNo);  
        }
        public int CompleteLog(string tradeNo, string returnText, DateTime bankTradeDate, string bankTradeNo, string prepayNo)
        {
                using (OracleConnection con = OracleConnect.Connect())
                {
                    if (con.State != ConnectionState.Open) con.Open();

                    OracleCommand orcCmd = new OracleCommand();
                    orcCmd.Connection = con;
                    OracleTransaction orcTr = con.BeginTransaction();
                    orcCmd.Transaction = orcTr;

                    try
                    {
                        orcCmd.CommandText = @"
Update BANK_TRADE_LOG
   set return_text = :arg_return_text,
		 BANK_TRADE_DATE = :arg_bankTradeDate,
		 LOG_STATUS = '2', 
		 BANK_TRADE_NO = :arg_bank_trade_no,
         PREPAY_NO = :argPrepayNo
 where NULLAH_NO = :arg_trade_no";
                        OracleParameter[] parameters = {
                new OracleParameter("arg_return_text", returnText),
                new OracleParameter("arg_bankTradeDate", bankTradeDate),
                new OracleParameter("arg_bank_trade_no", bankTradeNo),
                new OracleParameter("arg_trade_no", tradeNo),
                new OracleParameter("argPrepayNo", prepayNo)
            };
                        orcCmd.Parameters.AddRange(parameters);
                        orcCmd.ExecuteNonQuery();
                        orcTr.Commit();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        orcTr.Rollback();
                        con.Close();
                        Log4NetHelper.Error("更新银行交易日志", ex);
                        return 0; //完成日志必须成功
                    }
                }
        }

        public int EorrorLog(string tradeNo, string returnText)
        {
            
             using (OracleConnection con = OracleConnect.Connect())
             {
                if (con.State != ConnectionState.Open) con.Open();

                OracleCommand orcCmd = new OracleCommand();
                orcCmd.Connection = con;
                OracleTransaction orcTr = con.BeginTransaction();
                orcCmd.Transaction = orcTr;

                try
                {
                    orcCmd.CommandText = @"
Update BANK_TRADE_LOG
   set return_text = :as_return_text,
		 LOG_STATUS = '9'
 where NULLAH_NO = :as_trade_no";
                    OracleParameter[] parameters = {
                new OracleParameter("as_return_text", returnText),
                new OracleParameter("as_trade_no", tradeNo)
            };
                    orcCmd.Parameters.AddRange(parameters);
                    orcCmd.ExecuteNonQuery();
                    orcTr.Commit();
                    return 0;
                }
                catch (Exception ex)
                {
                    orcTr.Rollback();
                    con.Close();
                    Log4NetHelper.Error("更新银行交易日志", ex);
                    return -1;
                }
            }
        }
    }
}
