using System;
using UnityEngine;

namespace Framework.Core
{   
    
    public interface ISceneObject
    {   
        string      Label           {get; }
    }
    
    [Serializable]
    public abstract class ASceneObject : MonoBehaviour
    {   
        public string       Label           {get; private set;}
       
      
        public virtual void SetParams(string label)
        {
            Label = label;
        }

        public bool ActivateObject(bool activate)
        {
            gameObject.SetActive(activate);
            return activate;
        }
    }

}
