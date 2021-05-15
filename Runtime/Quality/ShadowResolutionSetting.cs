using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowResolutionSetting", menuName = "Game Settings/Quality/Shadow Resolution")]
    public class ShadowResolutionSetting : EnumSetting<ShadowResolution>
    {
        public override string settingName => "Shadow Resolution";

        public override ShadowResolution value 
        {
            get => QualitySettings.shadowResolution;
            set => QualitySettings.shadowResolution = value;
        }
    }
}
