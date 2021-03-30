using UnityEngine;

namespace Framework.Core
{
    public abstract class SceneObject : MonoBehaviour
    {
        public GameObject ObjectOnScene {get; private set;}
        
        private void Awake() 
        {
            ObjectOnScene = gameObject;
            OnAwake();
        
        }

        public abstract void OnEnable();
        
        
        public abstract void OnAwake();
        


    }

}
