using System;
using UnityEngine;

namespace Framework.Core
{   
    [Serializable]
    public abstract class FactoryControlPage : FactoryControl
    {
        [SerializeField]        
        private FactoryPage factoryPage;
        
        public override T Get<T>() 
        {
            var obj = CreateSceneObject(typeof(T).Name, PARENT_NAME);
            var instance = obj.AddComponent<T>() as IControlPage;
            
            instance.SetPages(factoryPage);
            
            return instance as T;
        }
        


    }
}
