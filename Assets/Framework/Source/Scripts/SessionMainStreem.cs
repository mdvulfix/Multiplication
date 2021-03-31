using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core 
{
    
    [Serializable]
    public class SessionMainStreem : Session
    {
        
        [Header("Controls")]
        [SerializeField] 
        private ControlPage controlPage;
        
        //public ControlUpdate    ControlUpdate   {get => this.controlUpdate; set => this.controlUpdate = value;}
        public ControlPage ControlPage     {get => this.controlPage; set => this.controlPage = value;}
        //public ControlScene     ControlScene    {get => this.controlScene;  set => this.ControlScene = value;}
        //public ControlInput     ControlInput    {get => this.controlInput;  set => this.controlInput = value;}
       // public ControlCamera    ControlCamera   {get => this.controlCamera; set => this.controlCamera = value;}
              
        
        
        public override void OnAwake() 
        {
            ControlPage.Initialize();
            
        
        }
    }
}