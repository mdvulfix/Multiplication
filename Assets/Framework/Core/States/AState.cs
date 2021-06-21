using System;

namespace Core.State
{

    public interface IState
    {
        event Action<IStateEventArgs> StateExecuted;
                
        void Initialize(ISession session, params object[] args);
        
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
        
        public event Action<IStateEventArgs> StateExecuted;

        private ISession m_Session;

        public AState()
        {

        }
        
        public virtual void Initialize(ISession session, params object[] args)
        {
            m_Session = session;
        }
        
        public abstract void Execute();

        public abstract void Load();
        public abstract void Play();
        public abstract void Pause();
        public abstract void Exit();
        public abstract void Close();

        protected void OnExecuted(IState state)
        {
            StateExecuted?.Invoke(new StateEventArgs(state, string.Format("State {0} was executed", state)));
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




}