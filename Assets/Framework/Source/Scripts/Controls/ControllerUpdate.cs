using System;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    public class ControllerUpdate : AControllerUpdate
    {
        
        public static readonly string OBJECT_NAME = "Controller: Update";

 #region Configure 
        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
        }
        
        public override IConfigurable Configure() 
        {                                     
            Log(Label, "was successfully configured.");
            return this;
        }

#endregion

        public override void OnStart()
        {
            Session.OnStart();
        }

        public override void OnUpdate()
        {
            Session.OnUpdate();
        }
    }
}
