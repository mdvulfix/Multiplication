using System;
using UnityEditor;

namespace Framework.Core
{

    public interface IControllerData: IController
    {
       
        
    } 

    [Serializable]
    public class ControllerData: Controller, IControllerData
    {
        public static ICache<IScene>    CacheScene  {get; } = new Cache<IScene>();
        
        public Scene SceneCurrent;
        
        
        public void Start()
        {   
            Configure();
            SceneCurrent = (Scene)CacheScene.Get();
        }

        public override void Configure()
        {
            CacheScene.Add(new SceneCore());
            CacheScene.Add(new SceneMenu());
            CacheScene.Add(new SceneRunTime());

        }
    }
}
