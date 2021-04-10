using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryPage", menuName = "Factories/Page")]
    public class FactoryPage : Factory
    {
        [SerializeField]
        private FactoryData factoryData;
        
        [SerializeField]
        protected GameObject prefab;
        
        public override List<IPage> Get<IPage>()
        {
            var list = new List<IPage>()
            {
                GetInstanceOf<PageLoading>("Page: Loading", Page.PARENT_OBJECT_NAME, prefab) as IPage,
                GetInstanceOf<PageLogin>("Page: Login", Page.PARENT_OBJECT_NAME, prefab) as IPage,
                GetInstanceOf<PageMenu>("Page: Menu", Page.PARENT_OBJECT_NAME, prefab) as IPage
            };
            
            foreach (var instance in list)
            {

            }
            
            
            return list;
        }

        public IPage SetDataAnimation(IPage page)
        {
            page.DataAnimation =  (IDataAnimation)factoryData.Get<DataAnimation>();
            page.DataAnimation.UseAnimation = true;
            return page;           
        }
    }
}
