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
                GetAndInitialize<ControllerPageDefault>(ControllerPageDefault.OBJECT_NAME, factoryPage)
            };

            return list;
        }


        private IControllerPage GetAndInitialize<T>(string label, IFactory<IPage> factory) 
            where T: AControllerPage
        {
            var instance = GetInstanceOfSceneObject<T>(label, ABuilder.OBJECT_NAME_CONTROLLERS);
            instance.Initialize();

            if(factory==null)
            {
               LogWarning(Label, "Factory [" + typeof(IPage)+ "] was not found!");
               return null;
            }

            var pages = factory.Get();

            instance.SetToCache(pages);
            return instance;
        
        }

    }
}
