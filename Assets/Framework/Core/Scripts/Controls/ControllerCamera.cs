using UnityEngine;
using UnityEditor;

namespace Framework.Core
{

    public interface IControllerCamera: IController
    {
       
        
    } 

    public abstract class ControllerCamera: Controller, IControllerCamera
    {
        protected readonly string SCENEOBJECT_NAME = "Controller: Camera";

    
    }

}
