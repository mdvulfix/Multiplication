using UnityEngine;
using UnityEditor;

namespace Framework.Core
{

    [CustomEditor(typeof(ControllerPageDefault))]
    [CanEditMultipleObjects]
    public class ControllerPageEditor: Editor
    {
        
        ControllerPage instance;
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
            
            if(GUILayout.Button("Loading"))
            {
                TurnPage<PageLoading>();
            }
            if(GUILayout.Button("<<"))
            {
                PrevPage();
            }
            if(GUILayout.Button(">>"))
            {
                NextPage();
            }
            if(GUILayout.Button("Menu"))
            {
                TurnPage<PageMenu>();
            }
            GUILayout.EndHorizontal();

        
        }
        
        private void TurnPage<TPage>() where TPage: class, IPage
        {
            instance.PageActive.Activate(false);
            instance.PageActive = (Page)ControllerPageDefault.Cache.Get<TPage>();
            instance.PageActive.Activate(true);

        }

        private void NextPage()
        {
            instance.PageActive.Activate(false);
            instance.PageActive = (Page)ControllerPageDefault.Cache.GetNext(instance.PageActive.GetType());
            instance.PageActive.Activate(true);

        }

        private void PrevPage()
        {
            instance.PageActive.Activate(false);
            instance.PageActive = (Page)ControllerPageDefault.Cache.GetPrev(instance.PageActive.GetType());
            instance.PageActive.Activate(true);

        }
    }

}
