using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerPage", menuName = "Factories/Controllers/Page/Default")]
    public class FactoryControllerPage : FactoryController
    {
        [SerializeField]        
        private FactoryPage factoryPage;
        
        public override IController GetControl()
        {
            if(factoryPage == null)
            {
                LogWarning(Label, "Factory page not set!");
                return null;

            }
            
            var instance = Get<ControllerPageDefault>("Controller: Page", PARENT_SCENEOBJECT_NAME);
            var pages = factoryPage.GetPages();
            instance.PageRegister(pages);
            instance.Configure();

            return instance;

        }
    }
}
