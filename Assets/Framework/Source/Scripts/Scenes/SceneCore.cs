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
            
            if(!DataCheck<IDataSceneLoading>(DataSceneLoading))
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
            
            DataSceneLoading.SceneBuildId = BUILD_ID;
            DataSceneLoading.PageDefault = pageLoading;
            DataSceneLoading.OnLoadCallback = null;
        
            if(Cache.IsEmpty())
            {
                LogWarning(Label, LogFailedConfigure("Cache is empty!"));
                return null;
            }
            else
            {
                foreach (var instance in Cache.GetAll())
                {
                    instance.Configure();
                }
            }
            
            DataStats.IsConfigerd = true;
            Log(Label, LogSuccessfulConfigure());;
            return this;
        }
    }
}
