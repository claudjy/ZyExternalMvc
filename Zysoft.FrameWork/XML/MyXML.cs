using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Zysoft.FrameWork.XML
{
    /// <XML操作>
    /// 2011-9-17.hjb.常用XML操作封装
    /// </XML操作>
    public class MyXML
    {
        /// <summary>
        /// XML文档
        /// </summary>
        public XDocument _XmlDoc = null;

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlText"></param>
        public MyXML(string xmlText)
        {
            _XmlDoc = XDocument.Parse(xmlText);
        }

        #endregion

        #region 文档操作

        /// <获取编辑后的XML>
        /// 
        /// </获取编辑后的XML>
        /// <returns></returns>
        public string GetDocXml()
        {
            CheckXmlDocInstantiate();
            //
            return "<?xml version=\"1.0\" encoding=\"GB2312\"?>" + _XmlDoc.ToString();
        }

        #endregion

        #region 节点操作

        /// <新增或修改XML节点>
        /// 
        /// </新增或修改XML节点>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="attr"></param>
        /// <param name="attrValue"></param>
        public void AddNodeToXmlDoc(string name, string value, string attr="", string attrValue="")
        {
            CheckXmlDocInstantiate();
            //
            AddNode(_XmlDoc, name, value, attr, attrValue);
        }

        /// <新增或修改一个XML节点，直接返回修改后的XML>
        /// 
        /// </新增或修改一个XML节点，直接返回修改后的XML>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="attr"></param>
        /// <param name="attrValue"></param>
        /// <returns></returns>
        public string AddNodeToXmlDocReturnXml(string name, string value, string attr="", string attrValue="")
        {
            CheckXmlDocInstantiate();
            //
            AddNode(_XmlDoc, name, value, attr, attrValue);

            return GetDocXml();
        }

        /// <XML文档新增或修改节点值>
        /// 注意：暂时只支持在ROOT节点下面新增或修改节点，不支持多级
        /// </XML文档新增或修改节点值>
        /// <param name="xDoc"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="attr"></param>
        /// <param name="attrValue"></param>
        private void AddNode(XDocument xDoc, string name, string value, string attr, string attrValue)
        {
            //a. 节点
            xDoc.Element("ROOT").Element(name).SetElementValue(name,value);

            //b. 属性
            if (attr.Length > 0)
            {
                xDoc.Element("ROOT").Element(name).SetAttributeValue(attr, attrValue);
            }
        }

        /// <检查XML文档是否已经实例化>
        /// 
        /// </检查XML文档是否已经实例化>
        private void CheckXmlDocInstantiate()
        {
            if (_XmlDoc == null)
            {
                throw new Exception("[XML操作错误] 请先加载XML文档!");
            }
        }

        #endregion
    }
}
