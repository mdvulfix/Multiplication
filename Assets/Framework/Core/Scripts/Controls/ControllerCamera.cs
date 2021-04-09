using UnityEngine;
using UnityEditor;

namespace Framework.Core
{

    public interface IControllerCamera: IController
    {
       
        
    } 

    public abstract class ControllerCamera: Controller, IControllerCamera
    {
        protected static readonly string OBJECT_NAME = "Controller: Camera";

    
    }

}
