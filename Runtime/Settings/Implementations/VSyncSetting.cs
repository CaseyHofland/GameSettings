using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "VSyncSetting", menuName = "Game Settings/VSync")]
    public class VSyncSetting : EnumSetting
    {
        public override string settingName => "VSync";

        public override Enum value
        {
            get => (VBlank)QualitySettings.vSyncCount;
            set => QualitySettings.vSyncCount = (int)(VBlank)value;
        }

        public enum VBlank
        {
            DontSync,
            EveryVBlank,
            EverySecondVBlank,
        }
    }
}
