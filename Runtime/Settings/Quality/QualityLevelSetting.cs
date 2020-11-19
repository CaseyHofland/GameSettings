using System;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "QualityLevelSetting", menuName = "Game Settings/Quality/Quality Level")]
    public class QualityLevelSetting : ArraySetting<string>
    {
        public override string settingName => "Quality Level";

        public bool applyExpensiveChanges = false;

        protected override string[] array => QualitySettings.names;
        public override string current 
        { 
            get => array[QualitySettings.GetQualityLevel()];
            protected set => QualitySettings.SetQualityLevel(Array.IndexOf(array, value), applyExpensiveChanges);
        }
    }
}

