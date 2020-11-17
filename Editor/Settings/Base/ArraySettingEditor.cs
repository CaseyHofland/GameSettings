using System;
using UnityEditor;
using UnityEngine;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(ArraySetting), true)]
    public class ArraySettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue()
        {
            try
            {
                var arraySetting = (ArraySetting)target;
                arraySetting.value = EditorGUILayout.Popup(arraySetting.settingName, arraySetting.value, Array.ConvertAll(arraySetting.objectArray, value => value.ToString()));
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
