using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_TEXTMESHPRO
using TMPro;
#endif

namespace GameSettings.UI.Editor
{
    [CustomEditor(typeof(SettingsSelectable), true)]
    public class SettingsSelectableEditor : UnityEditor.Editor
    {
        protected SerializedProperty _gameSetting;
        protected SerializedProperty selectableInterpreter;

        private string[] displayOptions;
        private GameSetting[] gameSettings;
        private Dictionary<GameSetting, Type> settingInterpreters = new Dictionary<GameSetting, Type>();
        private int index;
        private UnityEditor.Editor settingEditor;

        protected virtual void OnEnable()
        {
            // Get Properties
            _gameSetting = serializedObject.FindProperty(nameof(_gameSetting));
            selectableInterpreter = serializedObject.FindProperty(nameof(selectableInterpreter));

            // Get the Corresponding Interface Type
            Selectable selectable = (Selectable)typeof(SettingsSelectable).GetProperty(nameof(selectable)).GetValue(target);
            Type interfaceType;
            switch(selectable)
            {
#if UNITY_TEXTMESHPRO
                case TMP_InputField _:
                    interfaceType = typeof(TMPro.ISettingTMP_InputFieldInterpreter);
                    break;
                case TMP_Dropdown _:
                    interfaceType = typeof(TMPro.ISettingTMP_DropdownInterpreter);
                    break;
#endif
                case InputField _:
                    interfaceType = typeof(ISettingInputFieldInterpreter);
                    break;
                case Dropdown _:
                    interfaceType = typeof(ISettingDropdownInterpreter);
                    break;
                case Scrollbar _:
                    interfaceType = typeof(ISettingScrollbarInterpreter);
                    break;
                case Slider _:
                    interfaceType = typeof(ISettingSliderInterpreter);
                    break;
                case Toggle _:
                    interfaceType = typeof(ISettingToggleInterpreter);
                    break;
                case Button _:
                    interfaceType = typeof(ISettingButtonInterpreter);
                    break;
                case Selectable _:
                    interfaceType = typeof(ISettingSelectableInterpreter);
                    break;
                default:
                    interfaceType = null;
                    break;
            }

            // Find all classes of the Interface Type
            var libraryPath = Application.dataPath.Remove(Application.dataPath.LastIndexOf('/') + 1).Replace('/', '\\') + "Library";
            var interfaceTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  where assembly.Location.StartsWith(libraryPath)
                                  from type in assembly.GetTypes()
                                  where !type.IsAbstract
                                  where interfaceType.IsAssignableFrom(type)
                                  select type).ToArray();
            var gameSettingTypes = Array.ConvertAll(interfaceTypes, type => type.GetProperties().First(property => property.Name == "gameSetting").PropertyType);

            // Find all settings with a valid interpreter
            var displayOptions = new List<string>
            {
                "Nothing"
            };
            var gameSettings = new List<GameSetting>();

            var guids = AssetDatabase.FindAssets("t:GameSetting");
            for(int i = 0; i < guids.Length; i++)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                var gameSetting = AssetDatabase.LoadAssetAtPath<GameSetting>(assetPath);
                var gameSettingType = gameSetting.GetType();
                int typeIndex;
                do
                {
                    typeIndex = Array.IndexOf(gameSettingTypes, gameSettingType);
                    gameSettingType = gameSettingType.BaseType;
                } while(typeIndex == -1 && gameSettingType != null);

                if(typeIndex != -1)
                {
                    displayOptions.Add(gameSetting.settingName);
                    gameSettings.Add(gameSetting);
                    settingInterpreters.Add(gameSetting, interfaceTypes[typeIndex]);
                }
            }

            this.displayOptions = displayOptions.ToArray();
            this.gameSettings = gameSettings.ToArray();

            // Set starting values
            index = Array.IndexOf(this.gameSettings, _gameSetting.objectReferenceValue) + 1;
            if(index > 0)
            {
                if(!string.IsNullOrWhiteSpace(selectableInterpreter.managedReferenceFullTypename))
                {
                    var gameSetting = gameSettings[index - 1];
                    var interpreter = settingInterpreters[gameSetting];
                    var instance = (ISettingSelectableInterpreter)Activator.CreateInstance(interpreter);
                    instance.gameSetting = gameSetting;
                    selectableInterpreter.managedReferenceValue = instance;
                }

                settingEditor = CreateEditor(_gameSetting.objectReferenceValue);
            }
            else
            {
                selectableInterpreter.managedReferenceValue = null;
                settingEditor = null;
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            index = EditorGUILayout.Popup("Setting", index, displayOptions);
            if(EditorGUI.EndChangeCheck())
            {
                if(index > 0)
                {
                    var gameSetting = gameSettings[index - 1];
                    _gameSetting.objectReferenceValue = gameSetting;
                    
                    var interpreter = settingInterpreters[gameSetting];
                    var instance = (ISettingSelectableInterpreter)Activator.CreateInstance(interpreter);
                    instance.gameSetting = gameSetting;
                    selectableInterpreter.managedReferenceValue = instance;

                    settingEditor = CreateEditor(gameSetting);
                }
                else
                {
                    _gameSetting.objectReferenceValue = null;
                    selectableInterpreter.managedReferenceValue = null;
                    settingEditor = null;
                }

                serializedObject.ApplyModifiedProperties();
                ((SettingsSelectable)target).ResetView();
            }

            serializedObject.ApplyModifiedProperties();

            if(_gameSetting.objectReferenceValue
                && !string.IsNullOrWhiteSpace(selectableInterpreter.managedReferenceFullTypename)
                && settingEditor)
            {
                settingEditor.OnInspectorGUI();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel(" ");
                if(GUILayout.Button("Reset View"))
                {
                    ((SettingsSelectable)target).ResetView();
                    EditorApplication.QueuePlayerLoopUpdate();
                }
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}

