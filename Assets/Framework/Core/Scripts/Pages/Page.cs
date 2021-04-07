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
        void Activate(bool active);
    }
    public abstract class Page : SceneObject, IPage
    {
        public bool             IsLoading       {get; protected set;}
        public IDataAnimation   DataAnimation   {get; set;}
        
        public abstract void Register();
        public abstract void Activate(bool active);

    }


    [Serializable]
    public abstract class Page<T> : Page where T: Page
    {
        
        public static ICache<T> Cache {get; } = new Cache<T>();

        public override void Activate(bool active)
        {
            
            //DataAnimation.Animator = ObjectOnScene.GetComponent<Animator>();
            //if(DataAnimation.Animator == null)
            //    DataAnimation.Animator = ObjectOnScene.AddComponent<Animator>();
                
            
            if(!ActivateObject(active))
                return;
            /*
            if(DataAnimation.UseAnimation)
            {
                StopCoroutine(AwaitAnimation(active));
                StartCoroutine(AwaitAnimation(active));
                Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
            {
                Log("Animation is disabled on page [ " + Name + " ]");
            }
            */
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

        public void SetToCache(T page)
        {
            Cache.Add(page);
            Log("[ " + Name + " ] was set to cache.");

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
