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

            try
            {
                var enumSetting = (EnumSetting)target;
                enumSetting.value = EditorGUILayout.EnumPopup(enumSetting.settingName, enumSetting.value);
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
