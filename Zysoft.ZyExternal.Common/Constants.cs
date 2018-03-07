using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zysoft.ZyExternal.Common
{

    /// <summary>
    /// 日志类型
    /// </summary>
    public static class LogCategory
    {
        /// <summary>
        /// 异常日志
        /// </summary>
        public const string APP_ERROR = "AppError";

        /// <summary>
        /// 服务调用日志
        /// </summary>
        public const string SERVICE_CALL = "ServiceCall";

        /// <summary>
        /// 服务调用日志
        /// </summary>
        public const string METHOD_CALL = "MethodCall";
    }

    /// <summary>
    /// 门诊、住院标志
    /// </summary>
    public class IoFlag
    {
        /// <summary>
        /// 门诊
        /// </summary>
        public const string IO_DISP = "1";	//门诊
        /// <summary>
        /// 住院
        /// </summary>
        public const string IO_RESI = "2";	//住院
        /// <summary>
        /// 门诊/住院都支持
        /// </summary>
        public const string IO_BOTH = "0";	//门诊/住院都支持
        /// <summary>
        /// 都不支持
        /// </summary>
        public const string IO_NONE = "3";	//都不支持


    }

    public class PhysicFlag
    {
        public const string PHYSIC_YES = "Y";	//药品.
        public const string PHYSIC_NO = "N";	//诊疗.
    }

    /// <summary>
    /// 消息处理模式
    /// </summary>
    public class MessageDealMode
    {
        /// <summary>
        /// 单向消息
        /// </summary>
        public const string OneWay = "1";

        /// <summary>
        /// 双向消息
        /// </summary>
        public const string TwoWay = "2";
    }

    /// <消息状态>
    /// 
    /// </消息状态>
    public static class STDMessageStatus
    {
        /// <已发送>
        /// 
        /// </已发送>
        public const string SENDED = "1";

        /// <已接收>
        /// 
        /// </已接收>
        public const string RECEIVED = "3";

        /// <已作废>
        /// 
        /// </已作废>
        public const string OBSOLETED = "9";
    }

    /// <样式类型>
    /// 
    /// </summary>
    public static class STDStyleType
    {
        /// <检验报告样式>
        /// 
        /// </检验报告样式>
        public const string LIS_REPORT = "H01";

        /// <检查报告样式>
        /// 
        /// </检查报告样式>
        public const string PACS_REPORT = "H02";

        /// <医嘱查询样式>
        /// 
        /// </医嘱查询样式>
        public const string PRESCRIBE_HTML = "H03";

        /// <临床路径样式>
        /// 
        /// </临床路径样式>
        public const string ClinicPath_HTML = "H04";

        /// <检验报告XML样式>
        /// 
        /// </检验报告XML样式>
        public const string LIS_XML = "X01";

        /// <检查报告XML样式>
        /// 
        /// </检查报告XML样式>
        public const string PACS_XML = "X02";

        /// <医嘱查询XML样式>
        /// 
        /// </医嘱查询XML样式>
        public const string PRESCRIBE_XML = "X03";

        /// <临床路径查询XML>
        /// 
        /// </临床路径查询XML>
        public const string ClinicPath_XML = "X04";


        /// <语音呼叫查询XML>
        /// 
        /// </语音呼叫查询XML>
        public const string VoiceVisit_XML = "X05";

    }

    /// <样式类别>
    /// 
    /// </样式类别>
    public static class STDStyleClass
    {
        /// <通用类别>
        /// 
        /// </通用类别>
        public const string GENERAL_CLASS = "0";

        /// <summary>
        /// 临床路径表单
        /// </summary>
        public const string CLINIC_PATH_FORM = "0";


        /// <summary>
        /// 临床路径患者告知单
        /// </summary>
        public const string CLINIC_PATH_INFORM = "1";


        /// <summary>
        /// 临床路径执行评估单
        /// </summary>
        public const string CLINIC_PATH_EXECUTE_EVALUATION = "2";


        /// <summary>
        /// 临床路径列表
        /// </summary>
        public const string CLINIC_PATH_LIST = "3";

        /// <summary>
        /// 语音呼叫门诊病人
        /// </summary>
        public const string VOICE_VISIT_DISP = "1";

        /// <summary>
        /// 语音呼叫住院病人
        /// </summary>
        public const string VOICE_VISIT_RESI = "2";

        /// <summary>
        /// 语音呼叫体检病人
        /// </summary>
        public const string VOICE_VISIT_MEDICAL = "3";
    }

    /// <系统类型>
    /// 
    /// </系统类型>
    public static class STDSystemType
    {
        /// <LIS系统>
        /// 
        /// </LIS系统>
        public const string LIS_SYSTEM = "L";

        /// <PACS系统>
        /// 
        /// </PACS系统>
        public const string PACS_SYSTEM = "P";

        /// <HIS系统>
        /// 
        /// </HIS系统>
        public const string HIS_SYSTEM = "H";

        /// <移动系统>
        /// 
        /// </移动系统>
        public const string MOBILE_SYSTEM = "M";

        /// <电子病历系统>
        /// 
        /// </电子病历系统>
        public const string EMR_SYSTEM = "E";

        /// <体检系统>
        /// 
        /// </体检系统>
        public const string MEDICAL_SYSTEM = "C";
    }

}
