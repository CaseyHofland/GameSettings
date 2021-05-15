using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "SoftVegetationSetting", menuName = "Game Settings/Quality/Soft Vegetation")]
    public class SoftVegetationSetting : BoolSetting
    {
        public override string settingName => "Soft Vegetation";

        public override bool value 
        {
            get => QualitySettings.softVegetation;
            set => QualitySettings.softVegetation = value;
        }
    }
}
