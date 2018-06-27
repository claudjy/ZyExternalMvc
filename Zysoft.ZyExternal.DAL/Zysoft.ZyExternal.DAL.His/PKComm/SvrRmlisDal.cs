using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zysoft.FrameWork.Database;
using Zysoft.FrameWork;
using System.Data;
using System.Data.OracleClient;
using Zysoft.ZyExternal.DAL.Common;

namespace Zysoft.ZyExternal.DAL.His
{
    public class SvrRmlisDal : DB
    {



        #region 构造函数
        public SvrRmlisDal()
        {
        }

        public SvrRmlisDal(OracleConnection DBConnection, OracleTransaction DBTransaction)
        {
            this.DBConnection = DBConnection;
            this.DBTransaction = DBTransaction;
        }
        #endregion

        #region 生成试管费用 

        public int ChargeTube(List<string> applyNos, out string errorMsg)
        {
            errorMsg = "";
            try
            {


                UtilityDAL utilityDal = new UtilityDAL();
                //libin 20170626 生成试管费用 
                string itemCode;
                string itemClass;
                int visitNumber;
                string itemid;
                decimal qty;
                string reqitemCode;
                string temp;
                string reqGroupID;
                string applyClassCode;

                string recordNo = "";  //中间表主键
                string age;
                string sickId = "";  //病人id 
                string ioFlag; //门诊住院标志
                string residenceNo = "";//,门诊挂号号
                string sickName;   //病人姓名
                string sex;//性别
                string execDept;   //执行科室
                string chargeName; //收费项目名称
                decimal charge;//价格
                string patientDept = "";  //病人所在科室
                List<string> applyNoReals = new List<string>();
                string applyDoctor = "";  //申请医生
                if (applyNos.Count == 0)
                {
                    return 0;
                    //errorMsg = "获取试管费时,传入的单据号为空,请检查!";
                    //return -1;
                }
                itemCode = temp = "";

                StringBuilder sql = new StringBuilder();

                foreach (string applyNo in applyNos)
                {
                    sql.Clear();
                    sql.Append(@"select (a.APPLY_CLASS_CODE) apply_class_code, 
                                    (item_code) item_code, 
                                    (item_class) item_class,
                                    (visit_number) visit_number, 
                                    (sick_id) sick_id, 
                                    (nullah_number) residence_no, 
                                    (a.apply_doctor) apply_doctor, 
                                    (a.apply_dept) patient_dept
                                from v_apply_sheet_union a
                               where a.apply_no = :arg_apply_no
                                 and rownum =1");
                    OracleParameter[] parmApplySheet =
                        {
                        new OracleParameter("arg_apply_no",applyNo)
                    };
                    DataTable dtApplySheet = Select(sql.ToString(), parmApplySheet);
                    if (dtApplySheet.Rows.Count == 0) continue;
                    //退费单 不处理
                    applyClassCode = dtApplySheet.Rows[0]["apply_class_code"].ToString();
                    temp = dtApplySheet.Rows[0]["item_code"].ToString();
                    itemClass = dtApplySheet.Rows[0]["item_class"].ToString();
                    visitNumber = int.Parse(dtApplySheet.Rows[0]["visit_number"].ToString());
                    sickId = dtApplySheet.Rows[0]["sick_id"].ToString();
                    residenceNo = dtApplySheet.Rows[0]["residence_no"].ToString();
                    applyDoctor = dtApplySheet.Rows[0]["apply_doctor"].ToString();
                    patientDept = dtApplySheet.Rows[0]["patient_dept"].ToString();

                    if (applyClassCode == "0041") continue; //退费单 不处理

                    if (itemClass != "D") continue;//检验单才处理

                    if (visitNumber > 0) continue;//只有门诊处理

                    //判断是否已经生成过试管费
                    sql.Clear();
                    sql.Append(@"
                select 1
                  from custom.lis_requestion_tube_temp
                 where apply_no = :arg_apply_no
                   and valid_flag = 'Y'");
                    OracleParameter[] parmRequestionTube =
                        {
                        new OracleParameter("arg_apply_no",applyNo)
                    };
                    DataTable dtRequestionTube = Select(sql.ToString(), parmRequestionTube);
                    if (dtRequestionTube.Rows.Count > 0) continue;

                    temp = "'" + temp + "'" + ",";
                    itemCode = itemCode + temp;

                    applyNoReals.Add(applyNo);

                }


                if (applyNoReals.Count == 0) return 0;
                itemCode = StringExtension.ReplaceLast(itemCode, ",", "");

                if (itemCode.IsNull()) return 0;
                if (sickId.IsNull()) return 0;
                sql.Clear();
                sql.Append(@"
                select f.name sick_name,f_get_age(f.sick_id) age,f.sex sex
                 from sick_basic_info f
                where f.sick_id = :arg_sick_id");
                OracleParameter[] paraSickBase = { new OracleParameter("arg_sick_id",sickId)
                                                };
                DataTable dtSickBase = Select(sql.ToString(), paraSickBase);
                sickName = dtSickBase.Rows[0]["sick_name"].ToString();
                age = dtSickBase.Rows[0]["age"].ToString();
                sex = dtSickBase.Rows[0]["sex"].ToString();

                ioFlag = "0";
                execDept = utilityDal.GetSysParm("lis_fee_exec_dept");
                if (execDept.IsNull())
                {
                    errorMsg = "请确认lis_fee_exec_dept(试管费执行科室)是否配置正确!";
                    return -1;
                }

                if (residenceNo.IsNull())
                {
                    sql.Clear();
                    sql.Append(@"select max(to_number(f.nullah_number)) residence_no
                               from dispensary_sick_cure_info f
                              where f.sick_id = :arg_sick_id
                                and cure_dept is not null");
                    OracleParameter[] parmResidenceNo =
                        {
                        new OracleParameter("arg_sick_id",sickId)
                    };
                    DataTable dtResidenceNo = Select(sql.ToString(), parmResidenceNo);

                    if (dtResidenceNo.Rows.Count > 0)
                    {
                        residenceNo = dtResidenceNo.Rows[0]["residence_no"].ToString();
                    }
                }

                //优先获取申请科室
                if (patientDept.IsNull())
                {
                    sql.Clear();
                    sql.Append(@"select f.cure_dept patient_dept
                               from dispensary_sick_cure_info f 
                              where f.nullah_number = :arg_residence_no");
                    OracleParameter[] parmPatientDept =
                        {
                        new OracleParameter("arg_residence_no",residenceNo)
                    };
                    DataTable dtPatientDept = Select(sql.ToString(), parmPatientDept);

                    if (dtPatientDept.Rows.Count > 0)
                    {
                        patientDept = dtPatientDept.Rows[0]["patient_dept"].ToString();
                    }
                }

                //连接mssql数据库
                DataTable dtReqItemDict;
                sql.Clear();
                sql.Append(@" select distinct Req_GroupID from REQ_ITEM_DICT where HIS_ItemCode in (" + itemCode + ")");
                SvrRmlis svrRmlis = new SvrRmlis();
                dtReqItemDict = svrRmlis.GetDataTable(sql);
                if (dtReqItemDict == null) return 0;
                if (dtReqItemDict.Rows.Count == 0) return 0;
                foreach (DataRow drReqItemDict in dtReqItemDict.Rows)
                {
                    reqGroupID = drReqItemDict["Req_GroupID"].ToString();
                    qty = 0;
                    if (reqGroupID.IsNull()) continue;
                    sql.Clear();
                    sql.Append(@" select req_itemid itemid,qty  qty
	                             from HIS_ChargeRuleDetail
	                            where ChargeID in (select CHARGE_ID from REQ_GROUP where Req_GroupID  = '" + reqGroupID + "')");
                    DataTable dtChargeRuleDetail = svrRmlis.GetDataTable(sql);
                    if (dtChargeRuleDetail == null)
                    {
                        errorMsg = "查询lis数据库HIS_ChargeRuleDetail失败!";
                        return -1;
                    }

                    if (dtChargeRuleDetail.Rows.Count == 0) continue;
                    itemid = dtChargeRuleDetail.Rows[0]["itemid"].ToString();
                    qty = decimal.Parse(dtChargeRuleDetail.Rows[0]["qty"].ToString());


                    sql.Clear();
                    sql.Append(@"
                select req_itemcode reqitemcode
                    from REQ_ITEM_DICT where req_itemid = '" + itemid + "'");
                    DataTable dtReqItemCode = svrRmlis.GetDataTable(sql);
                    if (dtReqItemCode == null)
                    {
                        errorMsg = "查询lis数据库ls_reqitemcode失败!";
                        return -1;
                    }
                    if (dtReqItemCode.Rows.Count == 0) continue;
                    reqitemCode = dtReqItemCode.Rows[0]["reqitemcode"].ToString();

                    sql.Clear();
                    sql.Append(@"select t.standard_price charge,
	                                t.item_name charge_name
	                        from clinic_item_dict t 
                            where t.item_code = :arg_reqitemcode");
                    OracleParameter[] paraItemDict = { new OracleParameter("arg_reqitemcode",reqitemCode)
                                                };
                    DataTable dtItemDict = Select(sql.ToString(), paraItemDict);
                    if (dtItemDict.Rows.Count == 0) continue;

                    chargeName = dtItemDict.Rows[0]["charge_name"].ToString();
                    charge = decimal.Parse(dtItemDict.Rows[0]["charge"].ToString());

                    if (chargeName.IsNull())
                    {
                        errorMsg = "lis返回管子项目代码为:" + reqitemCode + ",在his诊疗项目中不存在,请检查!";
                        return -1;
                    }

                    recordNo = utilityDal.GetSequenceNO("zhiydba.lis_requestion_id").ToString();
                    if (applyDoctor.IsNull()) applyDoctor = "system";

                    sql.Clear();
                    sql.Append(@"insert into custom.lis_requestion(
                                record_no ,
                                sick_id ,
                                io_flag   ,
                                residence_no,
                                sick_name ,
                                sex  ,
                                age  ,
                                exec_dept ,
                                charge_item_id ,
                                charge_name ,
                                charge    ,
                                charge_state  ,
                                charge_person  ,
                                charge_num   ,
                                patient_dept,
                                operation_time)
                         values(:ls_record_no,
                                :ls_sick_id,
                                :ls_io_flag,
                                :ls_residence_no,
                                :ls_sick_name,
                                :ls_sex,
                                :ls_age,
                                :ls_exec_dept,
                                :ls_reqitemcode,
                                :ls_charge_name,
                                :ldc_charge,
                                '0',
                                :ls_apply_doctor,
                                :li_qty,
                                :ls_patient_dept,
                                sysdate)");
                    OracleParameter[] paraInsRequestion = { new OracleParameter("ls_record_no",recordNo),
                                                        new OracleParameter("ls_sick_id",sickId),
                                                        new OracleParameter("ls_io_flag",ioFlag),
                                                        new OracleParameter("ls_residence_no",residenceNo),
                                                        new OracleParameter("ls_sick_name",sickName),
                                                        new OracleParameter("ls_sex",sex),
                                                        new OracleParameter("ls_age",age),
                                                        new OracleParameter("ls_exec_dept",execDept),
                                                        new OracleParameter("ls_reqitemcode",reqitemCode),
                                                        new OracleParameter("ls_charge_name",chargeName),
                                                        new OracleParameter("ldc_charge",charge),
                                                        new OracleParameter("ls_apply_doctor",applyDoctor),
                                                        new OracleParameter("li_qty",qty),
                                                        new OracleParameter("ls_patient_dept",patientDept)
                                                };
                    Insert(sql.ToString(), paraInsRequestion);
                }
                if (dtReqItemDict.Rows.Count > 0)
                {
                    if (recordNo.IsNull()) recordNo = utilityDal.GetSequenceNO("zhiydba.lis_requestion_id").ToString();
                    //找最后一条ls_record_no 作为临时表的记录号
                    sql.Clear();
                    sql.Append(@"
                        insert into  custom.lis_requestion_tube_temp(
					          record_no,
					          apply_no,
					          operator_date,
					          register_dept,
					          register_man,
			                  valid_flag) 
                         values(
					          :ls_record_no,
					          :arg_apply_no,
					          sysdate,
					          :arg_register_dept,
					          :arg_operator,
					          'Y'
				                )");
                    foreach (string applyNo in applyNoReals)
                    {
                        OracleParameter[] paraInsRequestionTube = { new OracleParameter("ls_record_no",recordNo),
                                                        new OracleParameter("arg_apply_no",applyNo),
                                                        new OracleParameter("arg_register_dept",ioFlag),
                                                        new OracleParameter("arg_operator",residenceNo)
                                                };
                        Insert(sql.ToString(), paraInsRequestionTube);
                    }
                }
                else
                {
                    return 0;
                }
                return 2;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("生成试管费用 ", ex);
                return -1;
            }
        }
        #endregion
    }
}
