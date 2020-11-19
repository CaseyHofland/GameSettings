using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "StreamingMipmapsAddAllCamerasSetting", menuName = "Game Settings/Quality/Streaming Mipmaps Add All Cameras")]
    public class StreamingMipmapsAddAllCamerasSetting : BoolSetting
    {
        public override string settingName => "Streaming Mipmaps Add All Cameras";

        public override bool value 
        {
            get => QualitySettings.streamingMipmapsAddAllCameras;
            set => QualitySettings.streamingMipmapsAddAllCameras = value;
        }
    }
}
