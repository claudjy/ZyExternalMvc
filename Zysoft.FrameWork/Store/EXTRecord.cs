using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Zysoft.FrameWork.Store
{
    public class EXTRecord
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Namespace { get; set; }
        public IDictionary<string, EXTField> EXTFieldList { get; set; }
        private string createScript = "";
        private string formValueSetScript = "";
        private string formValueGetScript = "";

        public IList<EXTRecord> ChildList { get; set; }
        /// <summary>
        /// EXT实体生成代码
        /// </summary>
        public string CreateScript
        {
            get
            {
                if (createScript == "")
                {
                    StringBuilder strScript = new StringBuilder();
                    //strScript.Append(String.Format("Ext.namespace('{0}');\r\n", this.Namespace));
                    strScript.Append(String.Format("var {0}=[\r\n", this.Name));
                    //strScript.Append("var StoreModel=[\r\n");
                    //strScript.Append("[\r\n");
                    StringBuilder strfield = new StringBuilder();
                    foreach (EXTField extField in this.EXTFieldList.Values.ToList())
                    {

                        if (strfield.Length == 0)
                        {
                            if (extField.type == "date")
                                strfield.Append(String.Format("{{ name: '{0}', type: '{1}',dateFormat:'{2}' }}\r\n", new object[] { extField.name, extField.type, extField.dateFormat }));
                            else
                                strfield.Append(String.Format("{{ name: '{0}', type: '{1}'  }}\r\n", new object[] { extField.name, extField.type }));
                        }
                        else
                        {
                            if (extField.type == "date")
                                strfield.Append(String.Format(",{{ name: '{0}', type: '{1}',dateFormat:'{2}' }}\r\n", new object[] { extField.name, extField.type, extField.dateFormat }));
                            else
                                strfield.Append(String.Format(",{{ name: '{0}', type: '{1}' }}\r\n", new object[] { extField.name, extField.type }));
                        }
                    }
                    strScript.Append(strfield.ToString());
                    strScript.Append("];");
                    createScript = strScript.ToString();
                }
                return createScript;
            }
        }

        public static  EXTRecord CreateEXTRecord(Type t)
        {
            EXTRecord extRecord = new EXTRecord();
            extRecord.Name = t.Name;
            extRecord.FullName = t.FullName;
            //Namespace = t.Namespace;
            extRecord.Namespace = "EXTModels";
            extRecord.EXTFieldList = new Dictionary<string, EXTField>();
            #region 生成属性
            foreach (PropertyInfo field in t.GetProperties())
            {
                if (!extRecord.EXTFieldList.ContainsKey(field.Name))
                {

                    EXTField extField = new EXTField();
                    switch (field.PropertyType.Name.ToUpper())
                    {
                        case "STRING":
                            extField.type = "string";
                            break;
                        case "DATETIME":
                        case "DATETIME?":
                            extField.type = "date";
                            extField.dateFormat = "Y-m-d\\TH:i:s";
                            //                            extField.convert = @"function ToDate(v, r) {
                            //    return new Date(r.date.substring(0, 4), r.date.substring(5, 7), r.date.substring(8, 10), r.date.substring(11, 13), r.date.substring(14, 16), r.date.substring(17, 19))
                            //}";
                            break;
                        case "INT32":
                        case "INT32?":
                        case "INT":
                        case "INT?":
                            extField.type = "int";
                            break;
                        case "DOUBLE":
                        case "DOUBLE?":
                        case "DECIMAL":
                        case "DECIMAL?":
                        case "Nullable`1":
                            extField.type = "float";
                            break;
                    }
                    extField.name = field.Name;
                    extField.mapping = field.Name;
                    extRecord.EXTFieldList.Add(extField.name, extField);
                }
            }
            #endregion
            #region 如果有下级别
            #endregion
            return extRecord;
        }
    }
}
