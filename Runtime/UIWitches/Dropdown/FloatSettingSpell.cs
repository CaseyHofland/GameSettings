using System;
using System.Collections.Generic;
using UIWitches;

namespace GameSettings.UIWitches.Dropdown
{
    [Serializable]
    public class FloatSettingSpell : IDropdownSpell
    {
        public float[] values;

        public GameSetting<float> floatSetting;

        public int GetValue()
        {
            return floatSetting ? Array.IndexOf(values, floatSetting.value) : default;
        }

        public void ResetUI(UnityEngine.UI.Dropdown dropdown)
        {
            dropdown.ClearOptions();

            var options = new List<string>();
            foreach (var value in values)
            {
                options.Add(value.ToString());
            }

            dropdown.AddOptions(options);
        }

        public void ValueChanged(int dropdownIndex)
        {
            floatSetting.value = values[dropdownIndex];
            floatSetting.Save();
        }
    }
}
