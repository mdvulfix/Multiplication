using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageLogin : Page
    {
        protected static readonly string OBJECT_NAME = "Page: Login";
        
        public override void Initialize()
        {
            SetSceneObject(OBJECT_NAME);
            Activate(false);

            Log(Label, "was sucsessfully initialized");

        }

        public override ICacheable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }
    } 
}
