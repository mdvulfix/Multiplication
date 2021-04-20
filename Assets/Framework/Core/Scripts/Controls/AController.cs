using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IController<T>: IController, IHaveCache<T> 
        where T: class, ICacheable
    {   

    }     
    
    [Serializable]
    public abstract class AController<T> : AController, IController<T>  
        where T: class, ICacheable
    {                
        public ICache<T> Cache {get; protected set;} = new Cache<T>();  
          
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
    
    } 
    
///////////////////////////////////////////////////////////////////////////////////////////////// 
    
    public interface IController: IConfigurable, IDebug
    {   
        ISession Session {get; }
    }  

    [Serializable]
    public abstract class AController : ASceneObject, IController  
    {

        public bool         UseDebug    {get; set;} = true;
        
        public ISession     Session     {get => session; set => session = value as Session;}
        public IDataStats   DataStats   {get; set;}

        
        [SerializeField] protected bool isProject;
        [SerializeField] protected Session session;

#region Configure
        
        public abstract void Initialize();
        public abstract IConfigurable Configure();

#endregion

#region Debug

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