using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "AnisotropicFilteringSetting", menuName = "Game Settings/Quality/Anisotropic Filtering")]
    public class AnisotropicFilteringSetting : EnumSetting<AnisotropicFiltering>
    {
        public override string settingName => "Anisotropic Filtering";

        public override AnisotropicFiltering value 
        {
            get => QualitySettings.anisotropicFiltering;
            set => QualitySettings.anisotropicFiltering = value;
        }
    }
}

