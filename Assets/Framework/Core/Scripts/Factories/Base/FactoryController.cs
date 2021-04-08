using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactoryController: IFactory
    {
        IController GetControl();

    }
    


    public abstract class FactoryController : Factory, IFactoryController
    {
        protected readonly string PARENT_SCENEOBJECT_NAME = "Controllers";
        public abstract IController GetControl();
        

        


    }
}