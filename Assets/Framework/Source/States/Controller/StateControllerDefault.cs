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

        }

    }

    public struct StateControllerInitializationParams: IStateControllerInitializationParams
    { 
        public ISession Session { get; private set; }
        public ISceneController SceneController { get; private set; }
        public IStateFactory StateFactory { get; private set; }
        public IStateInitializationParams StateInitializationParams { get; private set; }

        public StateControllerInitializationParams( ISession session, 
                                                    ISceneController sceneController,
                                                    IStateFactory stateFactory,
                                                    IStateInitializationParams stateInitializationParams)
        {
            Session = session;
            SceneController = sceneController;
            StateFactory = stateFactory;
            StateInitializationParams = stateInitializationParams;
        }

    }
    
    public struct StateInitializationParams: IStateInitializationParams
    { 
        public ISession Session { get; private set; }     
        public ISceneController SceneController { get; private set; }
        

        public StateInitializationParams(ISession session, ISceneController sceneController)
        {
            Session = session;
            SceneController = sceneController;
        }

    }

}
