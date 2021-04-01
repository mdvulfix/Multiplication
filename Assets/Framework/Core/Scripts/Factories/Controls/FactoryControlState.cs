using System;
using UnityEngine;

namespace Framework.Core
{   
    [Serializable]
    public abstract class FactoryControlState : FactoryControl
    {
        [SerializeField]        
        private FactoryState factoryState;
        
        public override T Get<T>() 
        {
            var obj = CreateSceneObject(typeof(T).Name, PARENT_NAME);
            var instance = obj.AddComponent<T>() as IControlState;
            
            instance.SetStates(factoryState);
            
            return instance as T;
        }
        


    }
}
