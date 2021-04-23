using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public interface IDataSceneLoading: IData
    {
        ESceneBuildId   SceneBuildId    {get; set;}
        
        IPage           PageDefault     {get; set;} 
        IPage           PageActive      {get; set;}
        
        Action          OnLoadCallback  {get; set;} 


    }

    [Serializable]
    public class DataSceneLoading : AData, IDataSceneLoading
    {      
        
        public static readonly string OBJECT_NAME = "Data: Scene Loading";
            
        public ESceneBuildId    SceneBuildId    {get; set;}
        
        public IPage            PageDefault     {get; set;}
        public IPage            PageActive      {get; set;}
        public Action           OnLoadCallback  {get; set;}

        
        public DataSceneLoading()
        {


        }
    }
}