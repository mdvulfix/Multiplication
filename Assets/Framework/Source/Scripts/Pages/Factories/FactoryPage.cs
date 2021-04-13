using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryPage", menuName = "Factories/Page/Default")]
    public class FactoryPage : AFactory<IPage>
    {
        [SerializeField]
        private FactoryData factoryData;
        
        [SerializeField]
        protected GameObject prefab;
        
        public override List<IPage> Get()
        {
            var list = new List<IPage>()
            {
                GetAndInitialize<PageLoading>(PageLoading.OBJECT_NAME),
                GetAndInitialize<PageLogin>(PageLogin.OBJECT_NAME),
                GetAndInitialize<PageMenu>(PageMenu.OBJECT_NAME)
            };

            return list;
        }

        private IPage GetAndInitialize<T>(string label) where T: APage
        {

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
