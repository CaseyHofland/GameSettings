using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowNearPlaneOffsetSetting", menuName = "Game Settings/Quality/Shadow Near Plane Offset")]
    public class ShadowNearPlaneOffsetSetting : FloatSetting
    {
        public override string settingName => "Shadow Near Plane Offset";

        public override float min => 0f;

        public override float value
        {
            get => QualitySettings.shadowNearPlaneOffset;
            set => QualitySettings.shadowNearPlaneOffset = Mathf.Max(value, min);
        }
    }
}

