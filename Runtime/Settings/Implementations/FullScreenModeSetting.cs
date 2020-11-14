using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "FullScreenSetting", menuName = "Settings/Full Screen")]
    public class FullScreenModeSetting : EnumSetting<FullScreenMode>
    {
        public override string settingName => "Full Screen";

        public override FullScreenMode value 
        { 
            get => Screen.fullScreenMode;
            set => Screen.fullScreenMode = value;
        }
    }
}