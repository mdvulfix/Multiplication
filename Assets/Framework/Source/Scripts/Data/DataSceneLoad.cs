using System;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    public interface IDataSceneLoad: IData
    {
        ESceneBuildId   SceneBuildId    {get; set;}
        
        IPage           PageLoading     {get; set;} 
        IPage           PageActive      {get; set;}
        
        Action          OnLoadCallback  {get; set;} 


    }

    [Serializable]
    public class DataSceneLoad : AData, IDataSceneLoad
    {      
        
        public static readonly string OBJECT_NAME = "Data: SceneLoad";
            
        public ESceneBuildId    SceneBuildId    {get => sceneBuildId;   set => sceneBuildId = value;}
        
        public IPage            PageLoading     {get => pageLoading;    set => pageLoading = value as PageLoading;}
        public IPage            PageActive     {get; set;}
        public Action           OnLoadCallback  {get => onLoadCallback; set => onLoadCallback = value;}


        [SerializeField] private ESceneBuildId  sceneBuildId;
        
        [SerializeField] private PageLoading    pageLoading;
        [SerializeField] private Action         onLoadCallback;
        
        public DataSceneLoad()
        {


        }
    }
}