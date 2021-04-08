using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IController: ICacheable
    {
        void Configure();
    
        void Log(string controller, string message);
        void LogWarning(string controller, string message);
    }     
    
    [Serializable]
    public abstract class Controller : SceneObject, IController
    {
        [SerializeField]
        private bool debug;
                
        
 #region Configure
        
        public abstract void Configure();

#endregion   
    
#region LogFunctions

        public virtual void Log(string controller, string message)
        {
            Debug.Log("["+ controller +"]: " + message);
        }

        public virtual void LogWarning(string controller, string message)
        {
            Debug.LogWarning("["+ controller +"]: " + message);
        }

#endregion
    }
}