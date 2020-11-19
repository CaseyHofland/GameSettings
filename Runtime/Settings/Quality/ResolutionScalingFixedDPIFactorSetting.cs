using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ResolutionScalingFixedDPIFactorSetting", menuName = "Game Settings/Quality/Resolution Scaling Fixed DPI Factor")]
    public class ResolutionScalingFixedDPIFactorSetting : FloatSetting
    {
        public override string settingName => "Resolution Scaling Fixed DPI Factor";

        public override float min => 0.01f;

        public override float value
        {
            get => QualitySettings.resolutionScalingFixedDPIFactor;
            set => QualitySettings.resolutionScalingFixedDPIFactor = Mathf.Max(value, min);
        }
    }
}

