using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryData", menuName = "Factories/Data")]
    public class FactoryData : Factory
    {
        public override List<IData> Get<IData>()
        {
            var list = new List<IData>();
            


            return list;
        }
    
    
    
    }
}
