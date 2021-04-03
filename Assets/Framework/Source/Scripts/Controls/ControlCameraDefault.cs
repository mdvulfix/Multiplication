using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class ControlCameraDefault : ControlCamera
    {
        private readonly string PAGE_NAME = "Control: Camera";
        
        private Camera cameraMain;
        
        public override void Configure()
        {
            base.Initialize(PAGE_NAME);
            cameraMain = ObjectOnScene.AddComponent<Camera>();
            cameraMain.clearFlags = CameraClearFlags.SolidColor;
            cameraMain.backgroundColor = Color.cyan;
            cameraMain.orthographic = true;

        }
    }
}
