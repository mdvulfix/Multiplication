using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public interface IDataStats: IData, ISceneObject
    {
        int ID {get; }
    }
      
    [Serializable]  
    public class DataStats : ASceneObject, IDataStats
    {

        public int ID {get => id;   private set => id = value;}
        
        [SerializeField] private int id;
    }


}
