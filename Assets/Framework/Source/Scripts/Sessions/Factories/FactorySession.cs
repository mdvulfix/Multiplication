using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactorySession", menuName = "Factories/Session")]
    public class FactorySession : Factory
    {
        public override List<ISession> Get<ISession>()
        {
            var list = new List<ISession>()
            {
                (ISession)GetInstanceOf<SessionMain>("Session: Main", Session.PARENT_OBJECT_NAME).Initialize()
            };
            
            return list;
        }
    }
}