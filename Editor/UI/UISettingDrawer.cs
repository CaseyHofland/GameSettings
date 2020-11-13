using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameSettings.UI.Editor
{
    [CustomPropertyDrawer(typeof(UISetting), true)]
    public class UISettingDrawer : PropertyDrawer
    {
        private static Dictionary<string, UnityEngine.Object> storedReferences = new Dictionary<string, UnityEngine.Object>();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty gameSetting = property.FindPropertyRelative(nameof(gameSetting));
            if(gameSetting != null)
            {
                var splitName = property.managedReferenceFullTypename?.Split(' ');
                var propertyType = Type.GetType($"{splitName?[1]}, {splitName?[0]}")?.GetProperty("derivedGameSetting")?.PropertyType;

                if(storedReferences.TryGetValue(GetKey(), out var value))
                {
                    gameSetting.objectReferenceValue = value;
                }
                EditorGUI.BeginChangeCheck();
                if(propertyType != null)
                {
                    EditorGUI.ObjectField(position, gameSetting, propertyType);
                }
                else
                {
                    EditorGUI.PropertyField(position, gameSetting);
                }
                if(EditorGUI.EndChangeCheck())
                {
                    storedReferences[GetKey()] = gameSetting.objectReferenceValue;
                }

                if(gameSetting.objectReferenceValue)
                {
                    UnityEditor.Editor.CreateEditor(gameSetting.objectReferenceValue).OnInspectorGUI();
                }
            }

            EditorGUI.EndProperty();

            string GetKey() => property.serializedObject.targetObject.GetInstanceID() + property.managedReferenceFullTypename;
        }
    }
}
