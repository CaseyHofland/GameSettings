using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "AsyncUploadTimeSliceSetting", menuName = "Game Settings/Quality/Async Upload Time Slice")]
    public class AsyncUploadTimeSliceSetting : IntSetting
    {
        public const int min = 1;
        public const int max = 33;

        public override string settingName => "Async Upload Time Slice";

#if UNITY_EDITOR
        [NonSerialized] [Range(min, max)] private int serializedValue;
#endif

        public override int value
        {
            get => QualitySettings.asyncUploadTimeSlice;
            set => QualitySettings.asyncUploadTimeSlice = Mathf.Clamp(value, min, max);
        }
    }
}
