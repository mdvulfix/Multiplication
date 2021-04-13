using System;
using UnityEngine;

namespace Framework.Core 
{
    
    public interface ISession: IConfigurable, ICacheable, IDebug
    {

    }
    
    
    
    [Serializable]
    public abstract class ASession : ASceneObject, ISession
    {
        public static readonly string PARENT_OBJECT_NAME = ABuilder.OBJECT_NAME_SESSIONS; 
        
        public bool         UseDebug  {get; set;} = true;        
        public IDataStats   DataStats {get; set;}

        
        public abstract void Initialize();
        public abstract IConfigurable Configure();

        
#region DebugFunctions

        public virtual void Log(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
                
        }

        public virtual void LogWarning(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.LogWarning("["+ instance +"]: " + message);
            }
        }

#endregion
    
    }


}