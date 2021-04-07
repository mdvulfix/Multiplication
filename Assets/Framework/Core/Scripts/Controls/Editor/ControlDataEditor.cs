using UnityEngine;
using UnityEditor;

namespace Framework.Core
{

    [CustomEditor(typeof(ControlData))]
    [CanEditMultipleObjects]
    public class ControlDataEditor: Editor
    {
        
        ControlData instance;
        ICache<IScene> Cache {get; set;}

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
                instance.SceneCurrent = (Scene)ControlData.CacheScene.Get(typeof(SceneMenu));
            }
            if(GUILayout.Button("<<"))
            {
                instance.SceneCurrent = (Scene)ControlData.CacheScene.GetPrev(instance.SceneCurrent.GetType());
            }
            if(GUILayout.Button(">>"))
            {
                instance.SceneCurrent = (Scene)ControlData.CacheScene.GetNext(instance.SceneCurrent.GetType());
            }
            if(GUILayout.Button("RunTime"))
            {
                instance.SceneCurrent = (Scene)ControlData.CacheScene.Get(typeof(SceneRunTime));
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(5);
            var page = instance.PageCurrent;
            GUILayout.BeginHorizontal();
            
            if(GUILayout.Button("Menu"))
            {
                instance.PageCurrent.Activate(false);
                instance.PageCurrent = (Page)ControlData.CachePage.Get(typeof(PageLoading));
                instance.PageCurrent.Activate(true);
            }
            if(GUILayout.Button("<<"))
            {
                instance.PageCurrent.Activate(false);
                instance.PageCurrent = (Page)ControlData.CachePage.GetPrev(instance.PageCurrent.GetType());
                instance.PageCurrent.Activate(true);
            }
            if(GUILayout.Button(">>"))
            {
                instance.PageCurrent.Activate(false);
                instance.PageCurrent = (Page)ControlData.CachePage.GetNext(instance.PageCurrent.GetType());
                instance.PageCurrent.Activate(true);
            }
            if(GUILayout.Button("RunTime"))
            {
                
                instance.PageCurrent.Activate(false);
                instance.PageCurrent = (Page)ControlData.CachePage.Get(typeof(PageMenu));
                instance.PageCurrent.Activate(true);
            }
            GUILayout.EndHorizontal();
        }

    }

}
