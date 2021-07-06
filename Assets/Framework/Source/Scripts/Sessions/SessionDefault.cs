using System;
using System.Collections.Generic;
using Core;
using Core.Scene;
using Core.State;
using Source.Scene;
using Source.State;

namespace Source 
{
    [Serializable]
    public class SessionDefault : ASession
    {
        protected override void OnAwake()
        {
            var sceneController = new SceneControllerDefault();
            var stateFactory = new StateFactoryDefault();
            
            var stateInitializationParams = 
                new StateInitializationParams(
                    this, 
                    sceneController
                );

            var stateControllerParametrs = 
                new StateControllerInitializationParams(
                    this, 
                    sceneController, 
                    stateFactory, 
                    stateInitializationParams
                );

            var stateController = 
                new StateControllerDefault(
                    stateControllerParametrs
                );


            var sessionParametrs = 
                new SessionInitializationParams(
                    stateController, 
                    sceneController
                );
            
            Initialize(sessionParametrs);
            
            SetState<StateInitialize>();


        }
        

        protected override void OnStart()
        {
            //Load();
        }

    }

    public struct SessionInitializationParams: ISessionInitializationParams
    { 
        public IStateController StateController { get; private set; }       
        public ISceneController SceneController { get; private set; }
        

        public SessionInitializationParams(IStateController stateController, ISceneController sceneController)
        {
            StateController = stateController;
            SceneController = sceneController;
        }

    }

}