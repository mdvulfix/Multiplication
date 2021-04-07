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
            SceneCurrent = (Scene)DataHash.Get(typeof(SceneMenu).GetHashCode());
            SceneCurrent.IsActive = true;
        }

        public override void Configure()
        {
            DataHash = new DataHash();
            
            DataHash.Add(new SceneCore());
            DataHash.Add(new SceneMenu());
            DataHash.Add(new SceneRunTime());


        }
    

    
    }


}
