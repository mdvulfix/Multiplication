using System;
using UnityEngine;
using Framework.Core;

namespace Framework 
{
    [Serializable]
    public class Session : ASession
    {
        public static readonly string OBJECT_NAME = "Session: Main";

        [Header ("Controllers")]
        //[SerializeField] private ControllerState    controllerState;
        //[SerializeField] private ControllerScene    controllerScene;
        [SerializeField] private ControllerPage     controllerPage;
        [SerializeField] private ControllerInput    controllerInput;
        [SerializeField] private ControllerUpdate   controllerUpdate;

        
        public override void Initialize() 
        {
            SetParams(OBJECT_NAME);
            
            if(IsProject)
            {
                SetToCache(controllerPage);
                SetToCache(controllerInput);
                SetToCache(controllerUpdate);
                
                foreach (var instance in Cache.GetAll())
                {
                    instance.Initialize();
                }

            }
            



            Log(Label, "was sucsessfully initialized");
            //return this;
        }

        public override IConfigurable Configure()
        {

            if(IsProject)
            {
                foreach (var instance in Cache.GetAll())
                {
                    instance.Configure();
                }
            }



            Log(Label, "was sucsessfully configured");
            return this;
        
        }

        public override void OnAwake()
        {
            Initialize();
            Configure();

        }

        public override void OnStart()
        {
            controllerInput.OnStart();
        
        }

        public override void OnUpdate()
        {
            controllerInput.OnUpdate();
        
        }

        public TController GetController<TController>() where TController: IController
        {
            return (TController)Cache.Get<TController>();
        }
    }
}