using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageMenu : Page
    {
        private readonly string PAGE_NAME = "Page: Menu";
        
        public override void Initialize()
        {
            SetSceneObject(PAGE_NAME);
            Activate(false);
        
            Log(Name, "was initialized");
        } 
    }

}
