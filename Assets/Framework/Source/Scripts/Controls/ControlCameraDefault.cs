using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class ControlCameraDefault : ControlCamera
    {

        private Camera cameraMain;
        
        public override void Configure()
        {
            base.Initialize();

            cameraMain = ObjectOnScene.AddComponent<Camera>();
            cameraMain.clearFlags = CameraClearFlags.SolidColor;
            cameraMain.backgroundColor = Color.cyan;
            cameraMain.orthographic = true;

        }
    }
}
