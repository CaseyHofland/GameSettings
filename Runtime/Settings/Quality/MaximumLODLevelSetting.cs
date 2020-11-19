using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "MaximumLODLevelSetting", menuName = "Game Settings/Quality/Maximum LOD Level")]
    public class MaximumLODLevelSetting : IntSetting
    {
        public override string settingName => "Maximum LOD Level";

        public override int min => 0;
        public override int max => 7;

        public override int value
        {
            get => QualitySettings.maximumLODLevel;
            set => QualitySettings.maximumLODLevel = Mathf.Clamp(value, min, max);
        }
    }
}
