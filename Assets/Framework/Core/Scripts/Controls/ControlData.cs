using System;
using UnityEditor;

namespace Framework.Core
{

    public interface IControlData: IControl
    {
       
        
    } 

    [Serializable]
    public class ControlData: Control, IControlData
    {
        public static DataHash DataHash {get; set;}
        
        public Scene SceneCurrent;
        
        public void Start()
        {   
            
            
            Configure();
            SceneCurrent = DataHash.Get<SceneMenu>();
            SceneCurrent.IsActive = true;
        }

        public override void Configure()
        {
            DataHash = new DataHash();
            
            DataHash.Add<SceneCore>(new SceneCore());
            DataHash.Add<SceneMenu>(new SceneMenu());
            DataHash.Add<SceneRunTime>(new SceneRunTime());


        }
    

    
    }


}
