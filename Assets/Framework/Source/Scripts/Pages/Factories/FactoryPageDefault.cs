using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "Factory Page (Default)", menuName = "Factories/Page/Default")]
    public class FactoryPageDefault : FactoryPage
    {

        [SerializeField]
        private FactoryData factoryData;
        
        public override List<IPage> GetPages()
        {
            var cache = new List<IPage>();
            
            cache.Add(SetDataAnimation(Get<PageLoading>("Page: Loading", PARENT_SCENEOBJECT_NAME, prefab)));
            cache.Add(SetDataAnimation(Get<PageLogin>("Page: Login", PARENT_SCENEOBJECT_NAME, prefab)));
            cache.Add(SetDataAnimation(Get<PageMenu>("Page: Menu", PARENT_SCENEOBJECT_NAME, prefab)));
            
            return cache;
        }

        public IPage SetDataAnimation(IPage page)
        {
            page.DataAnimation =  factoryData.Get<DataAnimation>();
            page.DataAnimation.UseAnimation = true;
            return page;           
        }
    }
}
