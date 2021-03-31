using UnityEngine;

namespace Framework.Core
{
    public class SceneObject : MonoBehaviour
    {
        public GameObject ObjectOnScene {get; private set;}
        
        private void Awake() 
        {
            ObjectOnScene = gameObject;
            OnAwake();
        
        }
        
        public virtual void OnAwake()
        {


        }




    }

}
