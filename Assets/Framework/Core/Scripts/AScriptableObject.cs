using System;
using UnityEngine;

namespace Framework.Core
{   
    
    public interface IScriptableObject
    {
        string Label{get; }
        
    
    
    }
    
    [Serializable]
    public abstract class AScriptableObject : ScriptableObject, IScriptableObject
    {   
        public string Label {get; private set;}
       

        public virtual void SetSceneObject(string label)
        {
            Label = label;
        }
    
    
    
    
    }

}
