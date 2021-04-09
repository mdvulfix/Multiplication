using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IScene: ICacheable, ISimpleObject, IDebug
    {

    }
    
    [Serializable]
    public abstract class Scene: SimpleObject, IScene
    {
        
        public bool         UseDebug    {get; set;} = true;
        public IDataStats   DataStats   {get; set;}

        public abstract ICacheable Initialize();
        public abstract ICacheable Configure();
            
    
    
#region LogFunctions

        public void Log(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
        }

        
        public void LogWarning(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.LogWarning("["+ instance +"]: " + message);
            }
        }

#endregion
    
    }
}
