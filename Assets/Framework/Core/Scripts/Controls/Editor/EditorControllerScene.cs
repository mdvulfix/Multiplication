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
                SceneTurn<SceneMenu>();
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
                SceneTurn<SceneScore>();
            }
            GUILayout.EndHorizontal();

        
        }
        
        private void SceneTurn<TScene>() where TScene: class, IScene
        {
            instance.SceneTurn<TScene>(waitForSceneExit: true);

        }

        private void NextScene()
        {
            var sceneType = instance.Cache.GetNext(instance.SceneActive.GetType()).GetType();
            instance.SceneTurn(sceneType: sceneType, waitForSceneExit: true);

        }

        private void PrevScene()
        {
            var sceneType = instance.Cache.GetPrev(instance.SceneActive.GetType()).GetType();
            instance.SceneTurn(sceneType: sceneType, waitForSceneExit: true);

        }
    }

}
