using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core.Handlers;

namespace Framework.Core
{
    
    public interface IFactory<TCacheable>: IScriptableObject, IConfigurable, IDebug
        where TCacheable: ICacheable
    {
        TSceneObject GetInstanceOf<TSceneObject>(string label, string parent = null, GameObject prefab = null) 
            where TSceneObject: ASceneObject, TCacheable;

        TSimpleObject GetInstanceOf<TSimpleObject>(string label) 
            where TSimpleObject: ASimpleObject, TCacheable, new();
            
        List<TCacheable> Get();
        
        //TData GetData<TData>(string label)
        //    where TData: ASimpleObject, IData, new();
    
    }

    public abstract class AFactory<TCacheable>: AScriptableObject, IFactory<TCacheable>
        where TCacheable: ICacheable
    {      
        public bool     UseDebug    {get; set;} = true;      
        
        
#region Configure
        
        public abstract void Initialize();
        public abstract IConfigurable Configure();

#endregion   
            
#region GetFunctions
        
        public virtual TSceneObject GetInstanceOf<TSceneObject>(string label, string parent = null, GameObject prefab = null) 
            where TSceneObject: ASceneObject, TCacheable
        {
            return HandlerSceneObject.Create<TSceneObject>(label, parent, prefab);
        }
        
        public virtual TSimpleObject GetInstanceOf<TSimpleObject>(string label) 
            where TSimpleObject: ASimpleObject, TCacheable, new()
        {
            return HandlerSimpleObject.Create<TSimpleObject>(label);
        }
        
        /*
        public virtual TData GetData<TData>(string label)
            where TData: ASimpleObject, IData, new()
        {
            return HandlerSimpleObject.Create<TData>(label);
    
        }
        */
        public abstract List<TCacheable> Get();

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