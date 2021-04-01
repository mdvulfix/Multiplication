using System.Collections.Generic;

namespace Framework.Core
{
    
    public interface IBuilder
    {
        void Awake();        
    }
    
    
    public abstract class Builder : Singleton<Builder>, IBuilder
    {

        public void Awake()
        { 
            Initialize();
        }
    
        
        public abstract HashSet<IControl> GetControls();
        public abstract HashSet<ISession> GetSessions();
        public abstract void Configure();
    }
}