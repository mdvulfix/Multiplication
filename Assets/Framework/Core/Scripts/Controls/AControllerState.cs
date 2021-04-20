using System.Collections.Generic;

namespace Framework.Core
{    

    public interface IControllerState: IController<IState>
    {    
        IState StateActive {get; }
    
        void OnStateEnter(IState state);
        void OnStateExit(IState state);
    
    } 
    
    public abstract class AControllerState : AController<IState>, IControllerState
    {       
        public IState StateActive  {get; protected set;}       

#region Start&Update

        public abstract void OnAwake();

#endregion

#region StateManagement
            
        public abstract void OnStateEnter(IState state);
        public abstract void OnStateExit(IState state);

#endregion
    
    }
}
