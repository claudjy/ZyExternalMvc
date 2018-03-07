﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace Zysoft.FrameWork
{
    /// <summary>
    /// Xml序列化与反序列化
    /// </summary>
    public class XmlUtil
    {
        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion
    }
}


//下面是测试代码：

 /*
1. 实体对象转换到Xml
public class Student
{
    public string Name { set; get; }
    public int Age { set; get; }
}
 

Student stu1 = new Student() { Name = "okbase", Age = 10 };
string xml = XmlUtil.Serializer(typeof(Student), stu1);
Console.Write(xml);
2. Xml转换到实体对象
Student stu2 = XmlUtil.Deserialize(typeof(Student), xml) as Student;
Console.Write(string.Format("名字:{0},年龄:{1}", stu2.Name, stu2.Age));
3. DataTable转换到Xml
// 生成DataTable对象用于测试
DataTable dt1 = new DataTable("mytable");   // 必须指明DataTable名称
 
dt1.Columns.Add("Dosage", typeof(int));
dt1.Columns.Add("Drug", typeof(string));
dt1.Columns.Add("Patient", typeof(string));
dt1.Columns.Add("Date", typeof(DateTime));
 
// 添加行
dt1.Rows.Add(25, "Indocin", "David", DateTime.Now);
dt1.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
dt1.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
dt1.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
dt1.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
 
// 序列化
xml = XmlUtil.Serializer(typeof(DataTable), dt1);
Console.Write(xml);
4. Xml转换到DataTable
// 反序列化
DataTable dt2 = XmlUtil.Deserialize(typeof(DataTable), xml) as DataTable;
 
// 输出测试结果
foreach (DataRow dr in dt2.Rows)
{
    foreach (DataColumn col in dt2.Columns)
    {
        Console.Write(dr[col].ToString() + " ");
    }
 
    Console.Write("\r\n");
}
5. List转换到Xml
// 生成List对象用于测试
List<Student> list1 = new List<Student>(3);
 
list1.Add(new Student() { Name = "okbase", Age = 10 });
list1.Add(new Student() { Name = "csdn", Age = 15 });
// 序列化
xml = XmlUtil.Serializer(typeof(List<Student>), list1);
Console.Write(xml);

List<Student> list2 = XmlUtil.Deserialize(typeof(List<Student>), xml) as List<Student>;
foreach (Student stu in list2)
{
    Console.WriteLine(stu.Name + "," + stu.Age.ToString());
}
*/