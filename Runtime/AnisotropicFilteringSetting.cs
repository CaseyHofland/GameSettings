using UnityEngine;

namespace GameSettings2
{
    [CreateAssetMenu(fileName = "AnisotropicFilteringSetting", menuName = "Game Settings 2/Quality/Anisotropic Filtering")]
    public sealed class AnisotropicFilteringSetting : EnumSetting<AnisotropicFiltering>
    {
        public override string settingName => "Anisotropic Filtering";

        public override AnisotropicFiltering value 
        {
            get => QualitySettings.anisotropicFiltering;
            set => QualitySettings.anisotropicFiltering = value;
        }
    }
}
