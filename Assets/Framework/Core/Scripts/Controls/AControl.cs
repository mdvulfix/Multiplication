using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IControl: ICacheable
    {
        
    
    }     
    
    [Serializable]
    public abstract class AControl : ScriptableObject, IControl 
    {
        [SerializeField]
        private bool debug;
        
        
        public abstract void OnAwake();
        public abstract void OnUpdate();
    
    
    
    #region Public functions
        
   
        public void Log(string msg)
        {
            if(debug)
                Debug.Log(msg);

        }

        public void LogWarning(string msg)
        {
            if(debug)
                Debug.LogWarning(msg);

        }
    
    
    #endregion
    
    
    
    
    }

}