using UnityEditor;
using UnityEngine;

namespace GameSettings.UI.Editor
{
    [CustomPropertyDrawer(typeof(FloatSettingInterpreter), true)]
    public class FloatSettingInterpreterDrawer : SettingInterpreterDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty ratio = property.FindPropertyRelative(nameof(ratio));
            SerializedProperty adjustment = property.FindPropertyRelative(nameof(adjustment));

            EditorGUILayout.PropertyField(ratio);
            EditorGUILayout.PropertyField(adjustment);

            //EditorGUILayout.BeginHorizontal();
            //EditorGUILayout.PrefixLabel("Interpreter");

            //var labelOptions = GUILayout.Width(10f);
            //var floatContent = GUIContent.none;

            //SerializedProperty _gameSetting = property.FindPropertyRelative(nameof(_gameSetting));
            //var value = ((FloatSetting)_gameSetting.objectReferenceValue).value;
            //EditorGUILayout.LabelField("(", labelOptions);
            //EditorGUI.BeginDisabledGroup(true);
            //EditorGUILayout.FloatField(value);
            //EditorGUI.EndDisabledGroup();
            //EditorGUILayout.LabelField("-", labelOptions);
            //EditorGUILayout.PropertyField(adjustment, floatContent);
            //EditorGUILayout.LabelField(")", labelOptions);
            //EditorGUILayout.LabelField("/", labelOptions);
            //EditorGUILayout.PropertyField(ratio, floatContent);
            //EditorGUILayout.LabelField("=", labelOptions);
            //EditorGUILayout.LabelField($"{((value - adjustment.floatValue) / ratio.floatValue).ToString("0.##")}");
            //EditorGUILayout.EndHorizontal();

            property = adjustment.Copy();
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
    }
}

