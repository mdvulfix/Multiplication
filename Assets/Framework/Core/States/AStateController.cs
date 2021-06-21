using System;
using System.Collections.Generic;

namespace Core.State
{    

    public interface IStateController: IController<IState>
    {
        event Action<IStateEventArgs> StateExecuted;
        
        ISession Session { get; }

        TState State<TState>(ISession session)
            where TState : class, IState, new();
    }
    
    public abstract class AStateController : AController<IState>, IStateController
    {       
        private readonly int PARAMS_STATECONTROLLER = 0;
        
        public event Action<IStateEventArgs> StateExecuted;

        public ISession Session { get; private set; }
        
        public AStateController(IParams<IStateController> parametrs)
        {
            Initialize(parametrs);
        }

        protected override void Initialize(params object[] args)
        {
            var settings = (ParamsStateController)args[PARAMS_STATECONTROLLER];
            Session = settings.Session;
        }
        
        public abstract TState State<TState>(ISession session)
            where TState : class, IState, new();

    }


    public struct ParamsStateController: IParams<IStateController>
    { 
        public ISession Session { get; private set; }

        public ParamsStateController(ISession session)
        {
            Session = session;
        }

    }

}

