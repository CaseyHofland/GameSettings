using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace GameSettings2.Editor
{
    [CustomEditor(typeof(GameSetting<>), true)]
    public class GameSettingEditor : UnityEditor.Editor
    {
        protected SerializedProperty serializedValue;
        protected object dynamicSerializedValue
        {
            get
            {
                switch (serializedValue.propertyType)
                {
                    case SerializedPropertyType.AnimationCurve:
                        return serializedValue.animationCurveValue;
                    case SerializedPropertyType.ArraySize:
                        return serializedValue.arraySize;
                    case SerializedPropertyType.Boolean:
                        return serializedValue.boolValue;
                    case SerializedPropertyType.Bounds:
                        return serializedValue.boundsValue;
                    case SerializedPropertyType.BoundsInt:
                        return serializedValue.boundsIntValue;
                    //case SerializedPropertyType.Character:
                    case SerializedPropertyType.Color:
                        return serializedValue.colorValue;
                    case SerializedPropertyType.Enum:
                        return serializedValue.enumValueIndex;
                    case SerializedPropertyType.ExposedReference:
                        return serializedValue.exposedReferenceValue;
                    case SerializedPropertyType.FixedBufferSize:
                        return serializedValue.fixedBufferSize;
                    case SerializedPropertyType.Float:
                        return serializedValue.floatValue;
                    //case SerializedPropertyType.Generic:
                    //case SerializedPropertyType.Gradient:
                    case SerializedPropertyType.Integer:
                        return serializedValue.intValue;
                    //case SerializedPropertyType.LayerMask:
                    case SerializedPropertyType.ManagedReference:
                        return serializedValue.managedReferenceFullTypename;
                    case SerializedPropertyType.ObjectReference:
                        return serializedValue.objectReferenceValue;
                    case SerializedPropertyType.Quaternion:
                        return serializedValue.quaternionValue;
                    case SerializedPropertyType.Rect:
                        return serializedValue.rectValue;
                    case SerializedPropertyType.RectInt:
                        return serializedValue.rectIntValue;
                    case SerializedPropertyType.String:
                        return serializedValue.stringValue;
                    case SerializedPropertyType.Vector2:
                        return serializedValue.vector2Value;
                    case SerializedPropertyType.Vector2Int:
                        return serializedValue.vector2IntValue;
                    case SerializedPropertyType.Vector3:
                        return serializedValue.vector3Value;
                    case SerializedPropertyType.Vector3Int:
                        return serializedValue.vector3IntValue;
                    case SerializedPropertyType.Vector4:
                        return serializedValue.vector4Value;
                    default:
                        return null;
                }
            }
            set
            {
                switch (serializedValue.propertyType)
                {
                    case SerializedPropertyType.AnimationCurve:
                        serializedValue.animationCurveValue = (AnimationCurve)value;
                        break;
                    case SerializedPropertyType.ArraySize:
                        serializedValue.arraySize = (int)value;
                        break;
                    case SerializedPropertyType.Boolean:
                        serializedValue.boolValue = (bool)value;
                        break;
                    case SerializedPropertyType.Bounds:
                        serializedValue.boundsValue = (Bounds)value;
                        break;
                    case SerializedPropertyType.BoundsInt:
                        serializedValue.boundsIntValue = (BoundsInt)value;
                        break;
                    //case SerializedPropertyType.Character:
                    case SerializedPropertyType.Color:
                        serializedValue.colorValue = (Color)value;
                        break;
                    case SerializedPropertyType.Enum:
                        //serializedValue.enumValueIndex = value is Enum ? (int)(object)value : (int)value;
                        serializedValue.enumValueIndex = (int)value;
                        break;
                    case SerializedPropertyType.ExposedReference:
                        serializedValue.exposedReferenceValue = (UnityEngine.Object)value;
                        break;
                    //case SerializedPropertyType.FixedBufferSize:
                    case SerializedPropertyType.Float:
                        serializedValue.floatValue = (float)value;
                        break;
                    //case SerializedPropertyType.Generic:
                    //case SerializedPropertyType.Gradient:
                    case SerializedPropertyType.Integer:
                        serializedValue.intValue = (int)value;
                        break;
                    //case SerializedPropertyType.LayerMask:
                    case SerializedPropertyType.ManagedReference:
                        serializedValue.managedReferenceValue = value;
                        break;
                    case SerializedPropertyType.ObjectReference:
                        serializedValue.objectReferenceValue = (UnityEngine.Object)value;
                        break;
                    case SerializedPropertyType.Quaternion:
                        serializedValue.quaternionValue = (Quaternion)value;
                        break;
                    case SerializedPropertyType.Rect:
                        serializedValue.rectValue = (Rect)value;
                        break;
                    case SerializedPropertyType.RectInt:
                        serializedValue.rectIntValue = (RectInt)value;
                        break;
                    case SerializedPropertyType.String:
                        serializedValue.stringValue = (string)value;
                        break;
                    case SerializedPropertyType.Vector2:
                        serializedValue.vector2Value = (Vector2)value;
                        break;
                    case SerializedPropertyType.Vector2Int:
                        serializedValue.vector2IntValue = (Vector2Int)value;
                        break;
                    case SerializedPropertyType.Vector3:
                        serializedValue.vector3Value = (Vector3)value;
                        break;
                    case SerializedPropertyType.Vector3Int:
                        serializedValue.vector3IntValue = (Vector3Int)value;
                        break;
                    case SerializedPropertyType.Vector4:
                        serializedValue.vector4Value = (Vector4)value;
                        break;
                }
            }
        }

        protected GameSetting gameSetting;
        protected GUIContent propertyLabel;

        protected class GameSetting
        {
            protected readonly object target;
            protected readonly PropertyInfo settingNameProperty;
            protected readonly PropertyInfo valueProperty;

            public string settingName
            {
                get => (string)settingNameProperty.GetValue(target);
                set => settingNameProperty.SetValue(target, value);
            }

            public object value
            {
                get => valueProperty.GetValue(target);
                set => valueProperty.SetValue(target, value);
            }

            public GameSetting(object target)
            {
                this.target = target;

                var gameSetting = target.GetType();
                settingNameProperty = gameSetting.GetProperty(nameof(GameSetting<object>.settingName));
                valueProperty = gameSetting.GetProperty(nameof(GameSetting<object>.value));
            }
        }

        protected virtual void OnEnable()
        {
            gameSetting = new GameSetting(target);
            serializedValue = serializedObject.FindProperty(nameof(serializedValue));
            propertyLabel = new GUIContent(gameSetting.settingName); 

            dynamicSerializedValue = gameSetting.value;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedValue, propertyLabel, true);

            gameSetting.value = dynamicSerializedValue;
            dynamicSerializedValue = gameSetting.value;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
