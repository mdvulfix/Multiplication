using System;
using System.Collections;
using System.Collections.Generic;
using Core.Cache;
using Core.Data.Scene;
using Core.Data.Stats;
using Core.Events;
using Core.Scene.Page;
using Core.Scene.State;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Scene
{
    public interface IScene: IAwakable
    {
        event Action<ISceneEventArgs> StateUpdated;
        
        SceneIndex  Index { get; }
        IState      StateCurrent { get; }
       
        void Initialize(params object[] args);

        void Load();
        void Enter();
        void Play();
        void Pause();
        void Exit();
        void Unload();

        void SetState<TState>() 
            where TState: class, IState;
    }

    [Serializable]
    public abstract class AScene : ASceneObject, IScene
    {
        public event Action<ISceneEventArgs> StateUpdated;
        
        public SceneIndex   Index { get; private set; }
        public IState       StateCurrent { get; private set; }

        private ICache<IPage>       m_Pages;
        private ICache<IController> m_Controllers; 
        
        //public IPage            PageStart { get; private set; }
        //public IPage            PageActive { get; private set; }

        private IStateController    m_StateController;
        


        public void Awake()
        {
            Initialize();
        }


        public void Initialize(params object[] args)
        {
            m_Pages = new Cache<IPage>();
            
        
        }

        public void SetState<TState>() 
            where TState: class, IState
        {
            if(m_StateController.Get<TState>(out m_StateCurrent))
            {
                m_StateCurrent.Execute();
                StateUpdated?.Invoke(new SceneEventArgs(this, m_StateCurrent, true));
            }
        }
        

        public abstract void Load();
        public abstract void Enter();
        public abstract void Play();
        public abstract void Pause();
        public abstract void Exit();
        public abstract void Unload();

        
        protected T ControllerSetAndGet<T>()
            where T: class, IController, new()
        {
            IController controller = null;

            if(m_Controllers.Get<T>(out controller))
                return controller as T;

            
            controller = new T();
            controller.Initialize(this);
            m_Controllers.Add(controller);

            return controller as T;
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


    public class SceneEventArgs: EventArgs, ISceneEventArgs
    {
        public IScene   Scene           {get; private set;}
        public IState   State           {get; private set;}
        public bool     IsRegistered    {get; private set;}

        public SceneEventArgs(IScene scene, IState state, bool isRegistered)
        {
            Scene = scene;
            State = state;
            IsRegistered = isRegistered;
        }
    }





}
