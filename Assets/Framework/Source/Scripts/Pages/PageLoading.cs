using System.Collections;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PageLoading : Page
    {
        protected static readonly string OBJECT_NAME = "Page: Loading";
        
        public override ICacheable Initialize()
        {
            SetSceneObject(OBJECT_NAME);
            Activate(false);

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
