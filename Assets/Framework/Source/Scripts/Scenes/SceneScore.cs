using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class SceneScore : AScene
    {
        public static readonly string OBJECT_NAME = "Scene: Score";
        public static readonly ESceneBuildId BUILD_ID = ESceneBuildId.Score;
        
        
        [Header("Pages")]
        [SerializeField] private PageLoading pageLoading;
        [SerializeField] private PageScore pageScore;

        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME, BUILD_ID);
            
            DataStats.GUID = 3;
            DataStats.IsInitialized = true;
            
            if(isProject)
            {
                SetToCache(pageLoading);
                SetToCache(pageScore);
                    
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
