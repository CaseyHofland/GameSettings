using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "MasterTextureLimitSetting", menuName = "Game Settings/Quality/Master Texture Limit")]
    public class MasterTextureLimitSetting : IntSetting
    {
        public override string settingName => "Master Texture Limit";

        public override int min => 0;

        public override int value
        {
            get => QualitySettings.masterTextureLimit;
            set => QualitySettings.masterTextureLimit = Mathf.Max(value, min);
        }
    }
}
