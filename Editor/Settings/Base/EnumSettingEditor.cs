using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(EnumSetting), true)]
    public class EnumSettingEditor : GameSettingEditor
    {
        private SerializedProperty serializedValue;
        protected EnumSetting enumSetting => (EnumSetting)target;

        protected override void OnEnable()
        {
            base.OnEnable();
            serializedValue = serializedObject.FindProperty(nameof(serializedValue));
            serializedValue.intValue = enumSetting.intValue;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
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
                serializedValue.intValue = EditorGUILayout.Popup(enumSetting.settingName, serializedValue.intValue, Enum.GetNames(enumSetting.enumValue.GetType()));
                serializedObject.ApplyModifiedProperties();

                enumSetting.intValue = serializedValue.intValue;
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
