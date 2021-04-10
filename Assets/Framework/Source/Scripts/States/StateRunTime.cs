using Framework.Core;

namespace Framework
{
    public class StateRunTime : State
    {
        protected static readonly string OBJECT_NAME = "State: RunTime";
        
        public StateRunTime()
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
