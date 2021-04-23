using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControllerPage : AControllerPage
    {       
        public static readonly string OBJECT_NAME = "Controller: Page";

        [Header("Scene: Core")]
        [SerializeField] private PageLoading sceneCorePageLoading;
        
        [Header("Scene: Menu")]
        [SerializeField] private PageLoading sceneMenuPageLoading;
        [SerializeField] private PageLogin sceneMenuPageLogin;
        [SerializeField] private PageMenu sceneMenuPageMenu;

        [Header("Scene: RunTime")]
        [SerializeField] private PageLoading sceneRunTimePageLoading;
        [SerializeField] private PageRunTime sceneRunTimePageRunTime;
        [SerializeField] private PagePause sceneRunTimePagePause;

        [Header("Scene: Score")]
        [SerializeField] private PageLoading sceneScorePageLoading;
        [SerializeField] private PageScore sceneScorePageScore;


        
#region Configure
        
        // Initialize in factory        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            
            if(isProject)
            {

            }

            
            Log(Label, LogSuccessfulInitialize());
            //return this;
        } 
        
        // Initialize in builder 
        public override IConfigurable Configure() 
        {                                     
            
            
            Log(Label, LogSuccessfulConfigure());
            return this;
        }
        
#endregion

#region Start&Update


#endregion



        /*
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
        */
    }
}
