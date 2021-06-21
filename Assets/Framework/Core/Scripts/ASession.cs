using System;
using System.Collections.Generic;
using Core.Scene;
using Core.State;

namespace Core
{
    public interface ISession: IHandler
    {        
        List<IScene> ScenesLoaded {get; }
        List<IScene> ScenesActivated {get; }
        
        void Load();
        void Play();
        void Pause();
        void Exit();
        void Close();


        void SetState<TState>() 
            where TState: class, IState;
    }

    public abstract class ASession : ASceneObject, ISession
    {
        
        private readonly int PARAMS_SESSION = 0;
        
        public event Action<bool, string> StateUpdated;

        public List<IScene> ScenesLoaded { get => m_ScenesLoaded; }
        public List<IScene> ScenesActivated { get => m_ScenesActivated; }

        private static List<IScene> m_ScenesLoaded;
        private static List<IScene> m_ScenesActivated;

        private IScene m_Scene;
        private ISceneController m_SceneController;

        private IState m_State;
        private IStateController m_StateController;
        


        private void Awake()
        {
            OnAwake();
            Initialize();
        }

        private void Start()
        {
            OnStart();
            Load();
        }

        protected virtual void OnAwake()
        {

        }

        protected virtual void OnStart()
        {

        }


        protected void Initialize(params object[] args)
        {
            var parametrs = (ParamsSession)args[PARAMS_SESSION];
            m_StateController = parametrs.StateController;


            m_ScenesLoaded = new List<IScene>(10);
            m_ScenesActivated = new List<IScene>(10);


            //TODO: Dependency injection;
            //m_SceneController = new SceneControllerDefault();

        }

        private void Dispose()
        {
            OnDispose();
        }

        protected virtual void OnInitialize()
        {

        }

        protected virtual void OnDispose()
        { 

        }


        public virtual void Load()
        {
            m_State.Load();
            //OnUpdated("Конфигурация сцены [" + GetSceneNameViaType(Scene) + "] успешно выполнена.");
        }

        public virtual void Play()
        {
            m_State.Play();
            //Debug.Log("Сцена не проконфигурирована.");
        }

        public virtual void Pause()
        {
            m_State.Pause();
            //Debug.Log("Сцена не активирована.");
        }

        public virtual void Exit()
        {
            m_State.Exit();
            //Debug.Log("Сцена не открыта.");
        }

        public virtual void Close()
        {
            m_State.Close();
            //Debug.Log("Сцена не открыта.");
        }

        protected bool SetState<T>() where T: class, IState, new()
        {
            
            m_State = m_StateController.Sta
            
            state.Initialize(this);
            m_States.Add(state);
            
            return true;

        }

        protected bool GetState<T>(out IState state) where T: class, IState
        {
            state = null;
            if(m_States.Get<T>(out state))
                return true;

            return false;
        }

        protected void SetState<TState>() 
            where TState: class, IState
        {
            if(m_StateController.Get<TState>(out m_State))
            {
                m_State.Execute();
                StateUpdated?.Invoke(new SceneEventArgs(this, m_StateCurrent, true));
            }
        }


        private bool SceneCheckState<TState>(IScene scene)
            where TState: class, IState
        {
            //if(scene.State is TState)
            //    return true;
            //else
               return false;
        }

    }


    public interface IParams<T>
    { 

    }


    public struct ParamsSession: IParams<ISession>
    { 
        public IStateController StateController { get; private set; }

        public ParamsSession(IStateController stateController)
        {
            StateController =  stateController;
        }

    }


}


/*
        public void Load<TScene>() 
            where TScene: IScene
        {
            m_Scene.Load<TScene>();
        }

        public virtual void Enter<TScene>()
            where TScene: IScene
        {
            m_Scene.Enter<TScene>();
        }
        public virtual void Play<TScene>()
            where TScene: IScene
        {
            m_Scene.Play<TScene>();
        }
        public virtual void Pause<TScene>()
            where TScene: IScene
        {
            m_Scene.Pause<TScene>();
        }
        public virtual void Exit<TScene>()
            where TScene: IScene
        {
            m_Scene.Exit<TScene>();
        }
        public virtual void Close<TScene>()
            where TScene: IScene
        {
            m_Scene.Close<TScene>();
        }
*/