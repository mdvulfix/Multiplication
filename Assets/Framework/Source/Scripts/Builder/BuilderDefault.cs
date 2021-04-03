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
                
        private HashSet<IControl> controls = new HashSet<IControl>();
        private HashSet<ISession> sessions = new HashSet<ISession>();
                
        
        public override void OnAwake()
        {
            Initialize(BUILDER_NAME);
            SetSession();
            SetControls();
            Configure();
        
        }
    
        public override HashSet<IControl> GetControls()
        {
            return controls;

        }

        public override HashSet<ISession> GetSessions()
        {
            return sessions;

        }

        
        
        private void SetSession()
        {          
            sessions.Add(GetSession<SessionMainDefault>(factorySessions));

        }
        
        private void SetControls()
        {          
            controls.Add(GetControl<ControlStateDefault>(factoryControlState));
            controls.Add(GetControl<ControlCameraDefault>(factoryControlCamera));
            controls.Add(GetControl<ControlSceneDefault>(factoryControlScene));
            controls.Add(GetControl<ControlPageDefault>(factoryControlPage));
        }



        public override void Configure()
        {          
            foreach (var session in sessions)
            {
                session.Configure();
            }
            
            foreach (var control in controls)
            {
                control.Configure();
            }

        }


        private T GetSession<T>(IFactorySession factory) where T: SceneObject, ISession
        {
            return factory.Get<T>();
        }
    
        private T GetControl<T>(IFactoryControl factory) where T: SceneObject, IControl
        {
            return factory.Get<T>();
        }
    
    
    }
}