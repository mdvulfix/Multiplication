using System;

namespace Framework.Core 
{
    
    public interface ISession: ICacheable
    {
        
    }
    
    
    
    [Serializable]
    public abstract class Session : SceneObject, ISession
    {
        


        
    }


}