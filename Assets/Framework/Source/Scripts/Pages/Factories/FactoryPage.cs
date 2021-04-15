using System.Collections.Generic;
using UnityEngine;
using Framework.Core;
using Framework.Core.Handlers;

namespace Framework
{

    public struct DataStruct<IPage>
    {
        public IDataStats      ValueDataStats       {get; set;} 
        public IDataAnimation  ValueDataAnimation   {get; set;}

    }
    
    [CreateAssetMenu(fileName = "FactoryPage", menuName = "Factories/Page/Default")]
    public class FactoryPage : AFactory<IPage>, IHaveFactory
    {
        
        public static readonly string OBJECT_NAME = "Factory: Page";
        
        [SerializeField] protected GameObject prefabPageLoading;
        [SerializeField] protected GameObject prefabPageLogin;
        [SerializeField] protected GameObject prefabPageMenu;
        [SerializeField] protected GameObject prefabPageRunTime;
        [SerializeField] protected GameObject prefabPageScore;
        
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

#region Factory

        public IFactory<TCacheable> GetFactory<TCacheable>(IFactory<TCacheable> factory) 
            where TCacheable: class, ICacheable
        {
           if(factory==null)
           {
               LogWarning(Label, "Factory [" + typeof(TCacheable)+ "] is not set!");
               return null;
           }
           
            factory.Initialize();
            return factory;
        }

#endregion 
        
#region Get
        
        public override List<IPage> Get()
        {
            var list = new List<IPage>()
            {
                GetAndInitializeStaff<PageLoading>(PageLoading.OBJECT_NAME, prefabPageLoading),
                GetAndInitializeStaff<PageLogin>(PageLogin.OBJECT_NAME, prefabPageLogin),
                GetAndInitializeStaff<PageMenu>(PageMenu.OBJECT_NAME, prefabPageMenu), 
                GetAndInitializeStaff<PageRunTime>(PageRunTime.OBJECT_NAME, prefabPageRunTime), 
                GetAndInitializeStaff<PageScore>(PageScore.OBJECT_NAME, prefabPageScore), 
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
