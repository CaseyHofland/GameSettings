using System;
using System.Collections.Generic;
using TMPro;

namespace GameSettings.UI.TMPro
{
    public class ArraySettingTMP_Interpreter : ArraySettingInterpreter, ISettingTMP_DropdownInterpreter
    {
        public void ResetUI(TMP_Dropdown tmp_Dropdown)
        {
            tmp_Dropdown.ClearOptions();

            var options = new List<string>(Array.ConvertAll(gameSetting.objectArray, value => value.ToString()));
            if(descending)
            {
                options.Reverse();
            }

            tmp_Dropdown.AddOptions(options);
            tmp_Dropdown.RefreshShownValue();
        }

        public void UpdateView(TMP_Dropdown tmp_Dropdown)
        {
            if(tmp_Dropdown.options.Count > arrayLength)
            {
                tmp_Dropdown.options.RemoveRange(arrayLength, tmp_Dropdown.options.Count - arrayLength);
                tmp_Dropdown.RefreshShownValue();
            }
            else if(tmp_Dropdown.options.Count < arrayLength)
            {
                tmp_Dropdown.options.AddRange(new TMP_Dropdown.OptionData[arrayLength - tmp_Dropdown.options.Count]);
                tmp_Dropdown.RefreshShownValue();
            }

            tmp_Dropdown.SetValueWithoutNotify(alteredValue);
        }
    }
}

