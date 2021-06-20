using System;
using UnityEngine;
using Core.Session;
using Core.Scene;
using Core.Input;
using Source.Scene;
//using Source.Input;


namespace Source.Session 
{
    [Serializable]
    public class SessionDefault : ASession
    {
        private ISceneController m_SceneController;
        //private IInputController m_InputController;

        public override void Initialize(params object[] args) 
        {
            m_SceneController = ControllerSetAndGet<SceneControllerDefault>();
            //m_InputController = Controller<InputControllerDefault>();
        }

        public override void OnAwake()
        {

        }
       
        public override void OnStart()
        {
            //m_SceneCurrent.Load();
            m_SceneController.SceneLoad(SceneIndex.Menu);
        }

    }
}