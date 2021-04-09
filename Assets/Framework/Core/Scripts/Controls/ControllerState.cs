using System.Collections.Generic;

namespace Framework.Core
{    

    public interface IControllerState: IController
    {
        HashSet<IState> States {get; }
        
        void SetStates(IFactoryState factory);
        void SetStates(HashSet<IState> states);
        
        void OnStateEnter(IState state);
        void OnStateExit(IState state);
    
    
    } 
    
    
    
    public abstract class ControllerState : Controller, IControllerState
    {
        
        protected readonly string SCENEOBJECT_NAME = "Controller: State";

        private HashSet<IState> states;
        
        public HashSet<IState> States {get => states; private set => states = value; }
        
                
        public void SetStates(IFactoryState factory)
        {
            States = factory.GetStates();

        }
        
        public void SetStates(HashSet<IState> states)
        {
            States = states;

        }

        public void OnStateEnter(IState state)
        {

        }

        public void OnStateExit(IState state)
        {
            
        }



    }
}
