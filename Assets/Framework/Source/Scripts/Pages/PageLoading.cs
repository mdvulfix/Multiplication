using System.Collections;
using Framework.Core;

namespace Framework
{
    public class PageLoading : Page
    {
        private readonly string PAGE_NAME = "Page: Loading";
        
        public override void Register()
        {
            Initialize(PAGE_NAME);
            SetPageToCache(this);
            Animate(true);
            
        }




        
        protected override IEnumerator AwaitAnimation (bool on)
        {
            yield return null;
        }
        
    }

}
