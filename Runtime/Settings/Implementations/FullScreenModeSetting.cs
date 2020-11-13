using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "FullScreenSetting", menuName = "Settings/Full Screen")]
    public class FullScreenModeSetting : IntSetting
    {
        public override string settingName => "Full Screen";

        public virtual new FullScreenMode value
        {
            get => Screen.fullScreenMode;
            set => base.value = (int)(Screen.fullScreenMode = value);
        }
    }
}