using Core;
using Core.State;

namespace Source.State
{

    public class StateControllerDefault: AStateController, IStateController
    {

        protected override void OnInitialize()
        {
            State<StateInitialize>(Handler as ISession);
        }



        public override TState State<TState>(ISession session)
        {
            //TODO: DI;
            IState state;

            if(!Cache.Get<TState>(out state))
            {
                state = new TState();
                state.Initialize(session);
                Cache.Add(state);
            }

            return state as TState;
        }
    }
}
