using System;
using UnityEngine;

namespace Framework.Core
{   
    
    public interface ISceneObject
    {   
        string Label {get; }
    }
    
    [Serializable]
    public abstract class ASceneObject : MonoBehaviour
    {   
        public string Label {get; protected set;}
               
        public bool SetActvie(bool activate)
        {
            gameObject.SetActive(activate);
            return activate;
        }
    }

}
