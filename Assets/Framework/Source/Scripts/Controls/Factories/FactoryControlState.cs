using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControlState", menuName = "Factories/Controls/State/Default")]
    public class FactoryControlState : FactoryControl
    {
        [SerializeField]        
        private FactoryState factoryState;

        public override IControl GetControl()
        {
            var instance = Get<ControlStateDefault>("Control: State", PARENT_SCENEOBJECT_NAME);
            instance.SetStates(factoryState);

            return instance;

        }

    }
}
