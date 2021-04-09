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

        public override IController Get()
        {
            var instance = GetInstanceOf<ControllerStateDefault>("Controller: State", Controller.PARENT_OBJECT_NAME).Initialize() as ControllerState;
            //instance.SetStates(factoryState);

            return instance;

        }

    }
}
