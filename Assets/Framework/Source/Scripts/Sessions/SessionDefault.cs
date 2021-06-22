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
            var sceneIndexes = new Dictionary<Type, SceneIndex>(4);
            sceneIndexes.Add(typeof(SceneCore), SceneIndex.Core);
            sceneIndexes.Add(typeof(SceneMenu), SceneIndex.Menu);
            sceneIndexes.Add(typeof(SceneRunTime), SceneIndex.RunTime);
            sceneIndexes.Add(typeof(SceneScore), SceneIndex.Score);

            var sceneControllerParams = new SceneControllerInitializationParams(sceneIndexes);
            var sceneController = new SceneControllerDefault(sceneControllerParams);
            
            var stateControllerParams = new StateControllerInitializationParams(this, sceneController);
            var stateController = new StateControllerDefault(stateControllerParams);


            var sessionParams = new SessionInitializationParams(stateController, sceneController);
            
            Initialize(sessionParams);
            
            SetState<StateInitialize>();


        }
        

        protected override void OnStart()
        {
            Load();
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