using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class ControllerCameraDefault : ControllerCamera
    {
        private readonly string SCENEOBJECT_NAME = "Controller: Camera";
        
        private Camera cameraMain;
        
        public override void Configure()
        {
            //base.Initialize(SCENEOBJECT_NAME);
            cameraMain = ObjectOnScene.AddComponent<Camera>();
            cameraMain.clearFlags = CameraClearFlags.SolidColor;
            cameraMain.backgroundColor = Color.cyan;
            cameraMain.orthographic = true;

        }
    }
}
