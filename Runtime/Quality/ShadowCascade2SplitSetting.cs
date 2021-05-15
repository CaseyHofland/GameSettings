using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowCascade2SplitSetting", menuName = "Game Settings/Quality/Shadow Cascade 2 Split")]
    public class ShadowCascade2SplitSetting : FloatSetting
    {
        public const float min = 0f;
        public const float max = 1f;

        public override string settingName => "Shadow Cascade 2 Split";

        [NonSerialized] [Range(min, max)] private float serializedValue;

        public override float value
        {
            get => QualitySettings.shadowCascade2Split;
            set => QualitySettings.shadowCascade2Split = Mathf.Clamp(value, min, max);
        }
    }
}

