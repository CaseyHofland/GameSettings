using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "VSyncSetting", menuName = "Game Settings/Quality/VSync")]
    public class VSyncSetting : EnumSetting<VSyncSetting.VBlank>
    {
        public override string settingName => "VSync";

        public override VBlank value
        {
            get => (VBlank)QualitySettings.vSyncCount;
            set => QualitySettings.vSyncCount = (int)value;
        }

        public enum VBlank
        {
            DontSync,
            EveryVBlank,
            EverySecondVBlank,
        }
    }
}
