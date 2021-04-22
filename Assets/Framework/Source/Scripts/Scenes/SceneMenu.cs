using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class SceneMenu : AScene
    {
        public static readonly string OBJECT_NAME = "Scene: Menu";
        public static readonly ESceneBuildId BUILD_ID = ESceneBuildId.Menu;
        
        [Header("Pages")]
        [SerializeField] private PageLoading pageLoading;
        [SerializeField] private PageLogin pageLogin;
        [SerializeField] private PageMenu pageMenu;
        
        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            
            if(!DataCheck(DataStats))
                return;
            
            if(!DataCheck(DataSceneLoad))
                return; 
            
            
            DataStats.GUID = 1;
            DataStats.IsInitialized = true;
            
            if(isProject)
            {
                SetToCache(pageLoading);
                SetToCache(pageLogin);
                SetToCache(pageMenu);
                    
                foreach (var instance in Cache.GetAll())
                {
                    instance.Initialize();
                }

            }

            Log(Label, LogSuccessfulInitialize());
            //return this;
        }

        public override IConfigurable Configure()
        {
            
            DataSceneLoad.SceneBuildId = BUILD_ID;
            DataSceneLoad.PageLoading = pageLoading;
            DataSceneLoad.OnLoadCallback = null;

            DataStats.IsConfigerd = true;

            Log(Label, LogSuccessfulConfigure());
            return this;
        }
    }
}
