using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(FloatSetting), true)]
    public class FloatSettingEditor : GameSettingEditor
    {
        private SerializedProperty serializedValue;
        private FloatSetting floatSetting => (FloatSetting)target;

        protected override void OnEnable()
        {
            base.OnEnable();
            serializedValue = serializedObject.FindProperty(nameof(serializedValue));
            serializedValue.floatValue = floatSetting.value;
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
                if(!float.IsNegativeInfinity(floatSetting.min) && !float.IsPositiveInfinity(floatSetting.max))
                {
                    serializedValue.floatValue = EditorGUILayout.Slider(floatSetting.settingName, serializedValue.floatValue, floatSetting.min, floatSetting.max);
                }
                else
                {
                    serializedValue.floatValue = Mathf.Clamp(EditorGUILayout.FloatField(floatSetting.settingName, serializedValue.floatValue), floatSetting.min, floatSetting.max);
                }
                serializedObject.ApplyModifiedProperties();

                floatSetting.value = serializedValue.floatValue;
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
