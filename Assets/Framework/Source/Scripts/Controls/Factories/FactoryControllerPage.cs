using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerPage", menuName = "Factories/Controllers/Page/Default")]
    public class FactoryControllerPage : AFactory<IControllerPage>
    {
        [SerializeField]        
        private FactoryPage factoryPage;
        
        public override List<IControllerPage> Get()
        {
            var list = new List<IControllerPage>()
            {
                GetAndInitialize<ControllerPageDefault>("Controller: Page")
            };

            return list;
        }


        private IControllerPage GetAndInitialize<T>(string label) where T: AControllerPage
        {
            var instance = GetInstanceOfSceneObject<T>(label, ABuilder.OBJECT_NAME_CONTROLLERS);
            instance.Initialize();

            var pages = factoryPage.Get();
            instance.SetToCache(pages);
            return instance;
        
        }

    }
}
