using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryData", menuName = "Factories/Data/Default")]
    public class FactoryData : AFactory<IData>
    {
        public override List<IData> Get()
        {
            var list = new List<IData>();
            


            return list;
        }
    
    
    
    }
}
