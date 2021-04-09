using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [Serializable]
    public class BuilderDefault : Builder
    {
        [Header("Factories: Session")]
        [SerializeField] FactorySession         factorySessions; 
        
        [Header("Factories: Controls")]
        [SerializeField] FactoryControllerState    factoryControlState;
        [SerializeField] FactoryControllerCamera   factoryControlCamera;
        [SerializeField] FactoryControllerScene    factoryControlScene;
        [SerializeField] FactoryControllerPage     factoryControlPage;              
        //[SerializeField] FactoryControlInput factoryControlInput;
        public override void OnAwake()
        {
            SetSceneObject(SCENEOBJECT_NAME);
            SetSession();
            SetControls();
            Configure();
        
        }
        
        private void SetSession()
        {          
            Sessions.Add(typeof(SessionMain), AddSession<SessionMain>(factorySessions));

        }
        
        private void SetControls()
        {          
            Controls.Add(typeof(ControllerStateDefault), AddControl<ControllerStateDefault>(factoryControlState));
            Controls.Add(typeof(ControllerCameraDefault), AddControl<ControllerCameraDefault>(factoryControlCamera));
            Controls.Add(typeof(ControllerSceneDefault), AddControl<ControllerSceneDefault>(factoryControlScene));
            Controls.Add(typeof(ControllerPageDefault), AddControl<ControllerPageDefault>(factoryControlPage));
            //Controls.Add(typeof(ControlInputDefault), AddControl<ControlInputDefault>(factoryControlInput));
        }



        protected static readonly string OBJECT_NAME_BUILDER = "Builder";
        protected static readonly string OBJECT_NAME_CONTROLLERS = "Controllers";
        protected static readonly string OBJECT_NAME_SESSIONS = "Sessions";
        protected static readonly string OBJECT_NAME_SCENE = "Scene";
        protected static readonly string OBJECT_NAME_UI = "UI";
        
        
        
        
        
        
        
        public override void Configure()
        {          
            foreach (var instance in Cache.Store.Values)
            {
                instance.Configure();
            }            
        }


        private T Add<T>(IFactory factory) where T: SceneObject, ICacheable
        {
            return factory.GetInstanceOf<T>() as T;
        }
    
    }
}