using UnityEngine;
using UnityEditor;

namespace Framework.Core
{

    [CustomEditor(typeof(ControlData))]
    [CanEditMultipleObjects]
    public class ControlDataEditor: Editor
    {
        
        ControlData instance;
        DataHash DataHash {get; set;}

        private void OnEnable() 
        {
            instance = (ControlData)target;       
        }
        

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.BeginHorizontal();
            
            if(GUILayout.Button("Menu"))
            {

                instance.SceneCurrent.IsActive = false;
                instance.SceneCurrent = ControlData.DataHash.Get<SceneMenu>();
                instance.SceneCurrent.IsActive = true;
                
            }
            if(GUILayout.Button("<<"))
            {
                instance.SceneCurrent.IsActive = false;
                instance.SceneCurrent = ControlData.DataHash.Get<Scene>(instance.SceneCurrent.ID - 1);
                instance.SceneCurrent.IsActive = true;
            }
            if(GUILayout.Button(">>"))
            {
                instance.SceneCurrent.IsActive = false;
                instance.SceneCurrent = ControlData.DataHash.Get<Scene>(instance.SceneCurrent.ID + 1);
                instance.SceneCurrent.IsActive = true;
            }
            if(GUILayout.Button("RunTime"))
            {
                instance.SceneCurrent.IsActive = false;
                instance.SceneCurrent = ControlData.DataHash.Get<SceneRunTime>();
                instance.SceneCurrent.IsActive = true;
            }
            GUILayout.EndHorizontal();
        }

    }

}
