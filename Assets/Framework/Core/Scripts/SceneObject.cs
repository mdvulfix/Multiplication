using System;
using UnityEngine;

namespace Framework.Core
{
    public abstract class SceneObject : MonoBehaviour
    {
        public GameObject ObjectOnScene {get; private set;}
       
        public virtual void Initialize()
        {
            ObjectOnScene = gameObject;
        
        }


    }

}
