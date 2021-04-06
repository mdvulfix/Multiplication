using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    public interface IFactoryPage: IFactory
    {
        HashSet<IPage> GetPages();

    }
    
    [Serializable]
    public abstract class FactoryPage : Factory, IFactoryPage
    {
        [SerializeField]
        protected GameObject prefab;
        
        protected static readonly string PARENT_SCENEOBJECT_NAME = "UI";
        
        public abstract HashSet<IPage> GetPages();
       

    }
}
