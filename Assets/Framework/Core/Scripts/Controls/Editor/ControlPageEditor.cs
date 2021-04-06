using UnityEngine;
using UnityEditor;

namespace Framework.Core
{

    [CustomEditor(typeof(ControlPageDefault))]
    [CanEditMultipleObjects]
    public class ControlPageEditor: Editor
    {
        
        private Page pageOn;
        private Page pageOff;
        ControlPageDefault instance;

        private void OnEnable() 
        {
            instance = (ControlPageDefault)target;
            pageOn = instance.PageOn;
            pageOff = instance.PageOff;
        
        }
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.BeginHorizontal();
            if(GUILayout.Button("Prev"))
            {
                instance.TurnPageOff(pageOff);
            }
            if(GUILayout.Button("Next"))
            {
                instance.TurnPageOn(pageOn);
            }
            GUILayout.EndHorizontal();
        }

    }

}
