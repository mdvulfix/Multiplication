using System;
using System.Collections.Generic;
using UnityEngine;
using Core.Scene.State;

namespace Framework.Scene.Controller
{   
    public class StateControllerDefault : AStateController
    {
        public override void Init()
        {
            StateActive = Cache.Get<StateBuilding>();
        } 
        
    }
}
