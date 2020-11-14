using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(BoolSetting))]
    public class BoolSettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue()
        {
            var boolSetting = (BoolSetting)target;

            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUILayout.Toggle("Value", boolSetting.value);
            if(EditorGUI.EndChangeCheck())
            {
                boolSetting.value = newValue;
            }
        }
    }
}

