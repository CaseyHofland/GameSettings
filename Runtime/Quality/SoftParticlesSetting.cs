using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "SoftParticlesSetting", menuName = "Game Settings/Quality/Soft Particles")]
    public class SoftParticlesSetting : BoolSetting
    {
        public override string settingName => "Soft Particles";

        public override bool value 
        {
            get => QualitySettings.softParticles;
            set => QualitySettings.softParticles = value;
        }
    }
}
