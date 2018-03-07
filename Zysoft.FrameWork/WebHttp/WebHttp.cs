using System;
using System.IO;
using System.Net;
using System.Text;

namespace Zysoft.FrameWork.WetHttp
{
    /// <summary>
    /// 2012-3-13.hjb.GET/POST方法，调用HTTP页面，返回结果
    /// </summary>
    public class WebHttp
    {
        /// <summary>
        /// 编码方式: 默认UTF-8
        /// </summary>
        private Encoding _defaultEncode = Encoding.GetEncoding("UTF-8");

        /// <summary>
        /// 设置编码方式
        /// </summary>
        /// <param name="encode"></param>
        public void SetEncode(Encoding encode)
        {
            _defaultEncode = encode;
        }

        /// <summary>
        /// GET 方法，调用HTTP页面，返回结果
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetWebHttp(string url)
        {
            string getResult = string.Empty;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            myReq.Method = "GET";

            try
            {
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();

                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, _defaultEncode);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }
                //
                sr.Close();
                sr.Dispose();
                myStream.Close();
                myStream.Dispose();
                HttpWResp.Close();

                getResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }

            return getResult;
        }

        /// <summary>
        /// POST 方法，调用HTTP页面，返回结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public string PostWebHttp(string url, string postData)
        {
            string postResult = string.Empty;

            try
            {
                byte[] data = _defaultEncode.GetBytes(postData);

                //准备请求
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                Stream newStream = myRequest.GetRequestStream();

                //发送数据
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                newStream.Dispose();

                try
                {
                    HttpWebResponse HttpWResp = (HttpWebResponse)myRequest.GetResponse();
                    Stream myStream = HttpWResp.GetResponseStream();
                    StreamReader sr = new StreamReader(myStream, _defaultEncode);
                    StringBuilder strBuilder = new StringBuilder();
                    while (-1 != sr.Peek())
                    {
                        strBuilder.Append(sr.ReadLine());
                    }
                    //
                    sr.Close();
                    sr.Dispose();
                    myStream.Close();
                    myStream.Dispose();
                    HttpWResp.Close();
                    //
                    postResult = strBuilder.ToString();
                }
                catch (Exception exp)
                {
                    throw new Exception(exp.Message);
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }

            return postResult;
        }
    }
}
