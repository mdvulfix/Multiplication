using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{    
    
    public interface IControllerPage: IController
    {
        IPage PageActive {get; set;}
        
        void TurnPageOn<TPageNext>() where TPageNext: class, IPage;
        void TurnPageOff<TPageNext>(bool waitForPageExit = false) where TPageNext: class, IPage;
    } 
    
    public abstract class ControllerPage : Controller, IControllerPage
    {
        public static ICache<IPage> Cache {get; protected set;} = new Cache<IPage>();
       
        public  IPage PageActive {get => pageActive; set => pageActive = value; }       

        private IPage pageActive;
        
#region PageManagement
    
        public virtual void TurnPageOn<TPageNext>() where TPageNext: class, IPage
        {
            var pageNext = Cache.Get<TPageNext>();
            
            if(pageNext==null)
            {
                LogWarning(Name, "You are trying to turn a page on [" + pageNext.Name + "] that has not been registered!");
                return;
            }
    
            pageNext.Activate(true);
            Log(Name, pageNext.Name + "was animated");
        }
        
        public virtual void TurnPageOff<TPageNext>(bool waitForPageExit = false) where TPageNext: class, IPage
        {
            var pageNext = Cache.Get<TPageNext>();
            
            if(pageActive == null)
            {
                LogWarning(Name, "You are trying to turn a page off [" + pageActive.Name + "] that has not been registered!");
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
                TurnPageOn<TPageNext>();
        }
       
        private IEnumerator WaitForPageExit<TPageNext>() where TPageNext: class, IPage
        {
            while (pageActive.DataAnimation.TargetState != AnimationState.None)
            {
                yield return null;
            }
            
            TurnPageOn<TPageNext>();
        }
       
#endregion


   
    }
}
