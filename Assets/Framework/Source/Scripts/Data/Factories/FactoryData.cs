using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryData", menuName = "Factories/Data/Default")]
    public class FactoryData : AFactory<IDataAnimation>
    {
        
        public override List<IDataAnimation> Get()
        {
            var list = new List<IDataAnimation>()
            {
                Get<DataAnimation>(DataAnimation.OBJECT_NAME)

            };
            


            return list;
        }
        
        
        
        

    
    
    
    }
}
