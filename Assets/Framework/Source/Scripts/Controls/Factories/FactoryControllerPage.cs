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
            var instance = Get<ControllerPageDefault>("Controller: Page", PARENT_SCENEOBJECT_NAME);
            //instance.SetPages(factoryPage);

            return instance;

        }
    }
}
