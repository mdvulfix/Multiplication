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
            
            cache.Add(SetDataAnimation(GetInstanceOf<PageLoading>("Page: Loading", PARENT_OBJECT_NAME, prefab)));
            cache.Add(SetDataAnimation(GetInstanceOf<PageLogin>("Page: Login", PARENT_OBJECT_NAME, prefab)));
            cache.Add(SetDataAnimation(GetInstanceOf<PageMenu>("Page: Menu", PARENT_OBJECT_NAME, prefab)));
            
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
