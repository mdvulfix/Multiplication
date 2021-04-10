using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    
    public interface IBuilder: IConfigurable, IHasCache<ICacheable>, ICacheable, IDebug
    {
        
        void OnAwake();  
    }
    
    public abstract class Builder : Singleton<Builder>, IBuilder
    {
        public static readonly string OBJECT_NAME_BUILDER = "Builder";
        public static readonly string OBJECT_NAME_CONTROLLERS = "Controllers";
        public static readonly string OBJECT_NAME_SESSIONS = "Sessions";
        public static readonly string OBJECT_NAME_SCENE = "Scene";
        public static readonly string OBJECT_NAME_UI = "UI";
        
        public bool                 UseDebug    {get; set;} = true;
        public IDataStats           DataStats   {get; set;}
        
        public ICache<ICacheable>   Cache       {get; protected set;} = new Cache<ICacheable>();       
        
        public void Awake()
        {            
            OnAwake();
        }
    
        public virtual void OnAwake()
        {
            Initialize();


        }
        
        public abstract void Initialize();
        public abstract ICacheable Configure();

#region SetToCache

        public ICacheable SetToCache(ICacheable instance)
        {
            Cache.Add(instance);
            return instance;
        
        }   

        public void SetToCache(List<ICacheable> instances)
        {
            foreach (var instance in instances)
            {
                SetToCache(instance);
            }
        }

#endregion

#region FactoriesFunctions
        
        protected List<ICacheable> GetInstancesFormFactory(IFactory factory)
        {
            return factory.Get<ICacheable>();
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