using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "AsyncUploadTimeSliceSetting", menuName = "Game Settings/Quality/Async Upload Time Slice")]
    public class AsyncUploadTimeSliceSetting : IntSetting
    {
        public override string settingName => "Async Upload Time Slice";

        public override int min => 1;
        public override int max => 33;

        public override int value
        {
            get => QualitySettings.asyncUploadTimeSlice;
            set => QualitySettings.asyncUploadTimeSlice = Mathf.Clamp(value, min, max);
        }
    }
}
