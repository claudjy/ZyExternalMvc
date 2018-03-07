using System;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace Zysoft.FrameWork
{
    public static class XmlNodeExtension
    {
        /// <summary>
        /// 获取节点值
        /// </summary>
        public static string GetValue(this XmlNode root, string name)
        {
            for (XmlNode node = root.FirstChild; node != null; node = node.NextSibling)
            {
                if ((node.NodeType == XmlNodeType.Element) && (node.Name == name))
                {
                    return node.InnerText;
                }
            }
            return null;
        }

        /// <summary>
        /// 设置节点值
        /// </summary>
        public static void SetValue(this XmlNode root, string name, string value)
        {
            if (value == null) value = string.Empty;
            if (root.FirstChild == null)
            {
                root.AppendChild((root as XmlDocument).CreateElement("root"));
            }

            for (XmlNode node = root.FirstChild.FirstChild; node != null; node = node.NextSibling)
            {
                if ((node.NodeType == XmlNodeType.Element) && (node.Name == name))
                {
                    node.InnerText = value;
                    return;
                }
            }
            root.FirstChild.AppendChild((root as XmlDocument).CreateElement(name)).InnerText = value;
        }

        /// <summary>
        /// 获取DateTime类型节点值
        /// </summary>
        public static DateTime GetTime(this XmlNode root, string name)
        {
            return GetValue(root, name).To<DateTime>();
        }

        /// <summary>
        /// 设置DateTime类型节点值
        /// </summary>
        public static void SetTime(this XmlNode root, string name, DateTime value)
        {
            SetValue(root, name, value.ToString());
        }

        /// <summary>
        /// 获取int类型节点值
        /// </summary>
        public static long GetLong(this XmlNode root, string name)
        {
            return GetValue(root, name).To<int>();
        }

        /// <summary>
        /// 获取泛型类型节点值
        /// </summary>
        public static T GetValue<T>(this XmlNode root, string name)
        {
            string rtn = string.Empty;
            rtn = GetValue(root, name);
            if (rtn == null) rtn = string.Empty;
            return rtn.To<T>();
        }

        /// <summary>
        /// 设置int类型节点值
        /// </summary>
        public static void SetLong(this XmlNode root, string name, int value)
        {
            SetValue(root, name, value.ToString());
        }

        /// <summary>
        /// xml数据转化为DataTable【XML文档的报表打印常用到】
        /// </summary>
        /// <param name="root"></param>
        /// <param name="dt"></param>
        public static void CXmlToDataTable(this XmlNode root, ref DataTable dt)
        {
            if (dt.Columns.Count <= 0) dt.Columns.Add("PHOENIX");
            if (dt.Rows.Count <= 0)
            {
                System.Data.DataRow newRow = dt.NewRow();
                dt.Rows.Add(newRow);
            }

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == "#text")
                {
                    dt.Rows[0][node.ParentNode.Name] = node.InnerText;
                    if (node.Attributes == null || node.Attributes["VALUE"] == null)
                    {
                    }
                    else
                    {
                        dt.Columns.Add(node.ParentNode.Name + "_VALUE");
                        dt.Rows[0][node.ParentNode.Name + "_VALUE"] = node.Attributes["VALUE"].Value;
                    }
                    continue;
                }
                else
                {
                    dt.Columns.Add(node.Name);//增加新的列
                }

                if (node.ChildNodes.Count > 0)
                {
                    dt.Rows[0][node.Name] = node.InnerText;
                    if (node.Attributes == null || node.Attributes["VALUE"] == null)
                    {
                    }
                    else
                    {
                        dt.Columns.Add(node.Name + "_VALUE");
                        dt.Rows[0][node.Name + "_VALUE"] = node.Attributes["VALUE"].Value;
                    }
                    node.CXmlToDataTable(ref dt);
                }
                else
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (dt.Columns[i].ColumnName == node.Name)
                        {
                            dt.Rows[0][node.Name] = node.InnerText;
                            if (node.Attributes == null || node.Attributes["VALUE"] == null)
                            {

                            }
                            else
                            {
                                dt.Columns.Add(node.Name + "_VALUE");
                                dt.Rows[0][node.Name + "_VALUE"] = node.Attributes["VALUE"].Value;
                            }
                        }
                    }
                }
            }
        }
    }
}