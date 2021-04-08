using System;
using Framework.Core;

namespace Framework 
{
    [Serializable]
    public class SessionMain : Session
    {

        protected readonly string SCENEOBJECT_NAME = "Session: Main";

        public override void Initialize() 
        {
            SetSceneObject(SCENEOBJECT_NAME);
            Log(Label, "was configured.");
        
        
        
        }
    }
}