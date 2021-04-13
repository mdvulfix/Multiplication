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
                GetAndInitialize<ControllerStateDefault>(ControllerStateDefault.OBJECT_NAME, factoryState)
            };

            return list;
        }
        
        private IControllerState GetAndInitialize<T>(string label, IFactory<IState> factory) 
            where T: AControllerState
        {
            var instance = GetInstanceOfSceneObject<T>(label, ABuilder.OBJECT_NAME_CONTROLLERS);
            instance.Initialize();

            if(factory==null)
            {
               LogWarning(Label, "Factory [" + typeof(IState)+ "] was not found!");
               return null;
            }

            var states = factory.Get();

            instance.SetToCache(states);
            return instance;
        
        }        
    }
}
