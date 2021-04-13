using System;
using System.Collections.Generic;
using UnityEngine;


namespace Framework.Core
{
    
    public interface IFactory<TCacheable>: IScriptableObject, IDebug
        where TCacheable: ICacheable
    {
        T GetInstanceOfSceneObject<T>(string name, string parent = null, GameObject prefab = null) 
            where T: ASceneObject, TCacheable;

        T GetInstanceOfSimpleObject<T>(string label) 
            where T: ASimpleObject, TCacheable, new();
            
        List<TCacheable> Get();
        TData Get<TData>(string label)
            where TData: ASimpleObject, TCacheable, IData, new();
    
    }

    public abstract class AFactory<TCacheable>: ScriptableObject, IFactory<TCacheable>
        where TCacheable: ICacheable
    {       
        public string   Label       {get; set;} 
        public bool     UseDebug    {get; set;} = true;      
        
        public virtual T GetInstanceOfSceneObject<T>(string label, string parent = null, GameObject prefab = null) 
            where T: ASceneObject,  TCacheable 
        {
            var obj = HandlerSceneObject.Create(label, parent, prefab);
            var instance = obj.AddComponent<T>();
            
            return instance as T;
        }
        
        public virtual T GetInstanceOfSimpleObject<T>(string label) 
            where T: ASimpleObject, TCacheable, new()
        {
            var instance = new T();
            instance.Label = label;
            
            return instance as T;
        }

        public abstract List<TCacheable> Get();
        
        public TData Get<TData>(string label)
            where TData: ASimpleObject, TCacheable, IData, new()
        {
            var data = GetInstanceOfSimpleObject<TData>(label);
            
            
            return data;
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