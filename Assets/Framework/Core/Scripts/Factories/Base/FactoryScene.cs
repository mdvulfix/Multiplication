using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactoryScene: IFactory
    {
        HashSet<IScene> GetScenes();
        T Get<T>() where T: IScene, new();
    }
    
    public abstract class FactoryScene : Factory, IFactoryScene
    {

        public T Get<T>() where T: IScene, new()
        {
            return new T();
        
        }

        public abstract HashSet<IScene> GetScenes();

    }
}
