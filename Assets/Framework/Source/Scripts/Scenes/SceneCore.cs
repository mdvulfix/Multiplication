using UnityEngine;
using Core.Scene;

namespace Source.Scene
{
    public class SceneCore : AScene
    {
        public static readonly string OBJECT_NAME = "Scene: Core";
        public static readonly ESceneBuildId BUILD_ID = ESceneBuildId.Core;
        

        [Header("Pages")]
        [SerializeField] private PageLoading pageLoading;
     




        public override void Init()
        {
            SetParams(OBJECT_NAME);
            
            if(!DataCheck<IDataStats>(Stats))
                return;
            
            if(!DataCheck<IDataLoading>(SceneLoading))
                return;
              
            
            Stats.GUID = 0;
            Stats.IsInitialized = true;
            
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
            
            SceneLoading.SceneBuildId = BUILD_ID;
            SceneLoading.PageDefault = pageLoading;
            SceneLoading.OnLoadCallback = null;
        
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
            
            Stats.IsConfigerd = true;
            Log(Label, LogSuccessfulConfigure());;
            return this;
        }
    }
}
