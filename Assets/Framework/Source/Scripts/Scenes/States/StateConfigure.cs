using System.Collections;
using Core.Scene.State;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityScene = UnityEngine.SceneManagement.Scene;

namespace Source.Scene.State
{

    public interface IStateConfigure: IState
    {

    }
    
    public class StateConfigure : AState, IStateConfigure
    {

    
        public override void Execute()
        {
            //Controller.Execute(this);
            
            //OnExecuted("Производится конфигурирование сцены...");
            Controller<SceneController>().AddLoaded(Scene);
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
            Scene.SetState<StateDispose>();
            Debug.Log("Закрытие сцены [" + Scene.GetType().Name + "] успешно выполнено.");
        }
    
    

    
    
    
    
    }
}
