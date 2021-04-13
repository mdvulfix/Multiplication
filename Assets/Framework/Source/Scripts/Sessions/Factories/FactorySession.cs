using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactorySession", menuName = "Factories/Session/Default")]
    public class FactorySession : AFactory<ISession>
    {
        public override List<ISession> Get()
        {
            var list = new List<ISession>()
            {
                GetAndInitialize<SessionMain>(SessionMain.OBJECT_NAME)
            };
            
            return list;
        }

        private ISession GetAndInitialize<T>(string name) where T: ASession
        {
            var instance = GetInstanceOfSceneObject<T>(name,  ABuilder.OBJECT_NAME_SESSIONS);
            instance.Initialize();
            return instance;
        }
    }
}