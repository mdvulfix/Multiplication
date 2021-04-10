using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryState", menuName = "Factories/State")]
    public class FactoryState : Factory
    {
        public override List<IState> Get<IState>()
        {
            var list = new List<IState>()
            {
                (IState)GetInstanceOf<StateInitialize>("State: Initialize").Initialize(),
                (IState)GetInstanceOf<StateLogin>("State: Login").Initialize(),
                (IState)GetInstanceOf<StateRunTime>("State: RunTime").Initialize()
            };

            return list;
        }

    }
}
