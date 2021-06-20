using System;
using UnityEngine;
using Core.Scene.State;


namespace Sourse.Scene.State
{
    public interface IStateActivate: IState
    {

    }
    
    public class StateActivate : AState, IStateActivate
    {
        public override void Execute()
        {

            
            //SetSceneActive(true);
            //OnExecuted("Активация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        
            Scene.Data.Object.SetActive(true);
            Controller<SceneController>().AddActivated(Scene);
            OnExecuted(state);
        
        }
        
        public override void Load()
        {
            Debug.Log("Конфигурация сцены уже произведена.");
        }

        public override void Enter()
        {
            
            Debug.Log("Конфигурация сцены уже произведена.");
        }

        public override void Play()
        {
            
            Debug.Log("Активация сцены уже произведена.");
        
        }

        public override void Pause()
        {
            Scene.SetState<StateDiactivate>();
            Debug.Log("Диактивация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Exit()
        {
            Scene.SetState<StateDiactivate>();
            Debug.Log("Диактивация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Unload()
        {
            Debug.Log("Сцена не деактивирована.");
        }
    }
}
