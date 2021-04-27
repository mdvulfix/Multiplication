using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Framework.Core
{
    public interface IScene: ISceneObject, IConfigurable, IDebug, IHaveCache<IPage>
    {
        IDataSceneLoading   SceneLoading   {get; }

        IScene Activate(bool active);
    }
    
    [Serializable]
    public abstract class AScene: ASceneObject, IScene
    {
        
        public bool                 UseDebug            {get; set;} = true;
        public IDataStats           Stats           {get => dataStats;      private set => dataStats = value as DataStats;}
        public IDataSceneLoading    SceneLoading    {get => dataSceneLoading;  private set => dataSceneLoading = value as DataSceneLoading;}
                
        public ICache<IPage>  Cache {get; protected set;} = new Cache<IPage>("Scene: Cache"); 
        
        [SerializeField] protected bool isProject;
        
        [Header("Data")]
        [SerializeField] private DataStats dataStats;
        [SerializeField] private DataSceneLoading dataSceneLoading;
        
        
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
            if(!SceneChange(sceneBuildId: SceneLoading.GetIntBuildId(), isLoading: activate))
            {
                LogWarning(Label, "Activation is faild!");
                return null;
            }

            return this;
        }

        private bool SceneChange(int sceneBuildId, Action callback = null, bool isLoading = true)
        {

            if(isLoading)
            {
                Stats.IsActive = SetActvie(true);
                //DataSceneLoad.PageActive = DataSceneLoad.PageLoading.Activate(true);
                
                StopCoroutine("SceneLoadAsync");
                StartCoroutine(SceneLoadAsync(sceneBuildId));
            }  
            else
            {   
                StopCoroutine("SceneUnloadAsync");
                StartCoroutine(SceneUnloadAsync(sceneBuildId));
            }

            return true;
        }
        
        
        private IEnumerator SceneLoadAsync(int sceneBuildId)
        {
            yield return new WaitForSeconds(2f);
            
            var operation =  SceneManager.LoadSceneAsync(sceneBuildId, LoadSceneMode.Additive);

            while (!operation.isDone)
            {
                yield return null;
            } 

            Log(Label, "[" + sceneBuildId + "] was activated.");

            var objs = SceneManager.GetSceneByBuildIndex(sceneBuildId).GetRootGameObjects();
             
            foreach (var obj in objs)
            {
                var objUI = obj.GetComponent<IUI>();
                
                if(objUI!=null)
                {
                    var pages = obj.GetComponentsInChildren<IPage>();
                    foreach (var page in pages)
                    {
                        
                        page.Initialize();               
                        page.Configure();
                        Log(Label, "Page [" + page.Label + "] was initialized and configured!.");
                    }
                    
                }
            }
        }

        private IEnumerator SceneUnloadAsync(int sceneBuildId)
        {
            //DataSceneLoad.PageActive.Activate(false);
            //DataSceneLoad.PageActive = null;

            yield return new WaitForSeconds(2f);

            var operation = SceneManager.UnloadSceneAsync(sceneBuildId);
                
            while (!operation.isDone)
            {
                yield return null;
            }    

            Stats.IsActive = SetActvie(false);
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

        public void GetCache(ICache<IPage> cache)
        {
            Cache = cache;
        }

        public IPage SetToCache(IPage instance)
        {
            if(Cache.Add(instance)!=null)
                Log(Label, "Page [" + instance.Label + "] was set to cache! Hashcode is [" + instance.GetHashCode() + "]");
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
