using Framework.Core;

namespace Framework
{
    public class SceneMenu : AScene
    {
        public static readonly string OBJECT_NAME = "Scene: Menu";
        
        public SceneMenu()
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
