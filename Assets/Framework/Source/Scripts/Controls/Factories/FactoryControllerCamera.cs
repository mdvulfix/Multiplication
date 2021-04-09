using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerCamera", menuName = "Factories/Controllers/Camera/Default")]
    public class FactoryControllerCamera : FactoryController
    {

        public override IController Get()
        {
            return GetInstanceOf<ControllerCameraDefault>("Controller: Camera", Controller.PARENT_OBJECT_NAME).Initialize() as ControllerCamera;

        }

    }
}
