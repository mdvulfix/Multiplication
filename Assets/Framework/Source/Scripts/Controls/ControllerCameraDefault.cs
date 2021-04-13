using UnityEngine;
using Framework.Core;

namespace Framework
{
    /*
    public class ControllerCameraDefault : AControllerCamera
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
