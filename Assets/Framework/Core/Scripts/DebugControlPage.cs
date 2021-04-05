using System;
using UnityEngine;

namespace Framework.Core 
{

    public class TestControlPage : SceneObject
    {
        
        public  BuilderDefault         builder;

        private ControlPageDefault     controlPage;

        private PageLoading     pageLoading;
        private PageLogin       pageLogin;
        private PageMainMenu    pageMainMenu;


        private void Start() 
        {
            var key = typeof(ControlPageDefault);
            if(builder.Controls.ContainsKey(key))
                controlPage = builder.Controls[key] as ControlPageDefault;
            else
            {
                Debug.Log("ControlPage is not exist");
                return;
            }
        
            pageLoading =   Page.GetPageByType(pageLoading.GetType()) as PageLoading;
            pageLogin =     Page.GetPageByType(pageLogin.GetType()) as PageLogin;
            pageMainMenu =  Page.GetPageByType(pageMainMenu.GetType()) as PageMainMenu;
                
        }


        private void Update() 
        {
            
            if(Input.GetKeyUp(KeyCode.F))
                controlPage.TurnPageOn(pageLoading);
            if(Input.GetKeyUp(KeyCode.G))
                controlPage.TurnPageOff(pageLoading);
            if(Input.GetKeyUp(KeyCode.H))
                controlPage.TurnPageOff(pageLoading, pageLogin);
             if(Input.GetKeyUp(KeyCode.H))
                controlPage.TurnPageOff(pageLoading, pageLogin, true);       
        
        }

        
    }


}
