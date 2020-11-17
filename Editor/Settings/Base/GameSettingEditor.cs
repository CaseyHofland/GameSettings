using System;
using System.Collections.Generic;
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
            DrawLoadOnStartupToggle();
            DrawProperties();
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

        protected void DrawProperties()
        {
            serializedObject.Update();

            var property = serializedObject.GetIterator();
            if(property.NextVisible(true))
            {
                while(property.NextVisible(false))
                {
                    EditorGUILayout.PropertyField(property, true);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

