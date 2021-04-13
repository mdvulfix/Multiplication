using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryPage", menuName = "Factories/Page/Default")]
    public class FactoryPage : AFactory<IPage>
    {
        
        [SerializeField] private FactoryData factoryData;
        
        [SerializeField] protected GameObject prefabPageLoading;
        [SerializeField] protected GameObject prefabPageLogin;
        [SerializeField] protected GameObject prefabPageMenu;
        [SerializeField] protected GameObject prefabPageRunTime;
        [SerializeField] protected GameObject prefabPageScore;
        
        public override List<IPage> Get()
        {
            var list = new List<IPage>()
            {
                GetAndInitialize<PageLoading>(PageLoading.OBJECT_NAME, prefabPageLoading),
                GetAndInitialize<PageLogin>(PageLogin.OBJECT_NAME, prefabPageLogin),
                GetAndInitialize<PageMenu>(PageMenu.OBJECT_NAME, prefabPageMenu), 
                GetAndInitialize<PageRunTime>(PageRunTime.OBJECT_NAME, prefabPageRunTime), 
                GetAndInitialize<PageScore>(PageScore.OBJECT_NAME, prefabPageScore), 
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

            var instance = GetInstanceOfSceneObject<T>(label, APage.PARENT_OBJECT_NAME, prefab);
            instance.Initialize();
            instance.DataAnimation =  GetDataAnimation();
            return instance;
        }

        private IDataAnimation GetDataAnimation()
        {
            IDataAnimation data = null; //=  factoryData.Get<DataAnimation>();
            //data.UseAnimation = true;
            return data;           
        }
    }
}
