using System;

namespace Framework.Core 
{
    
    public interface ISession: ICacheable
    {
        void OnEnable();
    }
    
    
    
    [Serializable]
    public abstract class Session : SceneObject, ISession
    {
        


        
    }


}