using System.Collections.Generic;

namespace Framework.Core.Scene.State.Controller
{    

    public interface IStateController: IController<IState>
    {    
        IState StateActive {get; }
    
    
    } 
    
    public abstract class AStateController : AController<IState>, IStateController
    {       
        public IState StateActive  {get; protected set;}       


    
    }
}
