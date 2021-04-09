using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactorySession", menuName = "Factories/Sessions/Default")]
    public class FactorySessionDefault : FactorySession
    {
        public override ISession GetSession()
        {
            return GetInstanceOf<SessionMain>("Session: Main", PARENT_SCENEOBJECT_NAME);

        }

    }
}