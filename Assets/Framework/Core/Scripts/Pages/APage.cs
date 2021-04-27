using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core.Handlers;

namespace Framework.Core
{   
    public interface IPage: ISceneObject, IConfigurable, IDebug
    {   
        IDataAnimation  Animation   {get; set;}
        
        IPage Activate(bool active);
    }


    [Serializable, RequireComponent(typeof(Animator)), RequireComponent(typeof(CanvasGroup))]
    public abstract class APage : ASceneObject, IPage
    {       
        
        public static readonly string PARENT_OBJECT_NAME = ABuilder.OBJECT_NAME_UI;

        public static readonly string ANIMATOR_STATE_NONE = "None";
        public static readonly string ANIMATOR_STATE_ON = "On";
        public static readonly string ANIMATOR_STATE_OFF = "Off";
            
        public bool                     UseDebug        {get; set;} = false;
        public IDataStats               Stats       {get => dataStats;      set => dataStats = value as DataStats;}
        public IDataAnimation           Animation   {get => dataAnimation;  set => dataAnimation = value as DataAnimation;}
        
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
            
            if(Animation.UseAnimation)
            {
                if(activate)
                {
                    
                    Stats.IsActive = SetActvie(true);
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
                Stats.IsActive = SetActvie(activate);
            }
                
            return this;
        }
         
        private void Animate (bool animate)
        {
            
            if(Animation.Animator == null)
            {
                LogWarning(Label, "Animator is not set!");
                return;
            }


            if(!Stats.IsActive)
            {
                LogWarning(Label, "Page is not active!");
                return;
            }

            
    
            StopCoroutine("AwaitAnimation");
            StartCoroutine(AwaitAnimation(animate));

        }
          
        private IEnumerator AwaitAnimation (bool animate)
        {

            Animation.Animator.SetBool("On", animate);

            Animation.TargetState = animate ? ANIMATOR_STATE_ON : ANIMATOR_STATE_OFF;
            Log(Label, "Target state is ["  + Animation.TargetState + "].");
            
            //waiting for target state
            while(!Animation.Animator.GetCurrentAnimatorStateInfo(0).IsName(Animation.TargetState))
            {
                yield return null;

            }
        
            //waiting for target state is plaing
            while(Animation.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                yield return null;

            }

            Animation.TargetState = ANIMATOR_STATE_NONE;
        
            Log(Label, "Target state is ["  + Animation.TargetState + "].");
            Log(Label, "was finised transition to " + (animate ? "On" : "Off") + " animation state!"); 
    
    
            if(!animate)
            {
                Stats.IsActive = SetActvie(false);
                Log(Label, " was diactivated.");
                
            }
        }

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
