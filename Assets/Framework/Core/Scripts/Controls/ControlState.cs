﻿using System.Collections.Generic;

namespace Framework.Core
{    

    public interface IControlState: IControl
    {
        HashSet<IState> States {get; }
        
        void SetStates(IFactoryState factory);
        void SetStates(HashSet<IState> states);
        
        void OnStateEnter(IState state);
        void OnStateExit(IState state);
    
    
    } 
    
    
    
    public abstract class ControlState : Control, IControlState
    {
        
        private HashSet<IState> states;
        
        public HashSet<IState> States {get => states; private set => states = value; }
        
                
        public void SetStates(IFactoryState factory)
        {
            States = factory.GetStates();

        }
        
        public void SetStates(HashSet<IState> states)
        {
            States = states;

        }


        public abstract void OnStateEnter(IState state);
        public abstract void OnStateExit(IState state);



    }
}