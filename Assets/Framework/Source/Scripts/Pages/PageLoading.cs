using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageLoading : Page
    {
        private readonly string PAGE_NAME = "Page: Loading";
        
        public override void Initialize()
        {
            SetSceneObject(PAGE_NAME);
            Activate(false);

            Log(Name, "was initialized");

        } 
    }
}
