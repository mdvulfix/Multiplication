using System;
using Framework.Core;

namespace Framework 
{
    [Serializable]
    public class SessionMain : Session
    {
        protected static readonly string OBJECT_NAME = "Session: Main";

        public override void Initialize() 
        {
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
        }

        public override ICacheable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }
    }
}