using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Framework.Core;

namespace Framework 
{
    [CreateAssetMenu(fileName = "Scene(Default)", menuName = "Controls/Scene", order = 0)]
    public class ControlScene : AControl
    {

        public List<string> Scenes {get; private set;}  = new List<string>(5);     
        
        [SerializeField]
        private int currentSceneid;
        
        public override void OnAwake() 
        {      
            Scenes.Add("Core");
            Scenes.Add("MainMenu");
            Scenes.Add("RunTime");
            Scenes.Add("Score");
        
            SetCurrentScene(0);
        
        }

        public override void OnUpdate() 
        {

        
        }

        public void NextScene()
        {
            ExitScene(currentSceneid);
            SetCurrentScene(currentSceneid++);
            EnterScene(currentSceneid);
        }

        public void EnterScene(int sceneId)
        {
            
            SceneManager.LoadSceneAsync(sceneId);
            SetCurrentScene(sceneId);
        }

        public void ExitScene(int sceneId)
        {
            SceneManager.UnloadSceneAsync(sceneId);
        }

        public void SetCurrentScene(int sceneId)
        {
            this.currentSceneid = sceneId;

        }


    }


}
