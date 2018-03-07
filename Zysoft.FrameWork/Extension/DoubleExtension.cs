using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zysoft.FrameWork
{
    public static class DoubleExtension
    {


        #region 四舍五入
        /// <summary>
        /// Double值类型的四舍五入运算(利用ToString)
        /// 用法：a = MathMethod.DoubleRoundFormat(a, "##################.##");
        /// </summary>
        /// <param name="value">计算前的值</param>
        /// <param name="formatString">得到的值的格式：要保留的小数位等</param>
        /// <returns>计算后的值</returns>
        public static double DoubleRound(this double value, string formatString)
        {
            if (string.IsNullOrEmpty(formatString))
            {
                formatString = "##################.##";
            }
            string rtnValue;
            rtnValue = value.ToString(formatString);
            //if (string.IsNullOrEmpty(rtnValue))
            if (rtnValue.IsNull())
            {
                rtnValue = "0";
            };
            return Convert.ToDouble(rtnValue);
        }

        /// <summary>
        /// Double值类型的四舍五入运算(利用小数位)
        /// </summary>
        /// <param name="value">计算前的值</param>
        /// <param name="decimalPlace">几位小数</param>
        /// <returns>计算后的值</returns>
        public static double DoubleRound(this double value, int decimalPlace)
        {
            string formatString = "#.";
            for (int i = 0; i < decimalPlace; i++)
            {
                formatString += "#";
            }
            string rtnValue;
            rtnValue = value.ToString(formatString);
            if (rtnValue.IsNull())
            {
                rtnValue = "0";
            }
            return Convert.ToDouble(rtnValue);
        }

        /// <summary>
        /// Double值类型的四舍五入运算(2位小数)，一般用于统一金额运算(利用ToString)
        /// 用法：a = MathMethod.DoubleRoundFormat(a);
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns> 
        public static double DoubleRound(this double value)
        {
            return DoubleRound(value, "##################.##");
        }

        /// <summary>
        /// 计算从datatable中取得DOUBLE数据的四舍五入
        /// </summary>
        /// <param name="value">计算前的值</param>
        /// <param name="formatString">得到的值的格式：要保留的小数位等</param>
        /// <returns>计算后的值</returns>
        public static double DoubleRound(this object value, string formatString)
        {
            double rtn;
            rtn = value.To<double>();

            return DoubleRound(rtn, formatString);
        }

        /// <summary>
        /// 计算从datatable中取得DOUBLE数据的四舍五入
        /// </summary>
        /// <param name="value">计算前的值</param>
        /// <param name="decimalPlace">几位小数</param>
        /// <returns>计算后的值</returns>
        public static double DoubleRound(this object value, int decimalPlace)
        {
            double rtn;
            rtn = value.To<double>();
            return DoubleRound(rtn, decimalPlace);
        }

        /// <summary>
        /// 计算从datatable中取得DOUBLE数据的四舍五入
        /// </summary>
        /// <param name="value">计算前的值</param>
        /// <returns>计算后的值</returns>
        public static double DoubleRound(this object value)
        {
            double rtn;
            rtn = value.To<double>();

            return DoubleRound(rtn, "##################.##");
        }
        #endregion
    }
}
