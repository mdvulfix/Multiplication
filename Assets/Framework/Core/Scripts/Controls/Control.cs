using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IControl
    {
        void Configure();
    
    }     
    
    [Serializable]
    public abstract class Control : SceneObject, IControl 
    {
        [SerializeField]
        private bool debug;
        
        
        
        
        public abstract void Configure();

        
        protected void Log(string msg)
        {
            Debug.Log(msg);

        }

        protected void LogWarning(string msg)
        {
            Debug.LogWarning(msg);

        }
    
    

    
    
    
    
    }

}