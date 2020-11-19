using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "StreamingMipmapsMaxLevelReductionSetting", menuName = "Game Settings/Quality/Streaming Mipmaps Max Level Reduction")]
    public class StreamingMipmapsMaxLevelReductionSetting : IntSetting
    {
        public override string settingName => "Streaming Mipmaps Max Level Reduction";

        public override int min => 1;
        public override int max => 7;

        public override int value
        {
            get => QualitySettings.streamingMipmapsMaxLevelReduction;
            set => QualitySettings.streamingMipmapsMaxLevelReduction = Mathf.Clamp(value, min, max);
        }
    }
}
