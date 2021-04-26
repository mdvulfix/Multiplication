using System.Collections.Generic;
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
            
            if(!DataCheck<IDataStats>(DataStats))
                return;
            
            if(!DataCheck<IDataSceneLoading>(DataSceneLoading))
                return;
            
            
            DataStats.GUID = 1;
            
            
            if(isProject)
            {
                
                List<IPage> initializationList = new List<IPage>(3);
                
                initializationList.Add(pageLoading);
                initializationList.Add(pageLogin);
                initializationList.Add(pageMenu);
                    
                foreach (var instance in initializationList)
                {
                    instance.Initialize();
                    SetToCache(instance);
                }

            }

            DataStats.IsInitialized = true;
            Log(Label, LogSuccessfulInitialize());
            //return this;
        }

        public override IConfigurable Configure()
        {
            
            DataSceneLoading.SceneBuildId = BUILD_ID;
            DataSceneLoading.PageDefault = pageLogin;
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
            Log(Label, LogSuccessfulConfigure());
            return this;
        }
    }
}
