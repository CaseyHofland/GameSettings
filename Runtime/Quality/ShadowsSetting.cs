using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowsSetting", menuName = "Game Settings/Quality/Shadows")]
    public class ShadowsSetting : EnumSetting<ShadowQuality>
    {
        public override string settingName => "Shadows";

        public override ShadowQuality value
        {
            get => QualitySettings.shadows;
            set => QualitySettings.shadows = value;
        }
    }
}

