using UnityEngine;

namespace Framework.Core
{
    public interface IState: ISimpleObject, IConfigurable, ICacheable, IDebug
    {
        
    }
    
    public abstract class AState: ASimpleObject, IState
    {
        
        public bool         UseDebug    {get; set;} = true;
        public IDataStats   Stats   {get; set;}

        public abstract void Initialize();
        public abstract IConfigurable Configure();
            
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
