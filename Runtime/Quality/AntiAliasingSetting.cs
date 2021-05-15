using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "AntiAliasingSetting", menuName = "Game Settings/Quality/Anti Aliasing")]
    public class AntiAliasingSetting : EnumSetting<AntiAliasingSetting.AAFilteringOption>
    {
        public override string settingName => "Anti Aliasing";

        public override AAFilteringOption value 
        {
            get
            {
                switch(QualitySettings.antiAliasing)
                {
                    case 8:
                        return AAFilteringOption._8xMultiSampling;
                    case 4:
                        return AAFilteringOption._4xMultiSampling;
                    case 2:
                        return AAFilteringOption._2xMultiSampling;
                    default:
                        return AAFilteringOption.Disabled;
                }
            }
            set
            {
                switch(value)
                {
                    case AAFilteringOption._8xMultiSampling:
                        QualitySettings.antiAliasing = 8;
                        break;
                    case AAFilteringOption._4xMultiSampling:
                        QualitySettings.antiAliasing = 4;
                        break;
                    case AAFilteringOption._2xMultiSampling:
                        QualitySettings.antiAliasing = 2;
                        break;
                    case AAFilteringOption.Disabled:
                        QualitySettings.antiAliasing = 0;
                        break;
                }
            }
        }

        public enum AAFilteringOption
        {
            Disabled,
            _2xMultiSampling,
            _4xMultiSampling,
            _8xMultiSampling,
        }
    }
}
