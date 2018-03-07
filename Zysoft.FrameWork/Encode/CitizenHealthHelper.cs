using System;
using System.Text;

namespace Zysoft.FrameWork.Encode
{
    /// <summary>
    /// Add by Sugar at 2010.8.7
    /// 市民健康接口方法类
    /// </summary>
    public class CitizenHealthHelper
    {
        #region 引用DLL声明

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, EntryPoint = "MessageBox")]
        public extern static int MyMessageBox(Int32 hWnd, string lpText, string lpCaption, uint uType);

        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "EncodeVersion")]
        public extern static int EncodeVersion();
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "Compress")]
        public extern static int Compress(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDest, ref Int32 plngDestSize);
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "Decompress")]
        public extern static int Decompress(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDest, ref Int32 plngDestSize);

        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "GenerateKey128")]
        public extern static int GenerateKey128(byte[] pbyteKey);
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "Encrypt")]
        public extern static int Encrypt(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDest, ref Int32 plngDestSize, byte[] byteKey, Int32 lngKeySize);
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "Decrypt")]
        public extern static int Decrypt(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDest, ref Int32 plngDestSize, byte[] byteKey, Int32 lngKeySize);

        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "GenerateKeyRSA")]
        public extern static int GenerateKeyRSA(byte[] pbytePubKey, ref Int32 lngPubSize, byte[] pbytePrivKey, ref Int32 lngPrivSize);
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "RSAEncrypt")]
        public extern static int RSAEncrypt(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDest, ref Int32 plngDestSize, byte[] byteKey, Int32 lngKeySize);
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "RSADecrypt")]
        public extern static int RSADecrypt(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDest, ref Int32 plngDestSize, byte[] byteKey, Int32 lngKeySize);

        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "EncodeA")]
        public extern static int EncodeA(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDestSize, ref Int32 lngDestSize);
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "EncodeU")]
        public extern static int EncodeU(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDestSize, ref Int32 lngDestSize);
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "DecodeA")]
        public extern static int DecodeA(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDestSize, ref Int32 lngDestSize);
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "DecodeU")]
        public extern static int DecodeU(byte[] pbyteSource, Int32 lngSourceSize, byte[] pbyteDestSize, ref Int32 lngDestSize);

        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "AnsiToUnicode")]
        public extern static int AnsiToUnicode(byte[] pbyteSource, Int32 lngAnsiSize, byte[] byteUnicode, ref Int32 lngSize);
        [System.Runtime.InteropServices.DllImport("sehr.crypto.dll", SetLastError = true, EntryPoint = "UnicodeToAnsi")]
        public extern static int UnicodeToAnsi(byte[] pbyteSource, Int32 lngUnicodeSize, byte[] byteAnsi, ref Int32 lngSize);

        #endregion 引用DLL声明

        #region 公共静态方法

        /// <summary>
        /// 压缩对称加密并编码：Compress、Encrypt、Encode
        /// </summary>
        /// <param name="byteData">原始数据</param>
        /// <param name="bytePublicKey">公钥数据</param>
        /// <returns>最后编码的数据</returns>
        public static string CEEHelper(byte[] byteData, byte[] bytePublicKey)
        {
            //Compress
            int lenCom = 0;
            Compress(byteData, byteData.Length, null, ref lenCom);
            byte[] byteCom = new byte[lenCom];
            Compress(byteData, byteData.Length, byteCom, ref lenCom);
            //Compress、Encode、Decode两次获得的len可能不一样，所以在下面的传入参数里不能用byteCom.Length而只能用lenCom

            //Encrypt
            int lenRsa = 0;
            Encrypt(byteCom, lenCom, null, ref lenRsa, bytePublicKey, bytePublicKey.Length);
            byte[] byteRsa = new byte[lenRsa];
            Encrypt(byteCom, lenCom, byteRsa, ref lenRsa, bytePublicKey, bytePublicKey.Length);

            //Encode
            int lenEnc = 0;
            EncodeU(byteRsa, lenRsa, null, ref lenEnc);
            byte[] byteEnc = new byte[lenEnc];
            EncodeU(byteRsa, lenRsa, byteEnc, ref lenEnc);

            //返回结果
            UnicodeEncoding uconvert = new UnicodeEncoding();
            return uconvert.GetString(byteEnc, 0, lenEnc);
        }
        /// <summary>
        /// 解码对称解密并解压缩：Decode、Decrypt、Decompress
        /// </summary>
        /// <param name="strData">原始字符串</param>
        /// <param name="bytePrivateKey">私钥</param>
        /// <returns>输出数据</returns>
        public static byte[] DDDHelper(string strData, byte[] bytePrivateKey)
        {
            byte[] byteData = new UnicodeEncoding().GetBytes(strData);

            //Decode
            int lenDec = 0;
            DecodeU(byteData, byteData.Length, null, ref lenDec);
            byte[] byteDec = new byte[lenDec];
            DecodeU(byteData, byteData.Length, byteDec, ref lenDec);

            //Decrypt
            int lenRsa = 0;
            Decrypt(byteDec, lenDec, null, ref lenRsa, bytePrivateKey, bytePrivateKey.Length);
            byte[] byteRsa = new byte[lenRsa];
            Decrypt(byteDec, lenDec, byteRsa, ref lenRsa, bytePrivateKey, bytePrivateKey.Length);

            //Decompress
            int lenDep = 0;
            Decompress(byteRsa, lenRsa, null, ref lenDep);
            byte[] byteDep = new byte[lenDep];
            Decompress(byteRsa, lenRsa, byteDep, ref lenDep);

            //返回结果
            byte[] byteResult = null;
            Memcpy(byteDep, ref byteResult, 0, lenDep);
            return byteResult;
        }
        /// <summary>
        /// 压缩RSA加密并编码：Compress、RSAEncrypt、Encode
        /// </summary>
        /// <param name="byteData">原始数据</param>
        /// <param name="bytePublicKey">公钥数据</param>
        /// <returns>最后编码的数据</returns>
        public static string CREEHelper(byte[] byteData, byte[] bytePublicKey)
        {
            //Compress
            int lenCom = 0;
            Compress(byteData, byteData.Length, null, ref lenCom);
            byte[] byteCom = new byte[lenCom];
            Compress(byteData, byteData.Length, byteCom, ref lenCom);
            //Compress、Encode、Decode两次获得的len可能不一样，所以在下面的传入参数里不能用byteCom.Length而只能用lenCom

            //Encrypt
            int lenRsa = 0;
            RSAEncrypt(byteCom, lenCom, null, ref lenRsa, bytePublicKey, bytePublicKey.Length);
            byte[] byteRsa = new byte[lenRsa];
            RSAEncrypt(byteCom, lenCom, byteRsa, ref lenRsa, bytePublicKey, bytePublicKey.Length);

            //Encode
            int lenEnc = 0;
            EncodeU(byteRsa, lenRsa, null, ref lenEnc);
            byte[] byteEnc = new byte[lenEnc];
            EncodeU(byteRsa, lenRsa, byteEnc, ref lenEnc);

            //返回结果
            UnicodeEncoding uconvert = new UnicodeEncoding();
            return uconvert.GetString(byteEnc, 0, lenEnc);
        }
        /// <summary>
        /// 解码RSA解密并解压缩：Decode、RSADecrypt、Decompress
        /// </summary>
        /// <param name="strData">原始字符串</param>
        /// <param name="bytePrivateKey">私钥</param>
        /// <returns>输出数据</returns>
        public static byte[] DRDDHelper(string strData, byte[] bytePrivateKey)
        {
            byte[] byteData = new UnicodeEncoding().GetBytes(strData);

            //Decode
            int lenDec = 0;
            DecodeU(byteData, byteData.Length, null, ref lenDec);
            byte[] byteDec = new byte[lenDec];
            DecodeU(byteData, byteData.Length, byteDec, ref lenDec);

            //Decrypt
            int lenRsa = 0;
            RSADecrypt(byteDec, lenDec, null, ref lenRsa, bytePrivateKey, bytePrivateKey.Length);
            byte[] byteRsa = new byte[lenRsa];
            RSADecrypt(byteDec, lenDec, byteRsa, ref lenRsa, bytePrivateKey, bytePrivateKey.Length);

            //Decompress
            int lenDep = 0;
            Decompress(byteRsa, lenRsa, null, ref lenDep);
            byte[] byteDep = new byte[lenDep];
            Decompress(byteRsa, lenRsa, byteDep, ref lenDep);

            //返回结果
            byte[] byteResult = null;
            Memcpy(byteDep, ref byteResult, 0, lenDep);
            return byteResult;
        }
        /// <summary>
        /// 压缩加密封套并编码：Compress、Decrypt、Envelope、Encode
        /// </summary>
        /// <param name="byteData">原始数据</param>
        /// <param name="byteKey">加密数据的钥匙</param>
        /// <param name="bytePublicKey">封套公钥数据</param>
        /// <param name="strData">输出的原始数据</param>
        /// <param name="strKey"> 输出的加密钥匙</param>
        public static void CDEEHelper(byte[] byteData, byte[] byteKey, byte[] bytePublicKey, ref string strData, ref string strKey)
        {
            //Compress
            int lenCom = 0;
            Compress(byteData, byteData.Length, null, ref lenCom);
            byte[] byteCom = new byte[lenCom];
            Compress(byteData, byteData.Length, byteCom, ref lenCom);
            //Compress、Encode、Decode两次获得的len可能不一样，所以在下面的传入参数里不能用byteCom.Length而只能用lenCom

            //Encrypt
            int lenCry = 0;
            Encrypt(byteCom, lenCom, null, ref lenCry, byteKey, byteKey.Length);
            byte[] byteCry = new byte[lenCry];
            Encrypt(byteCom, lenCom, byteCry, ref lenCry, byteKey, byteKey.Length);

            //Envelope
            int lenRsa = 0;
            RSAEncrypt(byteKey, byteKey.Length, null, ref lenRsa, bytePublicKey, bytePublicKey.Length);
            byte[] byteRsa = new byte[lenRsa];
            RSAEncrypt(byteKey, byteKey.Length, byteRsa, ref lenRsa, bytePublicKey, bytePublicKey.Length);
            //DES钥匙也应该要编码后才返回str，编码目的是使byte[]中每一个元素都成为可显示
            int lenRsaEnc = 0;
            EncodeU(byteRsa, lenRsa, null, ref lenRsaEnc);
            byte[] byteRsaEnc = new byte[lenRsaEnc];
            EncodeU(byteRsa, lenRsa, byteRsaEnc, ref lenRsaEnc);

            //Encode
            int lenEnc = 0;
            EncodeU(byteCry, lenCry, null, ref lenEnc);
            byte[] byteEnc = new byte[lenEnc];
            EncodeU(byteCry, lenCry, byteEnc, ref lenEnc);

            //返回Data结果
            UnicodeEncoding uconvert = new UnicodeEncoding();
            strData = uconvert.GetString(byteEnc, 0, lenEnc);

            //返回Key结果
            strKey = uconvert.GetString(byteRsaEnc, 0, lenRsaEnc);
        }
        /// <summary>
        /// 解码开封解密解压：Decode、Open、Decrypt、Decompress
        /// </summary>
        /// <param name="strData">原始字符串数据</param>
        /// <param name="bytePrivateKey">开封私钥数据</param>
        /// <param name="byteKey">信封加密钥匙，使用私钥解密为原始钥匙</param>
        /// <returns>输出数据</returns>
        public static byte[] DODDHelper(string strData, byte[] bytePrivateKey, byte[] byteKey)
        {
            byte[] byteData = new UnicodeEncoding().GetBytes(strData);

            //Decode
            int lenDec = 0;
            DecodeU(byteData, byteData.Length, null, ref lenDec);
            byte[] byteDec = new byte[lenDec];
            DecodeU(byteData, byteData.Length, byteDec, ref lenDec);

            //DecodeKey
            int lenDecKey = 0;
            DecodeU(byteKey, byteKey.Length, null, ref lenDecKey);
            byte[] byteDecKey = new byte[lenDecKey];
            DecodeU(byteKey, byteKey.Length, byteDecKey, ref lenDecKey);

            //Open
            int lenRsa = 0;
            RSADecrypt(byteDecKey, lenDecKey, null, ref lenRsa, bytePrivateKey, bytePrivateKey.Length);
            byte[] byteRsa = new byte[lenRsa];
            RSADecrypt(byteDecKey, lenDecKey, byteRsa, ref lenRsa, bytePrivateKey, bytePrivateKey.Length);

            //Decrypt       
            Int32 lenCry = 0;
            Decrypt(byteDec, lenDec, null, ref lenCry, byteRsa, lenRsa);
            byte[] byteCry = new byte[lenCry];
            Decrypt(byteDec, lenDec, byteCry, ref lenCry, byteRsa, lenRsa);

            //Decompress
            int lenDep = 0;
            Decompress(byteCry, lenCry, null, ref lenDep);
            byte[] byteDep = new byte[lenDep];
            Decompress(byteCry, lenCry, byteDep, ref lenDep);

            //返回结果
            byte[] byteResult = null;
            Memcpy(byteDep, ref byteResult, 0, lenDep);
            return byteResult;
        }
        /// <summary>
        /// 解码并解压缩 : Decode , Decompress
        /// </summary>
        /// <param name="strData">原始字符串</param>
        public static void DDHelper(ref string strData)
        {
            byte[] byteData = new UnicodeEncoding().GetBytes(strData);

            //Decode
            int lenDec = 0;
            DecodeU(byteData, byteData.Length, null, ref lenDec);
            byte[] byteDec = new byte[lenDec];
            DecodeU(byteData, byteData.Length, byteDec, ref lenDec);

            //Decompress
            int lenDep = 0;
            Decompress(byteDec, lenDec, null, ref lenDep);
            byte[] byteDep = new byte[lenDep];
            Decompress(byteDec, lenDec, byteDep, ref lenDep);

            //返回Data结果
            UnicodeEncoding uconvert = new UnicodeEncoding();
            strData = uconvert.GetString(byteDep, 0, lenDep);
        }

        /// <summary>
        /// 通用加密算法
        /// 1.把原字符串按字符循环获取asc码，并格式化为3位整数
        /// 2.把数字字符串进行奇偶交换（第1位和第2位交换，第3位和第4位交换，依次类推，如果总长是奇数位，则最后一位不变），重新组合数字字符串
        /// </summary>
        /// <param name="source">源数据</param>
        /// <param name="dest">加密后的数据</param>
        public static void CommonEncrypt(string source, ref string dest)
        {
            string temp = "";
            int sourceLength = source.Trim().Length;
            for (int i = 0; i < sourceLength; i++)
            {
                string tempChar = source.Trim().Substring(i, 1);
                tempChar = Convert.ToString(Encoding.ASCII.GetBytes(tempChar)[0]).PadLeft(3, '0');
                temp += tempChar.Substring(tempChar.Length - 3, 3);
            }

            int tempLength = temp.Trim().Length;
            string[] asc = new string[tempLength];

            for (int i = 0; i < tempLength; i++)
            {
                asc[i] = temp.Trim().Substring(i, 1);
            }

            for (int i = 1; i < tempLength; i = i + 2)
            {
                temp = asc[i];
                asc[i] = asc[i - 1];
                asc[i - 1] = temp;
            }

            dest = "";
            for (int i = 0; i < tempLength; i++)
            {
                dest += asc[i];
            }
        }

        /// <summary>
        /// 重写解码
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static byte[] Decode(string strSource)
        {
            byte[] bSource = Encoding.Unicode.GetBytes(strSource);

            Int32 len = 0;
            DecodeU(bSource, bSource.Length, null, ref len);
            byte[] bCode = new byte[len];
            DecodeU(bSource, bSource.Length, bCode, ref len);

            return Memcpy(bCode, 0, len);
        }

        /// <summary>
        /// Byte数组解压
        /// </summary>
        /// <param name="ComByte"></param>
        /// <returns></returns>
        public static byte[] ByteDecompress(byte[] ComByte)
        {
            Int32 len_2 = 0;
            int nCode = Decompress(ComByte, ComByte.Length, null, ref len_2);
            byte[] returnByte = new byte[len_2];
            nCode = Decompress(ComByte, ComByte.Length, returnByte, ref len_2);

            return returnByte;
        }

        #endregion 公共静态函数

        #region 私有静态方法

        /// <summary>
        /// 从原有的byte[]中取一部份组成新的byte[]
        /// </summary>
        /// <param name="source">源byte[]</param>
        /// <param name="dest">结果byte[]</param>
        /// <param name="start">开始位置索引</param>
        /// <param name="end">至此位置索引之前</param>
        private static void Memcpy(byte[] source, ref byte[] dest, int start, int end)
        {
            if (source == null || start < 0 || (source.Length < start + 1) || (end < start))
            {
                dest = null;
            }
            else
            {
                int realend = source.Length > end ? end : source.Length;
                dest = new byte[end - start];
                for (int i = start; i < end; ++i)
                {
                    dest[i - start] = source[i];
                }
            }
        }

        /// <summary>
        /// 内存拷贝
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static byte[] Memcpy(byte[] source, int start, int end)
        {
            byte[] dest = new byte[end - start];
            for (int i = start; i < end; ++i)
            {
                dest[i - start] = source[i];
            }

            return dest;
        }
        #endregion
    }
}
