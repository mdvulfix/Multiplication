using System;
using UnityEngine;
using UnityEditor;


namespace Framework.Core
{

    [CustomEditor(typeof(ControllerScene))]
    [CanEditMultipleObjects]
    public class EditorControllerScene: Editor
    {
        
        IControllerScene instance;
        ICache<IScene> Cache {get; set;}

        private void OnEnable() 
        {
            instance = (IControllerScene)target;       
        }
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var page = instance.SceneActive;
            GUILayout.BeginHorizontal();
            
            if(GUILayout.Button("Menu")|| Input.GetKeyUp(KeyCode.L))
            {
                SceneGet<SceneMenu, PageMenu>();
            }
            if(GUILayout.Button("<<")|| Input.GetKeyUp(KeyCode.P))
            {
                PrevScene();
            }
            if(GUILayout.Button(">>")|| Input.GetKeyUp(KeyCode.N))
            {
                NextScene();
            }
            if(GUILayout.Button("Score")|| Input.GetKeyUp(KeyCode.M))
            {
                SceneGet<SceneScore, PageScore>();
            }
            GUILayout.EndHorizontal();

        
        }
        
        private void SceneGet<TScene, TPage>() 
            where TScene: class, IScene
            where TPage: class, IPage
        {
            instance.SceneEnterNext<TScene, TPage>(delay: true);

        }

        private void NextScene()
        {
            var sceneNext = instance.Cache.GetNext(instance.SceneActive.GetType());
            var sceneNextType = sceneNext.GetType();

            var pageDefault = sceneNext.SceneLoading.PageDefault;
            var pageDefaultType = pageDefault.GetType();
            
            instance.SceneEnterNext(sceneType: sceneNextType, pageType: pageDefaultType, delay: true);

        }

        private void PrevScene()
        {
            var sceneNext = instance.Cache.GetPrev(instance.SceneActive.GetType());
            var sceneNextType = sceneNext.GetType();

            var pageDefault = sceneNext.SceneLoading.PageDefault;
            var pageDefaultType = pageDefault.GetType();
            
            instance.SceneEnterNext(sceneType: sceneNextType, pageType: pageDefaultType, delay: true);

        }
    }

}
