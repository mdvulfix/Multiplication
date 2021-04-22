using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class SceneRunTime : AScene
    {
        public static readonly string OBJECT_NAME = "Scene: RunTime";
        public static readonly ESceneBuildId BUILD_ID = ESceneBuildId.RunTime;
        
        
        [Header("Pages")]
        [SerializeField] private PageLoading pageLoading;
        [SerializeField] private PageRunTime pageRunTime;
        [SerializeField] private PagePause pagePause;
        
        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            
            if(!DataCheck<IDataStats>(DataStats))
                return;
            
            if(!DataCheck<IDataSceneLoad>(DataSceneLoad))
                return;
            
            DataStats.GUID = 2;
            DataStats.IsInitialized = true;
            
            if(isProject)
            {
                SetToCache(pageLoading);
                SetToCache(pageRunTime);
                SetToCache(pagePause);
                    
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
