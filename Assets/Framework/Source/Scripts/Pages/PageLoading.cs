using Framework.Core;


namespace Framework
{
    public class PageLoading : Page
    {
        
        public override void Register()
        {
            Name = this.GetType().Name;
            Initialize();
            Activate(true);
            SetPageToCache(this);
            
        }

        public override void Activate(bool trueOrFalse)
        {
            ObjectOnScene.SetActive(trueOrFalse);
            Animate(trueOrFalse);

        }

        private void Animate(bool trueOrFalse)
        {
            if(trueOrFalse)
                Log("Animation is enabled");
            else
                Log("Animation is disabled");
        }

        
    }

}
