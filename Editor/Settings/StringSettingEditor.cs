using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(StringSetting), true)]
    public class StringSettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue(bool delayed = false)
        {
            var stringSetting = (StringSetting)target;

            try
            {
                EditorGUI.BeginChangeCheck();
                var newValue = delayed
                    ? EditorGUILayout.DelayedTextField(stringSetting.settingName, stringSetting.value)
                    : EditorGUILayout.TextField(stringSetting.settingName, stringSetting.value);
                if(EditorGUI.EndChangeCheck())
                {
                    stringSetting.value = newValue;
                }
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}