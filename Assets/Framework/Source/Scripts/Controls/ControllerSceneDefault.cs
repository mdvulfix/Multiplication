using UnityEngine;
using UnityEngine.SceneManagement;
using Framework.Core;


namespace Framework
{
    public class ControllerSceneDefault : AControllerScene
    {
        
        public static readonly string OBJECT_NAME = "Controller: Scene";
        
         
        public override void OnAwake()
        {
            //SetToCache(pageLoading);
            //SetToCache(pageLogin);
            //SetToCache(pageMenu);
            
            Initialize();
            Configure();

        }
        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
        } 
        
        
        public override IConfigurable Configure() 
        {                                     


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
