using Core;
using Core.Scene;
using Core.State;

namespace Source.State
{

    public class StateControllerDefault: AStateController, IStateController
    {

        public StateControllerDefault(IStateControllerInitializationParams parametrs)
        {
            Initialize(parametrs);

            State<StateInitialize>();
            State<StateRegister>();
            State<StatePlaying>();
            State<StateWin>();
            State<StateDie>();

            var stateParams = new StateInitializationParams(m_Session, this, m_SceneController);

            foreach (var state in Cache.GetAll())
            {
                state.Initialize(stateParams);
            }
        
        
        }

    }

    public struct StateControllerInitializationParams: IStateControllerInitializationParams
    { 
        public ISession Session { get; private set; }
        public ISceneController SceneController { get; private set; }

        public StateControllerInitializationParams(ISession session, ISceneController sceneController)
        {
            Session = session;
            SceneController = sceneController;
        }

    }
    
    public struct StateInitializationParams: IStateInitializationParams
    { 
        public ISession Session { get; private set; }     
        public IStateController StateController { get; private set; }
        public ISceneController SceneController { get; private set; }
        

        public StateInitializationParams(ISession session, IStateController stateController, ISceneController sceneController)
        {
            Session = session;
            StateController = stateController;
            SceneController = sceneController;
        }

    }

}
