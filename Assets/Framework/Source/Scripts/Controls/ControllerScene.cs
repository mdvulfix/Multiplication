using UnityEngine;
using UnityEngine.SceneManagement;
using Framework.Core;


namespace Framework
{
    
    public class ControllerScene: AControllerScene
    {
        
        public static readonly string OBJECT_NAME = "Controller: Scene";
        
        
        [Header("Controllers")]
        [SerializeField] private ControllerPage controllerPage;
        
        
        [Header("Scenes")]
        [SerializeField] private SceneCore sceneCore;
        [SerializeField] private SceneMenu sceneMenu;
        [SerializeField] private SceneRunTime sceneRunTime;
        [SerializeField] private SceneScore sceneScore;
        
                
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);

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

            Log(Label, LogSuccessfulInitialize());
            //return this;
        
        } 
        
        public override IConfigurable Configure() 
        {                                     
            
            if(Cache.IsEmpty())
            {
                LogWarning(Label, LogFailedConfigure("Cache is empty!"));
                return null;
            }
            else
            {
                foreach (var instance in Cache.GetAll())
                {
                    instance.Configure();
                }

            }

            SceneEnter<SceneMenu, PageMenu>();
            
            Log(Label, LogSuccessfulConfigure());
            return this;
        }



    }

}
