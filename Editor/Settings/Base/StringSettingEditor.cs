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
            try
            {
                var stringSetting = (StringSetting)target;
                stringSetting.value = delayed
                    ? EditorGUILayout.DelayedTextField(stringSetting.settingName, stringSetting.value)
                    : EditorGUILayout.TextField(stringSetting.settingName, stringSetting.value);
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}