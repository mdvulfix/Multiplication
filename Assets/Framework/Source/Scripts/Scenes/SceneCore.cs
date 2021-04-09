using Framework.Core;

namespace Framework
{
    public class SceneCore : Scene
    {
        protected static readonly string OBJECT_NAME = "Scene: Core";
        
        public SceneCore()
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
