using System;
using UnityEngine;
using Core.State;


namespace Source.State
{
    public interface IStateWin: IState
    {

    }
    
    public class StateWin : AState, IStateWin
    {

    
        public override void Execute()
        {
            

            OnExecuted(this);
        }
        
        public override void Load()
        {
            //Debug.Log("Конфигурация сцены уже произведена.");
        }

        public override void Play()
        {
            //Scene.SetState<StateActivate>();
            //Debug.Log("Активация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Pause()
        {
            
            //Scene.SetState<StateActivate>();
            //Debug.Log("Активация сцены [" + Scene.GetType().Name + "] успешно выполнена.");
        }

        public override void Exit()
        {
            //Debug.Log("Деактивация сцены уже произведена.");
        }

        public override void Close()
        {
            //Scene.SetState<StateDispose>();
            //Debug.Log("Закрытие сцены [" + Scene.GetType().Name + "] успешно выполнено.");
        }
    }
}