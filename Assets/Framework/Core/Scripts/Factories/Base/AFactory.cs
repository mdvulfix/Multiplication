using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core.Handlers;

namespace Framework.Core
{
    
    public interface IFactory<TCacheable>: IScriptableObject, IConfigurable, IDebug
        where TCacheable: ICacheable
    {
        TSceneObject GetInstanceOf<TSceneObject>(string label, GameObject objParent = null, GameObject objPrefab = null) 
            where TSceneObject: ASceneObject, TCacheable;

        TSimpleObject GetInstanceOf<TSimpleObject>(string label) 
            where TSimpleObject: ASimpleObject, TCacheable, new();
            
        List<TCacheable> Get();
        
        //IDataStruct<TCacheable> Get(TCacheable instance);
        
        TData SetData<TData>(string label, GameObject objParent = null, GameObject objPrefab = null)
            where TData: ASceneObject, IData;
    
    }

    public abstract class AFactory<TCacheable>: AScriptableObject, IFactory<TCacheable>
        where TCacheable: ICacheable
    {      
        
        
        public bool         UseDebug    {get; set;} = true;  
        public IDataStats   Stats   {get; set;}    
        
        
#region Configure
        
        public abstract void Initialize();
        public abstract IConfigurable Configure();

#endregion   
            
#region Get
        
        public virtual TSceneObject GetInstanceOf<TSceneObject>(string label, GameObject objParent = null, GameObject objPrefab = null) 
            where TSceneObject: ASceneObject, TCacheable
        {           
            return HandlerSceneObject.Create<TSceneObject>(label, objParent, objPrefab);
        }

        public GameObject FindSceneObjectByName(string label) 
        {
            var obj = HandlerSceneObject.Find(label);
            if(obj == null)
            {
                LogWarning(label, "Game object was not found by name [" + label + "]");
                return null;
            }

            return obj;
        }

        public virtual TSimpleObject GetInstanceOf<TSimpleObject>(string label) 
            where TSimpleObject: ASimpleObject, TCacheable, new()
        {
            return HandlerSimpleObject.Create<TSimpleObject>(label);
        }
        
        public virtual TData SetData<TData>(string label, GameObject objParent = null, GameObject objPrefab = null)
            where TData: ASceneObject, IData
        {
            return HandlerSceneObject.Create<TData>(label, objParent, objPrefab);
        }

        public abstract List<TCacheable> Get();

#endregion 

#region Data

        //public abstract IDataStruct<TCacheable> Get(TCacheable instance);

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