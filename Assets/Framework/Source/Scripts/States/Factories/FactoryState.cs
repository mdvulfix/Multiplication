using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryState", menuName = "Factories/State/Default")]
    public class FactoryState : AFactory<IState>
    {
        public override List<IState> Get()
        {
            var list = new List<IState>()
            {
                GetAndInitialize<StateInitialize>(StateInitialize.OBJECT_NAME),
                GetAndInitialize<StateLogin>(StateLogin.OBJECT_NAME),
                GetAndInitialize<StateRunTime>(StateRunTime.OBJECT_NAME)
            };

            return list;
        }
        
        private IState GetAndInitialize<T>(string name) where T: AState, new()
        {
            var instance = GetInstanceOfSimpleObject<T>(name);
            instance.Initialize();
            return instance;
        }
    }
}
