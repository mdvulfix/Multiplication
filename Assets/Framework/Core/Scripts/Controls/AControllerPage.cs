using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{    
    
    public interface IControllerPage: IController<IPage>
    {
        IPage PageActive  {get; set;}
        
        //void TurnPageOn<TPageNext>() where TPageNext: class, IPage;
        
        void PageTurn<TPageNext>(bool waitForPageExit = false) where TPageNext: class, IPage; 
        void PageTurn(Type pageType, bool waitForPageExit = false);   
    
    } 
    
    public abstract class AControllerPage : AController<IPage>, IControllerPage
    {
        public IPage PageActive  {get => pageActive; set => pageActive = value; }       

        private IPage pageActive;

#region Configure
        


#endregion 

#region PageManagement
    
        public void PageTurn<TPageNext>(bool waitForPageExit = false) where TPageNext: class, IPage
        {
            PageTurn(typeof(TPageNext), waitForPageExit);
        }
       
        public void PageTurn(Type pageType, bool waitForPageExit = false)
        {
            var pageNext = Cache.Get(pageType);
            var pageNextType = pageNext.GetType();
            
            if(pageActive == null)
            {
                LogWarning(Label, "You are trying to turn a page [" + pageActive.Label + "] that has not been registered!");
                return;
            }
    
            if(pageActive.ObjectOnScene.activeSelf)
            {
                pageActive.Activate(false);
                Log(Label, "[" + pageActive.Label + "] was deactivated!");

            }
                

            if(waitForPageExit)
            {
                StopCoroutine(WaitForPageExit(pageNextType));
                StartCoroutine(WaitForPageExit(pageNextType));
                
                //Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
                PageGetNext(pageType);
        }
               
        public void PageGetNext<TPageNext>() where TPageNext: class, IPage
        {
            PageGetNext(typeof(TPageNext));
        }  
    
        public void PageGetNext(Type pageType)
        {
            var pageNext = Cache.Get(pageType);
            
            if(pageNext==null)
            {
                LogWarning(Label, "You are trying to turn a page on [" + pageNext.Label + "] that has not been registered!");
                return;
            }
    
            pageActive = pageNext.Activate(true);
        
            pageActive = pageNext;
            Log(Label, "[" + pageActive.Label + "] was activated!");
        }
        
        
        private IEnumerator WaitForPageExit(Type pageType)
        {
            Log(Label, "Waiting for exit [" + pageActive.Label + "]...");
            while (pageActive.DataAnimation.TargetState != AnimationState.None)
            {
                yield return null;
            }
            
            PageGetNext(pageType);
        }
       
#endregion
    }
}
