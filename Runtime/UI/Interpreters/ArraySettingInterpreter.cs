using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class ArraySettingInterpreter : SettingInterpreter<ArraySetting>, ISettingDropdownInterpreter
    {
        [Tooltip("Show the values in descending order.")] public bool descending = false;

        protected int arrayLength => gameSetting.Length;
        protected virtual int alteredValue
        {
            get => descending ? arrayLength - 1 - gameSetting.value : gameSetting.value;
            set => gameSetting.value = descending ? arrayLength - 1 - value : value;
        }

        public void UpdateView(Dropdown dropdown)
        {
            if(dropdown.options.Count > arrayLength)
            {
                dropdown.options.RemoveRange(arrayLength, dropdown.options.Count - arrayLength);
                dropdown.RefreshShownValue();
            }
            else if(dropdown.options.Count < arrayLength)
            {
                dropdown.options.AddRange(new Dropdown.OptionData[arrayLength - dropdown.options.Count]);
                dropdown.RefreshShownValue();
            }

            dropdown.SetValueWithoutNotify(alteredValue);
        }

        public void ResetUI(Dropdown dropdown)
        {
            dropdown.ClearOptions();


            var options = new List<string>();
            for(int i = 0; i < arrayLength; i++)
            {
                options.Add(gameSetting[i].ToString());
            }

            if(descending)
            {
                options.Reverse();
            }

            dropdown.AddOptions(options);
            dropdown.RefreshShownValue();
        }

        public void ValueChanged(int value)
        {
            alteredValue = value;
            gameSetting.Save();
        }
    }
}

