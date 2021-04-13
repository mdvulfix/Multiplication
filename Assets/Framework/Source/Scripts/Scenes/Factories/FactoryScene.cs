using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryScene", menuName = "Factories/Scene/Default")]
    public class FactoryScene : AFactory<IScene>
    {
        [SerializeField]
        private FactoryData factoryData;
        
        public override List<IScene> Get()
        {
            var lsit = new List<IScene>()
            {
                GetAndInitialize<SceneCore>(SceneCore.OBJECT_NAME),
                GetAndInitialize<SceneMenu>(SceneMenu.OBJECT_NAME),
                GetAndInitialize<SceneRunTime>(SceneRunTime.OBJECT_NAME)
            };

            return lsit;
        }

        private IScene GetAndInitialize<T>(string name) where T: AScene, new()
        {
            var instance = GetInstanceOfSimpleObject<T>(name);
            instance.Initialize();

            return instance;
        }

    }
}
