using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Security;

namespace Zysoft.FrameWork.WebHttp
{
    public class WebPreview
    {

        private string _parameter = null;
        private Exception _ex = null;
        private byte[] _bitmap = null;
        private int _timeout = 30;//设置线程超时时长
        private int _width = 200;//缩图宽
        private int _height = 150;//缩图高
        private int _screenWidth = 800;//屏幕宽
        private int _screenHeight = 600;//屏幕高
        private bool _usingUrl = true;   //使用url获取网页还是通过html源码获取网页
        private bool _fix = false;       //是否截图为原始大小

        /// <summary>
        /// 使用url制作200*150的缩略图
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static byte[] GetWebPreview(string uri)
        {
            WebPreview wp = new WebPreview(true, uri, false);
            return wp.GetWebPreview();
        }

        /// <summary>
        /// 使用html源码制作无缩放的截图
        /// </summary>
        /// <param name="WebContent"></param>
        /// <returns></returns>
        public static byte[] GetWebFullPreviewByHtml(string WebContent)
        {
            WebPreview wp = new WebPreview(false, WebContent, true);
            return wp.GetWebPreview();
        }

        private WebPreview(bool usingUrl, string parameter, bool fix)
        {
            _usingUrl = usingUrl;
            _parameter = parameter;
            _fix = fix;
        }
        private WebPreview(string uri, int timeout, int width, int height, int screenWidth, int screenHeight)
        {
            _parameter = uri;
            _timeout = timeout;
            _width = width;
            _height = height;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }
        internal byte[] GetWebPreview()
        {
            //Asp.Net引用Winform（类似ActiveX）控件，必须开单线程
            Thread t = new Thread(new ParameterizedThreadStart(StaRun));
            t.SetApartmentState(ApartmentState.STA);
            t.Start(this);

            if (!t.Join(_timeout * 1000))
            {
                t.Abort();
                throw new TimeoutException();
            }

            if (_ex != null) throw _ex;
            //if (_bitmap == null) throw new ExecutionEngineException();

            return _bitmap;
        }
        /// <summary>
        /// 为WebBrowser所开线程的启动入口函数，相当于Winform里面的Main()
        /// </summary>
        /// <param name="_wp"></param>
        private static void StaRun(object _wp)
        {
            WebPreview wp = (WebPreview)_wp;
            try
            {
                if (wp._fix)
                {
                    using (WebPreviewBase wpb = new WebPreviewBase(wp._usingUrl, wp._parameter))
                    {
                        wp._bitmap = wpb.GetWebPreview();
                    }
                }
                else
                {
                    using (WebPreviewBase wpb = new WebPreviewBase(wp._usingUrl, wp._parameter, wp._width, wp._height, wp._screenWidth, wp._screenHeight))
                    {
                        wp._bitmap = wpb.GetWebPreview();
                    }
                }
            }
            catch (Exception ex)
            {
                wp._ex = ex;
            }
        }
    }

    class WebPreviewBase : IDisposable
    {
        string _uri = "about:blank";//原始uri
        int _thumbW = 1024;     //缩略图高度
        int _thumbH = 768;      //缩略图宽度
        WebBrowser _wb;         //浏览器对象
        bool fix = false;       //是否截图为原始大小
        bool _usingUrl = true;   //使用url获取网页还是通过html源码获取网页
        string _htmlCode = "";  //HTML源码

        public WebPreviewBase(bool usingUrl, string parameter, int thumbW, int thumbH, int screenWidth, int screenHeight)
        {
            _wb = new WebBrowser();
            _wb.ScriptErrorsSuppressed = true;
            _wb.ScrollBarsEnabled = false;
            _wb.Size = new Size(screenWidth, screenHeight);//浏览器分辨率为1024x768            
            _wb.NewWindow += new System.ComponentModel.CancelEventHandler(CancelEventHandler);
            _thumbW = thumbW;
            _thumbH = thumbH;

            _usingUrl = usingUrl;
            if (_usingUrl)
            {
                _uri = parameter;
            }
            else
            {
                _htmlCode = parameter;
            }
        }

        public WebPreviewBase(bool usingUrl, string parameter)
        {
            _wb = new WebBrowser();
            fix = true;
            _usingUrl = usingUrl;
            if (_usingUrl)
            {
                _uri = parameter;
            }
            else
            {
                _htmlCode = parameter;
            }
        }

        //防止弹窗
        public void CancelEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected void InitComobject()
        {
            try
            {
                if (_usingUrl)
                {
                    _wb.Navigate(this._uri);
                }
                else
                {
                    _wb.ScrollBarsEnabled = false;
                    _wb.DocumentText = _htmlCode;
                }

                //因为没有窗体，所以必须如此
                while (_wb.IsBusy || _wb.ReadyState != WebBrowserReadyState.Complete)
                {
                    //立即重绘
                    Application.DoEvents();
                }
                //这句最好注释，不然网页上的动画都抓不到了
                //_wb.Stop();
                if (_wb.ActiveXInstance == null) throw new Exception("实例不能为空");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取Web预览图
        /// </summary>
        /// <returns>Bitmap</returns>
        public byte[] GetWebPreview()
        {


            try
            {
                InitComobject();

                //全屏截图
                if (fix)
                {
                    _wb.Width = _thumbW = _wb.Document.Body.ScrollRectangle.Width;
                    _wb.Height = _thumbH = _wb.Document.Body.ScrollRectangle.Height;
                }

                #region 调整图片高宽，并调整浏览器高宽适应图片高宽
                int w = _wb.Width;
                int h = _wb.Height;
                Size sz = _wb.Size;

                // 最小宽度不能小于缩略图宽度
                if (w < _thumbW)
                    w = _thumbW;

                // 调整最小高度，充满浏览器
                if (h < sz.Height)
                    h = sz.Height;
                _wb.Size = new Size(w, h);
                #endregion

                //构造snapshot类，抓取浏览器ActiveX的图象
                Snapshot snap = new Snapshot();
                Bitmap thumBitmap = snap.TakeSnapshot(_wb.ActiveXInstance, new Rectangle(0, 0, w, h));
                //调整图片大小，这里选择以宽度为标准，高度保持比例
                thumBitmap = (Bitmap)ImageLibrary.ResizeImageToAFixedSize(thumBitmap, _thumbW, _thumbH, ImageLibrary.ScaleMode.W);
                using (MemoryStream ms = new MemoryStream())
                {
                    thumBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _wb.Dispose();
        }

    }

    #region WebPreview的类库

    /// <summary>
    /// 图像处理类
    /// </summary>
    public class ImageLibrary
    {
        /// <summary>
        /// 两张图片的对比结果
        /// </summary>
        public enum CompareResult
        {
            ciCompareOk,
            ciPixelMismatch,
            ciSizeMismatch
        };


        /// <summary>
        /// 对比两张图片
        /// </summary>
        /// <param name="bmp1">The first bitmap image</param>
        /// <param name="bmp2">The second bitmap image</param>
        /// <returns>CompareResult</returns>
        public static CompareResult CompareTwoImages(Bitmap bmp1, Bitmap bmp2)
        {
            CompareResult cr = CompareResult.ciCompareOk;

            //Test to see if we have the same size of image
            if (bmp1.Size != bmp2.Size)
            {
                cr = CompareResult.ciSizeMismatch;
            }
            else
            {
                //Convert each image to a byte array
                System.Drawing.ImageConverter ic =
                       new System.Drawing.ImageConverter();
                byte[] btImage1 = new byte[1];
                btImage1 = (byte[])ic.ConvertTo(bmp1, btImage1.GetType());
                byte[] btImage2 = new byte[1];
                btImage2 = (byte[])ic.ConvertTo(bmp2, btImage2.GetType());

                //Compute a hash for each image
                SHA256Managed shaM = new SHA256Managed();
                byte[] hash1 = shaM.ComputeHash(btImage1);
                byte[] hash2 = shaM.ComputeHash(btImage2);

                //Compare the hash values
                for (int i = 0; i < hash1.Length && i < hash2.Length
                                  && cr == CompareResult.ciCompareOk; i++)
                {
                    if (hash1[i] != hash2[i])
                        cr = CompareResult.ciPixelMismatch;
                }
            }
            return cr;
        }

        public enum ScaleMode
        {
            /// <summary>
            /// 指定高宽缩放（可能变形）
            /// </summary>
            HW,
            /// <summary>
            /// 指定宽，高按比例
            /// </summary>
            W,
            /// <summary>
            /// 指定高，宽按比例
            /// </summary>
            H,
            /// <summary>
            /// 指定高宽裁减（不变形）
            /// </summary>
            Cut
        };

        /// <summary>
        /// Resizes the image by a percentage
        /// </summary>
        /// <param name="imgPhoto">The img photo.</param>
        /// <param name="Percent">The percentage</param>
        /// <returns></returns>
        // http://www.codeproject.com/csharp/imageresize.asp
        public static Image ResizeImageByPercent(Image imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                    imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }


        /// <summary>
        /// 缩放、裁切图片
        /// </summary>
        /// <param name="originalImage"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Image ResizeImageToAFixedSize(Image originalImage, int width, int height, ScaleMode mode)
        {
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case ScaleMode.HW:
                    break;
                case ScaleMode.W:
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case ScaleMode.H:
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case ScaleMode.Cut:
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画布
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置画布的描绘质量
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            g.Dispose();

            return bitmap;
        }

    }

    /// <summary>
    /// ActiveX 组件快照类
    /// AcitveX 必须实现 IViewObject 接口
    /// 
    /// 作者:随飞
    /// http://chinasf.cnblogs.com
    /// chinasf@hotmail.com
    /// </summary>
    class Snapshot
    {
        /// <summary>
        /// 取快照
        /// </summary>
        /// <param name="pUnknown">Com 对象</param>
        /// <param name="bmpRect">图象大小</param>
        /// <returns></returns>
        public Bitmap TakeSnapshot(object pUnknown, Rectangle bmpRect)
        {
            if (pUnknown == null)
                return null;
            //必须为com对象
            if (!Marshal.IsComObject(pUnknown))
                return null;
            //IViewObject 接口
            UnsafeNativeMethods.IViewObject ViewObject = null;
            IntPtr pViewObject = IntPtr.Zero;
            //内存图
            Bitmap pPicture = new Bitmap(bmpRect.Width, bmpRect.Height);
            Graphics hDrawDC = Graphics.FromImage(pPicture);
            //获取接口
            object hret = Marshal.QueryInterface(Marshal.GetIUnknownForObject(pUnknown),
                ref UnsafeNativeMethods.IID_IViewObject, out pViewObject);
            try
            {
                ViewObject = Marshal.GetTypedObjectForIUnknown(pViewObject, typeof(UnsafeNativeMethods.IViewObject)) as UnsafeNativeMethods.IViewObject;
                //调用Draw方法
                ViewObject.Draw((int)DVASPECT.DVASPECT_CONTENT,
                    -1,
                    IntPtr.Zero,
                    null,
                    IntPtr.Zero,
                    hDrawDC.GetHdc(),
                    new NativeMethods.COMRECT(bmpRect),
                    null,
                    IntPtr.Zero,
                    0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            //释放
            hDrawDC.Dispose();
            return pPicture;
        }
    }

    /// <summary>
    /// 从 .Net 2.0 的 System.Windows.Forms.Dll 库提取
    /// 版权所有：微软公司
    /// </summary>
    internal static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagDVTARGETDEVICE
        {
            [MarshalAs(UnmanagedType.U4)]
            public int tdSize;
            [MarshalAs(UnmanagedType.U2)]
            public short tdDriverNameOffset;
            [MarshalAs(UnmanagedType.U2)]
            public short tdDeviceNameOffset;
            [MarshalAs(UnmanagedType.U2)]
            public short tdPortNameOffset;
            [MarshalAs(UnmanagedType.U2)]
            public short tdExtDevmodeOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class COMRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public COMRECT()
            {
            }

            public COMRECT(Rectangle r)
            {
                this.left = r.X;
                this.top = r.Y;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            public COMRECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public static NativeMethods.COMRECT FromXYWH(int x, int y, int width, int height)
            {
                return new NativeMethods.COMRECT(x, y, x + width, y + height);
            }

            public override string ToString()
            {
                return string.Concat(new object[] { "Left = ", this.left, " Top ", this.top, " Right = ", this.right, " Bottom = ", this.bottom });
            }

        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagLOGPALETTE
        {
            [MarshalAs(UnmanagedType.U2)]
            public short palVersion;
            [MarshalAs(UnmanagedType.U2)]
            public short palNumEntries;
        }
    }

    /// <summary>
    /// 从 .Net 2.0 的 System.Windows.Forms.Dll 库提取
    /// 版权所有：微软公司
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethods
    {
        public static Guid IID_IViewObject = new Guid("{0000010d-0000-0000-C000-000000000046}");

        [ComImport, Guid("0000010d-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IViewObject
        {
            [PreserveSig]
            int Draw([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethods.tagDVTARGETDEVICE ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, [In] NativeMethods.COMRECT lprcBounds, [In] NativeMethods.COMRECT lprcWBounds, IntPtr pfnContinue, [In] int dwContinue);
            [PreserveSig]
            int GetColorSet([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [In] NativeMethods.tagDVTARGETDEVICE ptd, IntPtr hicTargetDev, [Out] NativeMethods.tagLOGPALETTE ppColorSet);
            [PreserveSig]
            int Freeze([In, MarshalAs(UnmanagedType.U4)] int dwDrawAspect, int lindex, IntPtr pvAspect, [Out] IntPtr pdwFreeze);
            [PreserveSig]
            int Unfreeze([In, MarshalAs(UnmanagedType.U4)] int dwFreeze);
            void SetAdvise([In, MarshalAs(UnmanagedType.U4)] int aspects, [In, MarshalAs(UnmanagedType.U4)] int advf, [In, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink);
            void GetAdvise([In, Out, MarshalAs(UnmanagedType.LPArray)] int[] paspects, [In, Out, MarshalAs(UnmanagedType.LPArray)] int[] advf, [In, Out, MarshalAs(UnmanagedType.LPArray)] IAdviseSink[] pAdvSink);
        }
    }

    #endregion


}
