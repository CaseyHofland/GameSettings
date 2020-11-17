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

            try
            {
                var floatSetting = (FloatSetting)target;
                floatSetting.value = delayed
                    ? EditorGUILayout.DelayedFloatField(floatSetting.settingName, floatSetting.value)
                    : EditorGUILayout.FloatField(floatSetting.settingName, floatSetting.value);
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
}
    }
}
