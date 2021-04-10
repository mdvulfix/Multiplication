using UnityEngine;
using UnityEngine.SceneManagement;
using Framework.Core;


namespace Framework
{
    public class ControllerSceneDefault : ControllerScene
    {
        
        
        public override void Initialize()
        {
            SetSceneObject(ControllerScene.OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
        } 
        
        
        public override ICacheable Configure() 
        {                                     
            foreach (var scene in Cache.Store.Values)
            {
                scene.Initialize();
            }

            SceneActive = Cache.Get<SceneCore>();
            Log(Label, "was successfully configured.");
            return this;
        }
        
        public override void OnSceneEnter(IScene scene)
        {

        }

        public override void OnSceneExit(IScene scene)
        {

        }

    }

}
