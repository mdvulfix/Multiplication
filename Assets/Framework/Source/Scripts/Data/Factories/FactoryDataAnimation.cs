using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryDataAnimation", menuName = "Factories/Data/Animation/Default")]
    public class FactoryDataAnimation : AFactory<IDataAnimation>
    {
        
        public static readonly string OBJECT_NAME = "Factory: DataAnimation";
        
#region Configure

        public override void Initialize()
        {
            
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;       
        }

        public override IConfigurable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }
        
#endregion
        
#region Get
        
        public override List<IDataAnimation> Get()
        {
            var list = new List<IDataAnimation>()
            {
                GetInstanceOf<DataAnimation>(DataAnimation.OBJECT_NAME)

            };
            


            return list;
        }
        

#endregion

    }
}
