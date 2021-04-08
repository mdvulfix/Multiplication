using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    
    public interface IBuilder: IDebug
    {
        Dictionary<Type, IController> Controls {get; }
        Dictionary<Type, ISession> Sessions {get; }
        
        void OnAwake();        
    }
    
    
    public abstract class Builder : Singleton<Builder>, IBuilder
    {
        
        public bool UseDebug {get; set;} = true;
        
        protected readonly string SCENEOBJECT_NAME = "Builder";
        
        public Dictionary<Type, IController> Controls {get; private set;}
        public Dictionary<Type, ISession> Sessions {get; private set;}
        
        public void Awake()
        { 
            Controls = new Dictionary<Type, IController>(15);
            Sessions = new Dictionary<Type, ISession>(1);
            
            OnAwake();
        }
    
        public abstract void OnAwake();
        public abstract void Configure();


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