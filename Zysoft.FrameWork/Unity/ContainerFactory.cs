using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Zysoft.FrameWork.Cache;
using System.Web;

namespace Zysoft.FrameWork.Unity 
{
    /// <summary>
    /// Add by Sugar at 2012.2.16
    /// DI容器工厂类
    /// </summary>
    public static class ContainerFactory
    {
        public static IUnityContainer GetContainer()
        {
            
            if (CacheManager.GetCache("UnityContainer") == null)
            {
                IUnityContainer container = new UnityContainer();
                //依赖注入配置
                LoadUnityConfigFile(container);
                CacheManager.Add("UnityContainer", container);
            }

            return (IUnityContainer)CacheManager.GetCache("UnityContainer");
        }

        private static void LoadUnityConfigFile(IUnityContainer container)
        {
            UnityConfigurationSection unitySection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (unitySection.Containers.Default != null)
            {
                unitySection.Configure(container);
            }
        }
    }
}
