using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "FullScreenModeSetting", menuName = "Game Settings/Screen/Full Screen Mode")]
    public class FullScreenModeSetting : EnumSetting<FullScreenMode>
    {
        public override string settingName => "Full Screen Mode";

        public override FullScreenMode enumValue
        { 
            get => Screen.fullScreenMode;
            set => Screen.fullScreenMode = value;
        }
    }
}