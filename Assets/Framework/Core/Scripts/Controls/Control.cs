using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IControl
    {
        void OnInitialize();
        void OnUpdate();
    
    }     
    
    [Serializable]
    public abstract class Control : ScriptableObject, IControl 
    {
        [SerializeField]
        private bool debug;
        
        public abstract void OnInitialize();
        public abstract void OnUpdate();
            
   
        public void Log(string msg)
        {
                Debug.Log(msg);

        }

        public void LogWarning(string msg)
        {
                Debug.LogWarning(msg);

        }
    
    

    
    
    
    
    }

}