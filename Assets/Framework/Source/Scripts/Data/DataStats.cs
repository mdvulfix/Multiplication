using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public interface IDataStats: IData, ISceneObject
    {
        int ID {get; set;}
    }
      
    [Serializable]  
    public class DataStats : ASceneObject, IDataStats
    {
        public static readonly string OBJECT_NAME = "Data: Stats";

        public int ID {get => id; set => id = value;}
        
        [SerializeField] private int id;
    
       
    
    
    
    
    }


}
