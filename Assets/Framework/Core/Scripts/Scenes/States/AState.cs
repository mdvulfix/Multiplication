using UnityEngine;

namespace Core.Scene.State
{
    public interface IState
    {
        
    }
    
    public abstract class AState: IState
    {
        public IDataStats Stats { get; set; }

        public abstract void Init();
            
    }
}
