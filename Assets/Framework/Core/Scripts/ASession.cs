using System;
using Core.Cache;
using Core.Scene;

namespace Core.Session
{
    
    public interface ISession: IAwakable
    {

    }


    public abstract class ASession : ASceneObject, ISession
    {
        public event Action<bool, string> Activated;
        
        private ICache<IController> m_Controllers;

        protected IScene m_SceneCurrent;

        public void Awake()
        {
            OnAwake();
            Initialize();
        }

        private void Start() 
        { 
            OnStart();
        }
        public abstract void OnAwake();
        public abstract void OnStart();

        public virtual void Initialize(params object[] args)
        {
            m_Controllers = new Cache<IController>();
        }


        private void OnEnable() 
        {
            Activated?.Invoke(true, "Session was activated!");
        }
        
        private void OnDisable() 
        {
            Activated?.Invoke(false, "Session was deactivated!");
        }








        protected T Controller<T>()
            where T: class, IController, new()
        {
            IController controller;
            
            if (!m_Controllers.Get<T>(out controller))
            { 
                controller = m_Controllers.Add<T>();
                controller.Initialize();
            }

            return controller as T;
        }

    }
}