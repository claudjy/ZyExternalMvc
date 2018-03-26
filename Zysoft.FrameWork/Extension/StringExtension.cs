using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Zysoft.FrameWork
{
    public static class StringExtension
    {
        #region 正则表达式判断输入(add by lsz.2009-9-22)
        /// <summary>
        /// 判断字符串是否与指定正则表达式匹配
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <param name="regularExp">正则表达式</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsMatch(string value, string regularExp)
        {
            return Regex.IsMatch(value, regularExp);
        }

        /// <summary>
        /// 验证非负整数（正整数 + 0）
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUnMinusInt(this string value)
        {
            return Regex.IsMatch(value, RegularExp.UnMinusInteger);
        }

        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsPlusInt(this string value)
        {
            return Regex.IsMatch(value, RegularExp.PlusInteger);
        }

        /// <summary>
        /// 验证非正整数（负整数 + 0） 
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUnPlusInt(this string value)
        {
            return Regex.IsMatch(value, RegularExp.UnPlusInteger);
        }

        /// <summary>
        /// 验证负整数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsMinusInt(this string value)
        {
            return Regex.IsMatch(value, RegularExp.MinusInteger);
        }

        /// <summary>
        /// 验证整数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsInt(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Integer);
        }

        /// <summary>
        /// 验证非负浮点数（正浮点数 + 0）
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUnMinusFloat(this string value)
        {
            return Regex.IsMatch(value, RegularExp.UnMinusFloat);
        }

        /// <summary>
        /// 验证正浮点数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsPlusFloat(this string value)
        {
            return Regex.IsMatch(value, RegularExp.PlusFloat);
        }

        /// <summary>
        /// 验证非正浮点数（负浮点数 + 0）
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUnPlusFloat(this string value)
        {
            return Regex.IsMatch(value, RegularExp.UnPlusFloat);
        }

        /// <summary>
        /// 验证负浮点数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsMinusFloat(this string value)
        {
            return Regex.IsMatch(value, RegularExp.MinusFloat);
        }

        /// <summary>
        /// 验证浮点数
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsFloat(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Float);
        }

        /// <summary>
        /// 验证由26个英文字母组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsLetter(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Letter);
        }

        /// <summary>
        /// 验证由中文组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsChinese(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Chinese);
        }

        /// <summary>
        /// 验证由26个英文字母的大写组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUpperLetter(this string value)
        {
            return Regex.IsMatch(value, RegularExp.UpperLetter);
        }

        /// <summary>
        /// 验证由26个英文字母的小写组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsLowerLetter(this string value)
        {
            return Regex.IsMatch(value, RegularExp.LowerLetter);
        }

        /// <summary>
        /// 验证由数字和26个英文字母组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsNumericOrLetter(this string value)
        {
            return Regex.IsMatch(value, RegularExp.NumericOrLetter);
        }

        /// <summary>
        /// 验证由数字组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsNumeric(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Numeric);
        }
        /// <summary>
        /// 验证由数字和26个英文字母或中文组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsNumericOrLetterOrChinese(this string value)
        {
            return Regex.IsMatch(value, RegularExp.NumbericOrLetterOrChinese);
        }

        /// <summary>
        /// 验证由数字、26个英文字母或者下划线组成的字符串
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsNumericOrLetterOrUnderline(this string value)
        {
            return Regex.IsMatch(value, RegularExp.NumericOrLetterOrUnderline);
        }

        /// <summary>
        /// 验证email地址
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsEmail(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Email);
        }

        /// <summary>
        /// 验证URL
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsUrl(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Url);
        }

        /// <summary>
        /// 验证电话号码
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsTelephone(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Telephone);
        }

        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsMobile(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Mobile);
        }

        /// <summary>
        /// 通过文件扩展名验证图像格式
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsImageFormat(this string value)
        {
            return Regex.IsMatch(value, RegularExp.ImageFormat);
        }

        /// <summary>
        /// 验证IP
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsIP(this string value)
        {
            return Regex.IsMatch(value, RegularExp.IP);
        }

        /// <summary>
        /// 验证日期（YYYY-MM-DD）
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsDate(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Date);
        }

        /// <summary>
        /// 验证日期和时间（YYYY-MM-DD HH:MM:SS）
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsDateTime(this string value)
        {
            return Regex.IsMatch(value, RegularExp.DateTime);
        }

        /// <summary>
        /// 验证颜色（#ff0000）
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <returns>验证通过返回true</returns>
        public static bool IsColor(this string value)
        {
            return Regex.IsMatch(value, RegularExp.Color);
        }
        #endregion

        public struct RegularExp
        {
            public const string Chinese = @"^[\u4E00-\u9FA5\uF900-\uFA2D]+$";
            public const string Color = "^#[a-fA-F0-9]{6}";
            public const string Date = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
            public const string DateTime = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$";
            public const string Email = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            public const string Float = @"^(-?\d+)(\.\d+)?$";
            public const string ImageFormat = @"\.(?i:jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$";
            public const string Integer = @"^-?\d+$";
            public const string IP = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
            public const string Letter = "^[A-Za-z]+$";
            public const string LowerLetter = "^[a-z]+$";
            public const string MinusFloat = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";
            public const string MinusInteger = "^-[0-9]*[1-9][0-9]*$";
            public const string Mobile = "^0{0,1}13[0-9]{9}$";
            public const string NumbericOrLetterOrChinese = @"^[A-Za-z0-9\u4E00-\u9FA5\uF900-\uFA2D]+$";
            public const string Numeric = "^[0-9]+$";
            public const string NumericOrLetter = "^[A-Za-z0-9]+$";
            public const string NumericOrLetterOrUnderline = @"^\w+$";
            public const string PlusFloat = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
            public const string PlusInteger = "^[0-9]*[1-9][0-9]*$";
            public const string Telephone = @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?";
            public const string UnMinusFloat = @"^\d+(\.\d+)?$";
            public const string UnMinusInteger = @"\d+$";
            public const string UnPlusFloat = @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$";
            public const string UnPlusInteger = @"^((-\d+)|(0+))$";
            public const string UpperLetter = "^[A-Z]+$";
            public const string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
        }

        /// <summary>
        /// 获取基本SQL语句
        /// </summary>
        /// <param name="value">表名</param>
        /// <returns></returns>
        public static StringBuilder ToBasicSql(this string value)
        {
            StringBuilder sb = new StringBuilder("select * from ");
            return sb.Append(value);
        }

        // <summary>
        /// 获得一个16位时间随机数
        /// </summary>
        /// <returns>返回随机数</returns>
        public static string GetDataRandom()
        {
            string strData = DateTime.Now.ToString();
            strData = strData.Replace(":", "");
            strData = strData.Replace("-", "");
            strData = strData.Replace(" ", "");
            Random r = new Random();
            strData = strData + r.Next(100000);
            return strData;
        }
        /// <summary>
        /// 获得某个字符串在另个字符串中出现的次数
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strSymbol">符号</param>
        /// <returns>返回值</returns>
        public static int GetStrCount(string strOriginal, string strSymbol)
        {
            int count = 0;
            for (int i = 0; i < (strOriginal.Length - strSymbol.Length + 1); i++)
            {
                if (strOriginal.Substring(i, strSymbol.Length) == strSymbol)
                {
                    count = count + 1;
                }
            }
            return count;
        }
        /// <summary>
        /// 获得某个字符串在另个字符串第一次出现时前面所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strSymbol">符号</param>
        /// <returns>返回值</returns>
        public static string GetFirstStr(string strOriginal, string strSymbol)
        {
            int strPlace = strOriginal.IndexOf(strSymbol);
            if (strPlace != -1)
                strOriginal = strOriginal.Substring(0, strPlace);
            return strOriginal;
        }
        /// <summary>
        /// 获得某个字符串在另个字符串最后一次出现时后面所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strSymbol">符号</param>
        /// <returns>返回值</returns>
        public static string GetLastStr(string strOriginal, string strSymbol)
        {
            int strPlace = strOriginal.LastIndexOf(strSymbol) + strSymbol.Length;
            strOriginal = strOriginal.Substring(strPlace);
            return strOriginal;
        }
        /// <summary>
        /// 获得两个字符之间第一次出现时前面所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strFirst">最前哪个字符</param>
        /// <param name="strLast">最后哪个字符</param>
        /// <returns>返回值</returns>
        public static string GetTwoMiddleFirstStr(string strOriginal, string strFirst, string strLast)
        {
            strOriginal = GetFirstStr(strOriginal, strLast);
            strOriginal = GetLastStr(strOriginal, strFirst);
            return strOriginal;
        }
        /// <summary>
        /// 获得两个字符之间最后一次出现时的所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strFirst">最前哪个字符</param>
        /// <param name="strLast">最后哪个字符</param>
        /// <returns>返回值</returns>
        public static string GetTwoMiddleLastStr(string strOriginal, string strFirst, string strLast)
        {
            strOriginal = GetLastStr(strOriginal, strFirst);
            strOriginal = GetFirstStr(strOriginal, strLast);
            return strOriginal;
        }

        /// <summary>
        /// 检查相等之后，获得字符串
        /// </summary>
        /// <param name="str">字符串1</param>
        /// <param name="checkStr">字符串2</param>
        /// <param name="reStr">相等之后要返回的字符串</param>
        /// <returns>返回字符串</returns>
        public static string GetCheckStr(string str, string checkStr, string reStr)
        {
            if (str == checkStr)
            {
                return reStr;
            }
            return "";
        }
        /// <summary>
        /// 检查相等之后，获得字符串
        /// </summary>
        /// <param name="str">数值1</param>
        /// <param name="checkStr">数值2</param>
        /// <param name="reStr">相等之后要返回的字符串</param>
        /// <returns>返回字符串</returns>
        public static string GetCheckStr(int str, int checkStr, string reStr)
        {
            if (str == checkStr)
            {
                return reStr;
            }
            return "";
        }
        /// <summary>
        /// 检查相等之后，获得字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="checkStr"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public static string GetCheckStr(bool str, bool checkStr, string reStr)
        {
            if (str == checkStr)
            {
                return reStr;
            }
            return "";
        }
        /// <summary>
        /// 检查相等之后，获得字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="checkStr"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public static string GetCheckStr(object str, object checkStr, string reStr)
        {
            if (str == checkStr)
            {
                return reStr;
            }
            return "";
        }

        /// <summary>
        /// 截取左边规定字数字符串
        /// </summary>
        /// <param name="str">需截取字符串</param>
        /// <param name="length">截取字数</param>
        /// <returns>返回截取字符串</returns>
        public static string GetLeftStr(string str, int length)
        {
            string reStr;
            if (length < str.Length)
            {
                reStr = str.Substring(0, length);
            }
            else
            {
                reStr = str;
            }
            return reStr;
        }


        /// <summary>
        /// 截取右边规定字数字符串
        /// </summary>
        /// <param name="str">需截取字符串</param>
        /// <param name="length">截取字数</param>
        /// <returns>返回截取字符串</returns>
        public static string GetRightStr(string str, int length)
        {
            string reStr;
            if (length < str.Length)
            {
                reStr = str.Substring(str.Length - length, length);
            }
            else
            {
                reStr = str;
            }
            return reStr;
        }
        /// <summary>
        /// 获得双字节字符串的字节数
        /// </summary>
        /// <param name="str">要检测的字符串</param>
        /// <returns>返回字节数</returns>
        public static int GetStrLength(string str)
        {
            ASCIIEncoding n = new ASCIIEncoding();
            byte[] b = n.GetBytes(str);
            int l = 0; // l 为字符串之实际长度
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == 63) //判断是否为汉字或全脚符号
                {
                    l++;
                }
                l++;
            }
            return l;
        }
        /// <summary>
        /// 剥去HTML标签
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RegStripHtml(string text)
        {
            string reStr;
            string RePattern = @"<\s*(\S+)(\s[^>]*)?>";
            reStr = Regex.Replace(text, RePattern, string.Empty, RegexOptions.Compiled);
            reStr = Regex.Replace(reStr, @"\s+", string.Empty, RegexOptions.Compiled);
            return reStr;
        }
        /// <summary>
        /// 转换HTML与相对去处相对标签 未测试
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ReLabel"></param>
        /// <returns></returns>
        public static string RegStripHtml(string text, string[] ReLabel)
        {
            string reStr = text;
            string LabelPattern = @"<({0})\s*(\S+)(\s[^>]*)?>[\s\S]*<\s*\/\1\s*>";
            string RePattern = @"<\s*(\S+)(\s[^>]*)?>";
            for (int i = 0; i < ReLabel.Length; i++)
            {
                reStr = Regex.Replace(reStr, string.Format(LabelPattern, ReLabel[i]), string.Empty, RegexOptions.IgnoreCase);
            }
            reStr = Regex.Replace(reStr, RePattern, string.Empty, RegexOptions.Compiled);
            reStr = Regex.Replace(reStr, @"\s+", string.Empty, RegexOptions.Compiled);
            return reStr;
        }
        /// <summary>
        /// 使Html失效,以文本显示
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <returns>失效后字符串</returns>
        public static string ReplaceHtml(string str)
        {
            str = str.Replace("<", "&lt");
            return str;
        }
        /// <summary>
        /// 获得随机数字
        /// </summary>
        /// <param name="Length">随机数字的长度</param>
        /// <returns>返回长度为 Length 的　<see cref="System.Int32"/> 类型的随机数</returns>
        /// <example>
        /// Length 不能大于9,以下为示例演示了如何调用 GetRandomNext：<br />
        /// <code>
        /// int le = GetRandomNext(8);
        /// </code>
        /// </example>
        public static int GetRandomNext(int Length)
        {
            if (Length > 9)
                throw new System.IndexOutOfRangeException("Length的长度不能大于10");
            Guid gu = Guid.NewGuid();
            string str = "";
            for (int i = 0; i < gu.ToString().Length; i++)
            {
                if (IsNumber(gu.ToString()[i]))
                {
                    str += ((gu.ToString()[i]));
                }
            }
            int guid = int.Parse(str.Replace("-", "").Substring(0, Length));
            if (!guid.ToString().Length.Equals(Length))
                guid = GetRandomNext(Length);
            return guid;
        }
        /// <summary>
        /// 返回一个 bool 值，指明提供的值是不是整数
        /// </summary>
        /// <param name="obj">要判断的值</param>
        /// <returns>true[是整数]false[不是整数]</returns>
        /// <remarks>
        /// isNumber　只能判断正(负)整数，如果 obj 为小数则返回 false;
        /// </remarks>
        /// <example>
        /// 下面的示例演示了判断 obj 是不是整数：<br />
        /// <code>
        /// bool flag;
        /// flag = isNumber("200");
        /// </code>
        /// </example>
        public static bool IsNumber(object obj)
        {
            //为指定的正则表达式初始化并编译 Regex 类的实例
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^-?(\d*)$");
            //在指定的输入字符串中搜索 Regex 构造函数中指定的正则表达式匹配项
            System.Text.RegularExpressions.Match mc = rg.Match(obj.ToString());
            //指示匹配是否成功
            return (mc.Success);
        }

        /// <summary>
        /// 返回一个 bool 值，指明提供的值是不是日期
        /// </summary>
        /// <param name="obj">要判断的值</param>
        /// <returns>true[是日期]false[不是日期]</returns>
        /// <remarks>
        /// </remarks>
        /// <example>
        /// 下面的示例演示了判断 obj 是不是整数：<br />
        /// <code>
        /// bool flag;
        /// flag = isDate("2008-10-10");
        /// </code>
        /// </example>
        public static bool IsDate(object obj)
        {
            try
            {
                Convert.ToDateTime(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 高亮显示
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="findstr">查找字符串</param>
        /// <param name="cssclass">Style</param>
        /// <returns></returns>
        public static string OutHighlightText(string str, string findstr, string cssclass)
        {
            if (findstr != "")
            {
                string text1 = "<span class=\"" + cssclass + "\">%s</span>";
                str = str.Replace(findstr, text1.Replace("%s", findstr));
            }
            return str;
        }
        /// <summary>
        /// 去除html标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string OutHtmlText(string str)
        {
            string text1 = "<.*?>";
            Regex regex1 = new Regex(text1);
            str = regex1.Replace(str, "");
            str = str.Replace("[$page]", "");
            str = str.Replace("&nbsp;", "");
            return ToHtmlText(str);
        }
        /// <summary>
        /// 将html显示成文本
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToHtmlText(string str)
        {
            if (str == "")
            {
                return "";
            }
            StringBuilder builder1 = new StringBuilder();
            builder1.Append(str);
            builder1.Replace("<", "&lt;");
            builder1.Replace(">", "&gt;");
            //builder1.Replace("\r", "<br>");
            return builder1.ToString();
        }

        public static string AppentString(string strOrigian, int subLen, string strSymobl)
        {
            string strReturn = "";
            while (strOrigian.Length > 0)
            {
                strReturn = strReturn + strOrigian.Substring(0, subLen) + strSymobl;
                strOrigian = strOrigian.Substring(3, strOrigian.Length - subLen);

            }
            if (strReturn.Length > 0) strReturn = strReturn.Substring(0, strReturn.Length - strSymobl.Length);
            return strReturn;
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <param name="intLen"></param>
        /// <returns></returns>
        public static string CutString(string strInput, int intLen)
        {
            strInput = strInput.Trim();
            byte[] buffer1 = Encoding.Default.GetBytes(strInput);
            if (buffer1.Length > intLen)
            {
                string text1 = "";
                for (int num1 = 0; num1 < strInput.Length; num1++)
                {
                    byte[] buffer2 = Encoding.Default.GetBytes(text1);
                    if (buffer2.Length >= (intLen - 4))
                    {
                        break;
                    }
                    text1 = text1 + strInput.Substring(num1, 1);
                }
                return (text1 + "...");
            }
            return strInput;
        }

        /// <summary>
        /// 根据条件返回值
        /// </summary>
        /// <param name="ifValue"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseVale"></param>
        /// <returns></returns>
        public static string IfValue(bool ifValue, string trueValue, string falseVale)
        {
            if (ifValue)
            {
                return trueValue;
            }
            return falseVale;
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 对字符串进行base64编码
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>base64编码串</returns>
        public static string Base64StringEncode(string input)
        {
            if (input.IsNull()) input = "";
            byte[] encbuff = System.Text.Encoding.Default.GetBytes(input);
            return Convert.ToBase64String(encbuff);
        }
        /**/
        /**/
        /// <summary>
        /// 对字符串进行反编码
        /// </summary>
        /// <param name="input">base64编码串</param>
        /// <returns>字符串</returns>
        public static string Base64StringDecode(string input)
        {
            if (input.IsNull()) input = "";
            byte[] decbuff = Convert.FromBase64String(input);
            return System.Text.Encoding.UTF8.GetString(decbuff);
        }

        /**/
        /**/
        /// <summary>
        /// 替换字符串(忽略大小写)
        /// </summary>
        /// <param name="input">要进行替换的内容</param>
        /// <param name="oldValue">旧字符串</param>
        /// <param name="newValue">新字符串</param>
        /// <returns>替换后的字符串</returns>
        public static string CaseInsensitiveReplace(string input, string oldValue, string newValue)
        {
            Regex regEx = new Regex(oldValue, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return regEx.Replace(input, newValue);
        }
        /**/
        /**/
        /**/
        /// <summary>
        /// 替换首次出现的字符串
        /// </summary>
        /// <param name="input">要进行替换的内容</param>
        /// <param name="oldValue">旧字符串</param>
        /// <param name="newValue">新字符串</param>
        /// <returns>替换后的字符串</returns>
        public static string ReplaceFirst(string input, string oldValue, string newValue)
        {
            Regex regEx = new Regex(oldValue, RegexOptions.Multiline);
            return regEx.Replace(input, newValue, 1);
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 替换最后一次出现的字符串
        /// </summary>
        /// <param name="input">要进行替换的内容</param>
        /// <param name="oldValue">旧字符串</param>
        /// <param name="newValue">新字符串</param>
        /// <returns>替换后的字符串</returns>
        public static string ReplaceLast(string input, string oldValue, string newValue)
        {
            int index = input.LastIndexOf(oldValue);
            if (index < 0)
            {
                return input;
            }
            else
            {
                StringBuilder sb = new StringBuilder(input.Length - oldValue.Length + newValue.Length);
                sb.Append(input.Substring(0, index));
                sb.Append(newValue);
                sb.Append(input.Substring(index + oldValue.Length, input.Length - index - oldValue.Length));
                return sb.ToString();
            }
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 根据词组过虑字符串(忽略大小写)
        /// </summary>
        /// <param name="input">要进行过虑的内容</param>
        /// <param name="filterWords">要过虑的词组</param>
        /// <returns>过虑后的字符串</returns>
        public static string FilterWords(string input, params string[] filterWords)
        {
            return StringExtension.FilterWords(input, char.MinValue, filterWords);
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 根据词组过虑字符串(忽略大小写)
        /// </summary>
        /// <param name="input">要进行过虑的内容</param>
        /// <param name="mask">字符掩码</param>
        /// <param name="filterWords">要过虑的词组</param>
        /// <returns>过虑后的字符串</returns>
        public static string FilterWords(string input, char mask, params string[] filterWords)
        {
            string stringMask = mask == char.MinValue ? string.Empty : mask.ToString();
            string totalMask = stringMask;

            foreach (string s in filterWords)
            {
                Regex regEx = new Regex(s, RegexOptions.IgnoreCase | RegexOptions.Multiline);

                if (stringMask.Length > 0)
                {
                    for (int i = 1; i < s.Length; i++)
                        totalMask += stringMask;
                }

                input = regEx.Replace(input, totalMask);

                totalMask = stringMask;
            }

            return input;
        }




        /**/
        /**/
        /**/
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">要进行加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5String(string input)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 对字符串进行MD5较验
        /// </summary>
        /// <param name="input">要进行较验的字符串</param>
        /// <param name="hash">散列串</param>
        /// <returns>是否匹配</returns>
        public static bool MD5VerifyString(string input, string hash)
        {
            string hashOfInput = StringExtension.MD5String(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string PadLeftHtmlSpaces(string input, int totalSpaces)
        {
            string space = "&nbsp;";
            return PadLeft(input, space, totalSpaces * space.Length);
        }

        public static string PadLeft(string input, string pad, int totalWidth)
        {
            return StringExtension.PadLeft(input, pad, totalWidth, false);
        }

        public static string PadLeft(string input, string pad, int totalWidth, bool cutOff)
        {
            if (input.Length >= totalWidth)
                return input;

            int padCount = pad.Length;
            string paddedString = input;

            while (paddedString.Length < totalWidth)
            {
                paddedString += pad;
            }

            // trim the excess.
            if (cutOff)
                paddedString = paddedString.Substring(0, totalWidth);

            return paddedString;
        }

        public static string PadRightHtmlSpaces(string input, int totalSpaces)
        {
            string space = "&nbsp;";
            return PadRight(input, space, totalSpaces * space.Length);
        }

        public static string PadRight(string input, string pad, int totalWidth)
        {
            return StringExtension.PadRight(input, pad, totalWidth, false);
        }

        public static string PadRight(string input, string pad, int totalWidth, bool cutOff)
        {
            if (input.Length >= totalWidth)
                return input;

            string paddedString = string.Empty;

            while (paddedString.Length < totalWidth - input.Length)
            {
                paddedString += pad;
            }

            // trim the excess.
            if (cutOff)
                paddedString = paddedString.Substring(0, totalWidth - input.Length);

            paddedString += input;

            return paddedString;
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 去除新行
        /// </summary>
        /// <param name="input">要去除新行的字符串</param>
        /// <returns>已经去除新行的字符串</returns>
        public static string RemoveNewLines(string input)
        {
            return StringExtension.RemoveNewLines(input, false);
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 去除新行
        /// </summary>
        /// <param name="input">要去除新行的字符串</param>
        /// <param name="addSpace">是否添加空格</param>
        /// <returns>已经去除新行的字符串</returns>
        public static string RemoveNewLines(string input, bool addSpace)
        {
            string replace = string.Empty;
            if (addSpace)
                replace = " ";

            string pattern = @"[\r|\n]";
            Regex regEx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

            return regEx.Replace(input, replace);
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 字符串反转
        /// </summary>
        /// <param name="input">要进行反转的字符串</param>
        /// <returns>反转后的字符串</returns>
        public static string Reverse(string input)
        {
            char[] reverse = new char[input.Length];
            for (int i = 0, k = input.Length - 1; i < input.Length; i++, k--)
            {
                if (char.IsSurrogate(input[k]))
                {
                    reverse[i + 1] = input[k--];
                    reverse[i++] = input[k];
                }
                else
                {
                    reverse[i] = input[k];
                }
            }
            return new System.String(reverse);
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 转成首字母大字形式
        /// </summary>
        /// <param name="input">要进行转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string SentenceCase(string input)
        {
            if (input.Length < 1)
                return input;

            string sentence = input.ToLower();
            return sentence[0].ToString().ToUpper() + sentence.Substring(1);
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 空格转换成&nbsp;
        /// </summary>
        /// <param name="input">要进行转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string SpaceToNbsp(string input)
        {
            string space = "&nbsp;";
            return input.Replace(" ", space);
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 去除"<" 和 ">" 符号之间的内容
        /// </summary>
        /// <param name="input">要进行处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string StripTags(string input)
        {
            Regex stripTags = new Regex("<(.|\n)+?>");
            return stripTags.Replace(input, "");
        }

        public static string TitleCase(string input)
        {
            return TitleCase(input, true);
        }

        public static string TitleCase(string input, bool ignoreShortWords)
        {
            List<string> ignoreWords = null;
            if (ignoreShortWords)
            {
                //TODO: Add more ignore words?
                ignoreWords = new List<string>();
                ignoreWords.Add("a");
                ignoreWords.Add("is");
                ignoreWords.Add("was");
                ignoreWords.Add("the");
            }

            string[] tokens = input.Split(' ');
            StringBuilder sb = new StringBuilder(input.Length);
            foreach (string s in tokens)
            {
                if (ignoreShortWords == true
                    && s != tokens[0]
                    && ignoreWords.Contains(s.ToLower()))
                {
                    sb.Append(s + " ");
                }
                else
                {
                    sb.Append(s[0].ToString().ToUpper());
                    sb.Append(s.Substring(1).ToLower());
                    sb.Append(" ");
                }
            }

            return sb.ToString().Trim();
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 去除字符串内的空白字符
        /// </summary>
        /// <param name="input">要进行处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string TrimIntraWords(string input)
        {
            Regex regEx = new Regex(@"[\s]+");
            return regEx.Replace(input, " ");
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 换行符转换成Html标签的换行符<br />
        /// </summary>
        /// <param name="input">要进行处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string NewLineToBreak(string input)
        {
            Regex regEx = new Regex(@"[\n|\r]+");
            return regEx.Replace(input, "<br />");
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 插入换行符(不中断单词)
        /// </summary>
        /// <param name="input">要进行处理的字符串</param>
        /// <param name="charCount">每行字符数</param>
        /// <returns>处理后的字符串</returns>
        public static string WordWrap(string input, int charCount)
        {
            return StringExtension.WordWrap(input, charCount, false, Environment.NewLine);
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// 插入换行符
        /// </summary>
        /// <param name="input">要进行处理的字符串</param>
        /// <param name="charCount">每行字符数</param>
        /// <param name="cutOff">如果为真，将在单词的中部断开</param>
        /// <returns>处理后的字符串</returns>
        public static string WordWrap(string input, int charCount, bool cutOff)
        {
            return StringExtension.WordWrap(input, charCount, cutOff, Environment.NewLine);
        }


        /**/
        /**/
        /**/
        /// <summary>
        /// 插入换行符
        /// </summary>
        /// <param name="input">要进行处理的字符串</param>
        /// <param name="charCount">每行字符数</param>
        /// <param name="cutOff">如果为真，将在单词的中部断开</param>
        /// <param name="breakText">插入的换行符号</param>
        /// <returns>处理后的字符串</returns>
        public static string WordWrap(string input, int charCount, bool cutOff, string breakText)
        {
            StringBuilder sb = new StringBuilder(input.Length + 100);
            int counter = 0;

            if (cutOff)
            {
                while (counter < input.Length)
                {
                    if (input.Length > counter + charCount)
                    {
                        sb.Append(input.Substring(counter, charCount));
                        sb.Append(breakText);
                    }
                    else
                    {
                        sb.Append(input.Substring(counter));
                    }
                    counter += charCount;
                }
            }
            else
            {
                string[] strings = input.Split(' ');
                for (int i = 0; i < strings.Length; i++)
                {
                    counter += strings[i].Length + 1; // the added one is to represent the inclusion of the space.
                    if (i != 0 && counter > charCount)
                    {
                        sb.Append(breakText);
                        counter = 0;
                    }

                    sb.Append(strings[i] + ' ');
                }
            }
            return sb.ToString().TrimEnd(); // to get rid of the extra space at the end.
        }

        #region 字符串转字节
        /// <summary>
        /// 字符串转字节
        /// </summary>
        /// <param name="asStr"></param>
        /// <returns></returns>
        public static byte StringToByte(string asStr)
        {
            byte lbReturn = 0;
            byte[] lbArray;
            string lsStr;
            lsStr = asStr.Trim().ToUpper();
            if (string.IsNullOrEmpty(lsStr)) return 0;

            switch (lsStr)
            {
                case "[NUL]":           //0           00             NUL (null)                 空字符 
                    lbReturn = 0;
                    break;
                case "[SOH]":           //1           01             SOH (start of handing)     标题开始  
                    lbReturn = 1;
                    break;
                case "[STX]":           //2           02             STX (start of text)        正文开始  
                    lbReturn = 2;
                    break;
                case "[ETX]":           //3           03             ETX (end of text)          正文结束 
                    lbReturn = 3;
                    break;
                case "[EOT]":           //4           04             EOT (end of transmission)  传输结束 
                    lbReturn = 4;
                    break;
                case "[ENQ]":           //5           05             ENQ (enquiry)              请求
                    lbReturn = 5;
                    break;
                case "[ACK]":           //6           06             ACK (acknowledge)          收到通知  
                    lbReturn = 6;
                    break;
                case "[BEL]":           //7           07             BEL (bell)                 响铃 
                    lbReturn = 7;
                    break;
                case "[BS]":           //8           08             BS (backspace)              退格  
                    lbReturn = 8;
                    break;
                case "[HT]":           //9           09             HT (horizontal tab)         水平制表符
                    lbReturn = 9;
                    break;
                case "[LF]":           //10         0A             LF (NL line feed, new line)  换行键  
                    lbReturn = 10;
                    break;
                case "[VT]":           //11         0B             VT (vertical tab)            垂直制表符  
                    lbReturn = 11;
                    break;
                case "[FF]":           //12         0C             FF (NP form feed, new page)  换页键  
                    lbReturn = 12;
                    break;
                case "[CR]":           //13         0D             CR (carriage return)         回车键
                    lbReturn = 13;
                    break;
                case "[SO]":           //14         0E             SO (shift out)               不用切换  
                    lbReturn = 14;
                    break;
                case "[SI]":           //15         0F             SI (shift in)                启用切换  
                    lbReturn = 15;
                    break;
                case "[DLE]":           //16         10             DLE (data link escape)      数据链路转
                    lbReturn = 16;
                    break;
                case "[DC1]":           //17         11             DC1 (device control 1)      设备控制1
                    lbReturn = 17;
                    break;
                case "[DC2]":          //18         12             DC2 (device control 2)       设备控制2  
                    lbReturn = 18;
                    break;
                case "[DC3]":           //19         13             DC3 (device control 3)      设备控制3
                    lbReturn = 19;
                    break;
                case "[DC4]":           //20         14             DC4 (device control 4)      设备控制4 
                    lbReturn = 20;
                    break;
                case "[NAK]":           //21         15             NAK (negative acknowledge)  拒绝接收
                    lbReturn = 21;
                    break;
                case "[SYN]":           //22         16             SYN (synchronous idle)      同步空闲
                    lbReturn = 22;
                    break;
                case "[ETB]":           //23         17             ETB (end of trans. block)   传输块结束
                    lbReturn = 23;
                    break;
                case "[CAN]":           //24         18             CAN (cancel)                取消 
                    lbReturn = 24;
                    break;
                case "[EM]":           //25         19             EM (end of medium)           介质中断  
                    lbReturn = 25;
                    break;
                case "[SUB]":           //26         1A             SUB (substitute)            替补 
                    lbReturn = 26;
                    break;
                case "[ESC]":           //27         1B             ESC (escape)                溢出 
                    lbReturn = 27;
                    break;
                case "[FS]":           //28         1C             FS (file separator)          文件分割符 
                    lbReturn = 28;
                    break;
                case "[GS]":           //29         1D             GS (group separator)         分组符 
                    lbReturn = 29;
                    break;
                case "[RS]":           //30         1E             RS (record separator)        记录分离符
                    lbReturn = 30;
                    break;
                case "[US]":           //31         1F             US (unit separator)          单元分隔符 
                    lbReturn = 31;
                    break;
                case "[空格]":           //32         20             空格 
                    lbReturn = 32;
                    break;
                default:
                    lbArray = ASCIIEncoding.UTF8.GetBytes(lsStr);
                    lbReturn = lbArray[0];
                    break;

            }
            return lbReturn;
        }
        #endregion

        #region 字符串转字节数组
        /// <summary>
        /// 字符串转字节数组 
        /// 如:"[ETX]+[BEL]+[SO]+[CR]" 返回对应ASSII码
        /// </summary>
        /// <param name="asStr"></param>
        /// <returns></returns>
        public static byte[] StringToArrayByte(string asStr)
        {
            string lsSingleStr, lsRightStr;
            int liArray;
            lsRightStr = StringExtension.GetRightStr(asStr, 1);
            if (lsRightStr != "+")
                asStr += "+";
            liArray = StringExtension.GetStrCount(asStr, "+");
            byte[] lbReturn = new byte[liArray];
            for (int i = 0; i < liArray; i++)
            {
                lsSingleStr = StringMid(ref asStr, "+");
                lbReturn[i] = StringToByte(lsSingleStr);
            }
            return lbReturn;
        }
        #endregion

        #region 分割字符串 函数
        /// <summary>
        /// 分割字符串 函数
        /// </summary>
        /// <param name="as_value"></param>
        /// <returns></returns>
        public static string StringMid(ref string as_value)
        {

            return StringMid(ref as_value, ";");
        }

        /// <summary>
        /// 分割字符串 函数
        /// </summary>
        /// <param name="as_value"></param>
        /// <returns></returns>
        public static string StringMid(ref string as_value, string as_split)
        {
            string ls_value, ls_return;
            ls_value = as_value.Trim();
            if (ls_value == "" || ls_value == null)
            {
                as_value = "";
                return "";
            }

            int li_pos;
            li_pos = ls_value.IndexOf(as_split);
            if (li_pos < 0)
            {
                ls_return = ls_value;
                as_value = "";
            }
            else
            {
                ls_return = ls_value.Substring(0, li_pos);
                as_value = ls_value.Substring(li_pos + 1, ls_value.Length - (li_pos + 1));
            }
            return ls_return;
        }
        #endregion

        #region C#对字符串含中文字符时按byte[]方式读取
        /// <summary>
        /// 对字符串含中文字符时按byte[]方式读取
        /// </summary>
        /// <param name="strline"></param>
        /// <returns></returns>
        public static byte[] GetByteArrayFromString(string strline)
        {
            return Encoding.GetEncoding("gbk").GetBytes(strline);
        }

        public static string BytesToString(byte[] bs, int start, int bsLen)
        {
            string ss = Encoding.GetEncoding("gbk").GetString(bs, start, bsLen);
            return ss;
        }

        public static string ByteToString(byte byteData)
        {
            byte[] bs = new byte[1];
            bs[0] = byteData;
            string ss = BytesToString(bs, 0, 1);
            return ss;
        }
        #endregion

        /// <summary>
        /// 双字节 截取
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string DoubleSubStr(string s, int length)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(s);
            int n = 0;　//　表示当前的字节数
            int i = 0;　//　要截取的字节数
            for (; i < bytes.GetLength(0) && n < length; i++)
            {
                //　偶数位置，如0、2、4等，为UCS2编码中两个字节的第一个字节
                if (i % 2 == 0)
                {
                    n++;　　　//　在UCS2第一个字节时n加1
                }
                else
                {
                    //　当UCS2编码的第二个字节大于0时，该UCS2字符为汉字，一个汉字算两个字节
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }
            }
            //　如果i为奇数时，处理成偶数
            if (i % 2 == 1)
            {
                //　该UCS2字符是汉字时，去掉这个截一半的汉字
                if (bytes[i] > 0)
                    i = i - 1;
                //　该UCS2字符是字母或数字，则保留该字符
                else
                    i = i + 1;
            }
            return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        }
    }
}
