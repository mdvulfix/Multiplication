using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "Factory ControlCamera (Default)", menuName = "Factories/Controls/Camera/Default")]
    public class FactoryControlCameraDefault : FactoryControlCamera
    {

        public IControlCamera GetControl()
        {
            return Get<ControlCameraDefault>();

        }

    }
}
