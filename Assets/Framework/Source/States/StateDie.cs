using System;
using UnityEngine;
using Core.State;

namespace Source.State
{
    public interface IStateDie: IState
    {

    }

    public class StateDie : AState, IStateDie
    {
        public StateDie(IStateInitializationParams parametrs)
        {
            Initialize(parametrs);
        }

        public override void Execute()
        {
            
            //Controller.Execute(this);
            //OnExecuted("Производится удаление сцены...");

            //Controller<SceneController>().RemoveLoaded(Scene);
            //OnExecuted(state);
        }
        
        public override void Load()
        {
            //Scene.SetState<StateConfigure>();
            //Debug.Log("Конфигурация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }
      
        public override void Play()
        {
            //Scene.SetState<StateConfigure>();
            //Debug.Log("Конфигурация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Pause()
        {
            //Debug.Log("Сцена не активирована.");
        }

        public override void Exit()
        {
            //Debug.Log("Сцена не активирована.");
        }

        public override void Close()
        {
            //Debug.Log("Сцена не открыта.");
        }
    }
}
