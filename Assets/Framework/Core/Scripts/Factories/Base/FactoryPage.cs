using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactoryPage: IFactory
    {
        HashSet<IPage> GetPages();
        T Get<T>() where T: SceneObject, IPage;
    }
    
    public abstract class FactoryPage : Factory, IFactoryPage
    {

        protected static readonly string PARENT_NAME = "Builder";

        public T Get<T>() where T: SceneObject, IPage
        {
            var obj = CreateSceneObject(typeof(T).Name, PARENT_NAME);
            var instance = obj.AddComponent<T>();
            
            return instance as T;
        }

        public abstract HashSet<IPage> GetPages();

    }
}
