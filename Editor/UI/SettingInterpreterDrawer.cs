using UnityEditor;
using UnityEngine;

namespace GameSettings.UI.Editor
{
    [CustomPropertyDrawer(typeof(SettingInterpreter), true)]
    public class SettingInterpreterDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            property = property.Copy();
            if(property.NextVisible(true))
            {
                while(property.NextVisible(false) 
                    && property.propertyPath.StartsWith("selectableInterpreter."))
                {
                    EditorGUILayout.PropertyField(property, true);
                }
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 0f;
        }
    }
}

