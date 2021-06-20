using UnityEngine;


namespace Core.Update.Controller
{
    public interface IUpdateController: IController 
    {

    } 
    
    public abstract class AUpdateController : AController, IUpdateController
    {


#region Start&Update
        

        
        public void Start()
        {
            OnStart();
        }
        
        public void Update()
        {
            OnUpdate();
        } 

        public abstract void OnStart();
        public abstract void OnUpdate();

#endregion
    
    }

}
