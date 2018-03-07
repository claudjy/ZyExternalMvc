using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Zysoft.FrameWork
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class BaseTypeExtension
    {
        private const long _NULL_LONG = long.MinValue;
        private const int _NULL_INT = int.MinValue;
        private const decimal _NULL_DECIMAL = decimal.MinValue;
        private const double _NULL_DOUBLE = double.MinValue;

        /// <summary>
        /// 说明：如果空值返回0
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(this object value)
        {
            return To<T>(value, "ZERO");
        }

        /// <summary>
        /// 说明：如果空值返回空值自定义类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(this object value, string NULLFlag)
        {
            long NULL_LONG = 0;
            Int32 NULL_INT = 0;
            decimal NULL_DECIMAL = 0;
            double NULL_DOUBLE = 0;

            if (NULLFlag == "MIN")
            {
                NULL_LONG = _NULL_LONG;
                NULL_INT = _NULL_INT;
                NULL_DECIMAL = _NULL_DECIMAL;
                NULL_DOUBLE = _NULL_DOUBLE;
            }
            else
            {
                NULL_LONG = 0;
                NULL_INT = 0;
                NULL_DECIMAL = 0;
                NULL_DOUBLE = 0;
            }

            if (value.IsNull())
            {
                //返回空值
                object obj = null;
                if (typeof(T) == typeof(string))
                {
                    obj = string.Empty;
                }
                else if (typeof(T) == typeof(long))
                {
                    obj = NULL_LONG;
                }
                else if (typeof(T) == typeof(Int32))
                {
                    obj = NULL_INT;
                }
                else if (typeof(T) == typeof(double))
                {
                    obj = NULL_DOUBLE;
                }
                else if (typeof(T) == typeof(decimal))
                {
                    obj = NULL_DECIMAL;
                }
                else if (typeof(T) == typeof(DateTime))
                {
                    obj = DateTime.MinValue;
                }
                else
                {
                    throw new ApplicationException("未知的数据类型[" + value.GetType().Name + "]");
                }
                return (T)obj;
            }
            else
            {
                return ConvertType<T>(value);
            }
        }

        public static T NVL<T>(this object value, T value2)
        {
            if (value.IsNull())
            {
                return value2;
            }
            else
            {
                return ConvertType<T>(value);
            }
        }

        private static T ConvertType<T>(object value)
        {
            object obj;

            try
            {
                if (typeof(T) == typeof(string))
                {
                    obj = Convert.ToString(value);
                }
                else if (typeof(T) == typeof(long))
                {
                    obj = Convert.ToInt64(value);
                }
                else if (typeof(T) == typeof(int))
                {
                    obj = Convert.ToInt32(value);
                }
                else if (typeof(T) == typeof(decimal))
                {
                    obj = Convert.ToDecimal(value);
                }
                else if (typeof(T) == typeof(double))
                {
                    obj = Convert.ToDouble(value);
                }
                else if (typeof(T) == typeof(DateTime))
                {
                    obj = Convert.ToDateTime(value);
                }
                else
                {
                    throw new ApplicationException("未知数据类型[" + typeof(T).Name + "]");
                }
            }
            catch
            {
                throw new ApplicationException("数据类型[" + value.GetType().Name + "]转换到数据类型[" + typeof(T).Name + "]出错!");
            }
            return (T)obj;
        }

        public static bool IsNotNull(this object value)
        {
            return !IsNull(value);
        }

        public static bool IsNull(this object value)
        {
            if (Convert.IsDBNull(value)) return true;
            if (value == null) return true;

            if (value is string)
            {
                if ((value as string).IsNull()) return true;
            }
            else if (value is int)
            {
                if ((int)value == int.MinValue) return true;
            }
            else if (value is Int32)
            {
                if ((Int32)value == Int32.MinValue) return true;
            }
            else if (value is Int64)
            {
                if ((Int64)value == Int64.MinValue) return true;
            }
            else if (value is long)
            {
                if (((long)value).IsNull()) return true;
            }
            else if (value is decimal)
            {
                if (((decimal)value).IsNull()) return true;
            }
            else if (value is double)
            {
                if (((double)value).IsNull()) return true;
            }
            else if (value is DateTime)
            {
                if (((DateTime)value).IsNull()) return true;
            }
            else
            {
                //未知类型  -->异常
                throw new ApplicationException("未知数据类型[" + value.GetType().Name + "]");
            }

            return false;
        }

        public static bool IsNull(this string value)
        {
            if (string.IsNullOrEmpty(value) == true) return true;
            return false;
        }

        public static bool IsNull(this long value)
        {
            if (value == _NULL_LONG) return true;
            return false;
        }

        public static bool IsNull(this decimal value)
        {
            if (value == _NULL_DECIMAL) return true;
            return false;
        }

        public static bool IsNull(this double value)
        {
            if (value == _NULL_DOUBLE) return true;
            return false;
        }

        public static bool IsNull(this DateTime value)
        {
            if (value == DateTime.MinValue) return true;
            return false;
        }

        /// <summary>
        /// 值可能为NULL的转短时间 2011/7/11 Add by laijunming
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShortDateStringNullAble(this DateTime value)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                return value.ToShortDateString();
            }
        }
        public static void SetNull(this string value)
        {
            value = string.Empty;
        }

        public static void SetNull(this long value)
        {
            //value = _NULL_LONG;
            value = 0;
        }

        public static void SetNull(this int value)
        {
            //value = _NULL_INT;
            value = 0;
        }

        public static void SetNull(this double value)
        {
            //value = _NULL_DOUBLE;
            value = 0;
        }

        public static void SetNull(this decimal value)
        {
            //value = _NULL_DECIMAL;
            value = 0;
        }

        public static void SetNull(this DateTime value)
        {
            value = DateTime.MinValue;
        }
        public static int GetNum(this DayOfWeek dow)
        {
            int num=0;
            switch (dow)
            {
                case DayOfWeek.Monday:
                    num = 1;
                break;
                case DayOfWeek.Tuesday:
                    num = 2;
                break;
                case DayOfWeek.Wednesday:
                    num=3;
                break;
                case DayOfWeek.Thursday:
                num = 4;
                break;
                case DayOfWeek.Friday:
                num = 5;
                break;
                case DayOfWeek.Saturday:
                num = 6;
                break;
                case DayOfWeek.Sunday:
                num = 7;
                break;
            }
            return num;
        }
        public static List<int> toListInt(this string[] strs)
        {
            List<int> i = new List<int>();
            foreach(string str in strs)
            {
                i.Add(str.To<int>());
            }
            return i;
        }
        public static string ArrayToString(this double[] value)
        {
            //为空返回空字符串
            if (value == null) { return string.Empty; }
            if (value.Length == 0) { return string.Empty; }
            if (value.Length == 1) { return value[0].ToString(); }

            //
            string temp = string.Empty;

            if (value.Length > 1)

                for (int i = 0; i < value.Length; i++)
                {
                    temp += value[i].ToString();

                    if (i < (value.Length - 1))
                    {
                        temp += ",";
                    }
                }

            return temp;
        }

        public static string ArrayToString(this string[] value)
        {
            //为空返回空字符串
            if (value == null) { return string.Empty; }
            if (value.Length == 0) { return string.Empty; }
            if (value.Length == 1) { return value[0].Trim(); }

            //
            string temp = string.Empty;

            if (value.Length > 1)

                for (int i = 0; i < value.Length; i++)
                {
                    temp += value[i].Trim();

                    if (i < (value.Length - 1))
                    {
                        temp += ",";
                    }
                }

            return temp;
        }       

    }
}