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
        
        void SceneEnterNext<TScene, TPage>(bool delay = false) 
            where TScene: class, IScene
            where TPage: class, IPage;
        
        void SceneEnterNext(Type sceneType, Type pageType, bool delay = false);

        void SceneEnter<TScene, TPage>() 
            where TScene: class, IScene
            where TPage: class, IPage;
        
        void SceneEnter(Type sceneType, Type pageType);

    } 
    
    [Serializable]
    public abstract class AControllerScene: AController<IScene>, IControllerScene
    {
        public IScene SceneActive     {get; private set;}       

       
#region Start&Update

#endregion

#region SceneManagement
    
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
#endregion

#region PageManagement

        private void PageEnter(IPage page = null, IControllerPage controller = null, ICache<IPage> cache = null)
        {
            
            if(controller == null)
                controller = GetAndConfigureControllerPage(cache);
                
            if(page == null)
                page = SceneActive.SceneLoading.PageDefault;

            controller.PageEnter(page);
            
        }
        
        private void PageExit(IPage page = null, IControllerPage controller = null, ICache<IPage> cache = null)
        {
            
            if(controller == null)
                controller = GetAndConfigureControllerPage(cache);
                
            if(page == null)
                page = SceneActive.SceneLoading.PageActive;

            controller.PageExit(page);
            
        }

        private void PageEnterNext(IPage page = null, IControllerPage controller = null, ICache<IPage> cache = null, bool delay = true)
        {
            if(controller == null)
                controller = GetAndConfigureControllerPage(cache);
                
            if(page == null)
                page = SceneActive.SceneLoading.PageActive;
            
            controller.PageEnterNext(page, delay);

        }
        
        private IControllerPage GetAndConfigureControllerPage(ICache<IPage> cache = null)
        {
            var controller = Session.GetController<ControllerPage>();
        
            if(cache == null)
                controller.GetCache(SceneActive.Cache);
            else   
                controller.GetCache(cache);

            controller.PageSetActive(SceneActive.SceneLoading.PageActive);

            return controller;
        }

#endregion

    }

}
