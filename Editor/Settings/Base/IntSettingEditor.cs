using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(IntSetting), true)]
    public class IntSettingEditor : GameSettingEditor
    {
        private SerializedProperty serializedValue;
        private IntSetting intSetting => (IntSetting)target;

        protected override void OnEnable()
        {
            base.OnEnable();
            serializedValue = serializedObject.FindProperty(nameof(serializedValue));
            serializedValue.intValue = intSetting.value;
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
                if(intSetting.min != int.MinValue && intSetting.max != int.MaxValue)
                {
                    serializedValue.intValue = EditorGUILayout.IntSlider(intSetting.settingName, serializedValue.intValue, intSetting.min, intSetting.max);
                }
                else
                {
                    serializedValue.intValue = Mathf.Clamp(EditorGUILayout.IntField(intSetting.settingName, serializedValue.intValue), intSetting.min, intSetting.max);
                }
                serializedObject.ApplyModifiedProperties();

                intSetting.value = serializedValue.intValue;
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}

