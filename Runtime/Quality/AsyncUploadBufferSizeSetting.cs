using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "AsyncUploadBufferSizeSetting", menuName = "Game Settings/Quality/Async Upload Buffer Size")]
    public class AsyncUploadBufferSizeSetting : IntSetting
    {
        public const int min = 2;
        public const int max = 512;

        public override string settingName => "Async Upload Buffer Size";

        public override int value 
        { 
            get => QualitySettings.asyncUploadBufferSize;
            set => QualitySettings.asyncUploadBufferSize = Mathf.Clamp(value, min, max);
        }
    }
}
