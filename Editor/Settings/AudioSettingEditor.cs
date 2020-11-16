using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(AudioSetting), true)]
    public class AudioSettingEditor : FloatSettingEditor
    {
        private SerializedProperty audioMixer;
        private SerializedProperty exposedParameter;

        private float value;

        protected override void OnEnable()
        {
            base.OnEnable();

            audioMixer = serializedObject.FindProperty(nameof(audioMixer));
            exposedParameter = serializedObject.FindProperty(nameof(exposedParameter));

            value = ((AudioSetting)target).value;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawLoadOnStartupToggle();
            EditorGUILayout.PropertyField(audioMixer);
            if(audioMixer.objectReferenceValue != null)
            {
                var audioMixerReference = (AudioMixer)audioMixer.objectReferenceValue;

                // Exposed Parameters Popup
                var parameters = (Array)audioMixerReference.GetType().GetProperty("exposedParameters").GetValue(audioMixerReference);
                if(parameters.Length > 0)
                {
                    var names = new string[parameters.Length];
                    for(int i = 0; i < parameters.Length; i++)
                    {
                        var parameter = parameters.GetValue(i);
                        names[i] = (string)parameter.GetType().GetField("name").GetValue(parameter);
                    }

                    var index = Math.Max(Array.IndexOf(names, exposedParameter.stringValue), 0);
                    index = EditorGUILayout.Popup("Parameter", index, names);
                    exposedParameter.stringValue = names[index];

                    serializedObject.ApplyModifiedProperties();

                    // Draw Value
                    EditorGUI.BeginDisabledGroup(true);
                    var audioSetting = (AudioSetting)target;
                    var audioSettingValueLabel = new GUIContent(audioSetting.settingName, "Changing this value is only allowed in the Audio Mixer Window. Find it under Window > Audio > Audio Mixer.");
                    EditorGUILayout.FloatField(audioSettingValueLabel, audioSetting.value);
                    EditorGUI.EndDisabledGroup();

                    // Other Values
                    var property = exposedParameter.Copy();
                    while(property.NextVisible(false))
                    {
                        EditorGUILayout.PropertyField(property, true);
                    }
                }
                else
                {
                    EditorGUILayout.HelpBox("The AudioMixer doesn't have any exposed parameters on it.", MessageType.Warning, true);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
