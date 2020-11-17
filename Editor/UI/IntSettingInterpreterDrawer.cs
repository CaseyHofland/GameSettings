using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI.Editor
{
    [CustomPropertyDrawer(typeof(IntSettingInterpreter), true)]
    public class IntSettingInterpreterDrawer : SettingInterpreterDrawer
    {
        private int min;
        private int max;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty ratio = property.FindPropertyRelative(nameof(ratio));
            SerializedProperty adjustment = property.FindPropertyRelative(nameof(adjustment));

            var target = (Component)property.serializedObject.targetObject;
            int minValue, maxValue;
            switch(target.GetComponent<Selectable>())
            {
                case Slider slider:
                    minValue = (int)slider.minValue;
                    maxValue = (int)slider.maxValue;
                    break;
                default:
                    minValue = 0;
                    maxValue = 1;
                    break;
            }

            //if(float.IsNaN(min))
            //{
            //    min = minValue / ratio.intValue - adjustment.intValue;
            //}
            //if(float.IsNaN(max))
            //{
            //    max = (maxValue - minValue) / ratio.intValue + min;
            //}
            min = minValue / ratio.intValue - adjustment.intValue;
            max = (maxValue - minValue) / ratio.intValue + min;

            min = EditorGUILayout.IntField("Min Value", min);
            max = EditorGUILayout.IntField("Max Value", max);

            ratio.intValue = (maxValue - minValue) / (max - min);
            adjustment.intValue = -(min - minValue / ratio.intValue);

            //EditorGUILayout.LabelField($"Ratio: {ratio.floatValue}");
            //EditorGUILayout.LabelField($"Adjustment: {adjustment.floatValue}");

            property = adjustment.Copy();
            while(property.NextVisible(false) 
                && property.propertyPath.StartsWith("selectableInterpreter."))
            {
                EditorGUILayout.PropertyField(property, true);
            }

            EditorGUI.EndProperty();
        }
    }
}

