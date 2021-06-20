using System;
using System.Collections.Generic;
using UnityEngine;
using Core.Scene.State;

namespace Source.Scene.State
{

    public class StateControllerDefault: AStateController, IStateController
    {
        private static readonly int INITIALIZATION_INDEX_TYPEOF_ISCENE = 0;

        public override void Initialize (params object[] args)
        {
            Initialize(INITIALIZATION_INDEX_TYPEOF_ISCENE);


            
            m_ScenesIndexes.Add(typeof(SceneCore), SceneIndex.Core);
            m_ScenesIndexes.Add(typeof(SceneMenu), SceneIndex.Menu);
            m_ScenesIndexes.Add(typeof(SceneRunTime), SceneIndex.RunTime);

            Set<StateInitialize>();
            Set<StateConfigure>();
            Set<StateActivate>();
            Set<StateDiactivate>();
            Set<StateDispose>();
        }
    }
}
