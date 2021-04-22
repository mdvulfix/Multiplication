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
            SetParams(OBJECT_NAME);
            
            if(!DataCheck<IDataStats>(DataStats))
                return;
            
            if(!DataCheck<IDataSceneLoad>(DataSceneLoad))
                return;
            
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
