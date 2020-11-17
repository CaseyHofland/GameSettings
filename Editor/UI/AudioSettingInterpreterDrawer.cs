using UnityEditor;
using UnityEngine;

namespace GameSettings.UI.Editor
{
    [CustomPropertyDrawer(typeof(AudioSettingInterpreter), true)]
    public class AudioSettingInterpreterDrawer : FloatSettingInterpreterDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);

            //if(property.FindPropertyRelative("audioValue").enumValueIndex == (int)AudioSettingInterpreter.AudioValue.Decibel)
            //{
            //    EditorGUILayout.HelpBox("Decibel expects a value between 0 and 1", MessageType.Info);
            //}
        }
    }
}

