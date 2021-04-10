using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerPage", menuName = "Factories/Controllers/Page/Default")]
    public class FactoryControllerPage : Factory
    {
        [SerializeField]        
        private FactoryPage factoryPage;
        
        public override List<IControllerPage> Get<IControllerPage>()
        {
            if(factoryPage == null)
            {
                LogWarning(Label, "Factory page was not set!");
                return null;
            }
            
            var list = new List<ControllerPageDefault>()
            {
                GetInstanceOf<ControllerPageDefault>("Controller: Page", Controller.PARENT_OBJECT_NAME).Initialize()
                    

            };
            //var instance = ;
            var pages = factoryPage.Get<IPage>();
            //instance.SetToCache(pages);

            list.Add(instance);
            return list;
        }
    }
}
