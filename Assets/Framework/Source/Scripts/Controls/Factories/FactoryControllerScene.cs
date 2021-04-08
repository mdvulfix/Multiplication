using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerScene", menuName = "Factories/Controllers/Scene/Default")]
    public class FactoryControllerScene : FactoryController
    {
        [SerializeField]        
        private FactoryScene factoryScene;
        
        public override IController GetControl()
        {
            var instance = Get<ControllerSceneDefault>("Controller: Scene", PARENT_SCENEOBJECT_NAME);
            instance.SetScenes(factoryScene);

            return instance;
        }

    }
}
