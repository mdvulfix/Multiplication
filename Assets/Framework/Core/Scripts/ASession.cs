using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core 
{
    
    public interface ISession: IAwakable, IUpdatable, IConfigurable, IDebug, IHaveCache<IController>
    {

    }
    

    [Serializable]
    public abstract class ASession : ASceneObject, ISession
    {
        public static readonly string PARENT_OBJECT_NAME = ABuilder.OBJECT_NAME_SESSIONS; 
        
        public bool                 IsProject {get => isProject;  set => isProject = value; }
        public bool                 UseDebug  {get; set;} = true;        
        public IDataStats           DataStats {get; set;}
        public ICache<IController>  Cache     {get; protected set;} = new Cache<IController>(); 

        [SerializeField] private bool isProject;

#region Configure
        
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

#region Cache

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