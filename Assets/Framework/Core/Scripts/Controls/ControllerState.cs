using System.Collections.Generic;

namespace Framework.Core
{    

    public interface IControllerState: IController, IHasCache<IState>
    {    
        IState StateActive {get; }
    
        void OnStateEnter(IState state);
        void OnStateExit(IState state);
    
    } 
    
    
    
    public abstract class ControllerState : Controller, IControllerState
    {
        
        protected static readonly string OBJECT_NAME = "Controller: State";
        
        public ICache<IState>    Cache        {get; protected set;} = new Cache<IState>();
        public IState            StateActive  {get; protected set;}       

#region RegisterToCache

        public IState SetToCache(IState instance)
        {
            Cache.Add(instance as IState);
            return instance;
        }

        public void SetToCache(List<IState> instances)
        {
            foreach (var instance in instances)
            {
                SetToCache(instance);
            }
        }

#endregion



#region StateManagement
            
        public abstract void OnStateEnter(IState state);
        public abstract void OnStateExit(IState state);

#endregion
    






    }
}
