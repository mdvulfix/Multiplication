using UnityEngine;


namespace Framework.Core
{
    public interface IControllerUpdate: IController, IUpdatable 
    {

    } 
    
    public abstract class AControllerUpdate : AController, IControllerUpdate
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
