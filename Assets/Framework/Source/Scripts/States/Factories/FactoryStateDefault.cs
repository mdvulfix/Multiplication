using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "Factory State (Default)", menuName = "Factories/State/Default")]
    public class FactoryStateDefault : FactoryState
    {
        public override HashSet<IState> GetStates()
        {
            var states = new HashSet<IState>()
            {
                new StateInitialize(),
                new StateRunTime()


            };

            return states;
        }

    }
}
