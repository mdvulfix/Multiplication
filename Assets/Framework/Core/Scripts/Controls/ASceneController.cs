using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core.Scene;
using Core.Page;
using Core.Cache;

namespace Core.Scene.Controller
{
    public interface ISceneController: IController
    {
        void SceneLoad<TScene>()
            where TScene : IScene;

        void SceneEnter<TScene, TPage>()
            where TScene : IScene
            where TPage : IPage;

        void ScenePause();

        void SceneExit();

        void SceneUnload();

    } 
    
    [Serializable]
    public abstract class ASceneController: AController, ISceneController
    {
        public IScene SceneCurrent { get; private set; }

        protected static Dictionary<Type, SceneIndex> m_Indexes;
        protected static Cache<IScene> m_SceneLoaded;
        protected static Cache<IScene> m_SceneActivated;


        public void SceneLoad<TScene>()
            where TScene: IScene
        {
            SceneIndex index;
            if (GetSceneByIndex<T>(out index))
            {
                SceneLoadAsync(index);
            }

        }

        public void SceneEnter<TScene, TPage>() 
            where TScene : IScene
            where TPage : IPage
        {
            
            SceneIndex index;
            if (GetSceneByIndex<TScene>(out index))
            {
                SceneEnterAsync(index);
            }
            
        }

        public void ScenePause() 
        {


        }

        public void SceneExit() 
        {


        }

        public void SceneUnload() 
        {


        }
    

        public void SceneEnterNext<TScene, TPage>(bool delay = false) 
            where TScene: class, IScene
            where TPage: class, IPage
        {
            SceneEnterNext(typeof(TScene), typeof(TPage), delay);
        }
       
        public void SceneEnterNext(Type sceneNextType, Type pageNextType, bool delay = false)
        {
            var sceneNext = Cache.Get(sceneNextType);
            var pageNext = sceneNext.Cache.Get(pageNextType);

            if(SceneActive == null)
            {
                LogWarning(Label, "You are trying to turn a scene [" + SceneActive.Label + "] that has not been registered!");
                return;
            }
            
            if(SceneActive.Stats.IsActive)
            {
                
                PageExit(pageNext);
                SceneActive.Activate(false);
                Log(Label, "[" + SceneActive.Label + "] was deactivated!");
            }


            if(delay)
            {
                StopCoroutine("WaitForSceneExit");
                StartCoroutine(WaitForSceneExit(sceneNextType, pageNextType));
                //Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
            {
                SceneEnter(sceneNextType, pageNextType);
            }
                
        }
               
        public void SceneEnter<TScene, TPage>() 
            where TScene: class, IScene
            where TPage: class, IPage
        {
            SceneEnter(typeof(TScene), typeof(TPage));
        }  
    
        public void SceneEnter(Type sceneType, Type pageType)
        {
            var sceneNext = Cache.Get(sceneType);
            Log(Label, "[" + sceneNext.Label + "] was found in the cache! Hashcode is [" + sceneNext.GetHashCode() + "]");
            
            
            //var pageNext = sceneNext.Cache.Get(pageType);
            //Log(Label, "[" + pageNext.Label + "] was found in the cache! Hashcode is [" + pageNext.GetHashCode() + "]");


            
            if(sceneNext==null)
            {
                LogWarning(Label, "You are trying to turn a scene on [" + sceneNext.Label + "] that has not been registered!");
                return;
            }
    
            SceneActive = sceneNext.Activate(true);
            //SceneActive.DataSceneLoading.PageActive = pageNext;
            
            
            //PageEnter(pageNext);
            Log(Label, "[" + SceneActive.Label + "] was activated!");
        }

        
        private IEnumerator WaitForSceneExit(Type sceneType, Type pageType)
        {
            
            Log(Label, "Waiting for exit [" + SceneActive.Label + "]...");
            /*
            while (sceneActive.DataAnimation.TargetState != AScene.ANIMATOR_STATE_NONE)
            {
                yield return null;
            }
            */
            yield return new WaitForSeconds(2f);
            SceneEnter(sceneType, pageType);
        
        }

        private bool GetSceneByIndex<T>(out SceneIndex index)
            where T: IScene
        {
            if (!m_Indexes.TryGetValue(typeof(T), out index))
            {
                Debug.Log("Index was not found!");
                return false;
            }

            return true;
        }

    }

}
