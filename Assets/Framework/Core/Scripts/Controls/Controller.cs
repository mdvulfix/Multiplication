using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IController: IConfigurable, ICacheable, IDebug
    {

    }     
    
    [Serializable]
    public abstract class Controller : SceneObject, IController
    {        
        public static readonly string PARENT_OBJECT_NAME = Builder.OBJECT_NAME_CONTROLLERS; 
        
        public bool         UseDebug    {get; set;} = true;
        public IDataStats   DataStats   {get; set;}
                
        
 #region Configure
        
        public abstract void Initialize();
        public abstract ICacheable Configure();

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