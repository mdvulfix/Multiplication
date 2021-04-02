using UnityEngine;

namespace Framework.Core
{
    public interface IPage: ICacheable
    {
        string  Name        {get; }
        bool    IsLoading   {get; }
        
        void Register();
        void Activate(bool trueOrFalse);
    }
    
    public abstract class Page : SceneObject, IPage
    {
        
        public string                   Name        {get; protected set;}
        public bool                     IsLoading   {get; protected set;}
        public static ICache<IPage>     Cache       {get; } = new Cache<IPage>();


        public abstract void Register();
        public abstract void Activate(bool trueOrFalse);


        public void SetPageToCache(IPage page)
        {
            Cache.Add(page);
            Log(Name + " set to cache.");

        }
        
        public IPage GetPageFromCache()
        {
            IPage page = Cache.Get();

            if(page == null)
            {
                LogWarning(Name + " not found.");
                return null;
            }
            else
            {
                Log(Name + " got from cache.");
                return page;
                
            }
        }

        public IPage[] GetPagesFromCache()
        {
            var pages = new IPage[Cache.Storage.Count];
            Cache.Storage.Values.CopyTo(pages, 0);
            
            return pages;

        }


        protected void Log(string message)
        {
            Debug.Log("[Page]: " + message);

        }

        protected void LogWarning(string message)
        {
            Debug.LogWarning("[Page]: " + message);
            
        }
    
    
    }

}
