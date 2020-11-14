using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "FullScreenModeSetting", menuName = "Game Settings/Full Screen Mode")]
    public class FullScreenModeSetting : EnumSetting
    {
        public override string settingName => "Full Screen Mode";

        public override Enum value
        {
            get => Screen.fullScreenMode;
            set => Screen.fullScreenMode = (FullScreenMode)value;
        }
    }
}