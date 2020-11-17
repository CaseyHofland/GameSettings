using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI.Editor
{
    [CustomPropertyDrawer(typeof(FloatSettingInterpreter), true)]
    public class FloatSettingInterpreterDrawer : SettingInterpreterDrawer
    {
        private float min = float.NaN;
        private float max = float.NaN;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty ratio = property.FindPropertyRelative(nameof(ratio));
            SerializedProperty adjustment = property.FindPropertyRelative(nameof(adjustment));

            var target = (Component)property.serializedObject.targetObject;
            float minValue, maxValue;
            switch(target.GetComponent<Selectable>())
            {
                case Slider slider:
                    minValue = slider.minValue;
                    maxValue = slider.maxValue;
                    break;
                default:
                    minValue = 0f;
                    maxValue = 1f;
                    break;
            }

            if(float.IsNaN(min))
            {
                min = minValue / ratio.floatValue - adjustment.floatValue;
            }
            if(float.IsNaN(max))
            {
                max = (maxValue - minValue) / ratio.floatValue + min;
            }

            min = EditorGUILayout.FloatField("Min Value", min);
            max = EditorGUILayout.FloatField("Max Value", max);

            ratio.floatValue = (maxValue - minValue) / (max - min);
            adjustment.floatValue = -(min - minValue / ratio.floatValue);

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

