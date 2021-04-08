using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageLogin : Page
    {
        private readonly string SCENEOBJECT_NAME = "Page: Login";
        
        public override void Initialize()
        {
            SetSceneObject(SCENEOBJECT_NAME);
            Activate(false);

            Log(Label, "was sucsessfully initialized");
        } 
    }
}
