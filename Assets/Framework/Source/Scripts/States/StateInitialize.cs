using Framework.Core;

namespace Framework
{
    public class StateInitialize : AState
    {
        public static readonly string OBJECT_NAME = "State: Initialize";
        
        public StateInitialize()
        {

        }

        public override void Initialize()
        {
            Label = OBJECT_NAME;
            Log(Label, "was sucsessfully initialized");
            //return this;
        }

        public override IConfigurable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }

    }
}