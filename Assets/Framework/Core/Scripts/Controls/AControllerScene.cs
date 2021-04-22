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
        
        void SceneTurn<TScene, TPage>(bool delay = false) 
            where TScene: class, IScene
            where TPage: class, IPage;
        
        void SceneTurn(Type sceneType, Type pageType, bool delay = false);

    } 
    
    [Serializable]
    public abstract class AControllerScene: AController<IScene>, IControllerScene
    {
        public IScene           SceneActive     {get; private set;}       
        public IControllerPage  ControllerPage  {get; protected set;}   
       
#region Start&Update

#endregion

#region SceneManagement
    
        public void SceneTurn<TScene, TPage>(bool delay = false) 
            where TScene: class, IScene
            where TPage: class, IPage
        {
            SceneTurn(typeof(TScene), typeof(TPage), delay);
        }
       
        public void SceneTurn(Type sceneType, Type pageType, bool delay = false)
        {
            var sceneNext = Cache.Get(sceneType);
            var sceneNextType = sceneNext.GetType();

            var pageNext = sceneNext.Cache.Get(sceneType);
            var pageNextType = pageNext.GetType();
            
            if(SceneActive == null)
            {
                LogWarning(Label, "You are trying to turn a scene [" + SceneActive.Label + "] that has not been registered!");
                return;
            }
            
            var pageActive = SceneActive.DataSceneLoad.PageActive;
            if(pageActive == null)
            {
                LogWarning(Label, "You are trying to turn a page [" + pageActive.Label + "] that has not been registered!");
                return;
            }
            
            if(pageActive.DataStats.IsActive)
            {
                pageActive.Activate(false);
                Log(Label, "[" + pageActive.Label + "] was deactivated!");

                if(SceneActive.DataStats.IsActive && SceneActive!=sceneNext)
                {
                    SceneActive.Activate(false);
                    Log(Label, "[" + SceneActive.Label + "] was deactivated!");
                
                }
            }
            
            if(delay)
            {
                
                
                
                
                
                
                
                
                StopCoroutine("WaitForSceneExit");
                StartCoroutine(WaitForSceneExit(sceneNextType));
                //Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
                SceneGetNext(sceneNextType, pageNextType);
        }
               
        public void SceneGetNext<TScene, TPage>() 
            where TScene: class, IScene
            where TPage: class, IPage
        {
            SceneGetNext(typeof(TScene), typeof(TPage));
        }  
    
        public void SceneGetNext(Type sceneType, Type pageType)
        {
            var sceneNext = Cache.Get(sceneType);
            var pageNext = sceneNext.Cache.Get(sceneType);
            
            if(sceneNext==null)
            {
                LogWarning(Label, "You are trying to turn a page on [" + sceneNext.Label + "] that has not been registered!");
                return;
            }
    
            SceneActive = sceneNext.Activate(true);
            SceneActive.DataSceneLoad.PageActive = pageNext.Activate(true);
            
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


#region PageManagement
    
        public void PageTurn<TPage>(bool delay = false) where TPage: class, IPage
        {
            PageTurn(typeof(TPage), delay);
        }
       
        public void PageTurn(Type pageType, bool delay = false)
        {
            var pageNext = Cache.Get(pageType);
            var pageNextType = pageNext.GetType();
            
            var pageActive = SceneActive.DataSceneLoad.PageActive;
            
            if(pageActive == null)
            {
                LogWarning(Label, "You are trying to turn a page [" + pageActive.Label + "] that has not been registered!");
                return;
            }
    
            if(pageActive.DataStats.IsActive)
            {
                pageActive.Activate(false);
                Log(Label, "[" + pageActive.Label + "] was deactivated!");

            }
                

            if(delay)
            {
                StopCoroutine("WaitForPageExit");
                StartCoroutine(WaitForPageExit(pageNextType));
                //Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
                PageGetNext(pageNextType);
        }
               
        public void PageGetNext<TPageNext>() where TPageNext: class, IPage
        {
            PageGetNext(typeof(TPageNext));
        }  
    
        public void PageGetNext(Type pageType)
        {
            var pageActive = SceneActive.DataSceneLoad.PageActive; 
            var pageNext = Cache.Get(pageType);
            
            if(pageNext==null)
            {
                LogWarning(Label, "You are trying to turn a page on [" + pageNext.Label + "] that has not been registered!");
                return;
            }
    
            pageActive = pageNext.Activate(true);
            Log(Label, "[" + pageActive.Label + "] was activated!");
        }
              
        protected IEnumerator WaitForPageExit(Type pageType)
        {
            var pageActive = SceneActive.DataSceneLoad.PageActive;
            
            Log(Label, "Waiting for exit [" + pageActive.Label + "]...");
            while (pageActive.DataAnimation.TargetState != APage.ANIMATOR_STATE_NONE)
            {
                yield return null;
            }
            
            PageGetNext(pageType);
        }


#endregion
    }

}
