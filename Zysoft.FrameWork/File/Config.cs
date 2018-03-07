using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Zysoft.FrameWork
{
    public class Config
    {
        ///<summary> 
        ///返回＊.exe.config文件中appSettings配置节的value项  
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<returns></returns> 
        public static string GetAppSettingsKeyValue(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }

        /// <summary>
        /// 获取ConnectionStrings配置节中的值
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionStringsElementValue()
        {
            ConnectionStringSettings settings = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"];
            return settings.ConnectionString;
        }

        /// <summary>
        /// 保存节点中ConnectionStrings的子节点配置项的值
        /// </summary>
        /// <param name="ConnectionStringsName"></param>
        /// <param name="elementValue"></param>
        public static void ConnectionStringsSave(string ConnectionStringsName, string elementValue)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["connectionString"].ConnectionString = elementValue;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// 判断appSettings中是否有此项
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private static bool AppSettingsKeyExists(string strKey, Configuration config)
        {
            foreach (string str in config.AppSettings.Settings.AllKeys)
            {
                if (str == strKey)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 保存appSettings中某key的value值
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="newValue"></param>
        public static void AppSettingsSave(string strKey, string newValue)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (AppSettingsKeyExists(strKey, config))
            {
                config.AppSettings.Settings[strKey].Value = newValue;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
}
