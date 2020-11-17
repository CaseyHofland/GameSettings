using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "AntiAliasingSetting", menuName = "Game Settings/Quality/Anti Aliasing")]
    public class AntiAliasingSetting : EnumSetting<AntiAliasingSetting.AAFilteringOption>
    {
        public override string settingName => "Anti Aliasing";

        public override AAFilteringOption enumValue 
        {
            get => (AAFilteringOption)QualitySettings.antiAliasing;
            set => QualitySettings.antiAliasing = (int)value;
        }

        public enum AAFilteringOption
        {
            Disabled = 0,
            _2xMultiSampling = 2,
            _4xMultiSampling = 4,
            _8xMultiSampling = 8,
        }
    }
}
