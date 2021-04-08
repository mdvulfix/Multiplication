using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class ControllerCameraDefault : ControllerCamera
    {
    
        private Camera cameraMain;
        
        
        public override void Initialize()
        {
            SetSceneObject(SCENEOBJECT_NAME);
            Log(Label, "was sucsessfully initialized");

        } 
         
        public override void Configure()
        {
            
            cameraMain = ObjectOnScene.AddComponent<Camera>();
            cameraMain.clearFlags = CameraClearFlags.SolidColor;
            cameraMain.backgroundColor = Color.cyan;
            cameraMain.orthographic = true;

            Log(Label, "was successfully configured.");
        
        }
    }
}
