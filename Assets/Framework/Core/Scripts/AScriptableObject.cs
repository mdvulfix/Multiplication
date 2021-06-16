using System;
using UnityEngine;

namespace Core
{   
    [Serializable]
    public abstract class AScriptableObject : ScriptableObject
    {   
        public string Label {get; private set;}
       
        public virtual void SetSceneObject(string label)
        {
            Label = label;
        }
    }
}
