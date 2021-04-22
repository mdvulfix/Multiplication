using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Framework.Core
{
    public interface IScene: ISceneObject, IConfigurable, IDebug, IHaveCache<IPage>
    {
        IDataStats DataStats {get; set;}
        ESceneBuildId SceneBuildId {get; }
        
        IScene Activate(bool active);
    }
    
    [Serializable]
    public abstract class AScene: ASceneObject, IScene
    {
        
        public bool             UseDebug        {get; set;} = true;
        public IDataStats       DataStats       {get => dataStats; set => dataStats = value as DataStats;}
        public ESceneBuildId    SceneBuildId    {get; protected set;}
        
        public ICache<IPage>    Cache           {get; protected set;} = new Cache<IPage>("Scene: Cache"); 
        

        [SerializeField] protected bool isProject;
        
        [Header("Data")]
        [SerializeField] protected DataStats dataStats;
        
        
 
        
        public abstract void Initialize();
        public abstract IConfigurable Configure();
            
        protected virtual void SetParams(string label, ESceneBuildId sceneBuildId)
        {
            Label = label;
            SceneBuildId = sceneBuildId;
        }

        public IScene Activate(bool activate)
        {
            DataStats.IsActive = SetActvie(true);
            Log(Label, " was activated.");
           
            SceneLoad(SceneBuildId);
            
            return this;
        }

        private bool SceneLoad(ESceneBuildId scene)
        {
            SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive);
            return true;
        }


#region Cache

        public IPage SetToCache(IPage instance)
        {
            Cache.Add(instance);
            return instance;
        
        }   

        public List<IPage> SetToCache(List<IPage> instances)
        {
            foreach (var instance in instances)
            {
                SetToCache(instance);
            }
            return instances;
        }

#endregion

#region Logs

        public virtual void Log(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
                
        }

        public virtual void LogWarning(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.LogWarning("["+ instance +"]: " + message);
            }
        }

        protected string LogSuccessfulInitialize()
        {
            return "Initialization process was successfully finished!";
        }

        protected string LogSuccessfulConfigure()
        {
            return "Configuration process was successfully finished!";
        }
        
        protected string LogFailedInitialize(string reason = null)
        {
            return "Initialization process was failed! " + reason;
        }

        protected string LogFailedConfigure(string reason = null)
        {
            return "Configuration process was failed! " + reason;
        }

#endregion
    
    }
}
