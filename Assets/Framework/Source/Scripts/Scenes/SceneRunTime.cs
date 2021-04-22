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
            SetParams(OBJECT_NAME, BUILD_ID);
            
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

            Log(Label, "was sucsessfully initialized");
            //return this;
        }

        public override IConfigurable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }


    }
}
