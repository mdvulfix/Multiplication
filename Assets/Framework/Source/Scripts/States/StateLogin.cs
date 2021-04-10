using Framework.Core;

namespace Framework
{
    public class StateLogin : State
    {
        protected static readonly string OBJECT_NAME = "State: Login";
        
        public StateLogin()
        {
            Initialize();
        }

        public override void Initialize()
        {
            Label = OBJECT_NAME;
            Log(Label, "was sucsessfully initialized");
        }

        public override ICacheable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }

    }
}
