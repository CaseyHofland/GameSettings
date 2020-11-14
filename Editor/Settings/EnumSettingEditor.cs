using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(EnumSetting), true)]
    public class EnumSettingEditor : GameSettingEditor
    {
        public override void OnInspectorGUI()
        {
            DrawLoadOnStartupToggle();
            DrawValue();
            DrawProperties();
        }

        protected void DrawValue()
        {
            var enumSetting = (EnumSetting)target;

            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUILayout.EnumPopup("Value", enumSetting.value);
            if(EditorGUI.EndChangeCheck())
            {
                enumSetting.value = newValue;
            }
        }
    }
}
