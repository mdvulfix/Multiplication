using UnityEngine;
using UnityEngine.SceneManagement;
using Framework.Core;


namespace Framework
{
    public class ControllerSceneDefault : ControllerScene
    {
        
        
        public override IController Initialize()
        {
            SetSceneObject(SCENEOBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            return this; 
        } 
        
        
        public override IController Configure() 
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
