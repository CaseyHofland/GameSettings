using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(BoolSetting), true)]
    public class BoolSettingEditor : GameSettingEditor
    {
        private SerializedProperty serializedValue;
        private BoolSetting boolSetting => (BoolSetting)target;

        protected override void OnEnable()
        {
            base.OnEnable();
            serializedValue = serializedObject.FindProperty(nameof(serializedValue));
            serializedValue.boolValue = boolSetting.value;
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
                serializedValue.boolValue = EditorGUILayout.Toggle(boolSetting.settingName, serializedValue.boolValue);
                serializedObject.ApplyModifiedProperties();

                boolSetting.value = serializedValue.boolValue;
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}

