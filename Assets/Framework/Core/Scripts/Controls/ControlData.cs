using System;
using UnityEditor;

namespace Framework.Core
{

    public interface IControlData: IControl
    {
       
        
    } 

    [Serializable]
    public class ControlData: Control, IControlData
    {
        public static ICache<IScene>    CacheScene  {get; } = new Cache<IScene>();
        public static ICache<IPage>     CachePage   {get; } = new Cache<IPage>();
        
        public Scene SceneCurrent;
        public Page  PageCurrent;
        
        public FactoryPage factoryPage;
        
        
        public void Start()
        {   
            Configure();
            SceneCurrent = (Scene)CacheScene.Get(typeof(SceneMenu));
            PageCurrent = (Page)CachePage.Get(typeof(PageLoading));
        }

        public override void Configure()
        {
            CacheScene.Add(new SceneCore());
            CacheScene.Add(new SceneMenu());
            CacheScene.Add(new SceneRunTime());

            
            (CachePage.Add(factoryPage.Get<PageLoading>("Page: Loading"))).Register();
            (CachePage.Add(factoryPage.Get<PageLogin>("Page: Login"))).Register();
            (CachePage.Add(factoryPage.Get<PageMenu>("Page: Menu"))).Register();

        }
    }
}
