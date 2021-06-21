using System;
using Core;
using Core.State;
using Source.State;

namespace Source 
{
    [Serializable]
    public class SessionDefault : ASession
    {
        
        
        protected override void OnAwake()
        {

            var stateController = new StateControllerDefault();
            var stateControllerParams = new ParamsStateController(this);

            stateController.
            
            var sessionParams = new ParamsInitialize<ISession>(this);




        }
        
        
        
        protected override void OnInitialize()
        {
            
            
            
            AddState<StateInitialize>();
            AddState<StateRegister>();
            AddState<StatePlaying>();
            AddState<StateWin>();
            AddState<StateDie>();
        }
       
        protected override void OnStart()
        {
            Load();
        }

    }
}