using System;
using Core.State;
using UnityEngine;

namespace Source.State
{
   public interface IStateInitialize: IState
   {

   }
    
    public class StateInitialize: AState, IStateInitialize
    {       
        
        
        private IStateController m_StateController;
        
        
        
        
        
        public override void Execute()
        {

            OnExecuted(this);
        }

        
        public override void Load()
        {
            //Scene.SetState<StateConfigure>();
            //OnUpdated("Конфигурация сцены [" + GetSceneNameViaType(Scene) + "] успешно выполнена.");
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

