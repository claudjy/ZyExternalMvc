using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Zysoft.FrameWork.Encode
{
    public class MD5Helper
    {
        /// <summary>
        /// MD5加密(加密后转为大写)
        /// </summary>
        /// <param name="encryptString">原字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string GetMD5(string encryptString)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] byteHash = md5Hasher.ComputeHash(Encoding.Default.GetBytes(encryptString));
            md5Hasher.Dispose();
            return Convert.ToBase64String(byteHash);
        }
    }
}
