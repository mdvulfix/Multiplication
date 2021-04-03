using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{    
    
    public interface IControlPage: IControl
    {
        HashSet<IPage> Pages {get; }
        
        void SetPages(IFactoryPage factory);
        void SetPages(HashSet<IPage> pages); 
        
        void TurnPageOn(IPage page);
        void TurnPageOff(IPage pageOff, IPage pageOn = null, bool waitForExit = false);
    
    } 
    
    
    public abstract class ControlPage : Control, IControlPage
    {
   
        private HashSet<IPage> pages;
       
        public HashSet<IPage> Pages {get => pages; private set => pages = value; }
        
         
        
        public virtual void TurnPageOn(IPage pageOn)
        {
            if(!Pages.Contains(pageOn))
            {
                LogWarning("You are trying to turn a page on [" + pageOn.Name + "] that has not been registered!");
                return;
            }

            pageOn.Animate(true);
            Log(pageOn.Name + "was animated");
        }
        
        public virtual void TurnPageOff(IPage pageOff, IPage pageOn = null, bool waitForExit = false)
        {
            if(!Pages.Contains(pageOff))
            {
                LogWarning("You are trying to turn a page off [" + pageOff.Name + "] that has not been registered!");
                return;
            }

            if(pageOff.ObjectOnScene.activeSelf)
                pageOff.Animate(false);

            if(waitForExit)
            {
                GetCoroutine(pageOff, pageOn);
                //Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
                TurnPageOn(pageOn);
        }

        private void GetCoroutine(params IPage[] pages)
        {
            StopCoroutine(WaitForPageExit(pages));
            StartCoroutine(WaitForPageExit(pages));
        }
        
        private IEnumerator WaitForPageExit(params IPage[] pages)
        {
            while (true)
            {
                
            }
            
            
            yield return null;
        }



       
        public void SetPages(IFactoryPage factory)
        {
            Pages = factory.GetPages();

        }
        
        public void SetPages(HashSet<IPage> pages)
        {
            Pages = pages;

        }

   
        protected void Log(string message)
        {
            Debug.Log("[Control Page]: " + message);
        }

        protected void LogWarning(string message)
        {
            Debug.LogWarning("[Control Page]: " + message);
        }


    }
}
