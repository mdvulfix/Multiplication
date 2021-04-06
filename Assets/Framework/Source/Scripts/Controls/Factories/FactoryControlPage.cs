using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControlPage", menuName = "Factories/Controls/Page/Default")]
    public class FactoryControlPage : FactoryControl
    {
        [SerializeField]        
        private FactoryPage factoryPage;
        
        public override IControl GetControl()
        {
            var instance = Get<ControlPageDefault>("Control: Page", PARENT_SCENEOBJECT_NAME);
            instance.SetPages(factoryPage);

            return instance;

        }
    }
}
