using System;
using UnityEngine;

namespace Framework.Core 
{
    
    public interface ISession: IDebug
    {
        void Initialize();
    }
    
    
    
    [Serializable]
    public abstract class Session : SceneObject, ISession
    {
        
        
        public bool UseDebug {get; set;} = true;
        
        public abstract void Initialize();

        
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