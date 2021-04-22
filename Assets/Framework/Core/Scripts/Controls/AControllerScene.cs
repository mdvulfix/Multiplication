using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Framework.Core
{
    public enum ESceneBuildId
    {
        Core,
        Menu,
        RunTime,
        Score
    
    }
    
    public interface IControllerScene: IController<IScene>
    {
        IScene SceneActive {get; }
        
        void SceneTurn<TSceneNext>(bool waitForSceneExit = false) 
            where TSceneNext: class, IScene;
        
        void SceneTurn(Type sceneType, bool waitForSceneExit = false);   

    } 
    
    [Serializable]
    public abstract class AControllerScene: AController<IScene>, IControllerScene
    {
        public IScene           SceneActive     {get; private set;}       
        public IControllerPage  ControllerPage  {get; protected set;}   
       
#region Start&Update

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
            
            if(SceneActive == null)
            {
                LogWarning(Label, "You are trying to turn a scene [" + SceneActive.Label + "] that has not been registered!");
                return;
            }
    
            if(SceneActive.DataStats.IsActive)
            {
                //sceneActive.Activate(false);
                Log(Label, "[" + SceneActive.Label + "] was deactivated!");

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
            Log(Label, "[" + SceneActive.Label + "] was activated!");
        }
              
        private IEnumerator WaitForSceneExit(Type sceneType)
        {
            Log(Label, "Waiting for exit [" + SceneActive.Label + "]...");
            /*
            while (sceneActive.DataAnimation.TargetState != AScene.ANIMATOR_STATE_NONE)
            {
                yield return null;
            }
            */
            yield return null;
            SceneGetNext(sceneType);
        }

        protected void SceneSetActive<T>() where T: class, IScene
        {
            SceneActive = Cache.Get<T>();
            SceneActive.Activate(true);
            Log(Label, "Scene [" + SceneActive.Label + "] was activated.");
        }


#endregion
    
    }

}
