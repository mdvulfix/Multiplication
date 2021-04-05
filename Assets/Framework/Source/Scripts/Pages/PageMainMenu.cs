using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageMainMenu : Page
    {
        private readonly string PAGE_NAME = "Page: Main menu";
        
        public override void Register()
        {
            Initialize(PAGE_NAME);
            SetPageToCache(this);

            Animate(false);
        }

    }

}
