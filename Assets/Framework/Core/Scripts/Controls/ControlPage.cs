using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework 
{
    public enum PageType
    {
        None,
        Loading,
        MainMenu,
        Score,
        Leaders
    }
    
    [CreateAssetMenu(fileName = "Page(Default)", menuName = "Controls/Page", order = 7)]
    public class ControlPage : AControl
    {

        private APage       initialPage;
        private Hashtable   pagesCache;




#region Unity functions
    
        public override void OnAwake() 
        {      
            Configure();

        
        }

        public override void OnUpdate() 
        {

        
        }
#endregion

#region Public functions
    
    public void OnPageEnter(PageType _enterPage)
    {

    }

    public void OnPageExit(PageType _exitPage)
    {

    }




#endregion

#region Private functions
    private void Configure()
    {
        pagesCache = new Hashtable();
        
        RegisterAllPages();

    }

    private void RegisterAllPages()
    {
        foreach (var page in pages)
            RegisterPage(page);

    }

    private void RegisterPage(IPage page)
    {


    
    
    
    }

    
#endregion

    }


}
