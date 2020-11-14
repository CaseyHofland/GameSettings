using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "Full Screen", menuName = "Game Settings/Full Screen")]
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

