using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "LodBiasSetting", menuName = "Game Settings/Quality/Lod Bias")]
    public sealed class LodBiasSetting : FloatSetting
    {
        private const float min = 0.01f;

        public override string settingName => "Lod Bias";

        public override float value 
        { 
            get => QualitySettings.lodBias;
            set => QualitySettings.lodBias = Mathf.Max(value, min);
        }
    }
}
