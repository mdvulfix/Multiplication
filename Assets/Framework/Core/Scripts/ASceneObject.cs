using System;
using UnityEngine;

namespace Framework.Core
{   
    
    public interface ISceneObject
    {   
        GameObject  ObjectOnScene   {get; }
        string      Label           {get; }
    
        void SetSceneObject(string label);
    }
    
    [Serializable]
    public abstract class ASceneObject : MonoBehaviour
    {   
        public GameObject   ObjectOnScene   {get; private set;}
        public string       Label           {get; private set;}
       
      
        public virtual void SetSceneObject(string label)
        {
            ObjectOnScene = gameObject;
            Label = label;
        }

        public bool ActivateObject(bool activate)
        {
            ObjectOnScene.SetActive(activate);
            return activate;
        }
    }

}
