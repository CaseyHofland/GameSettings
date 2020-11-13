using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "VSyncSetting", menuName = "Settings/VSync")]
    public class VSyncSetting : IntSetting
    {
        public override string settingName => "VSync";

        public virtual new VBlank value 
        { 
            get => (VBlank)QualitySettings.vSyncCount; 
            set => base.value = QualitySettings.vSyncCount = (int)value; 
        }

        public enum VBlank
        {
            DontSync,
            EveryVBlank,
            EverySecondVBlank,
            EveryThirdVBlank,
            EveryFourthVBlank,
        }
    }
}
