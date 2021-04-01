using UnityEngine;

namespace Framework.Core
{
    public interface IPage: ICacheable
    {
        void Register();
    }
    
    public abstract class Page : SceneObject, IPage
    {
        private static ICache<IPage> Cache {get; } = new Cache<IPage>();

        public abstract void Register();
        
        public static void SetPage(IPage page)
        {
            Cache.Add(page);
            Log("[Page]: " + page.GetType().Name + " has been set to cache.");

        }
        
        public static IPage GetPage()
        {
            IPage page = Cache.Get();

            if(page == null)
            {
                LogWarning("[Page]: " + page.GetType().Name + "has't been found.");
                return null;
            }
            else
            {
                Log("[Page]: " + page.GetType().Name + "has been got from cache.");
                return page;
                
            }
        }

        public static IPage[] GetAllPages()
        {
            var pages = new IPage[Cache.Storage.Count];
            Cache.Storage.Values.CopyTo(pages, 0);
            
            return pages;

        }

        protected static void Log(string message)
        {
            Debug.Log(message);

        }

        protected static void LogWarning(string message)
        {
            Debug.LogWarning(message);
            
        }
    
    
    }

}
