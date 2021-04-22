using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Framework.Core
{
    public interface IScene: ISceneObject, IConfigurable, IDebug, IHaveCache<IPage>
    {
        IDataStats      DataStats       {get; }
        IDataSceneLoad  DataSceneLoad   {get; }

        IScene Activate(bool active);
    }
    
    [Serializable]
    public abstract class AScene: ASceneObject, IScene
    {
        
        public bool             UseDebug        {get; set;} = true;
        public IDataStats       DataStats       {get => dataStats;      private set => dataStats = value as DataStats;}
        public IDataSceneLoad   DataSceneLoad   {get => dataSceneLoad;  private set => dataSceneLoad = value as DataSceneLoad;}
                
        public ICache<IPage>    Cache           {get; protected set;} = new Cache<IPage>("Scene: Cache"); 
        
        [SerializeField] protected bool isProject;
        
        [Header("Data")]
        [SerializeField] private DataStats dataStats;
        [SerializeField] private DataSceneLoad dataSceneLoad;
        
        
#region Configure

        public abstract void Initialize();
        public abstract IConfigurable Configure();
            
        protected virtual void SetParams(string label)
        {
            Label = label;
        }


#endregion

#region SceneManagenent

        public IScene Activate(bool activate)
        {
            
            
            if(!SceneChange(scene: DataSceneLoad.SceneBuildId, page: DataSceneLoad.PageLoading, isLoading: activate))
            {
                LogWarning(Label, "Activation is faild!");
                return null;
            }

            return this;
        }

        private bool SceneChange(ESceneBuildId scene, IPage page, Action callback = null, bool isLoading = true)
        {

            if(isLoading)
            {
                DataStats.IsActive = SetActvie(true);
                
                StopCoroutine("SceneLoadAsync");
                StartCoroutine(SceneLoadAsync(scene));
            }  
            else
            {   
                StopCoroutine("SceneUnloadAsync");
                StartCoroutine(SceneUnloadAsync(scene));
            }

            return true;
        }
        
        
        private IEnumerator SceneLoadAsync(ESceneBuildId scene)
        {
            yield return null;
            
            var operation =  SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive);
            while (!operation.isDone)
            {
                yield return null;
            } 

            Log(Label, " was activated.");
        
        }

        private IEnumerator SceneUnloadAsync(ESceneBuildId scene)
        {
            
            yield return new WaitForSeconds(2f);

            var operation = SceneManager.UnloadSceneAsync((int)scene);
                
            while (!operation.isDone)
            {
                yield return null;
            }    

            DataStats.IsActive = SetActvie(false);
            Log(Label, " was diactivated.");

        }

#endregion

#region Data

        protected bool DataCheck<T>(T instance) 
            where T: IData
        {
            if(instance == null)
            {
                LogWarning(Label, LogFailedInitialize("[" + typeof(T).Name + "] was not found!"));
                return false;
            }
        
            return true;
        }
#endregion


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
