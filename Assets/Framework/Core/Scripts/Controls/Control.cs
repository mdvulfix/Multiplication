using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IControl
    {
        void Initialize();
    
    }     
    
    [Serializable]
    public abstract class Control : SceneObject, IControl 
    {
        [SerializeField]
        private bool debug;
        
        public abstract void Initialize();

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