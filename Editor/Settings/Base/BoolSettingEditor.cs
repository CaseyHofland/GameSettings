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
            try
            {
                var boolSetting = (BoolSetting)target;
                boolSetting.value = EditorGUILayout.Toggle(boolSetting.settingName, boolSetting.value);
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}

