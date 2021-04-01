using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "Factory Scene (Default)", menuName = "Factories/Scenes/Default")]
    public class FactorySceneDefault : FactoryScene
    {
        public override HashSet<IScene> GetScenes()
        {
            var scenes = new HashSet<IScene>()
            {


            };

            return scenes;
        }

    }
}
