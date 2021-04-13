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
                GetAndInitialize<ControllerSceneDefault>("Controller: Scene")
            };

            return list;
        }


        private IControllerScene GetAndInitialize<T>(string label) where T: AControllerScene
        {
            var instance = GetInstanceOfSceneObject<T>(label, ABuilder.OBJECT_NAME_CONTROLLERS);
            instance.Initialize();

            var scenes = factoryScene.Get();
            instance.SetToCache(scenes);
            return instance;
        
        }
    }
}
