using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactorySession: IFactory
    {
        ISession GetSession();
    }
    
    public abstract class FactorySession : Factory, IFactorySession
    {
        protected readonly string PARENT_SCENEOBJECT_NAME = "Sessions";
        public abstract ISession GetSession();

    }
}
