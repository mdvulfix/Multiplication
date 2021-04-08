using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{    
    
    public interface IControllerPage: IController
    {
        ICache<IPage>   Cache       {get; }
        IPage           PageActive  {get; }
        
        //void TurnPageOn<TPageNext>() where TPageNext: class, IPage;
        
        IPage PageRegister(IPage page);
        void  PageTurn<TPageNext>(bool waitForPageExit = false) where TPageNext: class, IPage;
    } 
    
    public abstract class ControllerPage : Controller, IControllerPage
    {
        
        protected readonly string SCENEOBJECT_NAME = "Controller: Page";
        
        public ICache<IPage>    Cache       {get; protected set;} = new Cache<IPage>();
        public IPage            PageActive  {get => pageActive; set => pageActive = value; }       


        private IPage pageActive;
        
#region PageManagement
    
        public IPage PageRegister(IPage page)
        {
            return Cache.Add(page);
        }

        public void PageRegister(List<IPage> pages)
        {
            foreach (var page in pages)
            {
                PageRegister(page);
            }
        }

        
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
