using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(ResolutionSetting), true)]
    public class ResolutionSettingEditor : ArraySettingEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Screen settings aren't applied in the Editor, only in Builds.", MessageType.Info, true);
            EditorGUILayout.HelpBox("Resolutions are based on Edit > Project Settings > Player > Resolution and Presentation > Supported Aspect Ratios. Note that if you change these values, they will only be updated after the Editor is restarted.", MessageType.None, true);
            base.OnInspectorGUI();
        }
    }
}
