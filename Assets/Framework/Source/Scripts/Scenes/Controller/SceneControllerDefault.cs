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
}
