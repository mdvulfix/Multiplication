using System;
using System.Collections.Generic;
using Core.Cache;
using Source.Scene.State;

namespace Core.Scene.State
{    

    public interface IStateController: IController
    {
        event Action<IStateEventArgs> StateExecuted;
        IState State {get; }
        
        //bool Get<T>(out IState state) where T: class, IState;
    }
    
    public abstract class AStateController : AController, IStateController
    {       
     
        public event Action<IStateEventArgs> StateExecuted;
        public IState State {get; private set;}

        private ICache<IState> m_States;   
        private ICache<IController> m_Controllers;   

        
        public AStateController()
        {        
            m_States = new Cache<IState>(); 
            m_Controllers = new Cache<IController>(); 

            Initialize();
        }   

        protected bool Set<T>() where T: class, IState, new()
        {
            var state = new T();
            state.Initialize(this);
            m_States.Add(state);
            
            return true;

        }

        protected bool Get<T>(out IState state) where T: class, IState
        {
            state = null;
            
            if(m_States.Get<T>(out state))
                return true;

            return false;
        }
        

        protected T ControllerSetAndGet<T>()
            where T: class, IController, new()
        {
            IController controller = null;

            if(m_Controllers.Get<T>(out controller))
                return controller as T;

            
            controller = new T();
            controller.Initialize(this);
            m_Controllers.Add(controller);

            return controller as T;
        }


    }
}

