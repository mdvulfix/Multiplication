using System;
using UnityEngine;
using Framework.Core;
/*
namespace Framework
{
    //[ExecuteInEditMode]
    [Serializable]
    public class Builder : ABuilder
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
            SetParams(OBJECT_NAME);
            
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
            Set<ISession>(factorySession);
            Set<IControllerState>(factoryControllerState);
            //Set<ControllerCameraDefault>(factoryControlCamera).Configure();
            Set<IControllerScene>(factoryControllerScene);
            Set<IControllerPage>(factoryControllerPage);
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

        private T Set<T>(IFactory<T> factory) 
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
            
                return instance as T;
           } 

           return null;
        }

#endregion 

    }
}
*/