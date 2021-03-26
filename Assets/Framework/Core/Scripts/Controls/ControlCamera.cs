using UnityEngine;
using Framework.Core;

namespace Framework 
{
    [CreateAssetMenu(fileName = "Camera(Default)", menuName = "Controls/Camera", order = 1)]
    public class ControlCamera : AControl
    {
        [SerializeField]
        private GameObject mainCamera;
                
        
        public override void OnAwake() 
        {      
            
            
        }

        public override void OnUpdate() 
        {

        
        }

        public void SetMainCamera()
        {
            

        }



    }


}
