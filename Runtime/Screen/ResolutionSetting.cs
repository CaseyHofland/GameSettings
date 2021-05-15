using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ResolutionSetting", menuName = "Game Settings/Screen/Resolution")]
    public sealed class ResolutionSetting : ArraySetting<Resolution>
    {
        public override string settingName => "Resolution";

        protected override Resolution[] array => Screen.resolutions;
        public override Resolution current
        {
            get => Screen.currentResolution;
            protected set => Screen.SetResolution(value.width, value.height, Screen.fullScreenMode, value.refreshRate);
        }
    }
}

