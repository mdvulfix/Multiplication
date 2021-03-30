using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Framework.Core;

namespace Framework 
{
    /*
    //[CreateAssetMenu(fileName = "Scene(Default)", menuName = "Controls/Scene", order = 0)]
    public class ControlScene : Control
    {

        public List<string> Scenes {get; private set;}  = new List<string>(5);     
        public int ActiveScene {get; } 
        
        [SerializeField]
        private int activeScene;
        
        public override void OnEnable() 
        {      
            Scenes.Add("Core");
            Scenes.Add("MainMenu");
            Scenes.Add("RunTime");
            Scenes.Add("Score");
        
            SetActiveScene(0);
        
        }

        public override void OnAwake() 
        {               

        }

        public override void OnUpdate() 
        {

        
        }

        public void NextScene()
        {
            EnterScene(activeScene);
            ExitScene(activeScene);
            SetActiveScene(activeScene++);
            
        }

        public void EnterScene(int sceneId)
        {
            
            SceneManager.LoadSceneAsync(sceneId);
            ExitScene(sceneId);
            SetActiveScene(sceneId);
            
        }

        public void ExitScene(int sceneId)
        {
            SceneManager.UnloadSceneAsync(sceneId);
        }

        public void SetActiveScene(int sceneId)
        {
            this.activeScene = sceneId;

        }


    }

    */
}
