using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Framework.Core
{
    public interface IControlScene: IControl
    {

        HashSet<IScene> Scenes {get; }
        
        void SetScenes(IFactoryScene factory);
        void SetScenes(HashSet<IScene> scenes);
        
        void OnSceneEnter(IScene scene);
        void OnSceneExit(IScene scene);

    } 
    
    [Serializable]
    public abstract class ControlScene: Control, IControlScene
    {
        [SerializeField]
        private int activeScene;
        
        
        private HashSet<IScene> scenes;
        
        public HashSet<IScene> Scenes {get => scenes; private set => scenes = value; }
        
        
        
        public void SetScenes(IFactoryScene factory)
        {
            Scenes = factory.GetScenes();

        }
        
        public void SetScenes(HashSet<IScene> scenes)
        {
            Scenes = scenes;

        }
        
        
        public abstract void OnSceneEnter(IScene scene);
        public abstract void OnSceneExit(IScene scene);
    
    
    
    
    
    
    
    
    }

}
