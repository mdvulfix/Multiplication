using UnityEngine;
using UnityEngine.SceneManagement;
using Framework.Core;


namespace Framework
{
    public class ControllerSceneDefault : ControllerScene
    {
        
        
        public override void Initialize()
        {
            SetSceneObject(SCENEOBJECT_NAME);
            Log(Label, "was sucsessfully initialized");

        } 
        
        
        public override void Configure() 
        {      
            
            Log(Label, "was successfully configured.");
        }
        
        public override void OnSceneEnter(IScene scene)
        {

        }

        public override void OnSceneExit(IScene scene)
        {

        }

    }

}
