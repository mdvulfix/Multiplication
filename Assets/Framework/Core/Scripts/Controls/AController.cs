using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IController<T>: IConfigurable, ICacheable, IDebug where T: class, ICacheable
    {   
        ICache<T> Cache {get; }
        T SetToCache(T instance);
        List<T> SetToCache(List<T> instances);

    }     
    
    [Serializable]
    public abstract class AController<T> : ASceneObject, IController<T>  where T: class, ICacheable
    {                
        public bool         UseDebug    {get; set;} = true;
        public IDataStats   DataStats   {get; set;}
        public ICache<T>    Cache       {get; protected set;} = new Cache<T>();  
        
 #region Configure
        
        public abstract void Initialize();
        public abstract IConfigurable Configure();

#endregion   

#region SetToCache

        public T SetToCache(T instance)
        {
            Cache.Add(instance);
            return instance;
        }

        public List<T> SetToCache(List<T> instances)
        {
            foreach (var instance in instances)
            {
                SetToCache(instance);
            }
            return instances;
        }

#endregion 
    
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