using Framework.Core;

namespace Framework
{
    public class StateBuilding : AState
    {
        public static readonly string OBJECT_NAME = "State: Building";
        
        public StateBuilding()
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
