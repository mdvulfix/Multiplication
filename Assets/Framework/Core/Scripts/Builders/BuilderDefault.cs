using System;
using UnityEngine;

namespace Framework.Core
{
    [Serializable]
    public class BuilderDefault : Builder
    {
       
        
        [SerializeField]
        FactoryControls factoryControls;
        
        
        
        public void Configure()
        {
            SetControls(factoryControls);


        }
    
        private void SetControls(IFactoryControls factory)
        {          
            GetControl<ControlState>(factory);



        }
    
        private void GetControl<T>(IFactoryControls factory) where T: SceneObject, IControl
        {
            factory.Get<T>();
        }
    
    
    
    }
}