using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class SceneCore : AScene
    {
        public static readonly string OBJECT_NAME = "Scene: Core";
        public static readonly ESceneBuildId BUILD_ID = ESceneBuildId.Core;
        

        [Header("Pages")]
        [SerializeField] private PageLoading pageLoading;
     




        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            
            if(!DataCheck<IDataStats>(DataStats))
                return;
            
            if(!DataCheck<IDataSceneLoad>(DataSceneLoad))
                return;
              
            
            DataStats.GUID = 0;
            DataStats.IsInitialized = true;
            
            if(isProject)
            {
                SetToCache(pageLoading);
                    
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
