using System;
using UnityEngine;

namespace Source.Scene.State
{
   public interface IStateInitialize: IState
   {

   }
    
    public class StateInitialize: AState, IStateInitialize
    {       
        public override void Execute()
        {
            //Controller.Execute(this);
            //SetSceneActive(false);
            //OnExecuted("Инициализация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        
            Controller<SceneController>().AddInitialized(Scene);            
            Scene.Data.Object.SetActive(false);
            OnExecuted(state);
        
        }

        public override void Load()
        {
            Scene.SetState<StateConfigure>();
            OnUpdated("Конфигурация сцены [" + GetSceneNameViaType(Scene) + "] успешно выполнена.");
        }

        public override void Enter()
        {
            Debug.Log("Сцена не проконфигурирована.");
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

