using System.Collections.Generic;

namespace Framework.Core
{
    
    public interface IBuilder
    {
        void OnAwake();        
    }
    
    
    public abstract class Builder : Singleton<Builder>, IBuilder
    {

        public void Awake()
        { 
            OnAwake();
        }
    
        
        public abstract HashSet<IControl> GetControls();
        public abstract HashSet<ISession> GetSessions();
        public abstract void OnAwake();
        public abstract void Configure();
    }
}