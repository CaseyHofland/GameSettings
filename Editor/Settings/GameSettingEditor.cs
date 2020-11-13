using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(GameSetting), true)]
    public class GameSettingEditor : UnityEditor.Editor
    {
        private SettingsStartupLoader settingsStartupLoader;

        protected virtual void OnEnable()
        {
            var guids = AssetDatabase.FindAssets("t:SettingsStartupLoader");
            var assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);
            settingsStartupLoader = AssetDatabase.LoadAssetAtPath<SettingsStartupLoader>(assetPath);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var property = serializedObject.GetIterator();
            if(property.NextVisible(true))
            {
                DrawLoadOnStartupToggle();
                DrawCurrentValue();

                while(property.NextVisible(false))
                {
                    EditorGUILayout.PropertyField(property, true);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        protected void DrawLoadOnStartupToggle()
        {
            GameSetting gameSetting = (GameSetting)target;

            EditorGUI.BeginChangeCheck();
            var loadOnStartup = EditorGUILayout.Toggle("Load on Startup", Array.IndexOf(settingsStartupLoader.setingsToLoadOnStartup, gameSetting) != -1);
            if(EditorGUI.EndChangeCheck())
            {
                var temp = new List<GameSetting>(settingsStartupLoader.setingsToLoadOnStartup);
                if(loadOnStartup)
                {
                    temp.Add(gameSetting);
                }
                else
                {
                    temp.Remove(gameSetting);
                }
                settingsStartupLoader.setingsToLoadOnStartup = temp.ToArray();
            }
        }

        protected void DrawCurrentValue()
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            var currentValue = target.GetType().GetProperty("value", bindingFlags).GetValue(target);
            EditorGUILayout.LabelField($"Current Value:", $"{currentValue}");
        }
    }
}

