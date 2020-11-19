using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(ShadowCascade4SplitSetting), true)]
    public class ShadowCascade4SplitSettingEditor : GameSettingEditor
    {
        private SerializedProperty serializedValue;
        private ShadowCascade4SplitSetting shadowCascade4SplitSetting => (ShadowCascade4SplitSetting)target;

        protected override void OnEnable()
        {
            base.OnEnable();
            serializedValue = serializedObject.FindProperty(nameof(serializedValue));
            serializedValue.vector3Value = shadowCascade4SplitSetting.value;
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
                serializedValue.vector3Value = EditorGUILayout.Vector3Field(shadowCascade4SplitSetting.settingName, serializedValue.vector3Value);
                serializedObject.ApplyModifiedProperties();

                shadowCascade4SplitSetting.value = serializedValue.vector3Value;
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
