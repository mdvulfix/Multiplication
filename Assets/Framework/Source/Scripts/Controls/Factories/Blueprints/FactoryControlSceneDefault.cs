using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "Factory ControlScene (Default)", menuName = "Factories/Controls/Scene/Default")]
    public class FactoryControlSceneDefault : FactoryControlScene
    {

        public IControlScene GetControl()
        {
            return Get<ControlSceneDefault>();

        }

    }
}
