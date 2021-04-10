using System.Collections.Generic;
using Framework.Core;

namespace Framework
{   
    public class ControllerStateDefault : ControllerState, IControllerState
    {
        
    public override void Initialize()
        {
            SetSceneObject(ControllerState.OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
        } 
        
        
        public override ICacheable Configure() 
        {                                     
            foreach (var state in Cache.GetAll())
            {
                state.Initialize();
            }

            StateActive = Cache.Get<StateBuilding>();
            Log(Label, "was successfully configured.");
            return this;
        }
        
        public override void OnStateEnter(IState state)
        {

        }

        public override void OnStateExit(IState state)
        {

        }
    }
}
