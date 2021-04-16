using System;
using System.Collections;
using UnityEngine;
using Framework.Core.Handlers;

namespace Framework.Core
{
    
    public interface IPageDataStruct: IDataStruct<IPage>
    {
        IDataStats DataStats    {get; }
        IDataAnimation DataAnimation {get; }
        
    
        void SetData(IDataStats dataStats, IDataAnimation dataAnimation);
    
    }
    
    
    
    public interface IPage: IPageDataStruct, ISceneObject, IConfigurable, ICacheable, IDebug 
    {   
        IPage Activate(bool active);
    }

    [Serializable, RequireComponent(typeof(Animator))]
    public abstract class APage : ASceneObject, IPage
    {       
        
        public static readonly string PARENT_OBJECT_NAME = ABuilder.OBJECT_NAME_UI; 
        
        public bool             UseDebug        {get; set;} = true;
        public IDataStats       DataStats       {get => dataStats;      set => dataStats = value as DataStats;}
        public IDataAnimation   DataAnimation   {get => dataAnimation;  set => dataAnimation = value as DataAnimation;}
        
        [Header("Data")]
        [SerializeField] private DataStats      dataStats;
        [SerializeField] private DataAnimation  dataAnimation;
        
    
        public abstract void SetData(IDataStruct<IPage> datasSruct);
        public abstract void SetData(IDataStats dataStats, IDataAnimation dataAnimation);

#region Configure

        public abstract void Initialize();
        public abstract IConfigurable Configure();

#endregion

        public IPage Activate(bool active)
        {
            
            /*
            if(DataAnimation.Animator == null)
            {
                LogWarning(Label, "Animator is not set!");
                return null;

            }
            */
            if(!ActivateObject(active))
                return null;
            else
                return this;
            /*
            if(DataAnimation.UseAnimation)
            {
                StopCoroutine(AwaitAnimation(active));
                StartCoroutine(AwaitAnimation(active));
                
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
            Log(Label, "was finised transition to " + (on ? "On" : "Off") + "snimation state");      
        }
        




#region Log

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

#endregion
    }





}
