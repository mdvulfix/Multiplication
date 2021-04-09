using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{   
    [CreateAssetMenu(fileName = "FactoryControllerScene", menuName = "Factories/Controllers/Scene/Default")]
    public class FactoryControllerScene : FactoryController
    {
        [SerializeField]        
        private FactoryScene factoryScene;
        
        public override IController Get()
        {
            if(factoryScene == null)
            {
                LogWarning(Label, "Factory scene was not set!");
                return null;
            }
            
            
            var instance = GetInstanceOf<ControllerSceneDefault>("Controller: Scene", Controller.PARENT_OBJECT_NAME).Initialize() as IControllerScene;           
            var scenes = factoryScene.GetScenes();
            instance.SetToCache(scenes);
            return instance;
            
            
            var instance = GetInstanceOf<ControllerPageDefault>("Controller: Page", Controller.PARENT_OBJECT_NAME).Initialize() as IControllerPage;
            var pages = factoryPage.GetPages();
            instance.PageRegister(pages);

        }

    }
}
