using UnityEngine;
using Core.Camera.Controller;

namespace Source.Camera.Controller
{
    /*
    public class CameraControllerDefault : ACameraController
    {
    
        private Camera cameraMain;
        
        
        public override IConfigurable Initialize()
        {
            SetSceneObject(ControllerCamera.OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            return this;
        } 
         
        public override IConfigurable Configure()
        {
            
            cameraMain = AObjectOnScene.AddComponent<Camera>();
            cameraMain.clearFlags = CameraClearFlags.SolidColor;
            cameraMain.backgroundColor = Color.cyan;
            cameraMain.orthographic = true;

            Log(Label, "was successfully configured.");
            return this;
        
        }
    }
    */
}
