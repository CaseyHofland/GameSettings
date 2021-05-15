using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowmaskModeSetting", menuName = "Game Settings/Quality/Shadowmask Mode")]
    public class ShadowmaskModeSetting : EnumSetting<ShadowmaskMode>
    {
        public override string settingName => "Shadowmask Mode";

        public override ShadowmaskMode value 
        {
            get => QualitySettings.shadowmaskMode;
            set => QualitySettings.shadowmaskMode = value;
        }
    }
}
