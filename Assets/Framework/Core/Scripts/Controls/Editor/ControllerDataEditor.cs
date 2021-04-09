using UnityEngine;
using UnityEditor;

namespace Framework.Core
{

    [CustomEditor(typeof(ControllerData))]
    [CanEditMultipleObjects]
    public class ControllerDataEditor: Editor
    {
        
        ControllerData instance;
        ICache<IScene> Cache {get; set;}

        private void OnEnable() 
        {
            instance = (ControllerData)target;       
        }
        

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            //var scene = instance.
            
            /*
            GUILayout.BeginHorizontal();
            
            if(GUILayout.Button("Menu"))
            {
                //instance.SceneCurrent = (Scene)ControllerData.CacheScene.Get(typeof(SceneMenu));
            }
            if(GUILayout.Button("<<"))
            {
                //instance.SceneCurrent = (Scene)ControllerData.CacheScene.GetPrev(instance.SceneCurrent.GetType());
            }
            if(GUILayout.Button(">>"))
            {
                //instance.SceneCurrent = (Scene)ControllerData.CacheScene.GetNext(instance.SceneCurrent.GetType());
            }
            if(GUILayout.Button("RunTime"))
            {
                //instance.SceneCurrent = (Scene)ControllerData.CacheScene.Get(typeof(SceneRunTime));
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(5);
            */
        }
    }
}
