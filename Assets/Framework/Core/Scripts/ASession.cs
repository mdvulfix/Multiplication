using System;
using System.Collections.Generic;
using UnityEngine;
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
            where TState : IState;
    }

    public abstract class ASession : ASceneObject, ISession
    {
        
        private readonly int PARAMS_INITIALIZATION = 0;
        
        public event Action<IStateEventArgs> StateUpdated;

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
        }

        private void Start()
        {
            OnStart();
        }

        protected virtual void OnAwake()
        {

        }

        protected virtual void OnStart()
        {

        }


        protected void Initialize(params object[] args)
        {
            var parametrs = args[PARAMS_INITIALIZATION] as ISessionInitializationParams;
            m_StateController = parametrs.StateController;
            m_SceneController = parametrs.SceneController;


            m_ScenesLoaded = new List<IScene>(10);
            m_ScenesActivated = new List<IScene>(10);

            Debug.Log("Session was initialized!");

        }

        private void Dispose()
        {
            OnDispose();
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

        public void SetState<TState>() 
            where TState: IState
        {
            m_State = m_StateController.State<TState>();
            m_State.Execute();

            StateUpdated?.Invoke(new StateEventArgs(m_State, string.Format("State {0} was updated!", m_State)));

        }



        private bool SceneCheckState<TState>(IScene scene)
            where TState: IState
        {
            //if(scene.State is TState)
            //    return true;
            //else
               return false;
        }

    }


    public interface ISessionInitializationParams
    { 
        IStateController StateController { get; }
        ISceneController SceneController { get; }
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