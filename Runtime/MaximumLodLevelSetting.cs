using System;
using UnityEngine;

namespace GameSettings2
{
    [CreateAssetMenu(fileName = "MaximumLODLevelSetting", menuName = "Game Settings 2/Quality/Maximum LOD Level")]
    public class MaximumLodLevelSetting : IntSetting
    {
        public const int min = 0;
        public const int max = 7;

        public override string settingName => "Maximum LOD Level";

        [NonSerialized] [Range(min, max)] private int serializedValue;

        public override int value
        {
            get => QualitySettings.maximumLODLevel;
            set => QualitySettings.maximumLODLevel = Mathf.Clamp(value, min, max);
        }
    }
}
