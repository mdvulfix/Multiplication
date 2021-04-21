using UnityEngine;
using UnityEngine.SceneManagement;
using Framework.Core;


namespace Framework
{
    
    public class ControllerScene: AControllerScene
    {
        
        public static readonly string OBJECT_NAME = "Controller: Scene";
        
        
        [Header("Scenes")]
        [SerializeField] private SceneCore sceneCore;
        [SerializeField] private SceneMenu sceneMenu;
        [SerializeField] private SceneRunTime sceneRunTime;
        [SerializeField] private SceneScore sceneScore;
        
        public override void OnAwake()
        {
            Initialize();

            if(isProject)
            {
                SetToCache(sceneCore);
                SetToCache(sceneMenu);
                SetToCache(sceneRunTime);
                SetToCache(sceneScore);

                foreach (var instance in Cache.GetAll())
                {
                    instance.Initialize();
                }
            }

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

    }

}
