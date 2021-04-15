using UnityEngine;
using Framework.Core;
using Framework.Core.Handlers;

namespace Framework
{
    public class PageLogin : APage
    {
        public static readonly string OBJECT_NAME = "Page: Login";
        
        public override void Initialize()
        {
            SetSceneObject(OBJECT_NAME);
            SetData(DataStruct);
            

            Log(Label, "was sucsessfully initialized");
            //return this;

        }

        public override IConfigurable Configure()
        {
            DataStats.ID = 2;

            DataAnimation.UseAnimation = true;
            DataAnimation.Animator = GetComponent<Animator>();

            
            Activate(false);
            Log(Label, "was sucsessfully configured");
            return this;
        }
    } 
}
