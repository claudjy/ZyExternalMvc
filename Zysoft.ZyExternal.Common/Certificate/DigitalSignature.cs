using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Zysoft.ZyExternal.Common.Certificate
{

    /// <summary>
    /// 数字签名
    /// 使用说明：(以A、B角色说明)
    ///     1、生成数字签名的密钥（公钥、私钥），将私钥给公布给B，公钥A自己保存
    ///     2、B用户调用方法GenerateSignature， 生成数字签名
    ///     3、A用户调用方法VerifySignature， 验证签名是否正确
    /// </summary>
    public class DigitalSignature
    {
        /// <summary>
        /// 随机生成密钥 （公钥、私钥）
        /// </summary>
        /// <param name="privateKey">公钥</param>
        /// <param name="publicKey">私钥</param>
        /// <returns></returns>
        public static int GenerateKey(out string publicKey, out string privateKey)
        {
            DSACryptoServiceProvider objdsa = new DSACryptoServiceProvider();
            publicKey = objdsa.ToXmlString(true);
            privateKey = objdsa.ToXmlString(false);
            return 0;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="content">原字符串</param>
        /// <param name="publicKey">私钥</param>
        /// <param name="signature">生成的签名</param>
        /// <returns></returns>
        public static int GenerateSignature(string content, string publicKey, out string signature)
        {
            DSACryptoServiceProvider objdsa = new DSACryptoServiceProvider();
            objdsa.FromXmlString(publicKey);
            byte[] source = System.Text.UTF8Encoding.UTF8.GetBytes(content);
            //数字签名
            signature = BitConverter.ToString(objdsa.SignData(source));
            return 0;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="content">原字符串</param>
        /// <param name="privateKey">公钥</param>
        /// <param name="signature">签名</param>
        /// <returns></returns>
        public static bool VerifySignature(string content, string privateKey, string signature)
        {
            DSACryptoServiceProvider objdsa = new DSACryptoServiceProvider();

            byte[] fileHashValue = new SHA1CryptoServiceProvider().ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(content));

            string[] strSplit = signature.Split('-');
            byte[] SignedHash = new byte[strSplit.Length];
            for (int i = 0; i < strSplit.Length; i++)
                SignedHash[i] = byte.Parse(strSplit[i], System.Globalization.NumberStyles.AllowHexSpecifier);

            objdsa.FromXmlString(privateKey);

            return objdsa.VerifySignature(fileHashValue, SignedHash);
        }

        /// <summary>
        /// 验证数字签名
        /// </summary>
        /// <param name="docRequest"></param>
        /// <param name="outResponse"></param>
        /// <returns></returns>
        public static bool VerifySignatureByPublic(XmlDocument docRequest, out string outResponse)
        {
            string content, publicKey, signature;
            string tradeCode, clientType;
            tradeCode = docRequest.SelectSingleNode("/Request/TradeCode").InnerText;
            clientType = docRequest.SelectSingleNode("/Request/ClientType").InnerText;
            XmlDocument docResponse = new XmlDocument();

            outResponse = "<?xml version=\"1.0\" encoding=\"gb2312\"?>";
            outResponse += @"<Response> 
                            <TradeCode>" + tradeCode + @"</TradeCode> 
                            <HospitalID>03001</HospitalID> 
                            <HISDate>20121203134608</HISDate> 
                            <HISTradeNo>1400001</HISTradeNo> 
                            <ResultCode>0000</ResultCode> 
                            <ResultContent>成功交易！</ResultContent> 
                        </Response>";
            docResponse.LoadXml(outResponse);
            switch (clientType)
            {
                case "88": //省便民平台
                    break;
                default:
                    outResponse = docResponse.OuterXml;
                    return true;

            }

            XmlDocument docPublicKey = new XmlDocument();
            string path;
            path = AppDomain.CurrentDomain.BaseDirectory;
            docPublicKey.Load(path + "PublicKey.xml");
            XmlNodeList nodeList = docPublicKey.SelectNodes("/Keys/key");

            XmlNode ndPublicKey, ndContent, ndSignature; //私有密钥  原字段串  签名
            ndPublicKey = docRequest.SelectSingleNode("/Request/PublicKey");
            ndContent = docRequest.SelectSingleNode("/Request/Content");
            ndSignature = docRequest.SelectSingleNode("/Request/Signature");

            if (!(ndPublicKey != null && ndContent != null && ndSignature != null))
            {
                docResponse.SelectSingleNode("Response").SelectSingleNode("ResultCode").InnerText = "9999";
                docResponse.SelectSingleNode("Response").SelectSingleNode("ResultContent").InnerText = "数字签名验证出错！";
                outResponse = docResponse.OuterXml;
                return false;
            }

            content = ndContent.InnerText;
            publicKey = ndPublicKey.InnerXml;
            signature = ndSignature.InnerText;

            ndPublicKey.InnerText = "";
            ndContent.InnerText = "";
            ndSignature.InnerText = "";
            string privateValue = string.Empty;
            foreach (XmlNode ndKey in nodeList)
            {
                string publicValue;
                publicValue = (ndKey.SelectSingleNode("PublicValue")).InnerXml.Trim();
                if (publicValue == publicKey)
                {
                    privateValue = (ndKey.SelectSingleNode("PrivateValue")).InnerXml.Trim();
                    break;
                }
            }
            if (privateValue == string.Empty)
            {
                docResponse.SelectSingleNode("Response").SelectSingleNode("ResultCode").InnerText = "9999";
                docResponse.SelectSingleNode("Response").SelectSingleNode("ResultContent").InnerText = "数字签名验证出错！";
                outResponse = docResponse.OuterXml;
                return false;
            }
            bool verifySign = VerifySignature(content, privateValue, signature);
            if (!verifySign)
            {
                docResponse.SelectSingleNode("Response").SelectSingleNode("ResultCode").InnerText = "9999";
                docResponse.SelectSingleNode("Response").SelectSingleNode("ResultContent").InnerText = "数字签名验证出错！";
            }
            outResponse = docResponse.OuterXml;
            return verifySign;
        }

       

    }
}
