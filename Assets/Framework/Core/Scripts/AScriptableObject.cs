using System;
using UnityEngine;

namespace Framework.Core
{   
    
    public interface IScriptableObject
    {
        string Label{get; set;}
        
    
    
    }
    
    [Serializable]
    public abstract class AScriptableObject : ScriptableObject, IScriptableObject
    {   
        public string Label {get; set;}
       

    }

}
