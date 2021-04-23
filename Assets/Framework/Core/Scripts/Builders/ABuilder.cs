using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    
    public interface IBuilder: IAwakable, IConfigurable, IDebug, IHaveFactory, IHaveCache<IConfigurable>
    {
        
    }
    
    public abstract class ABuilder : ASingleton<ABuilder>, IBuilder
    {
        public static readonly string OBJECT_NAME_BUILDER = "Builder";
        public static readonly string OBJECT_NAME_CONTROLLERS = "Controllers";
        public static readonly string OBJECT_NAME_SESSIONS = "Sessions";
        public static readonly string OBJECT_NAME_SCENE = "Scene";
        public static readonly string OBJECT_NAME_UI = "UI";
        
        public bool                     UseDebug    {get; set;} = true;
        public IDataStats               DataStats   {get; set;}
        
        public ICache<IConfigurable>    Cache       {get; protected set;} = new Cache<IConfigurable>("Builder: Cache");       

#region Configure
        
        public virtual void SetParams(string label)
        {
            Label = label;
        }

        public abstract void Initialize();
        public abstract IConfigurable Configure();

#endregion

#region Start&Update
        
        public void Awake()
        {
            OnAwake();
        }

        public abstract void OnAwake();

#endregion
        
#region Cache

        public void GetCache(ICache<IConfigurable> cache)
        {
            Cache = cache;

        }

        public IConfigurable SetToCache(IConfigurable instance)
        {
            Cache.Add(instance);
            return instance;
        
        }   

        public List<IConfigurable> SetToCache(List<IConfigurable> instances)
        {
            foreach (var instance in instances)
            {
                SetToCache(instance);
            }
            return instances;
        }

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

#region Factories

        public IFactory<TCacheable> GetFactory<TCacheable>(IFactory<TCacheable> factory) 
            where TCacheable: class, ICacheable
        {
           if(factory==null)
           {
               LogWarning(Label, "Factory [" + typeof(TCacheable)+ "] is not set!");
               return null;
           }
           
            factory.Initialize();
            return factory;
        }

#endregion 
    
    }
}