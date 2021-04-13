using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Framework.Core
{
    public interface IControllerScene: IController<IScene>
    {

        IScene SceneActive {get; }
    
        void OnSceneEnter(IScene scene);
        void OnSceneExit(IScene scene);

    } 
    
    [Serializable]
    public abstract class AControllerScene: AController<IScene>, IControllerScene
    {
        public IScene            SceneActive  {get => sceneActive; set => sceneActive = value; }       

        private IScene sceneActive;
        

#region SceneManagement
            
        public abstract void OnSceneEnter(IScene scene);
        public abstract void OnSceneExit(IScene scene);

#endregion
    
    
    }

}
