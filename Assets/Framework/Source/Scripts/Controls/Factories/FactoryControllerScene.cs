using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerScene", menuName = "Factories/Controllers/Scene/Default")]
    public class FactoryControllerScene : AFactory<IControllerScene>, IHaveFactory
    {
        
        public static readonly string OBJECT_NAME = "Factory: Scene";
        
        [SerializeField]        
        private FactoryScene factoryScene;
        
#region Configure

        public override void Initialize()
        {
            
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
        
            GetFactory<IScene>(factoryScene);
        
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
        
        public override List<IControllerScene> Get()
        {
            var list = new List<IControllerScene>()
            {
                GetAndInitializeStaff<ControllerScene>(ControllerScene.OBJECT_NAME, factoryScene)
            };

            return list;
        }

        private IControllerScene GetAndInitializeStaff<T>(string label, IFactory<IScene> factory) 
            where T: AControllerScene
        {
            var instance = GetInstanceOf<T>(label, FindSceneObjectByName(ABuilder.OBJECT_NAME_CONTROLLERS));
            instance.Initialize();

            if(factory==null)
            {
               LogWarning(Label, "Factory [" + typeof(IScene)+ "] was not found!");
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
