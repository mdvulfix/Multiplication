using System.Collections.Generic;
using Framework.Core;

namespace Framework
{   
    public class ControllerStateDefault : ControllerState, IControllerState
    {
        
        public override IController Initialize()
        {
            SetSceneObject(SCENEOBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            return this;
        } 
        
        public override IController Configure() 
        {                         

            Log(Label, "was successfully configured.");
            return this;
        }
    
    }
}
