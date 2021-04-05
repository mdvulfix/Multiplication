using System;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Core
{
    
    public interface IBuilder
    {
        Dictionary<Type, IControl> Controls {get; }
        Dictionary<Type, ISession> Sessions {get; }
        
        void OnAwake();        
    }
    
    
    public abstract class Builder : Singleton<Builder>, IBuilder
    {
        public Dictionary<Type, IControl> Controls {get; private set;}
        public Dictionary<Type, ISession> Sessions {get; private set;}
        
        public void Awake()
        { 
            Controls = new Dictionary<Type, IControl>(15);
            Sessions = new Dictionary<Type, ISession>(1);
            
            OnAwake();
        }
    
        public abstract void OnAwake();
        public abstract void Configure();
    }
}