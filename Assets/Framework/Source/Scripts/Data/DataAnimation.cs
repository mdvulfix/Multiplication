using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public enum AnimationState
    {
        None,
        On,
        Off
    }
    
    public interface IDataAnimation: IData
    {
        bool            UseAnimation    {get; set;}
        Animator        Animator        {get; set;}
        AnimationState  CurrentState    {get; set;}
        AnimationState  TargetState     {get; set;} 
    }
    
    [Serializable]
    public class DataAnimation : AData, IDataAnimation
    {      
        
        public static readonly string OBJECT_NAME = "Data: Animation";
        
        public bool           UseAnimation  {get => useAnimation;   set => useAnimation = value;}
        public Animator       Animator      {get => animator;       set => animator = value;}
        public AnimationState CurrentState  {get => currentState;   set => currentState = value;}
        public AnimationState TargetState   {get => targetState;    set => targetState = value;}

        [SerializeField] private bool           useAnimation;
        [SerializeField] private Animator       animator;
        [SerializeField] private AnimationState currentState;
        [SerializeField] private AnimationState targetState;
        
        public DataAnimation()
        {


        }

    
    
    
    
    }


}
