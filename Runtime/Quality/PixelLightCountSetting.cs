using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "PixelLightCountSetting", menuName = "Game Settings/Quality/Pixel Light Count")]
    public class PixelLightCountSetting : IntSetting
    {
        public const int min = 0;

        public override string settingName => "Pixel Light Count";

        public override int value
        {
            get => QualitySettings.pixelLightCount;
            set => QualitySettings.pixelLightCount = Mathf.Max(value, min);
        }
    }
}
