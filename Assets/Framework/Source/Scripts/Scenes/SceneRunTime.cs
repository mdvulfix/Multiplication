using Framework.Core;

namespace Framework
{
    public class SceneRunTime : Scene
    {
        protected static readonly string OBJECT_NAME = "Scene: RunTime";
        
        public SceneRunTime()
        {
            Initialize();
        }

        public override ICacheable Initialize()
        {
            Label = OBJECT_NAME;
            Log(Label, "was sucsessfully initialized");
            return this;
        }

        public override ICacheable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }


    }
}
