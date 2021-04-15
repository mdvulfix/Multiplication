using Framework.Core;

namespace Framework
{
    public class PageLogin : APage
    {
        public static readonly string OBJECT_NAME = "Page: Login";
        
        public override void Initialize()
        {
            SetSceneObject(OBJECT_NAME);
            

            Log(Label, "was sucsessfully initialized");
            //return this;

        }

        public override IConfigurable Configure()
        {
            Activate(false);
            
            Log(Label, "was sucsessfully configured");
            return this;
        }
    } 
}
