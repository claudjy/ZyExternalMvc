using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Zysoft.FrameWork
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileHelper : IDisposable
    {
        private bool _alreadyDispose = false;

        

        #region 构造函数
        public FileHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        ~FileHelper()
        {
            Dispose(); ;
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_alreadyDispose) return;
            //if (isDisposing)
            //{
            //     if (xml != null)
            //     {
            //         xml = null;
            //     }
            //}
            _alreadyDispose = true;
        }
        #endregion

        #region IDisposable 成员
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region 取得文件后缀名
        /****************************************
          * 函数名称：GetPostfixStr
          * 功能说明：取得文件后缀名
          * 参    数：filename:文件名称
          * 调用示列：
          *            string filename = "aaa.aspx";        
          *            string s = FileHelper.GetPostfixStr(filename);         
         *****************************************/
        /// <summary>
        /// 取后缀名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>.gif|.html格式</returns>
        public static string GetPostfixStr(string filename)
        {
            int start = filename.LastIndexOf(".");
            int length = filename.Length;
            string postfix = filename.Substring(start, length - start);
            return postfix;
        }
        #endregion
        
        #region 写文件
        /****************************************
          * 函数名称：WriteFile
          * 功能说明：写文件,会覆盖掉以前的内容
          * 参    数：Path:文件路径,Strings:文本内容
          * 调用示列：
          *            string Path = Server.MapPath("Default2.aspx");       
          *            string Strings = "这是我写的内容啊";
          *            FileHelper.WriteFile(Path,Strings);
         *****************************************/
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="Strings">文件内容</param>
        public static void WriteFile(string Path, string Strings)
        {
            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, false, System.Text.Encoding.GetEncoding("gb2312"));
            f2.Write(Strings);
            f2.Close();
            f2.Dispose();            
        }
        #endregion

        #region 读文件
        /****************************************
          * 函数名称：ReadFile
          * 功能说明：读取文本内容
          * 参    数：Path:文件路径
          * 调用示列：
          *            string Path = Server.MapPath("Default2.aspx");       
          *            string s = FileHelper.ReadFile(Path);
         *****************************************/
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <returns></returns>
        public static string ReadFile(string Path)
        {
            string s = "";
            if (!System.IO.File.Exists(Path))
                s = "不存在相应的目录";
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }

            return s;
        }
        #endregion

        #region 追加文件
        /****************************************
          * 函数名称：FileAdd
          * 功能说明：追加文件内容
          * 参    数：Path:文件路径,strings:内容
          * 调用示列：
          *            string Path = Server.MapPath("Default2.aspx");     
          *            string Strings = "新追加内容";
          *            FileHelper.FileAdd(Path, Strings);
         *****************************************/
        /// <summary>
        /// 追加文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="strings">内容</param>
        public static void FileAdd(string Path, string strings)
        {
            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
            }
            StreamWriter sw = File.AppendText(Path);
            sw.Write(strings);
            sw.Flush();
            sw.Close();
        }
        #endregion

        #region 拷贝文件
        /****************************************
          * 函数名称：FileCopy
          * 功能说明：拷贝文件
          * 参    数：OrignFile:原始文件,NewFile:新文件路径
          * 调用示列：
          *            string orignFile = Server.MapPath("Default2.aspx");     
          *            string NewFile = Server.MapPath("Default3.aspx");
          *            FileHelper.FileCopy(OrignFile, NewFile);
         *****************************************/
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="OrignFile">原始文件</param>
        /// <param name="NewFile">新文件路径</param>
        public static void FileCopy(string orignFile, string NewFile)
        {
            File.Copy(orignFile, NewFile, true);
        }

        #endregion

        #region 删除文件
        /****************************************
          * 函数名称：FileDel
          * 功能说明：删除文件
          * 参    数：Path:文件路径
          * 调用示列：
          *            string Path = Server.MapPath("Default3.aspx");    
          *            FileHelper.FileDel(Path);
         *****************************************/
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="Path">路径</param>
        public static void FileDel(string Path)
        {
            File.Delete(Path);
        }
        #endregion

        #region 移动文件
        /****************************************
          * 函数名称：FileMove
          * 功能说明：移动文件
          * 参    数：OrignFile:原始路径,NewFile:新文件路径
          * 调用示列：
          *             string orignFile = Server.MapPath("../说明.txt");    
          *             string NewFile = Server.MapPath("../../说明.txt");
          *             FileHelper.FileMove(OrignFile, NewFile);
         *****************************************/
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="OrignFile">原始路径</param>
        /// <param name="NewFile">新路径</param>
        public static void FileMove(string orignFile, string NewFile)
        {
            File.Move(orignFile, NewFile);
        }
        #endregion

        #region 在当前目录下创建目录
        /****************************************
          * 函数名称：FolderCreate
          * 功能说明：在当前目录下创建目录
          * 参    数：OrignFolder:当前目录,NewFloder:新目录
          * 调用示列：
          *            string orignFolder = Server.MapPath("test/");    
          *            string NewFloder = "new";
          *            FileHelper.FolderCreate(OrignFolder, NewFloder); 
         *****************************************/
        /// <summary>
        /// 在当前目录下创建目录
        /// </summary>
        /// <param name="OrignFolder">当前目录</param>
        /// <param name="NewFloder">新目录</param>
        public static void FolderCreate(string orignFolder, string NewFloder)
        {
            Directory.SetCurrentDirectory(orignFolder);
            Directory.CreateDirectory(NewFloder);
        }
        #endregion

        #region 递归删除文件夹目录及文件
        /****************************************
          * 函数名称：DeleteFolder
          * 功能说明：递归删除文件夹目录及文件
          * 参    数：dir:文件夹路径
          * 调用示列：
          *            string dir = Server.MapPath("test/");  
          *            FileHelper.DeleteFolder(dir);       
         *****************************************/
        /// <summary>
        /// 递归删除文件夹目录及文件
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件
                    else
                        DeleteFolder(d); //递归删除子文件夹
                }
                Directory.Delete(dir); //删除已空文件夹
            }

        }

        #endregion

        #region 将指定文件夹下面的所有内容copy到目标文件夹下面果目标文件夹为只读属性就会报错。
        /****************************************
          * 函数名称：CopyDir
          * 功能说明：将指定文件夹下面的所有内容copy到目标文件夹下面果目标文件夹为只读属性就会报错。
          * 参    数：srcPath:原始路径,aimPath:目标文件夹
          * 调用示列：
          *            string srcPath = Server.MapPath("test/");  
          *            string aimPath = Server.MapPath("test1/");
          *            FileHelper.CopyDir(srcPath,aimPath);   
         *****************************************/
        /// <summary>
        /// 指定文件夹下面的所有内容copy到目标文件夹下面
        /// </summary>
        /// <param name="srcPath">原始路径</param>
        /// <param name="aimPath">目标文件夹</param>
        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // 判断目标目录是否存在如果不存在则新建之
                if (!Directory.Exists(aimPath))
                    Directory.CreateDirectory(aimPath);
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                //如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                //string[] fileList = Directory.GetFiles(srcPath);
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                //遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    //先当作目录处理如果存在这个目录就递归Copy该目录下面的文件

                    if (Directory.Exists(file))
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    //否则直接Copy文件
                    else
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                }

            }
            catch (Exception ee)
            {
                throw new Exception(ee.ToString());
            }
        }


        #endregion

        #region 拷贝文件夹
        /****************************************
          * 函数名称：FolderCoppy
          * 功能说明：拷贝文件夹
          * 参    数：OrignFolder:源路径,NewFolder:目标路径
          * 调用示列：
          *            string orignFolder = "C:\\Temp";     
          *            string NewFolder = "D:\\";
          *            FileHelper.FolderCoppy(orignFolder, NewFolder);
         *****************************************/
        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="OrignFolder">源路径</param>
        /// <param name="NewFolder">目标路径</param>
        public static void FolderCoppy(string orignFolder, string NewFolder)
        {
            string path = (NewFolder.LastIndexOf("\\") == NewFolder.Length - 1) ? NewFolder : NewFolder + "\\";
            string parent = Path.GetDirectoryName(orignFolder);
            Directory.CreateDirectory(path + Path.GetFileName(orignFolder));
            DirectoryInfo dir = new DirectoryInfo((orignFolder.LastIndexOf("\\") == orignFolder.Length - 1) ? orignFolder : orignFolder + "\\");
            FileSystemInfo[] fileArr = dir.GetFileSystemInfos();
            Queue<FileSystemInfo> Folders = new Queue<FileSystemInfo>(dir.GetFileSystemInfos());
            while (Folders.Count > 0)
            {
                FileSystemInfo tmp = Folders.Dequeue();
                FileInfo f = tmp as FileInfo;
                if (f == null)
                {
                    DirectoryInfo d = tmp as DirectoryInfo;
                    Directory.CreateDirectory(d.FullName.Replace((parent.LastIndexOf("\\") == parent.Length - 1) ? parent : parent + "\\", path));
                    foreach (FileSystemInfo fi in d.GetFileSystemInfos())
                    {
                        Folders.Enqueue(fi);
                    }
                }
                else
                {
                    f.CopyTo(f.FullName.Replace(parent, path));
                }
            }
        }

        #endregion

        #region 移动文件夹
        /****************************************
          * 函数名称：FolderMove
          * 功能说明：拷贝文件夹
          * 参    数：OrignFolder:源路径,NewFolder:目标路径
          * 调用示列：
          *            string orignFolder = "C:\\Temp";     
          *            string NewFolder = "D:\\";
          *            FileHelper.FolderCoppy(orignFolder, NewFolder);
         *****************************************/
        /// <summary>
        /// 移动文件夹
        /// </summary>
        /// <param name="OrignFolder">源路径</param>
        /// <param name="NewFolder">目标路径</param>
        public static void FolderMove(string orignFolder, string NewFolder)
        {
            string filename = Path.GetFileName(orignFolder);
            string path = (NewFolder.LastIndexOf("\\") == NewFolder.Length - 1) ? NewFolder : NewFolder + "\\";
            if (Path.GetPathRoot(orignFolder) == Path.GetPathRoot(NewFolder))
                Directory.Move(orignFolder, path + filename);
            else
            {
                string parent = Path.GetDirectoryName(orignFolder);
                Directory.CreateDirectory(path + Path.GetFileName(orignFolder));
                DirectoryInfo dir = new DirectoryInfo((orignFolder.LastIndexOf("\\") == orignFolder.Length - 1) ? orignFolder : orignFolder + "\\");
                FileSystemInfo[] fileArr = dir.GetFileSystemInfos();
                Queue<FileSystemInfo> Folders = new Queue<FileSystemInfo>(dir.GetFileSystemInfos());
                while (Folders.Count > 0)
                {
                    FileSystemInfo tmp = Folders.Dequeue();
                    FileInfo f = tmp as FileInfo;
                    if (f == null)
                    {
                        DirectoryInfo d = tmp as DirectoryInfo;
                        DirectoryInfo dpath = new DirectoryInfo(d.FullName.Replace((parent.LastIndexOf("\\") == parent.Length - 1) ? parent : parent + "\\", path));
                        dpath.Create();
                        foreach (FileSystemInfo fi in d.GetFileSystemInfos())
                        {
                            Folders.Enqueue(fi);
                        }
                    }
                    else
                    {
                        f.MoveTo(f.FullName.Replace(parent, path));
                    }
                }
                Directory.Delete(orignFolder, true);
            }
        }

        #endregion

        #region 清空目录
        /****************************************
          * 函数名称：FolderClean
          * 功能说明：清空指定目录
          * 参    数：TargetFolder:指定目录
          * 调用示列：
          *            string TargetFolder = Server.MapPath("test/");
          *            FileHelper.FolderClean(TargetFolder); 
         *****************************************/
        /// <summary>
        /// 清空目录
        /// </summary>
        /// <param name="TargetFolder">指定目录</param>
        public static void FolderCreate(string TargetFolder)
        {
            Directory.Delete(TargetFolder, true);
            Directory.CreateDirectory(TargetFolder);
        }
        #endregion

        #region 以一个文件夹的框架在另一个目录创建文件夹和空文件
        /****************************************
          * 函数名称：FolderBuild
          * 功能说明：创建文件夹框架
          * 参    数：OrignFolder:源路径,NewFolder:目标路径
          * 调用示列：
          *            string orignFolder = "C:\\Temp";     
          *            string NewFolder = "D:\\";
          *            FileHelper.FolderBuild(orignFolder, NewFolder);
         *****************************************/
        /// <summary>
        /// 以一个文件夹的框架在另一个目录创建文件夹和空文件
        /// </summary>
        /// <param name="OrignFolder">源路径</param>
        /// <param name="NewFolder">目标路径</param>
        public static void FolderBuild(string orignFolder, string NewFolder)
        {
            bool b = false;
            string path = (NewFolder.LastIndexOf("\\") == NewFolder.Length - 1) ? NewFolder : NewFolder + "\\";
            string parent = Path.GetDirectoryName(orignFolder);
            Directory.CreateDirectory(path + Path.GetFileName(orignFolder));
            DirectoryInfo dir = new DirectoryInfo((orignFolder.LastIndexOf("\\") == orignFolder.Length - 1) ? orignFolder : orignFolder + "\\");
            FileSystemInfo[] fileArr = dir.GetFileSystemInfos();
            Queue<FileSystemInfo> Folders = new Queue<FileSystemInfo>(dir.GetFileSystemInfos());
            while (Folders.Count > 0)
            {
                FileSystemInfo tmp = Folders.Dequeue();
                FileInfo f = tmp as FileInfo;
                if (f == null)
                {
                    DirectoryInfo d = tmp as DirectoryInfo;
                    Directory.CreateDirectory(d.FullName.Replace((parent.LastIndexOf("\\") == parent.Length - 1) ? parent : parent + "\\", path));
                    foreach (FileSystemInfo fi in d.GetFileSystemInfos())
                    {
                        Folders.Enqueue(fi);
                    }
                }
                else
                {
                    if (b) File.Create(f.FullName.Replace(parent, path));
                }
            }
        }

        #endregion

        #region 提取扩展名
        /****************************************
          * 函数名称：GetExt
          * 功能说明：提取扩展名
          * 参    数：FilePath:文件路径
          * 调用示列：
          *            string FilePath = Server.MapPath("../说明.txt");
          *            string FileExtension= FileHelper.GetExt(FilePath);
         *****************************************/
        /// <summary>
        /// 提取扩展名
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        public static string GetExt(string FilePath)
        {
            return Path.GetExtension(FilePath);
        }

        #endregion

        #region 提取文件名
        /****************************************
          * 函数名称：GetFileName
          * 功能说明：提取文件名
          * 参    数：FilePath:文件路径
          * 调用示列：
          *            string FilePath = Server.MapPath("../说明.txt");
          *            string FileName= FileHelper.GetFileName(FilePath);
         *****************************************/
        /// <summary>
        /// 提取文件名
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        public static string GetFileName(string FilePath)
        {
            return Path.GetFileName(FilePath);
        }

        #endregion

        #region 提取文件路径
        /****************************************
          * 函数名称：GetDirName
          * 功能说明：提取文件路径
          * 参    数：FilePath:文件路径
          * 调用示列：
          *            string FilePath = Server.MapPath("../说明.txt");
          *            string DirName= FileHelper.GetDirName(FilePath);
         *****************************************/
        /// <summary>
        /// 提取文件路径
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        public static string GetDirName(string FilePath)
        {
            return Path.GetDirectoryName(FilePath);
        }

        #endregion
    }
}
