using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerState", menuName = "Factories/Controllers/State/Default")]
    public class FactoryControllerState : FactoryController
    {
        [SerializeField]        
        private FactoryState factoryState;

        public override IController GetControl()
        {
            var instance = Get<ControllerStateDefault>("Controller: State", PARENT_SCENEOBJECT_NAME);
            instance.SetStates(factoryState);

            return instance;

        }

    }
}
