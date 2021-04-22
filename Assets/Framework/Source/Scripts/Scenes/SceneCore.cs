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
            SetParams(OBJECT_NAME, BUILD_ID);
            
            if(DataStats == null)
            {
                LogWarning(Label, LogFailedInitialize("Data: Stats was not found!"));
                return;
            }
              
            
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
            
            
            DataStats.IsConfigerd = true;
            
            Log(Label, "was sucsessfully configured");
            return this;
        }
    }
}
