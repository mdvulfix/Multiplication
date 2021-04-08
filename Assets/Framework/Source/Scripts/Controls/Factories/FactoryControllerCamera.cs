using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerCamera", menuName = "Factories/Controllers/Camera/Default")]
    public class FactoryControllerCamera : FactoryController
    {

        public override IController GetControl()
        {
            return Get<ControllerCameraDefault>("Controller: Camera", PARENT_SCENEOBJECT_NAME);

        }

    }
}
