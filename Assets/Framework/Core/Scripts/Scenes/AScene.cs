using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core;
using Core.Scene.Page;
using Core.State;

namespace Core.Scene
{
    public interface IScene
    {
        event Action<IEventArgs<IScene>> StateUpdated;

        SceneIndex  Index { get; }

        void Load<TScene>()
            where TScene: IScene;

        void Enter<TScene>()
            where TScene: IScene;

        void Play<TScene>()
            where TScene: IScene;

        void Pause<TScene>()
            where TScene: IScene;

        void Exit<TScene>()
            where TScene: IScene;

        void Close<TScene>()
            where TScene: IScene;

    }

    [Serializable]
    public abstract class AScene : ASceneObject, IScene
    {
        public event Action<IEventArgs<IScene>> StateUpdated;
        
        //public ISession     Session { get; private set; }
        public SceneIndex   Index { get; private set; }
        

        private ICache<IPage>       m_Pages;
        
        //public IPage            PageStart { get; private set; }
        //public IPage            PageActive { get; private set; }

        private IStateController    m_StateController;
        private ISceneController    m_SceneController;
        
        private void Awake()
        {
            OnAwake();

        }

        private void Start()
        {
            OnStart();
        }

        protected virtual void OnAwake()
        {

        }

        protected virtual void OnStart()
        {

        }


        protected virtual void Initialize(params object[] args)
        {
            m_Pages = new Cache<IPage>();

        }

        public virtual void Load<TScene>()
            where TScene : IScene
        {
            m_SceneController.SceneLoad<TScene>();
        }

        public virtual void Enter<TScene>()
            where TScene: IScene
        {
            m_SceneController.SceneEnter<TScene>();
        }

        public virtual void Play<TScene>()
            where TScene: IScene
        {
            m_SceneController.ScenePlay<TScene>();
        }

        public virtual void Pause<TScene>()
            where TScene: IScene
        {
            m_SceneController.ScenePause<TScene>();
        }

        public virtual void Exit<TScene>()
            where TScene: IScene
        {
            m_SceneController.SceneExit<TScene>();
        }

        public virtual void Close<TScene>()
            where TScene: IScene
        {
            m_SceneController.SceneClose<TScene>();
        }

/*
        public IScene Activate(bool activate)
        {
            if(!SceneChange(sceneBuildId: Loading.GetIntBuildId(), isLoading: activate))
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
    */
    }
    
    public class SceneEventArgs: EventArgs, IEventArgs<IScene>
    {
        public IScene   Handler         {get; private set;}
        public bool     IsRegistered    {get; private set;}

        public SceneEventArgs(IScene handler, bool isRegistered)
        {
            Handler = handler;
            IsRegistered = isRegistered;
        }
    }





}
