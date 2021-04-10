using System.Collections.Generic;
using UnityEngine;


namespace Framework.Core
{
    
    public interface IFactory: IScriptableObject, IDebug
    {
        T GetInstanceOf<T>(string name, string parent = null, GameObject prefab = null) 
            where T: SceneObject, ICacheable;

        T GetInstanceOf<T>(string label) 
            where T: SimpleObject, ICacheable, new();
        
        List<T> Get<T>()
            where T: class, ICacheable;
    }

    public abstract class Factory: ScriptableObject, IFactory
    {       
        public string   Label       {get; set;} 
        public bool     UseDebug    {get; set;} = true;      
        
        public virtual T GetInstanceOf<T>(string label, string parent = null, GameObject prefab = null) 
            where T: SceneObject, ICacheable
        {
            var obj = CreateSceneObject(label, parent, prefab);
            var instance = obj.AddComponent<T>();
            
            return instance as T;
        }
        
        public virtual T GetInstanceOf<T>(string label) 
            where T: SimpleObject, ICacheable, new()
        {
            var instance = new T();
            instance.Label = label;
            
            return instance as T;
        }

        public abstract List<T> Get<T>()
            where T: class, ICacheable;

        protected GameObject CreateSceneObject(string name, string parent, GameObject prefab)
        {
            return HandlerSceneObject.Create(name, parent, prefab);

        }

#region DebugFunctions

        public virtual void Log(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
                
        }

        public virtual void LogWarning(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.LogWarning("["+ instance +"]: " + message);
            }
        }

#endregion
    
    
    }
}