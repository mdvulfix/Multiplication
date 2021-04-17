using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    

    
    public interface IDataStats: IData
    {
        int ID {get; set;}
    }
      
    public interface IDataStatsStuct
    {
        IDataStats DataStats {get; set;}
    } 
    
    
    [Serializable]  
    public class DataStats : AData, IDataStats
    {
        public static readonly string OBJECT_NAME = "Data: Stats";

        public int ID {get => id; set => id = value;}
        
        [SerializeField] private int id;
    
    
    }


}
