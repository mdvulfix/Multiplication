using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    
    public interface IBuilder: IDebug, IHasCache<ICacheable>, ICacheable
    {
        
        void OnAwake();  
    }
    
    public abstract class Builder : Singleton<Builder>, IBuilder
    {
        protected static readonly string OBJECT_NAME_BUILDER = "Builder";
        protected static readonly string OBJECT_NAME_CONTROLLERS = "Controllers";
        protected static readonly string OBJECT_NAME_SESSIONS = "Sessions";
        protected static readonly string OBJECT_NAME_SCENE = "Scene";
        protected static readonly string OBJECT_NAME_UI = "UI";
        
        public bool                 UseDebug    {get; set;} = true;
        public IDataStats           DataStats   {get; }
        
        public ICache<ICacheable>   Cache       {get; protected set;} = new Cache<ICacheable>();       
        
        public void Awake()
        {            
            OnAwake();
        }
    
        public virtual void OnAwake()
        {
            Initialize();


        }
        
        public abstract ICacheable Initialize();
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