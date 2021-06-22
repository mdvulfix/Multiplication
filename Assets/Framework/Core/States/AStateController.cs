using System;
using System.Collections.Generic;
using Core.Scene;
using UnityEngine;

namespace Core.State
{    

    public interface IStateController: IController<IState>
    {
        event Action<IStateEventArgs> StateExecuted;

        TState State<TState>()
            where TState : class, IState, new();
    }
    
    
    public abstract class AStateController : AController<IState>, IStateController
    {       
        private readonly int PARAMS_INITIALIZATION = 0;
        
        public event Action<IStateEventArgs> StateExecuted;

        protected ISession m_Session;
        protected ISceneController m_SceneController;


        protected override void Initialize(params object[] args)
        {
            base.Initialize();
            var parametrs = (IStateControllerInitializationParams)args[PARAMS_INITIALIZATION];
            m_Session = parametrs.Session;
            m_SceneController = parametrs.SceneController;
        
            Debug.Log("StateController was initialized!");
        }
          
    
    
        public virtual TState State<TState>() 
            where TState: class, IState, new()
        {
            //TODO: DI;
            IState state;

            if(!Cache.Get<TState>(out state))
            {
                state = new TState();
                Cache.Add(state);
            }

            return state as TState;
        }
    
    
    
    
    }


    public interface IStateControllerInitializationParams
    { 
        ISession Session { get; }
        ISceneController SceneController { get; }

    }







}

