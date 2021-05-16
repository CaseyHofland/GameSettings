using System;
using System.Collections;
using System.Reflection;
using UnityEditor;
using System.Linq;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(ArraySetting<>), true)]
    public class ArraySettingEditor : GameSettingEditor
    {
        protected string[] displayOptions;

        protected ArraySetting arraySetting;

        protected class ArraySetting : GameSetting
        {
            protected readonly PropertyInfo arrayProperty;
            protected readonly PropertyInfo currentProperty;

            public object[] array
            {
                get => ((IEnumerable)arrayProperty.GetValue(target)).Cast<object>().ToArray();
                set => arrayProperty.SetValue(target, value);
            }

            public object current
            {
                get => currentProperty.GetValue(target);
                set => currentProperty.SetValue(target, value);
            }

            public ArraySetting(object target) : base(target)
            {
                var arraySetting = target.GetType();
                arrayProperty = arraySetting.GetProperty(nameof(array), BindingFlags.NonPublic | BindingFlags.Instance);
                currentProperty = arraySetting.GetProperty(nameof(ArraySetting<object>.current));
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            arraySetting = new ArraySetting(target);
            displayOptions = Array.ConvertAll(arraySetting.array, item => item.ToString());
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            serializedValue.intValue = (int)arraySetting.value;
            arraySetting.value = EditorGUILayout.Popup(propertyLabel, serializedValue.intValue, displayOptions);
            serializedValue.intValue = (int)arraySetting.value;

            serializedObject.ApplyModifiedProperties();
        }
    }
}

