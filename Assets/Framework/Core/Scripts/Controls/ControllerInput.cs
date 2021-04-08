using UnityEngine;


namespace Framework.Core 
{
    public abstract class ControllerInput : Controller
    {

        public delegate void InputAction (KeyCode kode);
    
        public abstract void InputMethod_1(KeyCode kode);
        public abstract void InputMethod_2(KeyCode kode);
        public abstract void InputMethod_3(KeyCode kode);
        public abstract void InputMethod_4(KeyCode kode);
    
    }

}