using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Zysoft.FrameWork.FaultException
{
    /// <summary>
    /// Add by Sugar at 2012.2.18
    /// 公用Exception基类
    /// </summary>
    [Serializable]
    public class FaultException : System.Exception
    {
        private string _errorMsg;
        private string _errorCode;

        public FaultException():base()
        {

        }

        public FaultException(string errorCode, string errorMsg)
        {
            this._errorCode = errorCode;
            this._errorMsg = errorMsg;
        }

        protected FaultException(SerializationInfo si, StreamingContext context)
            : base(si, context)
        {
            _errorCode = si.GetString("ErrorCode");
            _errorMsg = si.GetString("ErrorMsg");
        }

        public override void GetObjectData(SerializationInfo si, StreamingContext context)
        {
            base.GetObjectData(si, context);

            si.AddValue("ErrorCode", _errorCode);
            si.AddValue("ErrorMsg", _errorMsg);
        }

        /// <summary>
        /// 异常代码
        /// </summary>
        public string ErrorCode
        {
            get
            {
                return _errorCode;
            }
        }

        /// <summary>
        /// 异常内容
        /// </summary>
        public string ErrorMsg
        {
            get
            {
                return _errorMsg;
            }
        }
        public override string Message
        {
            get
            {
                return string.Format("error:{0}:{1}",_errorCode,_errorMsg);
            }
        }
    }
}
