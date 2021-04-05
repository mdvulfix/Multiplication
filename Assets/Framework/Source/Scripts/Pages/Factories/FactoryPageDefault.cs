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
        
        public override HashSet<IPage> GetPages()
        {
            
            var pages = new HashSet<IPage>()
            {
                SetDataAnimation(Get<PageLoading>()),
                SetDataAnimation(Get<PageLogin>()),
                SetDataAnimation(Get<PageMainMenu>())
            };

            return pages;
        }

        public IPage SetDataAnimation(IPage page)
        {
            page.DataAnimation =  factoryData.Get<DataAnimation>();
            page.DataAnimation.UseAnimation = true;
            return page;           
        }
    }
}
