using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.OracleClient;
using System.Data;
using Zysoft.FrameWork.Database;
using Zysoft.FrameWork;
using Zysoft.ZyExternal.DAL.Common;
using Zysoft.FrameWork.WebService;
using Zysoft.ZyExternal.DAL.His.RemoteService;
using System.Web.Configuration;

namespace Zysoft.ZyExternal.DAL.His
{
    public class DHCRisDal : DB
    {



        #region RIS系统的报告信息返回
        public int ReportStatusInfo(string hisAppid, string affirmMan, string affirmDate, string status, out string outParm)
        {
            UtilityDAL utilityDAL = new UtilityDAL();
            string applyNo;
            //long itemSequence;
            DateTime intetAffirmDate;
            intetAffirmDate = affirmDate.To<DateTime>();

            applyNo = hisAppid.Substring(0, hisAppid.IndexOf('|'));
            outParm = "";
            StringBuilder sql = new StringBuilder();
            
            try
            {
                sql.Clear();
                sql.Append(@"update apply_sheet
                            set interface_affirm_flag = :arg_flag,
                                interface_affirm_man = :arg_man,
                                interface_affirm_date = :arg_date
                            where apply_no =:arg_apply_no");
                OracleParameter[] paraUpdateApplySheet = { 
                                              new OracleParameter("arg_apply_no", applyNo),
                                              new OracleParameter("arg_flag", status),
                                              new OracleParameter("arg_man", affirmMan),
                                              new OracleParameter("arg_date", intetAffirmDate)
                                                 };
                Insert(sql.ToString(), paraUpdateApplySheet);

                sql.Clear();
                sql.Append(@"update Apply_Sheet_Pool
                            set interface_affirm_flag = :arg_flag,
                                interface_affirm_man = :arg_man,
                                interface_affirm_date = :arg_date
                            where apply_no =:arg_apply_no");
                OracleParameter[] paraUpdateApplySheetPool = { 
                                              new OracleParameter("arg_apply_no", applyNo),
                                              new OracleParameter("arg_flag", status),
                                              new OracleParameter("arg_man", affirmMan),
                                              new OracleParameter("arg_date", intetAffirmDate)
                                                 };
                Insert(sql.ToString(), paraUpdateApplySheetPool);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("RIS系统的报告信息返回", ex);
                return -1;
            }
            return 0;
        }
        #endregion

        
    }
}
