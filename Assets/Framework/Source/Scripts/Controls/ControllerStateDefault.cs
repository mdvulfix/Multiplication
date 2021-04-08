using System.Collections.Generic;
using Framework.Core;

namespace Framework
{   
    public class ControllerStateDefault : ControllerState, IControllerState
    {
        
        public override void Initialize()
        {
            SetSceneObject(SCENEOBJECT_NAME);
            Log(Label, "was sucsessfully initialized");

        } 
        
        public override void Configure() 
        {                         

            Log(Label, "was successfully configured.");
        }
    
        public override void OnStateEnter(IState state)
        {

        }

        public override void OnStateExit(IState state)
        {

        }


    }
}
