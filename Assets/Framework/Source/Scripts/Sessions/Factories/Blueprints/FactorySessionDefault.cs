using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "Factory Session (Main)", menuName = "Factories/Sessions/Main")]
    public class FactorySessionDefault : FactorySessions
    {
        public override HashSet<ISession> GetSessions()
        {
            var session = new HashSet<ISession>()
            {
                new SessionMainDefault()

            };

            return session;
        }

    }
}