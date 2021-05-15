using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "SkinWeightsSetting", menuName = "Game Settings/Quality/Skin Weights")]
    public class SkinWeightsSetting : EnumSetting<SkinWeights>
    {
        public override string settingName => "Skin Weights";

        public override SkinWeights value
        {
            get => QualitySettings.skinWeights;
            set => QualitySettings.skinWeights = value;
        }
    }
}

