using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(StringSetting), true)]
    public class StringSettingEditor : GameSettingEditor
    {
        private SerializedProperty serializedValue;
        private StringSetting stringSetting => (StringSetting)target;

        protected override void OnEnable()
        {
            base.OnEnable();
            serializedValue = serializedObject.FindProperty(nameof(serializedValue));
            serializedValue.stringValue = stringSetting.value;
            serializedObject.ApplyModifiedProperties();
        }

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
                serializedObject.Update();
                serializedValue.stringValue = EditorGUILayout.TextField(stringSetting.settingName, serializedValue.stringValue);
                serializedObject.ApplyModifiedProperties();

                stringSetting.value = serializedValue.stringValue;
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}