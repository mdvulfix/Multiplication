using UnityEngine;
using UnityEngine.SceneManagement;
using Core;
using Core.Scene;
using System.Collections.Generic;
using System;

namespace Source.Scene
{
    public class SceneControllerDefault: ASceneController
    {  
        
        public SceneControllerDefault()
        {
            var sceneIndexes = new Dictionary<Type, SceneIndex>(4);
            sceneIndexes.Add(typeof(SceneCore), SceneIndex.Core);
            sceneIndexes.Add(typeof(SceneMenu), SceneIndex.Menu);
            sceneIndexes.Add(typeof(SceneRunTime), SceneIndex.RunTime);
            sceneIndexes.Add(typeof(SceneScore), SceneIndex.Score);

            var parametrs = new SceneControllerInitializationParams(sceneIndexes);
            
            Initialize(parametrs);
        }
        
        
        public SceneControllerDefault(ISceneControllerInitializationParams parametrs)
        {
            Initialize(parametrs);
        }
        
    }
    
    public struct SceneControllerInitializationParams: ISceneControllerInitializationParams
    { 
        public Dictionary<Type, SceneIndex> SceneIndexes { get; private set; }

        public SceneControllerInitializationParams(Dictionary<Type, SceneIndex> sceneIndexes)
        {
            SceneIndexes = sceneIndexes;
        }

    }

    public struct SceneInitializationParams: ISceneInitializationParams
    { 
        public ISceneController SceneController { get; private set; }
    
        public SceneInitializationParams(ISceneController sceneController)
        {
            SceneController = sceneController;
        }

    }

}
