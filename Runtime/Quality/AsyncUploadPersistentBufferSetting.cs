using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "AsyncUploadPersistentBufferSetting", menuName = "Game Settings/Quality/Async Upload Persistent Buffer")]
    public class AsyncUploadPersistentBufferSetting : BoolSetting
    {
        public override string settingName => "Async Upload Persistent Buffer";

        public override bool value 
        {
            get => QualitySettings.asyncUploadPersistentBuffer;
            set => QualitySettings.asyncUploadPersistentBuffer = value;
        }
    }
}
