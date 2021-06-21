using UnityEngine;
using UnityEngine.SceneManagement;
using Core;
using Core.Scene;


namespace Source.Scene.Controller
{
    public class SceneControllerDefault: ASceneController
    {  

        
        public override void Initialize(IScene handler, ICache<IScene> cache = null, params object[] args)
        {        
            m_SceneIndexes.Add(typeof(SceneCore), SceneIndex.Core);
            m_SceneIndexes.Add(typeof(SceneMenu), SceneIndex.Menu);
            m_SceneIndexes.Add(typeof(SceneRunTime), SceneIndex.RunTime);


            //if(isProject)
            //{
            //    SetToCache(sceneCore);
            //    SetToCache(sceneMenu);
            //    SetToCache(sceneRunTime);
            //    SetToCache(sceneScore);

            //    foreach (var instance in Cache.GetAll())
            //    {
            //        instance.Init();
            //    }
           // }

            //Log(Label, LogSuccessfulInitialize());
            //return this;
        
        } 
        
        /*
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

    */

    }

}
