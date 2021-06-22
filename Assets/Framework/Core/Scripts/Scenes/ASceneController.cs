using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UScene = UnityEngine.SceneManagement.Scene;
using Core;
using Core.Scene.Page;


namespace Core.Scene
{
    public interface ISceneController: IController<IScene>
    {       
        void SceneLoad<TScene>()
            where TScene : IScene;

        void SceneEnter<TScene>()
            where TScene : IScene;

        void SceneEnter<TScene, TPage>()
            where TScene : IScene
            where TPage : IPage;

        void ScenePlay<TScene>()
            where TScene : IScene;

        void ScenePause<TScene>()
            where TScene : IScene;

        void SceneExit<TScene>()
            where TScene : IScene;

        void SceneClose<TScene>()
            where TScene : IScene;

    } 
    
    [Serializable]
    public abstract class ASceneController: AController<IScene>, ISceneController
    {
        private readonly int PARAMS_INITIALIZATION = 0;

        public IScene SceneCurrent { get; private set; }
        
        protected static Dictionary<Type, SceneIndex> m_SceneIndexes;
        
        protected static Cache<IScene> m_SceneInitialized;
        protected static Cache<IScene> m_SceneLoaded;
        protected static Cache<IScene> m_SceneActivated;

        private Task            m_LoadingTask;
        private AsyncOperation  m_LoadingOperation;
        
        private UScene m_LoadingScene;
        private Type   m_LoadingSceneType;

        private CancellationTokenSource m_TokenSource;
        

        protected override void Initialize(params object[] args)
        { 
            m_SceneInitialized = new Cache<IScene>();
            m_SceneLoaded = new Cache<IScene>();
            m_SceneActivated = new Cache<IScene>();
            
            var parametrs = (ISceneControllerInitializationParams)args[PARAMS_INITIALIZATION];
            m_SceneIndexes = parametrs.SceneIndexes;
            
            Debug.Log("SceneController was initialized!");
        }

        protected override void Dispose()
        {
            Debug.Log("Scene controller disposed");
            m_TokenSource.Cancel();
            m_TokenSource.Dispose(); 
        }

    
        private void OnEnable()
        {
            //Handler.StateUpdated += Dispose;
        }
        
        private void OnDisable()
        {
            //Handler.StateUpdated -= Dispose;
        }

        
        public virtual void SceneLoad<TScene>()
            where TScene: IScene
        {
            SceneIndex index;
            if (GetSceneByIndex<TScene>(out index))
            {
                SceneLoadAsync(index);
            }

        }

        public virtual void SceneEnter<TScene>()
            where TScene: IScene
        {
            SceneIndex index;
            if (GetSceneByIndex<TScene>(out index))
            {
                SceneLoadAsync(index);
            }

        }

        public virtual void SceneEnter<TScene, TPage>() 
            where TScene : IScene
            where TPage : IPage
        {
            
            SceneIndex index;
            if (GetSceneByIndex<TScene>(out index))
            {
                //SceneEnterAsync(index);
            }
            
        }

        public virtual void ScenePlay<TScene>()
            where TScene : IScene
        {


        }

        public virtual void ScenePause<TScene>()
            where TScene : IScene
        {


        }

        public virtual void SceneExit<TScene>()
            where TScene : IScene
        {


        }

        public virtual void SceneClose<TScene>()
            where TScene : IScene
        {


        }
    
        
        private async void SceneLoadAsync(SceneIndex index)
        {
            var buildIndex = (int)index;
            m_LoadingOperation = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);

            m_TokenSource = new CancellationTokenSource();
            var token = m_TokenSource.Token;

            try
            {
                await ChackLoadingOperationStatus(m_LoadingOperation, token);
                //await TrySceneLoadAsync(index, token);
                
                Debug.Log("Scene loading is done!");
            }
            catch (OperationCanceledException ex)
            {
                Debug.Log(string.Format("Задача {0} завершена по причине {1}: ", nameof(SceneLoadAsync), ex.Message));
            } 

            m_LoadingScene = SceneManager.GetSceneByBuildIndex(buildIndex);
            
            m_TokenSource.Cancel();

        }

        private async Task ChackLoadingOperationStatus(AsyncOperation operation, CancellationToken token)
        {
            while (!operation.isDone)
            {
                Debug.Log("Scene is loading async!");
                await Task.Delay(1000);

                if (token.IsCancellationRequested)
                    break;
            }
        }


        /*
        private async void SceneEnterAsync(SceneIndex index) 
        {
            m_TokenSource = new CancellationTokenSource();
            var token = m_TokenSource.Token;
    
            try
            {
                await TrySceneEnterAsync(index, token);
            }
            catch (OperationCanceledException ex)
            {

                Debug.Log(string.Format("Задача {0} завершена по причине {1}: ", nameof(SceneEnterAsync), ex.Message));
            } 
            
            m_TokenSource.Cancel();
        }
        


        private async Task TrySceneLoadAsync(SceneIndex index, CancellationToken token)
        {
            IScene scene = null;
            while(!GetInitialized(index, out scene))
            {
                Debug.Log("Trying to get initialized scene...");
                await Task.Delay(1000);

                if (token.IsCancellationRequested)
                    break;;
            }
        
            
            scene.Load();

            while(!SceneCheckState<StateConfigure>(scene))
            {
                await Task.Delay(100);

                if (token.IsCancellationRequested)
                    break;;
            }
            Debug.Log("Scene load is done!");
            
        }

        private async Task TrySceneEnterAsync(SceneIndex index, CancellationToken token)
        {
            IScene scene = null;
            while(!GetLoaded(index, out scene))
            {
                Debug.Log("Trying to get initialized scene...");
                await Task.Delay(1000);

                if (token.IsCancellationRequested)
                    break;;
            }

            
            scene.Enter();

            while(!SceneCheckState<StateActivate>(scene))
            {
                await Task.Delay(100);
                
                if (token.IsCancellationRequested)
                    break;;
            }

            Debug.Log("Scene enter is done!");
            
        }
     


        public bool AddInitialized(IScene scene)
        {                        
            if(m_SceneInitialized.Contains(scene))
            {
                Debug.Log("Scene already registered.");    
                return false;           
            }
            
            m_SceneInitialized.Add(scene);
            
            //Subscribe(true, scene);

            Debug.Log("Scene was add to initialized list.");
            return true;
        }

        public bool RemoveInitialized(IScene scene)
        {
            if(m_SceneInitialized.Contains(scene))
            {
                Debug.Log("Scene was not registered.");
                return false;  
            }

            m_SceneInitialized.Remove(scene);

            //Subscribe(false, scene);
           
            Debug.Log("Scene removed.");
            return true;  
            
        }


        public bool AddLoaded(IScene scene)
        {            
            if(m_SceneLoaded.Contains(scene))
            {
                Debug.Log("Scene already registered.");    
                return false;           
            }
            
            m_SceneLoaded.Add(scene);
            
            //Subscribe(true, scene);

            Debug.Log("Scene was add to loaded list.");
            return true;
        }

        public bool RemoveLoaded(IScene scene)
        {
                
            if(m_SceneLoaded.Contains(scene))
            {
                Debug.Log("Scene was not registered.");
                return false;  
            }
            
            m_SceneLoaded.Remove(scene);
            
            //Subscribe(false, scene);
           
           Debug.Log("Scene removed.");
            return true;  
            
        }


        public bool AddActivated(IScene scene)
        {                        
            if(m_SceneActivated.Contains(scene))
            {
                Debug.Log("Scene already registered.");    
                return false;           
            }
            
            m_SceneActivated.Add(scene);
            
            //Subscribe(true, scene);

            Debug.Log("Scene was add to activated list.");
            return true;
        }

        public bool RemoveActivated(IScene scene)
        {
            if(m_SceneActivated.Contains(scene))
            {
                Debug.Log("Scene was not registered.");
                return false;  
            }
            
            m_SceneActivated.Remove(scene);
            
            //Subscribe(false, scene);
           
            Debug.Log("Scene removed.");
            return true;  
            
        }


        public bool GetInitialized(SceneIndex index, out IScene scene) 
        {
            if(m_SceneInitialized.Get(index, out scene))
            {
                return true;
            }

            Debug.Log("Scene is not initialize!");
            scene = null;
            return false;
        }

        public bool GetLoaded(SceneIndex index, out IScene scene) 
        {
            if(m_ScenesLoaded.TryGetValue(index, out scene))
            {
                return true;
            }

            Debug.Log("Scene is not load!");
            scene = null;
            return false;
        }

        public bool GetActivated(SceneIndex index, out IScene scene) 
        {
            if(m_ScenesActivated.TryGetValue(index, out scene))
            {
                return true;
            }

            Debug.Log("Scene is not active!");
            scene = null;
            return false;
        }

*/
        //private void Subscribe(bool subscribe, IScene scene)
        //{
        //    if(subscribe)
        //        scene.StateUpdated += SceneStateUpdated;
        //    else
        //       scene.StateUpdated -= SceneStateUpdated;
        //}

        //protected virtual void SceneStateUpdated(ISceneEventArgs args)
        //{
        //
        //
        //}



/*
        public void SceneEnterNext<TScene, TPage>(bool delay = false) 
            where TScene: class, IScene
            where TPage: class, IPage
        {
            SceneEnterNext(typeof(TScene), typeof(TPage), delay);
        }
       
        public void SceneEnterNext(Type sceneNextType, Type pageNextType, bool delay = false)
        {
            var sceneNext = Cache.Get(sceneNextType);
            var pageNext = sceneNext.Cache.Get(pageNextType);

            if(SceneActive == null)
            {
                LogWarning(Label, "You are trying to turn a scene [" + SceneActive.Label + "] that has not been registered!");
                return;
            }
            
            if(SceneActive.Stats.IsActive)
            {
                
                PageExit(pageNext);
                SceneActive.Activate(false);
                Log(Label, "[" + SceneActive.Label + "] was deactivated!");
            }


            if(delay)
            {
                StopCoroutine("WaitForSceneExit");
                StartCoroutine(WaitForSceneExit(sceneNextType, pageNextType));
                //Log("Animation is enabled on page [ " + Name + " ]");
            }
            else
            {
                SceneEnter(sceneNextType, pageNextType);
            }
                
        }
               
        public void SceneEnter<TScene, TPage>() 
            where TScene: class, IScene
            where TPage: class, IPage
        {
            SceneEnter(typeof(TScene), typeof(TPage));
        }  
    
        public void SceneEnter(Type sceneType, Type pageType)
        {
            var sceneNext = Cache.Get(sceneType);
            Log(Label, "[" + sceneNext.Label + "] was found in the cache! Hashcode is [" + sceneNext.GetHashCode() + "]");
            
            
            //var pageNext = sceneNext.Cache.Get(pageType);
            //Log(Label, "[" + pageNext.Label + "] was found in the cache! Hashcode is [" + pageNext.GetHashCode() + "]");


            
            if(sceneNext==null)
            {
                LogWarning(Label, "You are trying to turn a scene on [" + sceneNext.Label + "] that has not been registered!");
                return;
            }
    
            SceneActive = sceneNext.Activate(true);
            //SceneActive.DataSceneLoading.PageActive = pageNext;
            
            
            //PageEnter(pageNext);
            Log(Label, "[" + SceneActive.Label + "] was activated!");
        }

        
        private IEnumerator WaitForSceneExit(Type sceneType, Type pageType)
        {
            
            Log(Label, "Waiting for exit [" + SceneActive.Label + "]...");
            
            while (sceneActive.DataAnimation.TargetState != AScene.ANIMATOR_STATE_NONE)
            {
                yield return null;
            }
            
            yield return new WaitForSeconds(2f);
            SceneEnter(sceneType, pageType);
        
        }
*/
        private bool GetSceneByIndex<T>(out SceneIndex index)
            where T: IScene
        {
            if (!m_SceneIndexes.TryGetValue(typeof(T), out index))
            {
                Debug.Log("Index was not found!");
                return false;
            }

            return true;
        }

    }
    
    public interface ISceneControllerInitializationParams
    { 
        Dictionary<Type, SceneIndex> SceneIndexes { get; }

    }
}
