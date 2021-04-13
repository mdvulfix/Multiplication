using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerState", menuName = "Factories/Controllers/State/Default")]
    public class FactoryControllerState : AFactory<IControllerState>
    {
        [SerializeField]        
        private FactoryState factoryState;

        public override List<IControllerState> Get()
        {
            var list = new List<IControllerState>()
            {
                GetAndInitialize<ControllerStateDefault>("Controller: State")
            };

            return list;
        }

        private IControllerState GetAndInitialize<T>(string label) where T: AControllerState
        {
            var instance = GetInstanceOfSceneObject<T>(label, ABuilder.OBJECT_NAME_CONTROLLERS);
            instance.Initialize();

            var states = factoryState.Get();
            instance.SetToCache(states);
            return instance;
        
        }
    }
}
