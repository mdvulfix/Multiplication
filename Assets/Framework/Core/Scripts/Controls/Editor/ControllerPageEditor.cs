using System;
using UnityEngine;
using UnityEditor;

namespace Framework.Core
{

    [CustomEditor(typeof(ControllerPageDefault))]
    [CanEditMultipleObjects]
    public class ControllerPageEditor: Editor
    {
        
        IControllerPage instance;
        ICache<IPage> Cache {get; set;}

        private void OnEnable() 
        {
            instance = (ControllerPageDefault)target;       
        }
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var page = instance.PageActive;
            GUILayout.BeginHorizontal();
            
            if(GUILayout.Button("Loading")|| Input.GetKeyUp(KeyCode.L))
            {
                PageTurn<PageLoading>();
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
                PageTurn<PageMenu>();
            }
            GUILayout.EndHorizontal();

        
        }
        
        private void PageTurn<TPage>() where TPage: class, IPage
        {
            instance.PageTurn<TPage>(waitForPageExit: true);

        }

        private void NextPage()
        {
            var pageType = instance.Cache.GetNext(instance.PageActive.GetType()).GetType();
            instance.PageTurn(pageType: pageType, waitForPageExit: true);

        }

        private void PrevPage()
        {
            var pageType = instance.Cache.GetPrev(instance.PageActive.GetType()).GetType();
            instance.PageTurn(pageType: pageType, waitForPageExit: true);

        }
    }

}
