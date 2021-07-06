using System.Collections;
using UnityEngine;
using Core.State;


namespace Source.State
{

    public interface IStatePlaying: IState
    {

    }
    
    public class StatePlaying : AState, IStatePlaying
    {
        public StatePlaying(IStateInitializationParams parametrs)
        {
            Initialize(parametrs);
        }

        public override void Execute()
        {
            //Controller.Execute(this);
            
            //OnExecuted("Производится конфигурирование сцены...");
            //Controller<SceneController>().AddLoaded(Scene);
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
            //Debug.Log("Сцена не активирована.");
        }

        public override void Exit()
        {
            //Scene.SetState<StateDispose>();
            //Debug.Log("Закрытие сцены [" + Scene.GetType().Name + "] успешно выполнено.");
        }

        public override void Close()
        {

        }
    
    

    
    
    
    
    }
}
