using System.Collections.Generic;
using UnityEngine;


namespace Core.Input.Controller
{
    public interface IInputController: IController
    {
        
    } 
    
    public abstract class AInputController : AController, IInputController
    {


    }

}