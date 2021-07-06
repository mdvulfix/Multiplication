using Core.State;

namespace Source.State
{
    public class StateFactoryDefault : AStateFactory
    {
        public StateFactoryDefault()
        {
            Add<StateInitialize>((parametrs) => new StateInitialize(parametrs));
            Add<StateRegister>((parametrs) => new StateRegister(parametrs));
            Add<StatePlaying>((parametrs) => new StatePlaying(parametrs));
            Add<StateWin>((parametrs) => new StateWin(parametrs));
            Add<StateDie>((parametrs) => new StateDie(parametrs));
        }
    }
}