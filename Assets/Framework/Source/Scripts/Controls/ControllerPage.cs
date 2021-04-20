using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControllerPage : AControllerPage
    {       
        public static readonly string OBJECT_NAME = "Controller: Page";

        [Header("Pages")]
        [SerializeField] private PageLoading pageLoading;
        [SerializeField] private PageLogin pageLogin;
        [SerializeField] private PageMenu pageMenu;
        
#region Configure
        // Initialize in factory        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            
            SetToCache(pageLoading);
            SetToCache(pageLogin);
            SetToCache(pageMenu);
            
            foreach (var instance in Cache.GetAll())
            {
                instance.Initialize();
            }
            
            Log(Label, "was sucsessfully initialized");
            //return this;
        } 
        
        // Initialize in builder 
        public override IConfigurable Configure() 
        {                                     
            foreach (var page in Cache.GetAll())
            {
                page.Configure();
            }
            
            //SetPageActive<PageLoading>();
            
            Log(Label, "was successfully configured.");
            return this;
        }
        
#endregion

#region Start&Update


#endregion

        private void SetPageActive<T>() where T: class, IPage
        {
            PageActive = Cache.Get<T>();
            PageActive.Activate(true);
            Log(Label, "Page [" + PageActive.Label + "] was activated.");
        }

        public void TurnPageOn(Type pageType)
        {
            var pageNext = Cache.Get(pageType);
            
            if(pageNext==null)
            {
                LogWarning(Label, "You are trying to turn a page on [" + pageNext.Label + "] that has not been registered!");
                return;
            }
    
            pageActive = pageNext.Activate(true);
            Log(Label, "[" + pageActive.Label + "] was activated!");
        }

        public void TurnPageOff(Type pageType, bool waitForPageExit = false)
        {
            var pageNext = Cache.Get(pageType);
            var pageNextType = pageNext.GetType();
            
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
                
            if(waitForPageExit)
            {
                StopCoroutine("WaitForPageExit");
                StartCoroutine(WaitForPageExit(pageActive));

            }

        }
    }
}
