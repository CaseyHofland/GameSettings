using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class EnumSettingInterpreter : SettingInterpreter<EnumSetting>, ISettingDropdownInterpreter, ISettingSliderInterpreter
    {
        [Tooltip("Show the values in descending order.")] public bool descending = false;

        protected int enumLength => Enum.GetValues(gameSetting.value.GetType()).Length;
        protected virtual int alteredValue
        {
            get => descending ? enumLength - 1 - gameSetting.intValue : gameSetting.intValue;
            set => gameSetting.intValue = descending ? enumLength - 1 - value : value;
        }

        public virtual void UpdateView(Dropdown dropdown)
        {
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

            dropdown.SetValueWithoutNotify(alteredValue);
        }

        public virtual void ResetUI(Dropdown dropdown)
        {
            dropdown.ClearOptions();

            var options = new List<string>(Enum.GetNames(gameSetting.value.GetType()));
            if(descending)
            {
                options.Reverse();
            }

            dropdown.AddOptions(options);
            dropdown.RefreshShownValue();
        }

        public virtual void ValueChanged(int value)
        {
            alteredValue = value;
            gameSetting.Save();
        }

        public virtual void UpdateView(Slider slider)
        {
            slider.SetValueWithoutNotify(alteredValue);
        }

        public virtual void ResetUI(Slider slider)
        {
            slider.wholeNumbers = true;
            slider.minValue = 1;
            slider.maxValue = enumLength;
        }

        public virtual void ValueChanged(float value)
        {
            alteredValue = Mathf.RoundToInt(value) - 1;
            gameSetting.Save();
        }
    }
}

