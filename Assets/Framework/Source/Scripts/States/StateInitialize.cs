using Framework.Core;

namespace Framework
{
    public class StateInitialize : State
    {
        protected static readonly string OBJECT_NAME = "State: Initialize";
        
        public StateInitialize()
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