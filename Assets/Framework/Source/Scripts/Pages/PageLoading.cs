using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageLoading : Page<PageLoading>
    {
        private readonly string PAGE_NAME = "Page: Loading";
        
        public override void Register()
        {
            Initialize(PAGE_NAME);
            SetToCache(this);
            Activate(false);

        } 
    }
}
