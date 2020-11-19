using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(ResolutionSetting), true)]
    public class ResolutionSettingEditor : ArraySettingEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Screen settings aren't applied in the Editor, only in Builds.", MessageType.Info, true);
            EditorGUILayout.HelpBox("Note that if you change the Supported Aspect Ratios, this setting will be updated after an Editor restart.", MessageType.None, true);

            EditorGUI.BeginDisabledGroup(true);
            DrawValue();
            EditorGUI.EndDisabledGroup();
            DrawProperties();
        }
    }
}
