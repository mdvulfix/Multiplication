using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework.Factory
{
    
    /*
    
    [CreateAssetMenu(fileName = "FactoryState", menuName = "Factories/State/Default")]
    public class FactoryState : AFactory<IState>
    {

        public static readonly string OBJECT_NAME = "Factory: State";
          
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
        
        public override List<IState> Get()
        {
            var list = new List<IState>()
            {
                GetAndInitialize<StateInitialize>(StateInitialize.OBJECT_NAME),
                GetAndInitialize<StateLogin>(StateLogin.OBJECT_NAME),
                GetAndInitialize<StateRunTime>(StateRunTime.OBJECT_NAME)
            };

            return list;
        }
        
        private IState GetAndInitialize<T>(string name) where T: AState, new()
        {
            var instance = GetInstanceOf<T>(name);
            instance.Initialize();
            return instance;
        }

#endregion
    }


    */
}
