using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    
    public interface IBuilder: IConfigurable, ICacheable, IDebug, IHaveFactory
    {
        
        void OnAwake();  
    }
    
    public abstract class ABuilder : ASingleton<ABuilder>, IBuilder
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
        public abstract IConfigurable Configure();

#region Cache

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