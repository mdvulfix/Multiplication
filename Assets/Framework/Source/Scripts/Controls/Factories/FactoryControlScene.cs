using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControlScene", menuName = "Factories/Controls/Scene/Default")]
    public class FactoryControlScene : FactoryControl
    {
        [SerializeField]        
        private FactoryScene factoryScene;
        
        public override IControl GetControl()
        {
            var instance = Get<ControlSceneDefault>("Control: Scene", PARENT_SCENEOBJECT_NAME);
            instance.SetScenes(factoryScene);

            return instance;
        }

    }
}
