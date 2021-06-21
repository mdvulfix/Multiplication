using System;
using System.Collections;
using UnityEngine;
using Core.Data.Scene;

namespace Core.Scene.Page
{   
    public interface IPage
    {   
        IDataAnimation  Animation   {get; set;}
        
        IPage Activate(bool active);
    }


    [Serializable, RequireComponent(typeof(Animator)), RequireComponent(typeof(CanvasGroup))]
    public abstract class APage: ASceneObject, IPage
    {       
        
        //public static readonly string PARENT_OBJECT_NAME = ABuilder.OBJECT_NAME_UI;

        public static readonly string ANIMATOR_STATE_NONE = "None";
        public static readonly string ANIMATOR_STATE_ON = "On";
        public static readonly string ANIMATOR_STATE_OFF = "Off";
            
        public IDataAnimation Animation   { get; set; }

        [SerializeField]
        private bool m_IsDebug;


        public abstract void Init();


        public IPage Activate(bool activate)
        {
            
            if(Animation.UseAnimation)
            {
                if(activate)
                {
                    
                    //Stats.IsActive = SetActvie(true);
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
                //Stats.IsActive = SetActvie(activate);
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


            //if(!Stats.IsActive)
            //{
            //    LogWarning(Label, "Page is not active!");
            //    return;
            //}

            
    
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
                //Stats.IsActive = SetActvie(false);
                Log(Label, " was diactivated.");
                
            }
        }

#region Logs

        public virtual void Log(string instance, string message)
        {
            if(m_IsDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
                
        }

        public virtual void LogWarning(string instance, string message)
        {
            if(m_IsDebug)
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
