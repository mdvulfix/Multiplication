using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactorySession: IFactory
    {
        T Get<T>() where T: SceneObject, ISession;
        HashSet<ISession> GetSessions();
    }
    
    public abstract class FactorySessions : Factory, IFactorySession
    {

        private static readonly string PARENT_NAME = "Sessions";
        
        public T Get<T>() where T: SceneObject, ISession
        {
            var obj = CreateSceneObject(typeof(T).Name, PARENT_NAME);
            var instance = obj.AddComponent<T>();
            
            return instance;
        
        }

        public abstract HashSet<ISession> GetSessions();

    }
}
