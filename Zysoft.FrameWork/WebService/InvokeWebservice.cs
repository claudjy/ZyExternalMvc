using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.CSharp;
using System.Reflection;
using System.Web.Services;
using System.Web.Services.Description;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace Zysoft.FrameWork.WebService
{
    /// <summary>
    /// 动态Web服务代理方法
    /// </summary>
    public class InvokeWebservice : ICodeCompiler
    {
        string m_url = string.Empty, @m_namespace = string.Empty, m_classname = string.Empty, m_methodname = string.Empty;

        private WebClient wc = new WebClient();
        private ServiceDescription sd = null;
        private ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
        private CodeNamespace cn = null;
        private CodeCompileUnit ccu = new CodeCompileUnit();
        private CompilerParameters cplist = new CompilerParameters();
        private CSharpCodeProvider csc = new CSharpCodeProvider();
        //private ICodeCompiler icc =null;
        private CompilerResults cr = null;
        private Assembly assembly = null;
        private Type t = null;
        private Stream stream = null;
        private Object obj = null;
        private MethodInfo mi = null;

        /// <summary>
        /// 
        /// </summary>
        ///<param name="url">传入URL参数</param>
        ///<param name="@namespace">传入空间命名</param>
        ///<param name="classname">传入类名</param>
        ///<param name="methodname">传入方法名：可以为空</param>
        public InvokeWebservice(string url, string @namespace, string classname, string methodname)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_url = url;
            m_namespace = @namespace;
            m_classname = classname;
            m_methodname = methodname;
            CreateWebservice(m_url, m_namespace, m_classname, m_methodname);
        }

        /// <summary>
        /// 
        /// </summary>
        ///<param name="@namespace">传入空间命名</param>
        ///<param name="url">传入URL参数</param>
        ///<param name="classname">传入类名</param>
        public InvokeWebservice(string url, string @namespace, string classname)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_url = url;
            m_namespace = @namespace;
            m_classname = classname;
            CreateWebservice(m_url, m_namespace, m_classname, m_methodname);
        }

        /// <summary>
        /// 生成WebService的代理类
        /// </summary>
        /// <param name="url">服务地址</param>
        /// <param name="namespace">命名空间</param>
        /// <param name="classname">类名</param>
        /// <param name="methodname">方法名</param>
        private void CreateWebservice(string url, string @namespace, string classname, string methodname)
        {
            //创建
            string URL = string.Empty;
            if ((url.Substring(url.Length - 4, 4) != null) && ((url.Substring(url.Length - 4, 4).ToLower() != "wsdl")))
            {
                if (url.IndexOf(".asmx") > -1)
                {
                    m_url = url + "?WSDL";
                }
                else
                {
                    m_url = url + "WSDL";
                }
            }
            else
            {
                m_url = url;
            }
            stream = wc.OpenRead(m_url);
            sd = ServiceDescription.Read(stream);
            sdi.AddServiceDescription(sd, "", "");
            cn = new CodeNamespace(@m_namespace);
            ccu.Namespaces.Add(cn);
            sdi.Import(cn, ccu);
            //icc = CodeDomProvider.CreateProvider("CSharp").CreateCompiler();// CSharpCodeProvider.CreateProvider("CSharp").CreateCompiler(); //csc.CreateCompiler();
            cplist.GenerateExecutable = false;
            cplist.GenerateInMemory = true;
            if (cplist.ReferencedAssemblies.IndexOf("System.dll") < 0)
                cplist.ReferencedAssemblies.Add("System.dll");
            if (cplist.ReferencedAssemblies.IndexOf("System.XML.dll") < 0)
                cplist.ReferencedAssemblies.Add("System.XML.dll");
            if (cplist.ReferencedAssemblies.IndexOf("System.Web.Services.dll") < 0)
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
            if (cplist.ReferencedAssemblies.IndexOf("System.Data.dll") < 0)
                cplist.ReferencedAssemblies.Add("System.Data.dll");
            //cr=icc.CompileAssemblyFromDom(cplist, ccu);
            cr = CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromDom(cplist, ccu);

            if (true == cr.Errors.HasErrors)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (CompilerError ce in cr.Errors)
                {
                    sb.Append(ce.ToString());
                    sb.Append(System.Environment.NewLine);
                }
                throw new Exception(sb.ToString());
            }
            assembly = cr.CompiledAssembly;
            t = assembly.GetType(@m_namespace + "." + m_classname, true, true);
            obj = Activator.CreateInstance(t);
            if (m_methodname.Length > 0)
                mi = t.GetMethod(m_methodname);
        }
        ///<summary>
        ///获取数据
        ///</summary>
        ///<param name="args">传入参数，本参数为顺序参数</param>
        /// <returns></returns>
        public T GetWebserviceMethodData<T>(object[] args)
        {
            try
            {
                return (T)mi.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="methodname">方法名</param>
        /// <param name="args">传入参数，本参数为顺序参数</param>
        /// <returns></returns>
        public T GetWebserviceMethodData<T>(string methodname, object[] args)
        {
            try
            {
                if (methodname.Length > 0)
                    mi = t.GetMethod(methodname);
                return (T)mi.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="classname">类名</param>
        /// <param name="methodname">方法名</param>
        /// <param name="args">传入参数，本参数为顺序参数</param>
        /// <returns></returns>
        public T GetWebserviceMethodData<T>(string classname, string methodname, object[] args)
        {
            try
            {
                t = assembly.GetType(@m_namespace + "." + m_classname, true, true);
                obj = Activator.CreateInstance(t);
                if (m_methodname.Length > 0)
                    mi = t.GetMethod(m_methodname);
                return (T)mi.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }

        #region ICodeCompiler 成员

        public CompilerResults CompileAssemblyFromDom(CompilerParameters options, CodeCompileUnit compilationUnit)
        {
            throw new NotImplementedException();
        }

        public CompilerResults CompileAssemblyFromDomBatch(CompilerParameters options, CodeCompileUnit[] compilationUnits)
        {
            throw new NotImplementedException();
        }

        public CompilerResults CompileAssemblyFromFile(CompilerParameters options, string fileName)
        {
            throw new NotImplementedException();
        }

        public CompilerResults CompileAssemblyFromFileBatch(CompilerParameters options, string[] fileNames)
        {
            throw new NotImplementedException();
        }

        public CompilerResults CompileAssemblyFromSource(CompilerParameters options, string source)
        {
            throw new NotImplementedException();
        }

        public CompilerResults CompileAssemblyFromSourceBatch(CompilerParameters options, string[] sources)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
