using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zysoft.FrameWork.Database;
using Zysoft.FrameWork;


namespace Zysoft.ZyExternal.DAL.Common
{
    public class UtilityDAL : DB
    {

        public string HospitalID
        {
            get;
            set;
        }

       
        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetSysDateTime()
        {
            return Select<DateTime>("select sysdate from dual");
        }

        /// <summary>
        /// 获取数据库序列号
        /// </summary>
        /// <param name="sequenceName">序列号名称</param>
        /// <returns></returns>
        public long GetSequenceNO(string sequenceName)
        {
            string sql = String.Format("Select {0}.nextval From dual", sequenceName);
            //
            return Select<long>(sql);
        }

        public XmlDocument GetResponseXmlDoc()
        {
            XmlDocument docResponse = new XmlDocument();

            string inParm;
            inParm = "<?xml version=\"1.0\" encoding=\"gb2312\"?>";
            inParm += @"<Response> 
                            <TradeCode>3001</TradeCode> 
                            <HospitalID>03001</HospitalID> 
                            <HISDate>20121203134608</HISDate> 
                            <HISTradeNo></HISTradeNo> 
                            <ResultCode>0000</ResultCode> 
                            <ResultContent>成功</ResultContent> 
                        </Response>";
            docResponse.LoadXml(inParm);
            return docResponse;
        }

        public XmlDocument GetRequestXmlDoc()
        {
            XmlDocument docRequest = new XmlDocument();

            string inParm;
            inParm = "<?xml version=\"1.0\" encoding=\"gb2312\"?>";
            inParm += @"<Request> 
                            <TradeCode>3001</TradeCode> 
                            <BankID>02</BankID> 
                            <HospitalID>03001</HospitalID> 
                            <ClientType></ClientType>
                            <TerminalID></TerminalID> 
                            <ExtUserID>1400001</ExtUserID>
                            <HISDate></HISDate> 
                            <HISTradeNo></HISTradeNo> 
                        </Request>";
            docRequest.LoadXml(inParm);
            return docRequest;
        }

        public XmlDocument GetResponseXuanQueryXmlDoc() 
        {
            XmlDocument docResponseXuanQuery = new XmlDocument();

            string inParm;
            inParm = "<?xml version=\"1.0\" encoding=\"gb2312\"?>";
            inParm += @"<response>
                          <resultCode>  </resultCode>
                          <resultMessage>  </resultMessage>
                          <result>
                          </result>
                        </response>";
            docResponseXuanQuery.LoadXml(inParm);
            return docResponseXuanQuery;
        }

        public XmlDocument GetResponseNjpkQueryXmlDoc()
        {
            XmlDocument docResponseNjpkQuery = new XmlDocument();


            string inParm;
            inParm = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            inParm += @"<root>
                          <appCode>  </appCode>
                          <errorMsg>  </errorMsg>
                        </root>";
            docResponseNjpkQuery.LoadXml(inParm);
            return docResponseNjpkQuery; 
        }

        public XmlDocument GetResponseXuanTranXmlDoc()
        {
            XmlDocument docResponseXuanTran = new XmlDocument();

            string inParm;
            inParm = "<?xml version=\"1.0\" encoding=\"gb2312\"?>";
            inParm += @"<response>
                          <resultCode>  </resultCode>
                          <resultMessage>  </resultMessage>
                          <result> </result>
                        </response>";
            docResponseXuanTran.LoadXml(inParm);
            return docResponseXuanTran;
        }

        public string GetSysParm(string engName)
        {
            string sql = @"select value from sys_parm where eng_name =  :arg_eng_name";
            OracleParameter[] parameters = {
                new OracleParameter("arg_eng_name", engName)
            };

            DataTable dtSysParm = Select(sql, parameters, "arg_eng_name");
            if (dtSysParm.Rows.Count == 1)
                return dtSysParm.Rows[0]["value"].ToString().Trim();
            else
                return "";
        }

        #region 年龄转换为小时， 和出生日期
        /// <summary>
        /// 年龄转换为小时， 和出生日期
        /// </summary>
        /// <param name="rDisplayAge"></param>
        /// <param name="rHour"></param>
        /// <param name="rBirthDate"></param>
        /// <param name="rResult"></param>
        /// <returns></returns>
        public int AgeToHour(ref string rDisplayAge, out long rHour, out DateTime rBirthDate, out string rResult)
        {
            string display;
            int pos;
            //long ll_time;
            string year, month, week, day, time;
            if (rDisplayAge.IsNull()) rDisplayAge = "0岁";
            display = rDisplayAge.Trim();

            if (display.IndexOf("小时") > -1)
                display = display.Replace("小时", "时");

            if (display.IndexOf("个月") > -1)
                display = display.Replace("个月", "月");

            display = display.Replace("+", "");

            if (display.IndexOf("y") > -1)
                display = display.Replace("y", "岁");

            if (display.IndexOf("Y") > -1)
                display = display.Replace("Y", "岁");

            if (display.IndexOf("m") > -1)
                display = display.Replace("m", "月");

            if (display.IndexOf("M") > -1)
                display = display.Replace("M", "月");

            if (display.IndexOf("w") > -1)
                display = display.Replace("w", "周");

            if (display.IndexOf("W") > -1)
                display = display.Replace("W", "周");

            if (display.IndexOf("d") > -1)
                display = display.Replace("d", "天");

            if (display.IndexOf("D") > -1)
                display = display.Replace("D", "天");

            if (display.IndexOf("h") > -1)
                display = display.Replace("h", "时");

            if (display.IndexOf("H") > -1)
                display = display.Replace("H", "时");


            if (display.IsFloat())
                display = display + "岁";

            if (display.IndexOf("岁") < 0 && display.IndexOf("月") < 0 && display.IndexOf("周") < 0 && display.IndexOf("天") < 0 &&
                display.IndexOf("时") < 0
                )
            {
                rResult = "你输入的年龄格式不对，请重新输入!!";
                rHour = 1;
                rBirthDate = DateTime.Now;
                return -1;
            }

            rDisplayAge = display;
            pos = display.IndexOf("岁");
            if (pos > -1)
            {
                year = display.Substring(0, pos);
                display = display.Substring(pos + 1, display.Length - (pos + 1));
                if (year == "" && year == null)
                    year = "0";
            }
            else
                year = "0";

            pos = display.IndexOf("月");
            if (pos > -1)
            {
                month = display.Substring(0, pos);
                display = display.Substring(pos + 1, display.Length - (pos + 1));
                if (month == "" && month == null)
                    month = "0";
            }
            else
                month = "0";

            pos = display.IndexOf("周");
            if (pos > -1)
            {
                week = display.Substring(0, pos);
                display = display.Substring(pos + 1, display.Length - (pos + 1));
                if (week == "" && week == null)
                    week = "0";
            }
            else
                week = "0";

            pos = display.IndexOf("天");
            if (pos > -1)
            {
                day = display.Substring(0, pos);
                display = display.Substring(pos + 1, display.Length - (pos + 1));
                if (day == "" && day == null)
                    day = "0";
            }
            else
                day = "0";

            pos = display.IndexOf("时");
            if (pos > -1)
            {
                time = display.Substring(0, pos);
                display = display.Substring(pos + 1, display.Length - (pos + 1));
                if (time == "" && time == null)
                    time = "0";
            }
            else
                time = "0";

            rHour = (long.Parse(year) * 365) * 24 + (long.Parse(month) * 30) * 24 + (long.Parse(week) * 7) * 24 + long.Parse(day) * 24 + long.Parse(time);


            rBirthDate = DateTime.Now.AddYears(-Convert.ToInt16(year));
            rBirthDate = rBirthDate.AddMonths(-Convert.ToInt16(month));
            rBirthDate = rBirthDate.AddDays(-long.Parse(day));
            rBirthDate = rBirthDate.AddDays(-long.Parse(time));
            rResult = "成功";
            return 0;
        }
        #endregion

        #region 获取五笔码、拼音码
        public string GetSpellCode(string name)
        {
            return GetWordCode(name, "SPELL_CODE");
        }

        public string GetWbzxCode(string name)
        {
            return GetWordCode(name, "WBZX_CODE");
        }

        private string GetWordCode(string chinese, string type)
        {
            string returnStr = string.Empty;
            string myChar;

            do
            {
                myChar = chinese.Substring(0, 1);
                int myAsciiCode = GetAsciiCode(myChar);
                if (CheckChineseChar(myChar) == false)
                {
                    //非汉字
                    if ((myAsciiCode >= GetAsciiCode("A") && myAsciiCode <= GetAsciiCode("Z"))
                       || (myAsciiCode >= GetAsciiCode("a") && myAsciiCode <= GetAsciiCode("z"))
                       || (myAsciiCode >= GetAsciiCode("0") && myAsciiCode <= GetAsciiCode("9")))
                    {
                        if (string.IsNullOrEmpty(myChar) == false)
                        {
                            returnStr += myChar;
                        }
                    }
                }
                else
                {
                    returnStr += GetCode(myChar, type);
                }

                chinese = chinese.Substring(1);

            } while (string.IsNullOrEmpty(chinese) == false);

            if (returnStr.Length > 200)
                returnStr = returnStr.Substring(0, 200).Trim().ToUpper();

            return returnStr;
        }

        /// <summary>
        /// 获取拼音全拼(首字母大写)
        /// </summary>
        /// <param name="chinese"></param>
        /// <returns></returns>
        public string GetChineseSpellCode(string chinese)
        {
            string returnStr = string.Empty;
            string myChar;
            if (string.IsNullOrEmpty(chinese))
            {
                return string.Empty;
            }
            do
            {
                myChar = chinese.Substring(0, 1);
                int myAsciiCode = GetAsciiCode(myChar);
                if (CheckChineseChar(myChar) == false)
                {
                    //非汉字
                    if ((myAsciiCode >= GetAsciiCode("A") && myAsciiCode <= GetAsciiCode("Z"))
                       || (myAsciiCode >= GetAsciiCode("a") && myAsciiCode <= GetAsciiCode("z"))
                       || (myAsciiCode >= GetAsciiCode("0") && myAsciiCode <= GetAsciiCode("9")))
                    {
                        if (string.IsNullOrEmpty(myChar) == false)
                        {
                            returnStr += myChar;
                        }
                    }
                }
                else
                {
                    string wbzx = string.Empty;
                    string spell = string.Empty;
                    GetChineseCode(myChar, ref spell, ref wbzx);
                    if (!string.IsNullOrEmpty(spell))
                    {
                        string firstWord = spell[0].ToString().ToUpper();
                        spell = firstWord + spell.Substring(1);
                    }
                    returnStr += spell;
                }

                chinese = chinese.Substring(1);

            } while (string.IsNullOrEmpty(chinese) == false);

            if (returnStr.Length > 200)
                returnStr = returnStr.Substring(0, 200).Trim().ToUpper();

            return returnStr;
        }

        /// <summary>
        /// 获取国家英文名
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public string GetCountryEnglishName(int countryCode)
        {
            return (new UtilityDAL()).GetCountryEnglishName(countryCode);
        }

        /// <summary>
        /// 获取机构英文名
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public string GetOrgEnglishName(int orgId)
        {
            return (new UtilityDAL()).GetOrgEnglishName(orgId);
        }

        private int GetAsciiCode(string word)
        {
            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
            int myAsciiCode = Convert.ToInt32(asciiEncoding.GetBytes(word)[0]);

            return myAsciiCode;
        }

        /// <summary>
        /// 判断是否为汉字
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private bool CheckChineseChar(string word)
        {
            byte[] sarr = System.Text.Encoding.GetEncoding("gb2312").GetBytes(word);

            if (sarr.Length == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //获取单个汉字的拼音码或者五笔码
        private string GetCode(string chinese, string type)
        {
            string sql = string.Format("select {0} from INPUT_WAY_DICT where WORD = '{1}'", type, chinese);


            DataTable dtWayDict = Select(sql, null, "WayDict");
            if (dtWayDict.Rows.Count > 0)
            {
                string inputCode;
                inputCode = dtWayDict.Rows[0][0].ToString().Trim();
                if (inputCode.IsNotNull())
                {
                    return inputCode.Substring(0, 1);
                }
                return string.Empty;
            }
            else
            {
                return string.Empty;
            }

        }


        //获取单个汉字的拼音码或者五笔码
        public void GetChineseCode(string chinese, ref string spellCode, ref string wbzxCode)
        {
            string strSQL = "select SPELL_CODE,WBZX_CODE from INPUT_WAY_DICT where WORD = :chinese";
            OracleParameter[] para = { new OracleParameter("chinese", chinese) };
            DataTable dtResult = Select(strSQL, para);
            if (dtResult.Rows.Count > 0)
            {
                spellCode = dtResult.Rows[0]["SPELL_CODE"].ToString().Trim().ToUpper();
                wbzxCode = dtResult.Rows[0]["WBZX_CODE"].ToString().Trim().ToUpper();
            }
            else
            {
                spellCode = string.Empty;
                wbzxCode = string.Empty;
            }
        }
        #endregion

        public string GetIniDict(string iniName, string subsystemCode)
        {
            string iniValue;
            string sql = @"select INI_DEFAULT value from SUBSYSTEM_LOCALINI_DICT where STAFF_NO = '##' and INI_NAME =  :arg_ini_name and rownum = 1";
            OracleParameter[] parameters = {
                new OracleParameter("arg_ini_name", iniName)
            };

            DataTable dtSubsystemLocaliniDict = Select(sql, parameters, "SubsystemLocaliniDict");
            if (dtSubsystemLocaliniDict.Rows.Count == 1)
                iniValue = dtSubsystemLocaliniDict.Rows[0]["value"].ToString().Trim();
            else
                iniValue = "";
            return iniValue;
        }
    }
}
