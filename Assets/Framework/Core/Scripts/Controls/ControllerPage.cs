using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{    
    
    public interface IControllerPage: IController, IHasCache<IPage>
    {
        IPage PageActive  {get; }
        
        //void TurnPageOn<TPageNext>() where TPageNext: class, IPage;
        
        void  PageTurn<TPageNext>(bool waitForPageExit = false) where TPageNext: class, IPage;
    
    
    
    } 
    
    public abstract class ControllerPage : Controller, IControllerPage
    {
        protected static readonly string OBJECT_NAME = "Controller: Page";
        
        public ICache<IPage>    Cache       {get; protected set;} = new Cache<IPage>();
        public IPage            PageActive  {get => pageActive; set => pageActive = value; }       

        private IPage pageActive;

#region Configure
        


#endregion 

#region SetToCache

        public IPage SetToCache(IPage instance)
        {
            Cache.Add(instance as IPage);
            return instance;
        }

        public void SetToCache(List<IPage> instances)
        {
            foreach (var instance in instances)
            {
                SetToCache(instance);
            }
        }

#endregion 

#region PageManagement
    
        public void PageTurn<TPageNext>(bool waitForPageExit = false) where TPageNext: class, IPage
        {
            var pageNext = Cache.Get<TPageNext>();
            
            if(pageActive == null)
            {
                LogWarning(Label, "You are trying to turn a page [" + pageActive.Label + "] that has not been registered!");
                return;
            }
    
            if(pageActive.ObjectOnScene.activeSelf)
                pageActive.Activate(false);

            if(waitForPageExit)
            {
                StopCoroutine(WaitForPageExit<TPageNext>());
                StartCoroutine(WaitForPageExit<TPageNext>());
                
                //Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
                PageGetNext<TPageNext>();
        }
       
        private void PageGetNext<TPageNext>() where TPageNext: class, IPage
        {
            var pageNext = Cache.Get<TPageNext>();
            
            if(pageNext==null)
            {
                LogWarning(Label, "You are trying to turn a page on [" + pageNext.Label + "] that has not been registered!");
                return;
            }
    
            pageNext.Activate(true);
            pageActive = pageNext;
            Log(Label, pageNext.Label + "was animated");
        }  
    
        private IEnumerator WaitForPageExit<TPageNext>() where TPageNext: class, IPage
        {
            while (pageActive.DataAnimation.TargetState != AnimationState.None)
            {
                yield return null;
            }
            
            PageGetNext<TPageNext>();
        }
       
#endregion
    }
}
