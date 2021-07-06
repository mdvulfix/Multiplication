using System;
using System.Collections.Generic;

namespace Core.State
{
    public interface IStateFactory: IFactory
    {

    }

    public class AStateFactory : AFactory, IStateFactory
    {
        public delegate IState Constructor(IStateInitializationParams parametrs);

        private Dictionary<Type, Constructor> m_Constractors = new Dictionary<Type, Constructor>(10);


        public override T Get<T>(params object[] args)
        {
            if (!m_Constractors.ContainsKey(typeof(T)))
                Add<T>(args);

            var parametrs = (IStateInitializationParams)args[0];
            return (T)m_Constractors[typeof(T)](parametrs);
        }


        protected void Add<T>(params object[] args)
        {
            m_Constractors.Add(typeof(T), (p) => (IState)Activator.CreateInstance(typeof(T), p));
        }

        protected void Add<T>(Constructor constructor)
        {
            m_Constractors.Add(typeof(T), constructor);
        }
    }
}