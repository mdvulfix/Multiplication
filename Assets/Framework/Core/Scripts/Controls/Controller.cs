using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IController: ICacheable, IDebug
    {
        void Initialize();
        void Configure();
    }     
    
    [Serializable]
    public abstract class Controller : SceneObject, IController
    {
        public bool UseDebug{get; set;} = true;
                
        
 #region Configure
        
        public abstract void Initialize();
        public abstract void Configure();

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