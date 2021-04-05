using System;
using System.Collections;
using UnityEngine;

namespace Framework.Core
{
    public interface IPage: ISceneObject, ICacheable
    {
        bool            IsLoading       {get; }
        IDataAnimation  DataAnimation   {get; set;}
        
        void Register();
        void Animate(bool animate);
    }
    
    public abstract class Page : SceneObject, IPage
    {
        public bool             IsLoading       {get; protected set;}
        public IDataAnimation   DataAnimation   {get; set;}
        
        public static ICache<IPage> Cache {get; } = new Cache<IPage>();


        public abstract void Register();

        public void Animate(bool animate)
        {
            if(DataAnimation.Animator == null)
                DataAnimation.Animator = ObjectOnScene.AddComponent<Animator>();
            
            if(!ActivateObject(animate))
                return;
            
            if(DataAnimation.UseAnimation)
            {
                StopCoroutine(AwaitAnimation(animate));
                StartCoroutine(AwaitAnimation(animate));
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
            DataAnimation.CurrentState = on ? AnimationState.On : AnimationState.Off;

            while (DataAnimation.Animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationState.On.ToString()))
               yield return null;

            while (DataAnimation.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
               yield return null; 

            DataAnimation.CurrentState = AnimationState.None;
            Log("[ " + Name +" ] finised transition to " + (on ? "On" : "Off") + "snimation state");      
        }

        public void SetPageToCache(IPage page)
        {
            Cache.Add(page);
            Log("[ " + Name + " ] was set to cache.");

        }
        
        public static IPage GetPageByType(Type type)
        {
            IPage page = Cache.Get(type);

            if(page == null)
            {
                LogWarning(page.GetType() + " not found.");
                return null;
            }
            else
            {
                Log(page.GetType() + " got from cache.");
                return page;
                
            }
        }

        public IPage[] GetPagesFromCache()
        {
            var pages = new IPage[Cache.Storage.Count];
            Cache.Storage.Values.CopyTo(pages, 0);
            
            return pages;

        }


        protected static void Log(string message)
        {
            Debug.Log("[Page]: " + message);

        }

        protected static void LogWarning(string message)
        {
            Debug.LogWarning("[Page]: " + message);
            
        }
    
    
    }

}
