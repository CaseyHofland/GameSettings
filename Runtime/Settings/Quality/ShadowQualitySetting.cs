using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowQualitySetting", menuName = "Game Settings/Quality/Shadow Quality")]
    public class ShadowQualitySetting : EnumSetting<ShadowQuality>
    {
        public override string settingName => "Shadow Quality";

        public override ShadowQuality value
        {
            get => QualitySettings.shadows;
            set => QualitySettings.shadows = value;
        }
    }
}

