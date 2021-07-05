using System;
using UnityEngine;
using Core.State;
using Source.Scene;

namespace Source.State
{
    public interface IStateRegister: IState
    {

    }
    
    public class StateRegister : AState, IStateRegister
    {
        public override void Execute()
        {
            
            m_SceneController.SceneEnter<SceneMenu>();
            OnExecuted(this);
        
        }
        
        public override void Load()
        {
            //Debug.Log("Конфигурация сцены уже произведена.");
        }

        public override void Play()
        {
            
            //Debug.Log("Активация сцены уже произведена.");
        
        }

        public override void Pause()
        {
            //Session.SetState<StateDiactivate>();
            //Debug.Log("Диактивация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Exit()
        {
            //Session.SetState<StateDiactivate>();
            //Debug.Log("Диактивация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Close()
        {
            //Debug.Log("Сцена не деактивирована.");
        }
    }
}
