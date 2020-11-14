using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowQualitySetting", menuName = "Game Settings/Shadow Quality")]
    public class ShadowQualitySetting : EnumSetting
    {
        public override string settingName => "Shadow Quality";

        public override Enum value 
        {
            get => QualitySettings.shadows;
            set => QualitySettings.shadows = (ShadowQuality)value;
        }
    }
}

