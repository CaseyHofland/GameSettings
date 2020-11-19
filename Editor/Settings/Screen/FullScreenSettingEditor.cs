using UnityEditor;

namespace GameSettings.Editor
{
    [CustomEditor(typeof(FullScreenSetting), true)]
    public class FullScreenSettingEditor : BoolSettingEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Screen settings aren't applied in the Editor, only in Builds.", MessageType.Info, true);

            EditorGUI.BeginDisabledGroup(true);
            DrawValue();
            EditorGUI.EndDisabledGroup();
            DrawProperties();
        }
    }
}
