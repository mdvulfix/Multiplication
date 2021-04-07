using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageMenu : Page<PageMenu>
    {
        private readonly string PAGE_NAME = "Page: Menu";
        
        public override void Register()
        {
            Initialize(PAGE_NAME);
            SetToCache(this);
            Activate(false);
        }

    }

}
