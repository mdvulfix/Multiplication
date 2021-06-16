using System;
using UnityEngine;
using Core.Input.Controller;

namespace Framework.Input.Controller
{
    public class InputControllerDefault : AInputController
    {
        public static readonly string OBJECT_NAME = "Controller: Input";

        private KeyCode m_FadeIn;
        private KeyCode m_FadeOut;

        private ControllerPage m_ControllerPage;
        
        public override void Init()
        {
            m_FadeIn = KeyCode.I;
            m_FadeOut = KeyCode.O;
            m_ControllerPage = session.GetController<ControllerPage>();
        } 
        
        

#region Start&Update

        public override void OnStart()
        {

        }

        public override void OnUpdate()
        {
            if(Input.GetKeyUp(m_FadeIn))
            {
                //Log(Label, "Get key [ " + m_FadeIn + " ]!");
                //controllerPage.TurnPageOn(typeof(PageLoading));

            }

           if(Input.GetKeyUp(m_FadeOut))
            {
                //Log(Label, "Get key [ " + m_FadeOut + " ]!");
                //controllerPage.TurnPageOff(typeof(PageLoading), true);

            }
        }

#endregion
        
    }
}
