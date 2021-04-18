using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public interface IDataAnimation: IData
    {
        bool        UseAnimation    {get; set;}
        string      CurrentState    {get; set;}
        string      TargetState     {get; set;} 

        Animator    Animator        {get; set;}
    }

    [Serializable]
    public class DataAnimation : AData, IDataAnimation
    {      
        
        public static readonly string OBJECT_NAME = "Data: Animation";
        
        public bool     UseAnimation  {get => useAnimation;   set => useAnimation = value;}
        public string   CurrentState  {get => currentState;   set => currentState = value;}
        public string   TargetState   {get => targetState;    set => targetState = value;}

        public Animator Animator      {get => animator;       set => animator = value;}


        [SerializeField] private bool       useAnimation;
        [SerializeField] private string     currentState;
        [SerializeField] private string     targetState;
        
        [SerializeField] private Animator   animator;
        
        
        
        
        public DataAnimation()
        {


        }

    
    
    
    
    }


}
