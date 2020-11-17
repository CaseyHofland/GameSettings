using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(FullScreenModeSetting), true)]
    public class FullScreenModeSettingEditor : EnumSettingEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Screen settings aren't applied in the Editor, only in Builds.", MessageType.Info, true);
            base.OnInspectorGUI();
        }
    }
}
