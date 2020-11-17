using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ResolutionSetting", menuName = "Game Settings/Screen/Resolution")]
    public class ResolutionSetting : ArraySetting<Resolution>
    {
        public override string settingName => "Resolution";

        public override Resolution[] array => Screen.resolutions;
        public override Resolution arrayValue 
        {
            get => Screen.currentResolution;
            protected set => Screen.SetResolution(value.width, value.height, Screen.fullScreenMode, value.refreshRate);
        }
    }
}

