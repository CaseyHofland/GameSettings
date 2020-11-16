using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(FloatSetting), true)]
    public class FloatSettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue(bool delayed = false)
        {
            var floatSetting = (FloatSetting)target;

            try
            {
                EditorGUI.BeginChangeCheck();
                var newValue = delayed
                    ? EditorGUILayout.DelayedFloatField(floatSetting.settingName, floatSetting.value)
                    : EditorGUILayout.FloatField(floatSetting.settingName, floatSetting.value);
                if(EditorGUI.EndChangeCheck())
                {
                    floatSetting.value = newValue;
                }
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
}
    }
}
