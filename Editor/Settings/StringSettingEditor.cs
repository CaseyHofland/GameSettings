using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(StringSetting))]
    public class StringSettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue(bool delayed = false)
        {
            var stringSetting = (StringSetting)target;

            EditorGUI.BeginChangeCheck();
            var newValue = delayed
                ? EditorGUILayout.DelayedTextField("Value", stringSetting.value)
                : EditorGUILayout.TextField("Value", stringSetting.value);
            if(EditorGUI.EndChangeCheck())
            {
                stringSetting.value = newValue;
            }
        }
    }
}