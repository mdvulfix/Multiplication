using System;
using System.Collections;
using UnityEngine;

namespace Framework.Core
{
    public interface IPage: ISceneObject, ICacheable
    {
        bool            IsLoading       {get; }
        IDataAnimation  DataAnimation   {get; set;}
        
        void Initialize();
        void Activate(bool active);
    }

    [Serializable]
    public abstract class Page : SceneObject, IPage
    {
        public bool             IsLoading       {get; protected set;}
        public IDataAnimation   DataAnimation   {get; set;}
        
        public abstract void Initialize();

        public void Activate(bool active)
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
            Log(Name, "was finised transition to " + (on ? "On" : "Off") + "snimation state");      
        }
 




#region LogFunctions

        public virtual void Log(string page, string message)
        {
            Debug.Log("["+ page +"]: " + message);
        }

        public virtual void LogWarning(string page, string message)
        {
            Debug.LogWarning("["+ page +"]: " + message);
        }

#endregion
    }

}
