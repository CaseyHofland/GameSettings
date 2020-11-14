using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(IntSetting))]
    public class IntSettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue(bool delayed = false)
        {
            var intSetting = (IntSetting)target;

            EditorGUI.BeginChangeCheck();
            var newValue = delayed
                ? EditorGUILayout.DelayedIntField("Value", intSetting.value)
                : EditorGUILayout.IntField("Value", intSetting.value);
            if(EditorGUI.EndChangeCheck())
            {
                intSetting.value = newValue;
            }
        }
    }
}

