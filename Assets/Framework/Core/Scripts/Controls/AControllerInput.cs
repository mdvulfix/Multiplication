using System.Collections.Generic;
using UnityEngine;


namespace Framework.Core 
{

    public interface IControllerInput: IController, IUpdatable
    {
        
    } 
    
    public abstract class AControllerInput : AController, IControllerInput
    {

#region Start&Update

        public abstract void OnStart();
        public abstract void OnUpdate();

#endregion

    }

}