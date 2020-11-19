using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(ArraySetting), true)]
    public class ArraySettingEditor : GameSettingEditor
    {
        private SerializedProperty serializedValue;
        private string[] displayOptions;
        private ArraySetting arraySetting => (ArraySetting)target;

        protected override void OnEnable()
        {
            base.OnEnable();

            serializedValue = serializedObject.FindProperty(nameof(serializedValue));
            serializedValue.intValue = arraySetting.value;
            serializedObject.ApplyModifiedProperties();

            displayOptions = new string[arraySetting.Length];
            for(int i = 0; i < displayOptions.Length; i++)
            {
                displayOptions[i] = arraySetting[i].ToString();
            }
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
                serializedValue.intValue = EditorGUILayout.Popup(arraySetting.settingName, serializedValue.intValue, displayOptions);
                serializedObject.ApplyModifiedProperties();

                arraySetting.value = serializedValue.intValue;
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
