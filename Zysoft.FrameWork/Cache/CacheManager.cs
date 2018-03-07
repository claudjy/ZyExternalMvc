using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Zysoft.FrameWork.Cache
{        
    /// <summary>
    /// Add by Sugar at 2012.2.16
    /// 缓存管理类
    /// </summary>
    public static class CacheManager
    {
        /// <summary>
        /// 缓存管理
        /// </summary>
        private static ICacheManager _cache = CacheFactory.GetCacheManager();

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="isRefresh">是否刷新</param>
        public static void Add(string key, object value, bool isRefresh = false)
        {
            if (isRefresh)
            {
                //自定义刷新方式,如果过期将自动重新加载,过期时间为5分钟
                TimeSpan timeSpan = TimeSpan.FromMinutes(5);

                _cache.Add(key, value, CacheItemPriority.Normal, new CacheItemRefreshAction(), new AbsoluteTime(timeSpan));
            }
            else //手动管理方式
            {
                _cache.Add(key, value);
            }
        }

         /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            return _cache.GetData(key);
        }

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveCache(string key)
        {
            _cache.Remove(key);
        }
    }
}
