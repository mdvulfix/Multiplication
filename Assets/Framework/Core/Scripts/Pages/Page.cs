using System.Collections;
using UnityEngine;

namespace Framework.Core
{
    public interface IPage: ISceneObject, ICacheable
    {
        bool    IsLoading       {get; }
        bool    UseAnimation    {get; }
        string  AnimationState  {get; }
        
        void Register();
        void Animate(bool animate);
    }
    
    public abstract class Page : SceneObject, IPage
    {
        
        private readonly string ANIMATION_NONE = "None";
        private readonly string ANIMATION_ON = "On";
        private readonly string ANIMATION_OFF = "Off";
        
        
        public bool     IsLoading       {get; protected set;}
        public bool     UseAnimation    {get; protected set;}
        public string   AnimationState  {get; protected set;}
        
        public static ICache<IPage> Cache {get; } = new Cache<IPage>();


        public abstract void Register();


        public void Animate(bool animate)
        {
            if(!ActivateObject(animate))
                return;
            
            if(UseAnimation)
            {
                StopCoroutine("AwaitAnimation");
                StartCoroutine("AwaitAnimation", animate);
                Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
            {
                Log("Animation is disabled on page [ " + Name + " ]");
            }
        }

        // TODO: check AwaitAnimation function;
        protected IEnumerator AwaitAnimation (bool on)
        {
            AnimationState = on ? ANIMATION_ON : ANIMATION_OFF;
            yield return null;
        }

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
