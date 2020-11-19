using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowCascade2SplitSetting", menuName = "Game Settings/Quality/Shadow Cascade 2 Split")]
    public class ShadowCascade2SplitSetting : FloatSetting
    {
        public override string settingName => "Shadow Cascade 2 Split";

        public override float min => 0f;
        public override float max => 1f;

        public override float value
        {
            get => QualitySettings.shadowCascade2Split;
            set => QualitySettings.shadowCascade2Split = Mathf.Clamp(value, min, max);
        }
    }
}

