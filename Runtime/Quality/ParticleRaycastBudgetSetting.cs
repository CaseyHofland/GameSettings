using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ParticleRaycastBudgetSetting", menuName = "Game Settings/Quality/Particle Raycast Budget")]
    public class ParticleRaycastBudgetSetting : IntSetting
    {
        public override string settingName => "Particle Raycast Budget";

        public override int value
        {
            get => QualitySettings.particleRaycastBudget;
            set => QualitySettings.particleRaycastBudget = value;
        }
    }
}
