using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowProjectionSetting", menuName = "Game Settings/Quality/Shadow Projection")]
    public class ShadowProjectionSetting : EnumSetting<ShadowProjection>
    {
        public override string settingName => "Shadow Projection";

        public override ShadowProjection value 
        {
            get => QualitySettings.shadowProjection;
            set => QualitySettings.shadowProjection = value;
        }
    }
}
