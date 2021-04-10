using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [Serializable]
    public class BuilderDefault : Builder
    {
        
        public static readonly string OBJECT_NAME = Builder.OBJECT_NAME_BUILDER;
        
        [Header("Factories: Session")]
        [SerializeField] Factory                    factorySessions; 
        
        [Header("Factories: Controls")]
        [SerializeField] FactoryControllerState     factoryControlState;
        [SerializeField] FactoryControllerCamera    factoryControlCamera;
        [SerializeField] FactoryControllerScene     factoryControlScene;
        [SerializeField] FactoryControllerPage      factoryControlPage;              
        //[SerializeField] FactoryControlInput factoryControlInput;
        

#region Configure
        
        public override void OnAwake()
        {
            Initialize();
            Configure();
        }
        
        public override void Initialize()
        {
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
        }
        
        public override ICacheable Configure()
        {          
            Set<SessionMain>(factorySessions);
            Set<ControllerStateDefault>(factoryControlState);
            Set<ControllerCameraDefault>(factoryControlCamera);
            Set<ControllerSceneDefault>(factoryControlScene);
            Set<ControllerPageDefault>(factoryControlPage);
            //Set<ControlInputDefault>(factoryControlInput);
            
            foreach (var instance in Cache.GetAll())
            {
                instance.Configure();
            }

            Log(Label, "was sucsessfully configured");
            return this;            
        }     
        

#endregion 

#region SetToCache

        private void Set<T>(IFactory factory) where T:  class, ICacheable
        {          
           var list = GetInstancesFormFactory(factory);
           if(list.Count == 0)
           {
               LogWarning(Label, "Instance type of ["+ typeof(T) +"] was not found! Check factory ["+ factory +"] configuration.");
               return;
           }
           
           foreach (var instance in list)
           {
              if(instance.GetType() is T)
              {   
                  SetToCache(instance);
                  Log(Label, "Instance type of ["+ typeof(T) +"] was sucsessfully set to cache.");
              }
           } 
        }

#endregion 
        
    }
}