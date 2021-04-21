using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Framework.Core
{
    
    public enum TypeScene
    {
        Core,
        Menu,
        RunTime,
        Score
    
    }
    
    
    public interface IControllerScene: IController<IScene>
    {
        IScene SceneActive {get; set;}
        
        void SceneTurn<TSceneNext>(bool waitForSceneExit = false) 
            where TSceneNext: class, IScene;
        
        void SceneTurn(Type sceneType, bool waitForSceneExit = false);   

    } 
    
    [Serializable]
    public abstract class AControllerScene: AController<IScene>, IControllerScene
    {
        public IScene SceneActive  {get => sceneActive; set => sceneActive = value; }       

        private IScene sceneActive;
        
#region Start&Update

        public abstract void OnAwake();

#endregion

#region SceneManagement
    
        public void SceneTurn<TSceneNext>(bool waitForSceneExit = false) where TSceneNext: class, IScene
        {
            SceneTurn(typeof(TSceneNext), waitForSceneExit);
        }
       
        public void SceneTurn(Type sceneType, bool waitForSceneExit = false)
        {
            var sceneNext = Cache.Get(sceneType);
            var sceneNextType = sceneNext.GetType();
            
            if(sceneActive == null)
            {
                LogWarning(Label, "You are trying to turn a scene [" + sceneActive.Label + "] that has not been registered!");
                return;
            }
    
            if(sceneActive.DataStats.IsActive)
            {
                //sceneActive.Activate(false);
                Log(Label, "[" + sceneActive.Label + "] was deactivated!");

            }
                

            if(waitForSceneExit)
            {
                StopCoroutine("WaitForSceneExit");
                StartCoroutine(WaitForSceneExit(sceneNextType));
                //Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
                SceneGetNext(sceneNextType);
        }
               
        public void SceneGetNext<TSceneNext>() where TSceneNext: class, IScene
        {
            SceneGetNext(typeof(TSceneNext));
        }  
    
        public void SceneGetNext(Type sceneType)
        {
            var sceneNext = Cache.Get(sceneType);
            
            if(sceneNext==null)
            {
                LogWarning(Label, "You are trying to turn a page on [" + sceneNext.Label + "] that has not been registered!");
                return;
            }
    
            //sceneActive = sceneNext.Activate(true);
            Log(Label, "[" + sceneActive.Label + "] was activated!");
        }
              
        protected IEnumerator WaitForSceneExit(Type sceneType)
        {
            Log(Label, "Waiting for exit [" + sceneActive.Label + "]...");
            /*
            while (sceneActive.DataAnimation.TargetState != AScene.ANIMATOR_STATE_NONE)
            {
                yield return null;
            }
            */
            yield return null;
            SceneGetNext(sceneType);
        }
       
#endregion
    
    }

}
