using UnityEngine;

namespace Framework.Core
{
    public interface IState: ISimpleObject, IConfigurable, ICacheable, IDebug
    {
        
    }
    
    public abstract class State: SimpleObject, IState
    {
        
        public bool         UseDebug    {get; set;} = true;
        public IDataStats   DataStats   {get; set;}

        public abstract void Initialize();
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
