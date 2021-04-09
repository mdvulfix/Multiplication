using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IController: ICacheable, IDebug
    {

    }     
    
    [Serializable]
    public abstract class Controller : SceneObject, IController
    {        
        public bool         UseDebug    {get; set;} = true;
        public IDataStats   DataStats   {get; }
                
        
 #region Configure
        
        public abstract ICacheable Initialize();
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