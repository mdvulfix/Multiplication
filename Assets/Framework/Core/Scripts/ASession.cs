using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core 
{
    
    public interface ISession: IAwakable, IUpdatable, IConfigurable, IDebug, IHaveCache<IController>
    {
        TController GetController<TController>() 
            where TController: IController;
    }
    

    [Serializable]
    public abstract class ASession : ASceneObject, ISession
    {
        public static readonly string PARENT_OBJECT_NAME = ABuilder.OBJECT_NAME_SESSIONS; 
        
        public bool                 UseDebug    {get; set;} = true;        
        public IDataStats           Stats       {get => dataStats; set => dataStats = value as DataStats;}
        public ICache<IController>  Cache       {get; protected set;} = new Cache<IController>("Session: Cache"); 

        [SerializeField] protected bool isProject;
        
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

#region Start&Update
        
        public void Awake()
        {
            if(isProject)
            {
                OnAwake();
            } 
        }

        public abstract void OnAwake();
        public abstract void OnStart();
        public abstract void OnUpdate();

#endregion

#region Controllers

        public TController GetController<TController>() 
            where TController: IController
        {
            return (TController)Cache.Get<TController>();
        }

#endregion


#region Cache

        public void GetCache(ICache<IController> cache)
        {
            Cache = cache;
        }

        public IController SetToCache(IController instance)
        {
            Cache.Add(instance);
            return instance;
        
        }   

        public List<IController> SetToCache(List<IController> instances)
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
    
    }


}