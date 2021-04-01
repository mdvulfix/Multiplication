using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactoryControl: IFactory
    {
        T Get<T>() where T: SceneObject, IControl;
    }
    

    public abstract class FactoryControl : Factory, IFactoryControl
    {

        protected static readonly string PARENT_NAME = "Controls";
        
        public abstract T Get<T>() where T: SceneObject, IControl;
            
        
        


    }
}