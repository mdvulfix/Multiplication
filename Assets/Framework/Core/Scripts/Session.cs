using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core 
{
    [Serializable]
    public class Session : MonoBehaviour
    {
        
        [Header("Controls")]
        [SerializeField] 
        private ControlUpdate   controlUpdate;
        [SerializeField] 
        private ControlScene    controlScene;
        [SerializeField] 
        private ControlInput    controlInput;
        [SerializeField] 
        private ControlCamera   controlCamera;
        
        public ControlUpdate    ControlUpdate   {get => this.controlUpdate; set => this.controlUpdate = value;}
        public ControlScene     ControlScene    {get => this.controlScene; set => this.ControlScene = value;}
        public ControlInput     ControlInput    {get => this.controlInput; set => this.controlInput = value;}
        public ControlCamera    ControlCamera   {get => this.controlCamera; set => this.controlCamera = value;}
        
        
        
        
        
        
        
        private void Awake() 
        {
            
            controlScene.OnAwake();
            controlCamera.OnAwake();


        
        }

        private void Update() 
        {
            ControlUpdate.OnUpdate();
        
        }


    
    
    }


}