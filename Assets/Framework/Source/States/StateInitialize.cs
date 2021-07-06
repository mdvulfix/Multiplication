using System;
using Core;
using Core.State;
using Source.Scene;
using UnityEngine;

namespace Source.State
{
   public interface IStateInitialize: IState
   {

   }
    
    public class StateInitialize: AState, IStateInitialize
    {
        public StateInitialize(IStateInitializationParams parametrs)
        {
            Initialize(parametrs);
        }

        public override void Execute()
        {
            //m_SceneController.SceneLoad<SceneMenu>();
            OnExecuted(this);
        }

        
        public override void Load()
        {
            m_Session.SetState<StateRegister>();
        }

        public override void Play()
        {
            //Debug.Log("Сцена не проконфигурирована.");
        }

        public override void Pause()
        {
            //Debug.Log("Сцена не активирована.");
        }

        public override void Exit()
        {
           // Debug.Log("Сцена не открыта.");
        }

        
        public override void Close()
        {
            //Debug.Log("Сцена не открыта.");
        }
    }
}

