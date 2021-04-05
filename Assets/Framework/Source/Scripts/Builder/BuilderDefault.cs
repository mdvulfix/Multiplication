using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [Serializable]
    public class BuilderDefault : Builder
    {
       
        private readonly string BUILDER_NAME = "Builder";

        [Header("Factories: Session")]
        [SerializeField] FactorySessions factorySessions; 
        
        [Header("Factories: Controls")]
        [SerializeField] FactoryControlState    factoryControlState;
        [SerializeField] FactoryControlCamera   factoryControlCamera;
        [SerializeField] FactoryControlScene    factoryControlScene;
        [SerializeField] FactoryControlPage     factoryControlPage;              
        
        public override void OnAwake()
        {
            Initialize(BUILDER_NAME);
            SetSession();
            SetControls();
            Configure();
        
        }
        
        private void SetSession()
        {          
            Sessions.Add(typeof(SessionMainDefault), AddSession<SessionMainDefault>(factorySessions));

        }
        
        private void SetControls()
        {          
            Controls.Add(typeof(ControlStateDefault), AddControl<ControlStateDefault>(factoryControlState));
            Controls.Add(typeof(ControlCameraDefault), AddControl<ControlCameraDefault>(factoryControlCamera));
            Controls.Add(typeof(ControlSceneDefault), AddControl<ControlSceneDefault>(factoryControlScene));
            Controls.Add(typeof(ControlPageDefault), AddControl<ControlPageDefault>(factoryControlPage));
        }



        public override void Configure()
        {          
            foreach (var session in Sessions.Values)
            {
                session.Configure();
            }
            
            foreach (var control in Controls.Values)
            {
                control.Configure();
            }

        }


        private T AddSession<T>(IFactorySession factory) where T: SceneObject, ISession
        {
            return factory.Get<T>();
        }
    
        private T AddControl<T>(IFactoryControl factory) where T: SceneObject, IControl
        {
            return factory.Get<T>();
        }
    
    
    }
}