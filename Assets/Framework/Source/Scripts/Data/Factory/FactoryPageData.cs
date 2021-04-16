using System.Collections.Generic;
using UnityEngine;
using Framework.Core;
using Framework.Core.Handlers;

namespace Framework
{    
    [CreateAssetMenu(fileName = "FactoryPage", menuName = "Factories/Page/Default")]
    public class FactoryData : AFactory<DataStruct<IPage>>
    {
        
        public static readonly string OBJECT_NAME = "Factory: Data";
                
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
        
        public override List<IDataStruct<IPage>> Get()
        {
            var list = new List<IDataStruct<IPage>>()
            {
                GetAndInitializeStaff<DataStruct<IPage>>(PageLoading.OBJECT_NAME),
            };

            return list;
        }

        private IPage GetAndInitializeStaff<T>(string label, GameObject prefab) where T: APage
        {
            if(prefab==null)
            {
               LogWarning(Label, "Prefab for [" + label + "] page was not found!");
               return null;
            }

            var instance = GetInstanceOf<T>(label, FindSceneObjectByName(APage.PARENT_OBJECT_NAME), prefab);
            
            instance.DataStruct = GetData(instance);
            instance.Initialize();
            
            return instance;
        }


#endregion

#region Data

        public override DataStruct<IPage> GetData(IPage instance)
        {
            var data = new DataStruct<IPage>()
            {
                ValueDataStats = HandlerSceneObject.Create<DataStats>("Data: Stats", instance.ObjectOnScene),
                ValueDataAnimation = HandlerSceneObject.Create<DataAnimation>("Data: Animation", instance.ObjectOnScene)

            };

            return data;
                
        }

#endregion

    }
}
