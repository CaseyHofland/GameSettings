using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class EnumSettingInterpreter : SettingInterpreter<EnumSetting>, ISettingDropdownInterpreter
    {
        public void UpdateView(Dropdown dropdown)
        {
            var enumLength = Enum.GetValues(gameSetting.value.GetType()).Length;
            if(dropdown.options.Count > enumLength)
            {
                dropdown.options.RemoveRange(enumLength, dropdown.options.Count - enumLength);
                dropdown.RefreshShownValue();
            }
            else if(dropdown.options.Count < enumLength)
            {
                dropdown.options.AddRange(new Dropdown.OptionData[enumLength - dropdown.options.Count]);
                dropdown.RefreshShownValue();
            }

            dropdown.SetValueWithoutNotify(gameSetting.intValue);
        }

        public void ResetView(Dropdown dropdown)
        {
            dropdown.ClearOptions();

            var options = new List<string>(Enum.GetNames(gameSetting.value.GetType()));

            dropdown.AddOptions(options);
            dropdown.RefreshShownValue();
        }

        public void ValueChanged(int value)
        {
            gameSetting.intValue = value;
            gameSetting.Save();
        }
    }
}

