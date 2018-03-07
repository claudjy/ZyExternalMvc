using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace Zysoft.FrameWork.Cache 
{
    /// <summary>
    /// Add by Sugar at 2012.2.16
    /// 自定义缓存刷新操作
    /// </summary>
    [Serializable]
    public class CacheItemRefreshAction : ICacheItemRefreshAction
    {
        #region ICacheItemRefreshAction接口

        /// <summary>
        /// 自定义刷新操作
        /// </summary>
        /// <param name="removedKey">移除的键</param>
        /// <param name="expiredValue">过期的值</param>
        /// <param name="removalReason">移除理由</param>
        public void Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
        {
            if (removalReason == CacheItemRemovedReason.Expired)
            {
                ICacheManager cache = CacheFactory.GetCacheManager();
                cache.Add(removedKey, expiredValue);
            }
        }

        #endregion
    }
}
