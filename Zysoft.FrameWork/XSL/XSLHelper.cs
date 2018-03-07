using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace Zysoft.FrameWork.XSL
{
    public class XSLHelper
    {
        /// <summary>
        /// XML文档XSL格式化
        /// </summary>
        /// <param name="strXml">要转换的XML的字符串表示。</param>
        /// <param name="xmlFragment">转换格式文档XSLT的字符串表示。</param>
        /// <returns>转换后的HTML字符串。</returns>
        public static string FormatXml(string strXml, string xmlFragment)
        {
            if (string.IsNullOrEmpty(strXml)) return "";
            XmlTextReader reader = new XmlTextReader(xmlFragment, XmlNodeType.Document, null);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "xsl:stylesheet")
                    break;
            }

            XslCompiledTransform xslt = new XslCompiledTransform();
            //xslt.Load(reader);
            //加载样式表 new XsltSettings(false, true)第二个参数enableScript=true时允许执行脚本
            xslt.Load(reader, new XsltSettings(false, true), null);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(strXml);

            MemoryStream ms = new MemoryStream();
            StreamReader sr = new StreamReader(ms);
            xslt.Transform(doc, null, ms);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            string strResult = sr.ReadToEnd();
            ms.Close();
            sr.Close();

            return strResult;
        }
    }
}
