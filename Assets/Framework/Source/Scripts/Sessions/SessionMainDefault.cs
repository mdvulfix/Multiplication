using System;
using Framework.Core;

namespace Framework 
{
    [Serializable]
    public class SessionMainDefault : Session
    {

        private readonly string SESSION = "Session: Main";

        public override void Configure() 
        {
            Initialize(SESSION);
            
        
        }
    }
}