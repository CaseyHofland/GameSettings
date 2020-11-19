using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(QualityLevelSetting), true)]
    public class QualityLevelSettingEditor : ArraySettingEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("All Quality Levels are shown in the Editor, Levels that are disallowed on certain platforms will be excluded in Builds.", MessageType.Info, true);
            base.OnInspectorGUI();
        }
    }
}
