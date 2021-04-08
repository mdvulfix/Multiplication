using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactoryPage: IFactory
    {
        List<IPage> GetPages();

    }
    
    [Serializable]
    public abstract class FactoryPage : Factory, IFactoryPage
    {
        [SerializeField]
        protected GameObject prefab;
        
        protected static readonly string PARENT_SCENEOBJECT_NAME = "UI";
        
        public abstract List<IPage> GetPages();
       

    }
}
