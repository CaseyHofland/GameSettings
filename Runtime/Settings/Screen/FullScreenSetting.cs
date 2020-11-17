using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "FullScreenSetting", menuName = "Game Settings/Screen/Full Screen")]
    public class FullScreenSetting : BoolSetting
    {
        public override string settingName => "Full Screen";

        public override bool value 
        {
            get => Screen.fullScreen;
            set => Screen.fullScreen = value;
        }
    }
}

