using System;
using UnityEngine;

namespace Framework.Core
{
    public interface ISceneObject
    {   
        GameObject   ObjectOnScene   {get; }
        string       Name            {get; }
    }
    
    
    public abstract class SceneObject : MonoBehaviour
    {
        public GameObject   ObjectOnScene   {get; private set;}
        public string       Name            {get; protected set;}
       
        public virtual void Initialize(string name)
        {
            ObjectOnScene = gameObject;
            Name = name;
        }

        public bool ActivateObject(bool activate)
        {
            ObjectOnScene.SetActive(activate);
            return activate;
        }


    }

}
