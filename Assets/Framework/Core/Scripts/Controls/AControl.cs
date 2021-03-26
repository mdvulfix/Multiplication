using UnityEngine;

namespace Framework.Core
{
    public interface IControl: ICacheable
    {
        
    
    }     
    
    
    public abstract class AControl : ScriptableObject, IControl 
    {
        public abstract void OnAwake();
        public abstract void OnUpdate();
    
    }

}