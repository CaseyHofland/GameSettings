using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowDistanceSetting", menuName = "Game Settings/Quality/Shadow Distance")]
    public class ShadowDistanceSetting : FloatSetting
    {
        public const float min = 0f;
        
        public override string settingName => "Shadow Distance";

        public override float value
        {
            get => QualitySettings.shadowDistance;
            set => QualitySettings.shadowDistance = Mathf.Max(value, min);
        }
    }
}

