using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(BoolSetting), true)]
    public class BoolSettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue()
        {
            var boolSetting = (BoolSetting)target;

            try
            {
                EditorGUI.BeginChangeCheck();
                var newValue = EditorGUILayout.Toggle(boolSetting.settingName, boolSetting.value);
                if(EditorGUI.EndChangeCheck())
                {
                    boolSetting.value = newValue;
                }
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}

