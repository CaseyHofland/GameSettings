using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(EnumSetting), true)]
    public class EnumSettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue()
        {
            var enumSetting = (EnumSetting)target;

            try
            {
                EditorGUI.BeginChangeCheck();
                var newValue = EditorGUILayout.EnumPopup(enumSetting.settingName, enumSetting.value);
                if(EditorGUI.EndChangeCheck())
                {
                    enumSetting.value = newValue;
                }
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
