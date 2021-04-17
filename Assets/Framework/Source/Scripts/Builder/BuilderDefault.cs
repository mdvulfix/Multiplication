using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    //[ExecuteInEditMode]
    [Serializable]
    public class BuilderDefault : ABuilder
    {
        
        public static readonly string OBJECT_NAME = ABuilder.OBJECT_NAME_BUILDER;
        
        [Header("Factories: Session")]
        [SerializeField] FactorySession             factorySession; 
        
        [Header("Factories: Controls")]
        [SerializeField] FactoryControllerState     factoryControllerState;
        //[SerializeField] FactoryControllerCamera    factoryControlCamera;
        [SerializeField] FactoryControllerScene     factoryControllerScene;
        [SerializeField] FactoryControllerPage      factoryControllerPage;              
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
            
            //return this;
        
            GetFactory<ISession>(factorySession);
            GetFactory<IControllerState>(factoryControllerState);
            //GetFactory<ControllerCamera>(factoryControlCamera);
            GetFactory<IControllerScene>(factoryControllerScene);
            GetFactory<IControllerPage>(factoryControllerPage);
            //GetFactory<ControlInput>(factoryControlInput);
            
            Log(Label, "was sucsessfully initialized");

        }
        
        public override IConfigurable Configure()
        {          
            SetAndConfigure<ISession>(factorySession);
            SetAndConfigure<IControllerState>(factoryControllerState);
            //Set<ControllerCameraDefault>(factoryControlCamera).Configure();
            SetAndConfigure<IControllerScene>(factoryControllerScene);
            SetAndConfigure<IControllerPage>(factoryControllerPage);
            //Set<ControlInputDefault>(factoryControlInput);
            
            
            foreach (var instance in Cache.GetAll())
            {
                instance.Configure();
            }
            
            
            Log(Label, "was sucsessfully configured");
            return this;            
        }     
        

#endregion 

#region Cache

        private T SetAndConfigure<T>(IFactory<T> factory) 
            where T: class, IConfigurable, ICacheable
        {          
           var list = factory.Get();
           if(list.Count == 0)
           {
               LogWarning(Label, "Instance type of ["+ typeof(T) +"] was not found! Check factory ["+ factory +"] configuration.");
               return null;
           }
           
           foreach (var instance in list)
           {
                SetToCache(instance);
                Log(Label, "Instance type of ["+ typeof(T) +"] was sucsessfully set to cache.");
            
                instance.Configure();
                return instance as T;
           } 

           return null;
        }

#endregion 

    }
}