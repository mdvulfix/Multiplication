using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core.Handlers;

namespace Framework.Core
{   
    public interface IPage: ISceneObject, IConfigurable, IDebug, IHaveCache<IPageDataStruct>
    {   
        IDataStats      DataStats       {get; set;}
        IDataAnimation  DataAnimation   {get; set;}
        
        IPage Activate(bool active);
    }


    [Serializable, RequireComponent(typeof(Animator)), RequireComponent(typeof(CanvasGroup))]
    public abstract class APage : ASceneObject, IPage
    {       
        
        public static readonly string PARENT_OBJECT_NAME = ABuilder.OBJECT_NAME_UI;

        public static readonly string ANIMATOR_STATE_NONE = "None";
        public static readonly string ANIMATOR_STATE_ON = "On";
        public static readonly string ANIMATOR_STATE_OFF = "Off";
        
        public ICache<IPageDataStruct>  Cache           {get; protected set;} = new Cache<IPageDataStruct>("Page: Cache"); 
        
        public bool                     UseDebug        {get; set;} = false;
        public IDataStats               DataStats       {get => dataStats;      set => dataStats = value as DataStats;}
        public IDataAnimation           DataAnimation   {get => dataAnimation;  set => dataAnimation = value as DataAnimation;}
        
        [SerializeField] 
        protected bool isProject;

        [Header("Data")]
        [SerializeField] protected DataStats      dataStats;
        [SerializeField] protected DataAnimation  dataAnimation;
        


 #region Configure
        
        protected virtual void SetParams(string label)
        {
            Label = label;
        }
        
        public abstract void Initialize();
        public abstract IConfigurable Configure();

#endregion

        public IPage Activate(bool activate)
        {
            
            if(DataAnimation.UseAnimation)
            {
                if(activate)
                {
                    
                    DataStats.IsActive = SetActvie(true);
                    Log(Label, " was activated.");
                    Animate(true);
                }
                else
                {
                    Animate(false);
                }
            }
            else
            {
                Log(Label, "Animation is disabled on page [ " + Label + " ]");
                DataStats.IsActive = SetActvie(activate);
            }
                
            return this;
        }
         
        private void Animate (bool animate)
        {
            
            if(DataAnimation.Animator == null)
            {
                LogWarning(Label, "Animator is not set!");
                return;
            }


            if(!DataStats.IsActive)
            {
                LogWarning(Label, "Page is not active!");
                return;
            }

            
    
            StopCoroutine("AwaitAnimation");
            StartCoroutine(AwaitAnimation(animate));

        }
          
        private IEnumerator AwaitAnimation (bool animate)
        {

            DataAnimation.Animator.SetBool("On", animate);

            DataAnimation.TargetState = animate ? ANIMATOR_STATE_ON : ANIMATOR_STATE_OFF;
            Log(Label, "Target state is ["  + DataAnimation.TargetState + "].");
            
            //waiting for target state
            while(!DataAnimation.Animator.GetCurrentAnimatorStateInfo(0).IsName(DataAnimation.TargetState))
            {
                yield return null;

            }
        
            //waiting for target state is plaing
            while(DataAnimation.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                yield return null;

            }

            DataAnimation.TargetState = ANIMATOR_STATE_NONE;
        
            Log(Label, "Target state is ["  + DataAnimation.TargetState + "].");
            Log(Label, "was finised transition to " + (animate ? "On" : "Off") + " animation state!"); 
    
    
            if(!animate)
            {
                DataStats.IsActive = SetActvie(false);
                Log(Label, " was diactivated.");
                
            }
        }
        

#region Cache

        public IPageDataStruct SetToCache(IPageDataStruct instance)
        {
            Cache.Add(instance);
            return instance;
        }

        public List<IPageDataStruct> SetToCache(List<IPageDataStruct> instances)
        {
            foreach (var instance in instances)
            {
                SetToCache(instance);
            }
            return instances;
        }

#endregion 

#region Logs

        public virtual void Log(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
                
        }

        public virtual void LogWarning(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.LogWarning("["+ instance +"]: " + message);
            }
        }

        protected string LogSuccessfulInitialize()
        {
            return "Initialization process was successfully finished!";
        }

        protected string LogSuccessfulConfigure()
        {
            return "Configuration process was successfully finished!";
        }
        
        protected string LogFailedInitialize(string reason = null)
        {
            return "Initialization process was failed! " + reason;
        }

        protected string LogFailedConfigure(string reason = null)
        {
            return "Configuration process was failed! " + reason;
        }

#endregion
    }





}
