using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageLogin : Page<PageLogin>
    {
        private readonly string PAGE_NAME = "Page: Login";
        
        public override void Register()
        {
            Initialize(PAGE_NAME);
            SetToCache(this);
            Activate(false);
        } 
    }
}
