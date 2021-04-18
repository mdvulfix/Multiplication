using System.Collections.Generic;
using UnityEngine;
using Framework.Core;
using Framework.Core.Handlers;

namespace Framework
{    
    [CreateAssetMenu(fileName = "FactoryPage", menuName = "Factories/Page/Default")]
    public class FactoryPage : AFactory<IPage> //, IHaveFactory
    {
        
        public static readonly string OBJECT_NAME = "Factory: Page";
        
        //[SerializeField] private FactoryPageData factoryPageDataStruct;
        
        [SerializeField] private GameObject prefabPageLoading;
        [SerializeField] private GameObject prefabPageLogin;
        [SerializeField] private GameObject prefabPageMenu;
        [SerializeField] private GameObject prefabPageRunTime;
        [SerializeField] private GameObject prefabPageScore;
        
#region Configure

        public override void Initialize()
        {
            
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
                
            //GetFactory<IPageDataStruct>(factoryPageDataStruct);
        
        }

        public override IConfigurable Configure()
        {
            
            
            
            Log(Label, "was sucsessfully configured");
            return this;
        }
        
#endregion
 
#region Get
        
        public override List<IPage> Get()
        {
            var list = new List<IPage>()
            {
                GetAndInitialize<PageLoading>(PageLoading.OBJECT_NAME, prefabPageLoading),
                GetAndInitialize<PageLogin>(PageLogin.OBJECT_NAME, prefabPageLogin),
                GetAndInitialize<PageMenu>(PageMenu.OBJECT_NAME, prefabPageMenu), 
                GetAndInitialize<PageRunTime>(PageRunTime.OBJECT_NAME, prefabPageRunTime), 
                GetAndInitialize<PageScore>(PageScore.OBJECT_NAME, prefabPageScore)
            };

            return list;
        }

        private IPage GetAndInitialize<T>(string label, GameObject prefab) where T: APage
        {
            if(prefab==null)
            {
               LogWarning(Label, "Prefab for [" + label + "] page was not found!");
               return null;
            }

            var instance = GetInstanceOf<T>(label, FindSceneObjectByName(APage.PARENT_OBJECT_NAME), prefab);   
        
            instance.DataStats = SetData<DataStats>(DataStats.OBJECT_NAME, instance.gameObject);
            instance.DataAnimation = SetData<DataAnimation>(DataAnimation.OBJECT_NAME, instance.gameObject);
            instance.Initialize();

            return instance;
        }

#endregion

    }
}
