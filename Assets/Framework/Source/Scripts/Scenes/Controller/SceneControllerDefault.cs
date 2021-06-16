using Core.Scene.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Source.Scene.Controller
{
    public class SceneControllerDefault: ASceneController
    {  
        public override void Init()
        {
            m_Indexes = new Dictionary<Type, SceneIndex>(10);
        
            m_Indexes.Add(typeof(SceneCore), SceneIndex.Core);
            m_Indexes.Add(typeof(SceneMenu), SceneIndex.Menu);
            m_Indexes.Add(typeof(SceneRunTime), SceneIndex.RunTime);


            if(isProject)
            {
                SetToCache(sceneCore);
                SetToCache(sceneMenu);
                SetToCache(sceneRunTime);
                SetToCache(sceneScore);

                foreach (var instance in Cache.GetAll())
                {
                    instance.Init();
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
