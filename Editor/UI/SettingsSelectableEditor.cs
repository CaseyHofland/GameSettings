using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI.Editor
{
    [CustomEditor(typeof(SettingsSelectable), true)]
    public class SettingsSelectableEditor : UnityEditor.Editor
    {
        protected SerializedProperty _uiSetting;

        protected Selectable selectable => (Selectable)typeof(SettingsSelectable).GetProperty(nameof(selectable)).GetValue(target);

        private Type[] types;
        private string[] displayOptions;
        private int index;

        private void OnEnable()
        {
            _uiSetting = serializedObject.FindProperty(nameof(_uiSetting));

            Type interfaceType;
            switch(selectable)
            {
                case Slider _:
                    interfaceType = typeof(ISettingSlider);
                    break;
                case Toggle _:
                    interfaceType = typeof(ISettingToggle);
                    break;
                case Selectable _:
                    interfaceType = typeof(ISettingSelectable);
                    break;
                default:
                    interfaceType = null;
                    break;
            }

            var libraryPath = Application.dataPath.Remove(Application.dataPath.LastIndexOf('/') + 1).Replace('/', '\\') + "Library";
            const string defaultDisplayOption = "Nothing";
            types = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                     where assembly.Location.StartsWith(libraryPath)
                     from type in assembly.GetTypes()
                     where !type.IsAbstract
                     where typeof(UISetting).IsAssignableFrom(type)
                     where interfaceType.IsAssignableFrom(type)
                     where type.Name != defaultDisplayOption
                     select type).ToArray();

            var typeNames = Array.ConvertAll(types, type => type.Name);
            displayOptions = new string[typeNames.Length + 1];
            displayOptions[0] = defaultDisplayOption;
            Array.Copy(typeNames, 0, displayOptions, 1, typeNames.Length);

            var currentOption = _uiSetting.managedReferenceFullTypename.Substring(_uiSetting.managedReferenceFullTypename.LastIndexOf('.') + 1);
            index = Array.IndexOf(typeNames, currentOption) + 1;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            index = EditorGUILayout.Popup("Setting", index, displayOptions);
            if(EditorGUI.EndChangeCheck())
            {
                _uiSetting.managedReferenceValue = index > 0
                    ? Activator.CreateInstance(types[index - 1])
                    : null;
                ((SettingsSelectable)target).ResetView();
            }

            if(!string.IsNullOrWhiteSpace(_uiSetting.managedReferenceFullTypename))
            {
                EditorGUILayout.PropertyField(_uiSetting);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel(" ");
                if(GUILayout.Button("Reset View"))
                {
                    ((SettingsSelectable)target).ResetView();
                }
                EditorGUILayout.EndHorizontal();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
