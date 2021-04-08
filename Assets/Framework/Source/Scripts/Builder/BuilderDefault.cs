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



        public override void Configure()
        {          
            foreach (var session in Sessions.Values)
            {
                session.Initialize();
            }
            
            foreach (var control in Controls.Values)
            {
                control.Initialize();
            }

        }


        private T AddSession<T>(IFactorySession factory) where T: SceneObject, ISession
        {
            return factory.GetSession() as T;
        }
    
        private T AddControl<T>(IFactoryController factory) where T: SceneObject, IController
        {
            return factory.GetControl() as T;
        }
    
    
    }
}