using System;
using UnityEngine;

namespace Framework.Core
{   
    [Serializable]
    public abstract class SceneObject : MonoBehaviour
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
