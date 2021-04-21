using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class ControllerInput : AControllerInput
    {
        public static readonly string OBJECT_NAME = "Controller: Input";

        private KeyCode fadeIn;
        private KeyCode fadeOut;

        private ControllerPage controllerPage;
        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
        } 
        
        
        public override IConfigurable Configure()
        {
            fadeIn = KeyCode.I;
            fadeOut = KeyCode.O;

            controllerPage = session.GetController<ControllerPage>();
            
            Log(Label, "was successfully configured.");
            return this;
        }

#region Start&Update


        public override void OnStart()
        {

        }

        public override void OnUpdate()
        {
            if(Input.GetKeyUp(fadeIn))
            {
                Log(Label, "Get key [ " + fadeIn + " ]!");
                //controllerPage.TurnPageOn(typeof(PageLoading));

            }

           if(Input.GetKeyUp(fadeOut))
            {
                Log(Label, "Get key [ " + fadeOut + " ]!");
                //controllerPage.TurnPageOff(typeof(PageLoading), true);

            }
        }

#endregion
        
    }
}
