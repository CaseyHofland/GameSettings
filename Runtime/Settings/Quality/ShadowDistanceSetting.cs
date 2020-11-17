using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "ShadowDistanceSetting", menuName = "Game Settings/Quality/Shadow Distance")]
    public class ShadowDistanceSetting : FloatSetting
    {
        public override string settingName => "Shadow Distance";

        public override float value
        {
            get => QualitySettings.shadowDistance;
            set => QualitySettings.shadowDistance = value;
        }
    }
}

