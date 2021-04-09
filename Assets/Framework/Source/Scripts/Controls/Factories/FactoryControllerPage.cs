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
        
        public override IController Get()
        {
            if(factoryPage == null)
            {
                LogWarning(Label, "Factory page was not set!");
                return null;

            }
            
            var instance = GetInstanceOf<ControllerPageDefault>("Controller: Page", Controller.PARENT_OBJECT_NAME).Initialize() as IControllerPage;
            var pages = factoryPage.GetPages();
            instance.Register(pages);
            return instance;
        }
    }
}
