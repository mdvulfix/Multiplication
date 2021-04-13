using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerScene", menuName = "Factories/Controllers/Scene/Default")]
    public class FactoryControllerScene : AFactory<IControllerScene>
    {
        [SerializeField]        
        private FactoryScene factoryScene;
        
        public override List<IControllerScene> Get()
        {
            var list = new List<IControllerScene>()
            {
                GetAndInitialize<ControllerSceneDefault>(ControllerSceneDefault.OBJECT_NAME, factoryScene)
            };

            return list;
        }

        private IControllerScene GetAndInitialize<T>(string label, IFactory<IScene> factory) 
            where T: AControllerScene
        {
            var instance = GetInstanceOfSceneObject<T>(label, ABuilder.OBJECT_NAME_CONTROLLERS);
            instance.Initialize();

            if(factory==null)
            {
               LogWarning(Label, "Factory [" + typeof(IScene)+ "] was not found!");
               return null;
            }

            var scenes = factory.Get();

            instance.SetToCache(scenes);
            return instance;
        
        }
    }
}
