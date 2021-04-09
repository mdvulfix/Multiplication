using System;
using UnityEditor;

namespace Framework.Core
{

    public interface IControllerData: IController
    {
       
        
    } 

    [Serializable]
    public abstract class ControllerData: Controller, IControllerData
    {


    }
}
