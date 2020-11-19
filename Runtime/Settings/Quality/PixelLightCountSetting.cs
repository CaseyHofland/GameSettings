using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "PixelLightCountSetting", menuName = "Game Settings/Quality/Pixel Light Count")]
    public class PixelLightCountSetting : IntSetting
    {
        public override string settingName => "Pixel Light Count";

        public override int min => 0;

        public override int value
        {
            get => QualitySettings.pixelLightCount;
            set => QualitySettings.pixelLightCount = Mathf.Max(value, min);
        }
    }
}
