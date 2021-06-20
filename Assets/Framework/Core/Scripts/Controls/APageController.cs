using System;
using System.Collections;
using System.Collections.Generic;
using Core.Scene.Page;
using UnityEngine;

/*
namespace Core.Page.Controller
{    
    public interface IPageController: IController
    {
        IPage PageActive  {get; }
        
        void PageSetActive<T>()
            where T: class, IPage;

        void PageSetActive<T>(T page)
            where T: class, IPage;
        
        void PageEnter<TPageNext>() 
            where TPageNext: class, IPage;
        
        void PageEnter(Type pageType);

        void PageEnter(IPage page);

        void PageExit(IPage pageActive);
        
        void PageEnterNext<TPage>(bool delay = false)
            where TPage: class, IPage; 
        
        void PageEnterNext(Type pageType, bool delay = false);  

        void PageEnterNext(IPage pageNext, bool delay = false);

    } 
    
    public abstract class APageController : AController, IPageController
    {   
        public IPage PageActive  {get; private set;}      

        

    
        // Page Enter /////////////////////////////////////////////////
               
        public void PageEnter<TPage>() where TPage: class, IPage
        {
            PageEnter(typeof(TPage));
        }  
    
        public void PageEnter(Type pageType)
        {
            var page = Cache.Get(pageType);
            
            if(page==null)
            {
                LogWarning(Label, "You are trying to turn a page on [" + page.Label + "] that has not been registered!");
                return;
            }
    
            PageActive = page.Activate(true);
            Log(Label, "[" + PageActive.Label + "] was activated!");
        }

        public void PageEnter(IPage page)
        {
            if(Cache.Contains(page))
            {
                PageActive = page.Activate(true);
                Log(Label, "[" + PageActive.Label + "] was activated!");
            }
            else
            {
                LogWarning(Label, "You are trying to turn a page on [" + page.Label + "] that has not been registered!");
                return;
            }
    
        }

        // Page Exit //////////////////////////////////////////////////
        
        public void PageExit(IPage pageActive = null)
        {
            
            if(pageActive == null)
                pageActive = PageActive;
            
            
            if(pageActive == null)
            {
                LogWarning(Label, "You are trying to turn a page [" + PageActive.Label + "] that has not been registered!");
                return;
            }
    
            if(pageActive.Stats.IsActive)
            {
                pageActive.Activate(false);
                Log(Label, "[" + pageActive.Label + "] was deactivated!");
            }
        }
        
        // Page Enter Next (after exit active page) ///////////////////
        
        public void PageEnterNext<TPageNext>(bool delay = false) 
            where TPageNext: class, IPage
        {
            PageEnterNext(typeof(TPageNext), delay);
        }
       
        public void PageEnterNext(Type pageNextType, bool delay = false)
        {
            var pageNext = Cache.Get(pageNextType);
             
            if(PageActive == null)
            {
                LogWarning(Label, "You are trying to turn a page [" + PageActive.Label + "] that has not been registered!");
                return;
            }
    
            if(PageActive.Stats.IsActive)
            {
                PageActive.Activate(false);
                Log(Label, "[" + PageActive.Label + "] was deactivated!");
            }
                

            if(delay)
            {
                StopCoroutine("WaitForPageExit");
                StartCoroutine(WaitForPageExit(pageNextType));
                //Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
                PageEnter(pageNextType);
        }

        public void PageEnterNext(IPage pageNext, bool delay = false)
        {
            if(Cache.Contains(pageNext))
            {
                if(PageActive == null)
                {
                    LogWarning(Label, "You are trying to turn a page [" + PageActive.Label + "] that has not been registered!");
                    return;
                }
        
                if(PageActive.Stats.IsActive)
                {
                    PageActive.Activate(false);
                    Log(Label, "[" + PageActive.Label + "] was deactivated!");
                }
                    
                if(delay)
                {
                    StopCoroutine("WaitForPageExit");
                    StartCoroutine(WaitForPageExit(pageNext.GetType()));
                    //Log("Animation is enabled on page [ " + Name + " ]");
                }
                else
                    PageEnter(pageNext);
            }
            else
            {
                LogWarning(Label, "You are trying to turn on page [" + pageNext.Label + "] that has not been registered!");
                return;
            }
        }

        // Delay //////////////////////////////////////////////////////

        protected IEnumerator WaitForPageExit(Type pageType)
        {
            Log(Label, "Waiting for exit [" + PageActive.Label + "]...");
            while (PageActive.Animation.TargetState != APage.ANIMATOR_STATE_NONE)
            {
                yield return null;
            }
            
            PageEnter(pageType);
        }

        // Page Activate //////////////////////////////////////////////

        public void PageSetActive<T>() 
            where T: class, IPage
        {
            PageActive = Cache.Get<T>();
            PageActive.Activate(true);
            Log(Label, "Page [" + PageActive.Label + "] was activated.");
        }
        
        public void PageSetActive<T>(T page) 
            where T: class, IPage
        {
            if(Cache.Contains(page))
            {
                PageActive = page;
                PageActive.Activate(true);
                Log(Label, "Page [" + PageActive.Label + "] was activated.");
            }
            else
                LogWarning(Label, "Page [" + PageActive.Label + "] cannot be activated. Cache is not contains this page!");

        }
    }
}
*/