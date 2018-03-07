using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Zysoft.FrameWork.Encode
{
    public class DESHelper
    {
        #region 私有变量

        /// <summary>
        /// 默认密钥向量
        /// </summary>
        private static byte[] _keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// 密钥(注意必须是8位,该密钥可以从数据库获取得到，暂时写死掉)
        /// </summary>
        private static string _keyt = "XMZYSOFT";

        #endregion

        #region 公用静态方法

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string str)
        {
            try
            {
                string encryptKey = _keyt;
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = _keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                string result = Convert.ToBase64String(mStream.ToArray());
                //
                provider.Clear();
                mStream.Close();
                mStream.Dispose();
                cStream.Close();
                cStream.Dispose();

                rgbKey = null;
                rgbIV = null;
                inputByteArray = null;

                return result;
            }
            catch
            {
                return str;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">待解密的字符串</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string Decrypt(string str)
        {
            try
            {
                string decryptKey = _keyt;
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = _keys;
                byte[] inputByteArray = Convert.FromBase64String(str);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                string result = Encoding.UTF8.GetString(mStream.ToArray());
                //
                provider.Clear();
                mStream.Close();
                mStream.Dispose();
                cStream.Close();
                cStream.Dispose();

                rgbKey = null;
                rgbIV = null;
                inputByteArray = null;

                return result;
            }
            catch
            {
                return str;
            }
        }

        #endregion

    }
}
