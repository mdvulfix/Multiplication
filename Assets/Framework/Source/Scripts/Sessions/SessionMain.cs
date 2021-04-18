using System;
using Framework.Core;

namespace Framework 
{
    [Serializable]
    public class SessionMain : ASession
    {
        public static readonly string OBJECT_NAME = "Session: Main";

        public override void Initialize() 
        {
            SetParams(OBJECT_NAME);
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