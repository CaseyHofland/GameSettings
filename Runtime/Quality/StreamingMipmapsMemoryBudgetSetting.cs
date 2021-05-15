using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "StreamingMipmapsMemoryBudgetSetting", menuName = "Game Settings/Quality/Streaming Mipmaps Memory Budget")]
    public class StreamingMipmapsMemoryBudgetSetting : FloatSetting
    {
        public override string settingName => "Streaming Mipmaps Memory Budget";

        public override float value
        {
            get => QualitySettings.streamingMipmapsMemoryBudget;
            set => QualitySettings.streamingMipmapsMemoryBudget = value;
        }
    }
}

