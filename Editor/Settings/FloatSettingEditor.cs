using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(FloatSetting))]
    public class FloatSettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue(bool delayed = false)
        {
            var floatSetting = (FloatSetting)target;

            EditorGUI.BeginChangeCheck();
            var newValue = delayed
                ? EditorGUILayout.DelayedFloatField("Value", floatSetting.value)
                : EditorGUILayout.FloatField("Value", floatSetting.value);
            if(EditorGUI.EndChangeCheck())
            {
                floatSetting.value = newValue;
            }
        }
    }
}
