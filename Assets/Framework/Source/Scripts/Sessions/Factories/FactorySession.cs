using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "FactorySession", menuName = "Factories/Session/Default")]
    public class FactorySession : AFactory<ISession>
    {
        
        public static readonly string OBJECT_NAME = "Factory: Session";
        
        
#region Configure

        public override void Initialize()
        {
            
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
          
        }

        public override IConfigurable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }
        
#endregion
        
#region Get
        
        public override List<ISession> Get()
        {
            var list = new List<ISession>()
            {
                GetAndInitialize<Session>(Session.OBJECT_NAME)
            };
            
            return list;
        }

        private ISession GetAndInitialize<T>(string name) where T: ASession
        {
            var instance = GetInstanceOf<T>(name,  FindSceneObjectByName(ABuilder.OBJECT_NAME_SESSIONS));
            instance.Initialize();
            return instance;
        }

#endregion

    }
}