using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Zysoft.FrameWork.XML
{
    public class XDocumentHelper
    {
        /// <summary>
        /// 创建带根节点的Xml文档
        /// </summary>
        /// <param name="rootName"></param>
        /// <returns></returns>
        public static XDocument CreateDocument(string rootName = "root")
        {
            return XDocument.Parse(string.Format("<?xml version=\"1.0\" ?><{0}></{0}>", rootName));
        }
    }
}
