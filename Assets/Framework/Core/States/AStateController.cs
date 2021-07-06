using System;
using System.Collections.Generic;
using Core.Scene;
using Source.State;
using UnityEngine;

namespace Core.State
{    

    public interface IStateController: IController<IState>
    {
        event Action<IStateEventArgs> StateExecuted;

        TState State<TState>()
            where TState : IState;
    }
    
    
    public abstract class AStateController : AController<IState>, IStateController
    {       
        private readonly int PARAMS_INITIALIZATION = 0;
        
        public event Action<IStateEventArgs> StateExecuted;

        protected ISession m_Session;
        protected ISceneController m_SceneController;

        private IStateFactory m_StateFactory;
        private IStateInitializationParams m_StateInitializationParams;


        protected override void Initialize(params object[] args)
        {
            base.Initialize();
            var parametrs = (IStateControllerInitializationParams)args[PARAMS_INITIALIZATION];
            m_Session = parametrs.Session;
            m_SceneController = parametrs.SceneController;
            m_StateFactory = parametrs.StateFactory;
            m_StateInitializationParams = parametrs.StateInitializationParams;

            Debug.Log("StateController was initialized!");
        }
          
    
        public virtual TState State<TState>() 
            where TState : IState
        {

            IState state;
            if(!Cache.Get<TState>(out state))
            {
                //state = new TState();
                state = m_StateFactory.Get<TState>(m_StateInitializationParams);
                Cache.Add(state);
            }

            return (TState)state;
        }
    }


    public interface IStateControllerInitializationParams
    { 
        ISession Session { get; }
        ISceneController SceneController { get; }
        
        IStateFactory StateFactory { get; }
        IStateInitializationParams StateInitializationParams { get; }

    }







}

