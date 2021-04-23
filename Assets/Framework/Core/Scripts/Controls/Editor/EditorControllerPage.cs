using System;
using UnityEngine;
using UnityEditor;

namespace Framework.Core
{

    [CustomEditor(typeof(ControllerPage))]
    [CanEditMultipleObjects]
    public class EditorControllerPage: Editor
    {
        
        IControllerPage instance;
        ICache<IPage> Cache {get; set;}

        private void OnEnable() 
        {
            instance = (ControllerPage)target;       
        }
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var page = instance.PageActive;
            GUILayout.BeginHorizontal();
            
            if(GUILayout.Button("Loading")|| Input.GetKeyUp(KeyCode.L))
            {
                PageGet<PageLoading>();
            }
            if(GUILayout.Button("<<")|| Input.GetKeyUp(KeyCode.P))
            {
                PrevPage();
            }
            if(GUILayout.Button(">>")|| Input.GetKeyUp(KeyCode.N))
            {
                NextPage();
            }
            if(GUILayout.Button("Menu")|| Input.GetKeyUp(KeyCode.M))
            {
                PageGet<PageMenu>();
            }
            GUILayout.EndHorizontal();

        
        }
        
        private void PageGet<TPage>() where TPage: class, IPage
        {
            instance.PageEnterNext<TPage>(delay: true);

        }

        private void NextPage()
        {
            var pageType = instance.Cache.GetNext(instance.PageActive.GetType()).GetType();
            instance.PageEnterNext(pageType: pageType, delay: true);

        }

        private void PrevPage()
        {
            var pageType = instance.Cache.GetPrev(instance.PageActive.GetType()).GetType();
            instance.PageEnterNext(pageType: pageType, delay: true);

        }
    }

}
