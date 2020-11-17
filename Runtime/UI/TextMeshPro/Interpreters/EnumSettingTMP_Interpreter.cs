using System;
using System.Collections.Generic;
using TMPro;

namespace GameSettings.UI.TMPro
{
    public class EnumSettingTMP_Interpreter : EnumSettingInterpreter, ISettingTMP_DropdownInterpreter
    {
        public void UpdateView(TMP_Dropdown tmp_Dropdown)
        {
            if(tmp_Dropdown.options.Count > enumLength)
            {
                tmp_Dropdown.options.RemoveRange(enumLength, tmp_Dropdown.options.Count - enumLength);
                tmp_Dropdown.RefreshShownValue();
            }
            else if(tmp_Dropdown.options.Count < enumLength)
            {
                tmp_Dropdown.options.AddRange(new TMP_Dropdown.OptionData[enumLength - tmp_Dropdown.options.Count]);
                tmp_Dropdown.RefreshShownValue();
            }

            tmp_Dropdown.SetValueWithoutNotify(alteredValue);
        }

        public void ResetUI(TMP_Dropdown tmp_Dropdown)
        {
            tmp_Dropdown.ClearOptions();

            var options = new List<string>(Enum.GetNames(gameSetting.value.GetType()));

            tmp_Dropdown.AddOptions(options);
            tmp_Dropdown.RefreshShownValue();
        }
    }
}

