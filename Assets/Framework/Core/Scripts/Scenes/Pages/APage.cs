using System;
using System.Collections;
using UnityEngine;
using Core.Data.Scene;

namespace Core.Scene.Page
{   
    public interface IPage
    {   
        //IDataAnimation  Animation   {get; set;}
        
        void Activate(bool active);
    }


    [Serializable, RequireComponent(typeof(Animator)), RequireComponent(typeof(CanvasGroup))]
    public abstract class APage: ASceneObject, IPage
    {       
        
        private readonly int PARAMS_INITIALIZATION = 0;
        //public static readonly string PARENT_OBJECT_NAME = ABuilder.OBJECT_NAME_UI;

        public static readonly string ANIMATOR_STATE_NONE = "None";
        public static readonly string ANIMATOR_STATE_ON = "On";
        public static readonly string ANIMATOR_STATE_OFF = "Off";

        private IDataAnimation m_DataAnimation;

        [SerializeField]
        private bool m_IsDebug;


        private void Awake()
        {
            OnAwake();

        }

        private void Start()
        {

            OnStart();
        }

        protected virtual void OnAwake()
        {

        }

        protected virtual void OnStart()
        {

        }

        protected virtual void Initialize(params object[] args)
        {
            //m_Pages = new Cache<IPage>();

            var parametrs = (IPageInitializationParams)args[PARAMS_INITIALIZATION];
            m_DataAnimation = parametrs.DataAnimation;

            Debug.Log("Page was initialized!");

        }


        public void Activate(bool active)
        {
            SetActvie(active);
            
            if(m_DataAnimation.UseAnimation)
                Animate(true);
            else
                Animate(false);
        }


        private void Animate (bool animate)
        {
            
            if(m_DataAnimation.Animator == null)
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

            m_DataAnimation.Animator.SetBool("On", animate);

            m_DataAnimation.TargetState = animate ? ANIMATOR_STATE_ON : ANIMATOR_STATE_OFF;
            Log(Label, "Target state is ["  + m_DataAnimation.TargetState + "].");
            
            //waiting for target state
            while(!m_DataAnimation.Animator.GetCurrentAnimatorStateInfo(0).IsName(m_DataAnimation.TargetState))
            {
                yield return null;

            }
        
            //waiting for target state is plaing
            while(m_DataAnimation.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                yield return null;

            }

            m_DataAnimation.TargetState = ANIMATOR_STATE_NONE;
        
            Log(Label, "Target state is ["  + m_DataAnimation.TargetState + "].");
            Log(Label, "was finised transition to " + (animate ? "On" : "Off") + " animation state!"); 
    

            if(!animate)
            {
                SetActvie(false);
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

    public interface IPageInitializationParams
    { 
        
        IDataAnimation DataAnimation { get; }

        //ISceneController SceneController { get; }
    }

    public struct PageInitializationParams: IPageInitializationParams
    {
        public IDataAnimation DataAnimation { get; private set; }

        public PageInitializationParams(IDataAnimation dataAnimation)
        {
            DataAnimation = dataAnimation;
        }

        


    }



}
