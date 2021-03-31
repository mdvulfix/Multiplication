using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactoryControls: IFactory
    {
        T Get<T>() where T: SceneObject, IControl;
    }
    
    
    public class FactoryControls : Factory, IFactoryControls
    {

        private static readonly string PARENT_NAME = "Controls";
        
        private static HashSet<IControl> controls;
           
        public T Get<T>() where T: SceneObject, IControl
        {
            var obj = CreateGameObject(typeof(T).Name, PARENT_NAME);
            var instance = obj.AddComponent<T>();
            
            
            return instance;
        
        }

            
        private GameObject CreateGameObject(string name, string parent)
        {
            return HandlerSceneObject.Create(name, parent);

        }

    }
}