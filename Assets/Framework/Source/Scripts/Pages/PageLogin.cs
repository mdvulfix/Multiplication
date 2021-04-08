using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageLogin : Page
    {
        private readonly string PAGE_NAME = "Page: Login";
        
        public override void Initialize()
        {
            SetSceneObject(PAGE_NAME);
            Activate(false);

            Log(Name, "was initialized");
        } 
    }
}
