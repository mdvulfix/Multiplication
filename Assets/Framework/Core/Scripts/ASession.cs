using Core.Cache;

namespace Core.Session
{
    
    public interface ISession: IAwakable
    {

    }


    public abstract class ASession : ASceneObject, ISession
    {
        private ICache<IController> m_Controllers;

        public void Awake()
        {
            Init();
        }

        public virtual void Init()
        {
            m_Controllers = new Cache<IController>();
        }

        protected T Controller<T>()
            where T: class, IController, new()
        {
            IController controller;
            
            if (!m_Controllers.Get<T>(out controller))
            { 
                controller = m_Controllers.Add<T>();
                controller.Init();
            }

            return controller as T;
        }

    }
}