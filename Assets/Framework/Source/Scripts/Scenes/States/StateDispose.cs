using System;
using UnityEngine;

namespace Source.Scene.State
{
    public interface IStateDispose: IState
    {

    }

    public class StateDispose : AState, IStateDispose
    {

    
        public override void Execute()
        {
            
            //Controller.Execute(this);
            //OnExecuted("Производится удаление сцены...");

            Controller<SceneController>().RemoveLoaded(Scene);
            OnExecuted(state);
        }
        
        public override void Load()
        {
            Scene.SetState<StateConfigure>();
            Debug.Log("Конфигурация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Enter()
        {
            Scene.SetState<StateConfigure>();
            Debug.Log("Конфигурация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        

        public override void Play()
        {
            Debug.Log("Сцена не проконфигурирована.");
        }

        public override void Pause()
        {
            Debug.Log("Сцена не активирована.");
        }

        public override void Exit()
        {
            Debug.Log("Сцена не активирована.");
        }

        public override void Unload()
        {
            Debug.Log("Сцена не открыта.");
        }
    }
}
