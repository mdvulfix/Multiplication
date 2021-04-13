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
            Log(Label, "was sucsessfully initialized");
            //return this;
        
        

        
        
        
        
        
        
        }
        
        public override IConfigurable Configure()
        {          
            var instance = Set<ISession>(factorySession);
            instance.Configure();
            Set<IControllerState>(factoryControllerState).Configure();
            //Set<ControllerCameraDefault>(factoryControlCamera).Configure();
            Set<IControllerScene>(factoryControllerScene).Configure();
            Set<IControllerPage>(factoryControllerPage).Configure();
            //Set<ControlInputDefault>(factoryControlInput);
            
            Log(Label, "was sucsessfully configured");
            return this;            
        }     
        

#endregion 

#region SetToCache

        private T Set<T>(IFactory<T> factory) 
            where T: class, ICacheable
        {          
           
           if(factory==null)
           {
               LogWarning(Label, "Factory [" + typeof(T)+ "] was not found!");
               return null;
           }
           
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