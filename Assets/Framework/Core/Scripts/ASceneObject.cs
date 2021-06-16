using System;
using UnityEngine;

namespace Core
{   
        
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
