using System;

namespace Framework.Core 
{
    
    public interface ISession
    {
        void Configure();
    }
    
    
    
    [Serializable]
    public abstract class Session : SceneObject, ISession
    {
        public abstract void Configure();

        
    }


}