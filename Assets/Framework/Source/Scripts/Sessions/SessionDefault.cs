using System;
using UnityEngine;
using Core.Session;

namespace Framework.Session 
{
    [Serializable]
    public class SessionDefault : ASession
    {

        private ISceneController m_SceneController;
        private IInputController m_InputController;

        public override void Init() 
        {
             m_SceneController = Controller<SceneControllerDefault>();
             m_InputController = Controller<InputControllerDefault>();
        }


    }
}