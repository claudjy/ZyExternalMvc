using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Zysoft.FrameWork.Encode
{
    public class SHA1Helper
    {
        /// <summary>
        /// MD5加密(加密后转为大写)
        /// </summary>
        /// <param name="encryptString">原字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string GetSHA1(string encryptString)
        {
            SHA1CryptoServiceProvider SHA1Hasher = new SHA1CryptoServiceProvider();
            byte[] byteHash = SHA1Hasher.ComputeHash(Encoding.Default.GetBytes(encryptString));
            SHA1Hasher.Dispose();
            return Convert.ToBase64String(byteHash);
        }
    }
}
