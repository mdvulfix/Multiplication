using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerState", menuName = "Factories/Controllers/State/Default")]
    public class FactoryControllerState : AFactory<IControllerState>, IHaveFactory
    {
        public static readonly string OBJECT_NAME = "Factory: State";
        
        [SerializeField]        
        private FactoryState factoryState;


#region Configure

        public override void Initialize()
        {
            
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
        
            GetFactory<IState>(factoryState);
        
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

        public override List<IControllerState> Get()
        {
            var list = new List<IControllerState>()
            {
                GetAndInitializeStaff<ControllerStateDefault>(ControllerStateDefault.OBJECT_NAME, factoryState)
            };

            return list;
        }
        
        private IControllerState GetAndInitializeStaff<T>(string label, IFactory<IState> factory) 
            where T: AControllerState
        {
            var instance = GetInstanceOf<T>(label, FindSceneObjectByName(ABuilder.OBJECT_NAME_CONTROLLERS));
            instance.Initialize();

            if(factory==null)
            {
               LogWarning(Label, "Factory [" + typeof(IState)+ "] was not found!");
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
