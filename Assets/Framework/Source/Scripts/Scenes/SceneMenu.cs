using System.Collections.Generic;
using UnityEngine;
using Core.Scene;

namespace Source.Scene
{
    public class SceneMenu : AScene
    {
        public static readonly string OBJECT_NAME = "Scene: Menu";
        public static readonly SceneIndex BUILD_ID = SceneIndex.Menu;
        
        //[Header("Pages")]
        //[SerializeField] private PageLoading pageLoading;
        //[SerializeField] private PageLogin pageLogin;
        //[SerializeField] private PageMenu pageMenu;
        
        /*
        public override void Init(IDataScene data)
        {
            SetParams(OBJECT_NAME);
            
            if(!DataCheck<IDataStats>(Stats))
                return;
            
            if(!DataCheck<IDataLoading>(SceneLoading))
                return;
            
            
            Stats.GUID = 1;
            
            
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

            Stats.IsInitialized = true;
            Log(Label, LogSuccessfulInitialize());
            //return this;
        }

        public override IConfigurable Configure()
        {
            
            SceneLoading.SceneBuildId = BUILD_ID;
            SceneLoading.PageDefault = pageLogin;
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
            Log(Label, LogSuccessfulConfigure());
            return this;
        }
        */
    }
}
