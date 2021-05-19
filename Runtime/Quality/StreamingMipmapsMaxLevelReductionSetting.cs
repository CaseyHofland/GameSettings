using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "StreamingMipmapsMaxLevelReductionSetting", menuName = "Game Settings/Quality/Streaming Mipmaps Max Level Reduction")]
    public class StreamingMipmapsMaxLevelReductionSetting : IntSetting
    {
        public const int min = 1;
        public const int max = 7;

        public override string settingName => "Streaming Mipmaps Max Level Reduction";

#if UNITY_EDITOR
        [NonSerialized] [Range(min, max)] private int serializedValue;
#endif

        public override int value
        {
            get => QualitySettings.streamingMipmapsMaxLevelReduction;
            set => QualitySettings.streamingMipmapsMaxLevelReduction = Mathf.Clamp(value, min, max);
        }
    }
}
