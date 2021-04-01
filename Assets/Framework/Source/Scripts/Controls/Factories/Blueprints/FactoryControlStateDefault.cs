using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "Factory ControlState (Default)", menuName = "Factories/Controls/State/Default")]
    public class FactoryControlStateDefault : FactoryControlState
    {

        public IControlState GetControl()
        {
            return Get<ControlStateDefault>();

        }

    }
}
