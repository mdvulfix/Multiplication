using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class ControlInputDefault : ControlInput
    {
        private readonly string PAGE_NAME = "Control: Input";
    
        public InputAction InputActionByTyping;
        
        public override void Configure()
        {
            InputActionByTyping += InputMethod_1(KeyCode.F);
            InputActionByTyping += InputMethod_2(KeyCode.F);
            InputActionByTyping += InputMethod_3(KeyCode.F);
            InputActionByTyping += InputMethod_4(KeyCode.F);
        
        }

        public override void InputMethod_1(KeyCode kode)
        {
            Input.GetKeyDown(kode);
        }

        public override void InputMethod_2(KeyCode kode)
        {
            Input.GetKeyDown(kode);
        }
        
        public override void InputMethod_3(KeyCode kode)
        {
            Input.GetKeyDown(kode);
        }
        
        public override void InputMethod_4(KeyCode kode)
        {
            Input.GetKeyDown(kode);
        }

        public void TypeCode(KeyCode kode)
        {
            InputActionByTyping.Invoke(kode);
        }
    
    
    }
}
