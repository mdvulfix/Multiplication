using System;
using Core.Scene;
using UnityEngine;

namespace Core.State
{

    public interface IState
    {
        event Action<IStateEventArgs> StateExecuted;
                
        void Initialize(params object[] args);
        
        void Execute();
        
        void Load();
        void Play();
        void Pause();
        void Exit();
        void Close();
    }


    [Serializable]
    public abstract class AState: IState
    {
        private readonly int PARAMS_INITIALIZATION = 0;

        public event Action<IStateEventArgs> StateExecuted;

        
        protected ISession m_Session;
        protected IStateController m_StateController;
        protected ISceneController m_SceneController;

        public AState()
        { 

        }


        public virtual void Initialize(params object[] args)
        {
            var parametrs = (IStateInitializationParams)args[PARAMS_INITIALIZATION];
            m_Session = parametrs.Session;
            m_StateController = parametrs.StateController;
            m_SceneController = parametrs.SceneController;

            //Debug.Log("State was initialized!");

        }
        
        public abstract void Execute();

        public abstract void Load();
        public abstract void Play();
        public abstract void Pause();
        public abstract void Exit();
        public abstract void Close();

        protected void OnExecuted(IState state)
        {
            var message = string.Format("State {0} was executed", state.GetType().Name);

            StateExecuted?.Invoke(new StateEventArgs(state, message));
            Debug.Log(message);
        }
    
    }

    public interface IStateEventArgs
    {
        IState State {get; }
        string Message {get; }

    }
    
    public class StateEventArgs: EventArgs, IStateEventArgs
    {
        public IState State {get; private set;}
        public string Message {get; private set;}

        public StateEventArgs(IState state, string message)
        {
            State = state;
            Message = message;

        }
    }

    public interface IStateInitializationParams
    { 
        ISession Session { get; }
        IStateController StateController { get; }
        ISceneController SceneController { get; }
        
    }


}