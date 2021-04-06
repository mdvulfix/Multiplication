using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactoryControl: IFactory
    {
        IControl GetControl();

    }
    


    public abstract class FactoryControl : Factory, IFactoryControl
    {
        protected readonly string PARENT_SCENEOBJECT_NAME = "Controls";
        public abstract IControl GetControl();
        

        


    }
}