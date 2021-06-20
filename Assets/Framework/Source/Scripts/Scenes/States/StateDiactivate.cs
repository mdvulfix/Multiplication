using System;
using UnityEngine;


namespace Source.Scene.State
{
    public interface IStateDiactivate: IState
    {

    }
    
    public class StateDiactivate : AState, IStateDiactivate
    {

    
        public override void Execute()
        {
            
            //OnExecuted("Производится деактивация сцены...");

            Scene.Data.Object.SetActive(false);
            Controller<SceneController>().RemoveActivated(Scene);
            OnExecuted(state);
        }
        
        public override void Load()
        {
            Debug.Log("Конфигурация сцены уже произведена.");
        }

        public override void Enter()
        {
            Scene.SetState<StateActivate>();
            Debug.Log("Активация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Play()
        {
            Scene.SetState<StateActivate>();
            Debug.Log("Активация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Pause()
        {
            Debug.Log("Деактивация сцены уже произведена.");
        }

        public override void Exit()
        {
            Debug.Log("Деактивация сцены уже произведена.");
        }

        public override void Unload()
        {
            Scene.SetState<StateDispose>();
            Debug.Log("Закрытие сцены [" + Scene.GetType().Name + "] успешно выполнено.");
        }
    }
}