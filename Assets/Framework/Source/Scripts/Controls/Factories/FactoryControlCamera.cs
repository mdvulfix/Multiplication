using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControlCamera", menuName = "Factories/Controls/Camera/Default")]
    public class FactoryControlCamera : FactoryControl
    {

        public override IControl GetControl()
        {
            return Get<ControlCameraDefault>("Control: Camera", PARENT_SCENEOBJECT_NAME);

        }

    }
}
