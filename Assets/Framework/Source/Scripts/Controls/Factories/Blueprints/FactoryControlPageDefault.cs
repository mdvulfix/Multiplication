using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "Factory ControlPage (Default)", menuName = "Factories/Controls/Page/Default")]
    public class FactoryControlPageDefault : FactoryControlPage
    {

        public IControlPage GetControl()
        {
            return Get<ControlPageDefault>();

        }

    }
}
