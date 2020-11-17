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
        protected SerializedProperty forceUI;

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
            forceUI = serializedObject.FindProperty(nameof(forceUI));

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
            var interfaceTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
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

            var newIndex = _gameSetting.objectReferenceValue
                ? Array.IndexOf(gameSettings, _gameSetting.objectReferenceValue) + 1
                : 0;
            newIndex = EditorGUILayout.Popup("Setting", newIndex, displayOptions);
            if(index != newIndex)
            {
                index = newIndex;
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
            }

            if(settingEditor)
            {
                settingEditor.OnInspectorGUI();
            }

            if(!string.IsNullOrWhiteSpace(selectableInterpreter.managedReferenceFullTypename))
            {
                EditorGUILayout.LabelField("Interpreter", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(selectableInterpreter, true);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(forceUI, GUILayout.ExpandWidth(false));
                if(forceUI.boolValue)
                {
                    GUILayout.Toggle(true, "Reset UI", GUI.skin.button);
                }
                else
                {
                    if(GUILayout.Button("Reset UI"))
                    {
                        ((SettingsSelectable)target).ResetUI();
                        EditorApplication.QueuePlayerLoopUpdate();
                    }
                }
                EditorGUILayout.EndHorizontal();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

