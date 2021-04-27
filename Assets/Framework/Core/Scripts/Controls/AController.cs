using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IController<T>: IController, IHaveCache<T> 
        where T: class, ICacheable
    {   

    }     

    public abstract class AController<T> : AController, IController<T>  
        where T: class, ICacheable
    {                
        public ICache<T> Cache {get; protected set;} = new Cache<T>("Controller: Cache");  
          
#region Cache

        public void GetCache(ICache<T> cache)
        {
            Cache = cache;
        }
        
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
    
    public interface IController: ISceneObject, IConfigurable, IDebug
    {   
        ISession Session {get; }
    }  

    [Serializable]
    public abstract class AController : ASceneObject, IController  
    {

        public bool         UseDebug    {get; set;} = true;
        
        public ISession     Session     {get => session; set => session = value as Session;}
        public IDataStats   Stats       {get => dataStats; set => dataStats = value as DataStats;}

        
        [SerializeField] protected bool isProject;
        [SerializeField] protected Session session;
        
        [Header("Data")]
        [SerializeField] protected DataStats dataStats;


#region Configure
        
        
        public virtual void SetParams(string label)
        {
            Label = label;
        }
        
        public abstract void Initialize();
        public abstract IConfigurable Configure();

#endregion

#region Logs

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

        protected string LogSuccessfulInitialize()
        {
            return "Initialization process was successfully finished!";
        }

        protected string LogSuccessfulConfigure()
        {
            return "Configuration process was successfully finished!";
        }
        
        protected string LogFailedInitialize(string reason = null)
        {
            return "Initialization process was failed! " + reason;
        }

        protected string LogFailedConfigure(string reason = null)
        {
            return "Configuration process was failed! " + reason;
        }

#endregion

    } 
    

}