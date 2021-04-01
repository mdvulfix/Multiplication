using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactoryState: IFactory
    {
        HashSet<IState> GetStates();
        T Get<T>() where T: IState, new();
    }
    
    public abstract class FactoryState : Factory, IFactoryState
    {

        public T Get<T>() where T: IState, new()
        {
            return new T();
        
        }

        public abstract HashSet<IState> GetStates();

    }
}
