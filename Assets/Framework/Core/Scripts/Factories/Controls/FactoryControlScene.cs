using System;
using UnityEngine;

namespace Framework.Core
{   
    [Serializable]
    public abstract class FactoryControlScene : FactoryControl
    {
        [SerializeField]        
        private FactoryScene factoryScene;
        
        public override T Get<T>() 
        {
            var obj = CreateSceneObject(typeof(T).Name, PARENT_NAME);
            var instance = obj.AddComponent<T>() as IControlScene;
            
            instance.SetScenes(factoryScene);
            
            return instance as T;
        }
        


    }
}
