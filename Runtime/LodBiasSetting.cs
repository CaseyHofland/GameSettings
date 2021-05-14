using UnityEngine;

namespace GameSettings2
{
    [CreateAssetMenu(fileName = "LodBiasSetting", menuName = "Game Settings 2/Quality/Lod Bias")]
    public sealed class LodBiasSetting : FloatSetting
    {
        private const float min = 0.01f;

        public override string settingName => "Lod Bias";

        //[System.NonSerialized] [Range(min, 20)] protected float serializedValue;

        public override float value 
        { 
            get => QualitySettings.lodBias;
            set => QualitySettings.lodBias = Mathf.Max(value, min);
        }
    }
}
