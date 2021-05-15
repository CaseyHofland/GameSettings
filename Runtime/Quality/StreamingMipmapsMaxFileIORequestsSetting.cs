using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "StreamingMipmapsMaxFileIORequestsSetting", menuName = "Game Settings/Quality/Streaming Mipmaps Max File IO Requests")]
    public class StreamingMipmapsMaxFileIORequestsSetting : IntSetting
    {
        public const int min = 1;

        public override string settingName => "Streaming Mipmaps Max File IO Requests";

        public override int value
        {
            get => QualitySettings.streamingMipmapsMaxFileIORequests;
            set => QualitySettings.streamingMipmapsMaxFileIORequests = Mathf.Max(value, min);
        }
    }
}
