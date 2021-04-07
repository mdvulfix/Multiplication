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
            var scene = instance.SceneCurrent;
            
            GUILayout.BeginHorizontal();
            
            if(GUILayout.Button("Menu"))
            {

                instance.SceneCurrent.IsActive = false;
                instance.SceneCurrent = (Scene)ControlData.DataHash.Get(typeof(SceneMenu).GetHashCode());
                instance.SceneCurrent.IsActive = true;
                
            }
            if(GUILayout.Button("<<"))
            {
                instance.SceneCurrent.IsActive = false;
                instance.SceneCurrent = (Scene)ControlData.DataHash.GetPrev(instance.SceneCurrent.GetType().GetHashCode());
                instance.SceneCurrent.IsActive = true;
            }
            if(GUILayout.Button(">>"))
            {
                
                instance.SceneCurrent.IsActive = false;
                instance.SceneCurrent = (Scene)ControlData.DataHash.GetNext(instance.SceneCurrent.GetType().GetHashCode());
                instance.SceneCurrent.IsActive = true;
            }
            if(GUILayout.Button("RunTime"))
            {
                instance.SceneCurrent.IsActive = false;
                instance.SceneCurrent = (Scene)ControlData.DataHash.Get(typeof(SceneRunTime).GetHashCode());
                instance.SceneCurrent.IsActive = true;
            }
            GUILayout.EndHorizontal();
        }

    }

}
