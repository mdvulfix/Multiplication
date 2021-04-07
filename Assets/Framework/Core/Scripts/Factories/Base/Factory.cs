using UnityEngine;

namespace Framework.Core
{
    
    public interface IFactory
    {
        T Get<T>(string name, string parent = null, GameObject prefab = null) where T: SceneObject;
    }

    public abstract class Factory: ScriptableObject, IFactory
    {       
        public virtual T Get<T>(string name, string parent = null, GameObject prefab = null) where T: SceneObject
        {

            var obj = CreateSceneObject(name, parent, prefab);
            var instance = obj.AddComponent<T>();
            
            return instance as T;
        }

        protected GameObject CreateSceneObject(string name, string parent, GameObject prefab)
        {
            return HandlerSceneObject.Create(name, parent, prefab);

        }
    
    
    }
}