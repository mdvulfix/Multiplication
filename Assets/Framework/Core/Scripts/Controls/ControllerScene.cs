using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Framework.Core
{
    public interface IControllerScene: IController, IHasCache<IScene>
    {

        IScene SceneActive {get; }
    
        void OnSceneEnter(IScene scene);
        void OnSceneExit(IScene scene);

    } 
    
    [Serializable]
    public abstract class ControllerScene: Controller, IControllerScene
    {
        protected static readonly string OBJECT_NAME = "Controller: Scene";
        
        public ICache<IScene>    Cache        {get; protected set;} = new Cache<IScene>();
        public IScene            SceneActive  {get => sceneActive; set => sceneActive = value; }       

        private IScene sceneActive;
        
        

#region RegisterToCache

        public IScene SetToCache(IScene instance)
        {
            Cache.Add(instance as IScene);
            return instance;
        }

        public void SetToCache(List<IScene> instances)
        {
            foreach (var instance in instances)
            {
                SetToCache(instance);
            }
        }

#endregion



#region SceneManagement
            
        public abstract void OnSceneEnter(IScene scene);
        public abstract void OnSceneExit(IScene scene);

#endregion
    
    
    }

}
