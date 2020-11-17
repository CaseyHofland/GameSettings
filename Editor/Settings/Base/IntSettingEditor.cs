using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(IntSetting), true)]
    public class IntSettingEditor : GameSettingEditor
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
                var intSetting = (IntSetting)target;
                intSetting.value = delayed
                    ? EditorGUILayout.DelayedIntField(intSetting.settingName, intSetting.value)
                    : EditorGUILayout.IntField(intSetting.settingName, intSetting.value);
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
}
    }
}

