using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public interface IDataStats: IData
    {
        int  ID             {get; set;}
        
        bool IsInitialized  {get; set;}
        bool IsConfigerd    {get; set;}
        bool IsActive       {get; set;}
    }
      
    [Serializable]  
    public class DataStats : AData, IDataStats
    {
        public static readonly string OBJECT_NAME = "Data: Stats";

        public int ID               {get => id;             set => id = value;}

        public bool IsInitialized   {get => isInitialized;  set => isInitialized = value;}
        public bool IsConfigerd     {get => isConfigerd;    set => isConfigerd = value;}
        public bool IsActive        {get => isActive;       set => isActive = value;}
        
        [SerializeField] private int id;

        [SerializeField] private bool isInitialized;
        [SerializeField] private bool isConfigerd;
        [SerializeField] private bool isActive;
    
    
    }


}
