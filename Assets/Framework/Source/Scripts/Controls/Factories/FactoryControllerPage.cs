using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerPage", menuName = "Factories/Controllers/Page/Default")]
    public class FactoryControllerPage : AFactory<IControllerPage>, IHaveFactory
    {
        
        public static readonly string OBJECT_NAME = "Factory: Page";
        
        [SerializeField]        
        private FactoryPage factoryPage;
        
         
#region Configure

        public override void Initialize()
        {
            
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
        
            GetFactory<IPage>(factoryPage);
        
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

        public override List<IControllerPage> Get()
        {
            var list = new List<IControllerPage>()
            {
                GetAndInitialize<ControllerPage>(ControllerPage.OBJECT_NAME, factoryPage)
            };

            return list;
        }

        private IControllerPage GetAndInitialize<T>(string label, IFactory<IPage> factory) 
            where T: AControllerPage
        {
            var instance = GetInstanceOf<T>(label, FindSceneObjectByName(ABuilder.OBJECT_NAME_CONTROLLERS));
            instance.Initialize();

            if(factory==null)
            {
               LogWarning(Label, "Factory [" + typeof(IPage)+ "] was not found!");
               return null;
            }

            var list = factory.Get();
            if(list.Count == 0)
            {
               LogWarning(Label, "Instance type of ["+ typeof(T) +"] was not found! Check factory ["+ factory +"] configuration.");
               return null;
            }
            
            foreach (var cacheable in list)
            {
                instance.SetToCache(cacheable);
                Log(Label, "Instance type of ["+ cacheable.Label +"] was sucsessfully set to cache.");
            } 
            
            return instance;
        }
        
#endregion

    }
}
