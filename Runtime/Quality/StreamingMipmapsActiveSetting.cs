using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "StreamingMipmapsActiveSetting", menuName = "Game Settings/Quality/Streaming Mipmaps Active")]
    public class StreamingMipmapsActiveSetting : BoolSetting
    {
        public override string settingName => "Streaming Mipmaps Active";

        public override bool value 
        {
            get => QualitySettings.streamingMipmapsActive;
            set => QualitySettings.streamingMipmapsActive = value;
        }
    }
}
