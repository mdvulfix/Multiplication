using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryScene", menuName = "Factories/Scenes")]
    public class FactoryScene : Factory
    {
        [SerializeField]
        private FactoryData factoryData;
        
        public override List<IScene> Get<IScene>()
        {
            var lsit = new List<IScene>()
            {
                (IScene)GetInstanceOf<SceneCore>("Scene: Core").Initialize(),
                (IScene)GetInstanceOf<SceneMenu>("Scene: Menu").Initialize(),
                (IScene)GetInstanceOf<SceneRunTime>("Scene: RunTime").Initialize()
            };

            return lsit;
        }
    }
}
