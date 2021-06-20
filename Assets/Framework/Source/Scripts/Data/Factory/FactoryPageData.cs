using System.Collections.Generic;
using UnityEngine;
using Core;
//using Core.Handlers;
/*
namespace Framework
{       
    [CreateAssetMenu(fileName = "FactoryPageDataStruct", menuName = "Factories/Page/DataStruct/Default")]
    public class FactoryPageData : AFactory<IPageDataStruct>
    {
        
        public static readonly string OBJECT_NAME = "Factory: PageDataStruct";
                
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
        
        public override List<IPageDataStruct> Get()
        {
            var list = new List<IPageDataStruct>()
            {
                GetAndInitialize<PageDataStruct>(PageDataStruct.OBJECT_NAME)

            };
            
            return list;

        }

        private T GetAndInitialize<T>(string label) where T: ASimpleObject, IPageDataStruct, new()
        {
            var instance = GetInstanceOf<T>(label);
            instance.Initialize();
    
        
            return instance;
        }


#endregion

#region Data

        public PageDataStruct Get(IPage instance)
        {
            var data = new PageDataStruct()
            {
                DataStats = HandlerSceneObject.Create<DataStats>("Data: Stats", instance.ga),
                DataAnimation = HandlerSceneObject.Create<DataAnimation>("Data: Animation", instance.ObjectOnScene)

            };

            return data;
        }

#endregion
        
    }
}
*/