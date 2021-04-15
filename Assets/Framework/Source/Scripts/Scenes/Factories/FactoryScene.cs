using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactoryScene", menuName = "Factories/Scene/Default")]
    public class FactoryScene : AFactory<IScene>
    {       
        
        public static readonly string OBJECT_NAME = "Factory: Scene";
        
        
#region Configure

        public override void Initialize()
        {
            
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
               
        }

        public override IConfigurable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }
        
#endregion

#region Get
        
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
            var instance = GetInstanceOf<T>(name);
            instance.Initialize();

            return instance;
        }
        
#endregion

    }
}
