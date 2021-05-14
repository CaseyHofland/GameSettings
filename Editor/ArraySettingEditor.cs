using System;
using System.Collections;
using System.Reflection;
using UnityEditor;
using System.Linq;

namespace GameSettings2.Editor
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

            public dynamic[] array
            {
                get => ((IEnumerable)arrayProperty.GetValue(target)).Cast<object>().ToArray();
                set => arrayProperty.SetValue(target, value);
            }

            public dynamic current
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
            displayOptions = Array.ConvertAll<dynamic, string>(arraySetting.array, item => item.ToString());
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            arraySetting.value = EditorGUILayout.Popup(propertyLabel, serializedValue.intValue, displayOptions);
            serializedValue.intValue = arraySetting.value;

            serializedObject.ApplyModifiedProperties();
        }
    }
}

