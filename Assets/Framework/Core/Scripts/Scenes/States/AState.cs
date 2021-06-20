using System;


namespace Core.Scene.State
{

    public interface IState
    {
        event Action<IStateEventArgs> Updated;
        event Action<IStateEventArgs> StateExecuted;
                
        //IScene              Scene       {get; }
        //IStateController    Controller  {get; }
        
        void Initialize(params object[] args);
        
        void Execute();
        
        void Load();
        void Enter();
        void Play();
        void Pause();
        void Exit();
        void Unload();
    }


    [Serializable]
    public abstract class AState: IState
    {
        
        private static readonly int INITIALIZATION_INDEX_TYPEOF_ISCENE= 0;
        
        public event Action<IStateEventArgs> Updated;
        public event Action<IStateEventArgs> StateExecuted;

        public IScene m_Scene;



        public AState()
        {

        }
        
        public void Initialize(params object[] args)
        { 
            m_Scene = args[INITIALIZATION_INDEX_TYPEOF_ISCENE] as IScene;
        }
        
        public abstract void Execute();

        public abstract void Load();
        public abstract void Enter();
        public abstract void Play();
        public abstract void Pause();
        public abstract void Exit();
        public abstract void Unload();

        protected void OnExecuted(IState state)
        {
            StateExecuted?.Invoke(new StateEventArgs(state, string.Format("State {0} was executed", state)));
        }

        protected virtual void OnUpdated(string message)
        {
            Updated?.Invoke(new StateEventArgs(this, message));
        }

        protected string GetSceneNameViaType(IScene instance)
        {
            return instance.GetType().Name;
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