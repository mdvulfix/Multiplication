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
        bool            UseAnimation    {get; }
        Animator        Animator        {get; }
        AnimationState  CurrentState    {get; }
        AnimationState  TargetState     {get; } 
    }
    
    [Serializable]
    public class DataAnimation : AData, IDataAnimation
    {      
        
        public static readonly string OBJECT_NAME = "Data: Animation";
        
        public bool           UseAnimation  {get => useAnimation;   private set => useAnimation = value;}
        public Animator       Animator      {get => animator;       private set => animator = value;}
        public AnimationState CurrentState  {get => currentState;   private set => currentState = value;}
        public AnimationState TargetState   {get => targetState;    private set => targetState = value;}

        [SerializeField] private bool           useAnimation;
        [SerializeField] private Animator       animator;
        [SerializeField] private AnimationState currentState;
        [SerializeField] private AnimationState targetState;
        
        public DataAnimation()
        {


        }

    
    
    
    
    }


}
