using UnityEngine;

namespace Framework.Core
{    
    [CreateAssetMenu(fileName = "Control State (default)", menuName = "Controls/State", order = 1)]
    public class ControlState : Control
    {
        private IPage initialPage;

                
        public override void Initialize() 
        {                         

            
        }
        
        
        
        public void OnStateEnter(IState state)
        {

        }

        public void OnStateExit(IState state)
        {

        }


    }
}
