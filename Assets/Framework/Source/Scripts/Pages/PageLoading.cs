using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageLoading : Page
    {
        private readonly string SCENEOBJECT_NAME = "Page: Loading";
        
        public override void Initialize()
        {
            SetSceneObject(SCENEOBJECT_NAME);
            Activate(false);

            Log(Label, "was sucsessfully initialized");

        } 
    }
}
