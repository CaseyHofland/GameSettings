using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class IntSettingInterpreter : SettingInterpreter<IntSetting>, ISettingSliderInterpreter, ISettingInputFieldInterpreter
    {
        public void UpdateView(Slider slider)
        {
            slider.SetValueWithoutNotify(gameSetting.value);
        }

        public void ResetView(Slider slider)
        {
            slider.wholeNumbers = true;
        }

        public void ValueChanged(float value)
        {
            gameSetting.value = Mathf.RoundToInt(value);
            gameSetting.Save();
        }

        public void UpdateView(InputField inputField)
        {
            inputField.SetTextWithoutNotify(gameSetting.value.ToString());
        }

        public void ResetView(InputField inputField)
        {
            inputField.contentType = InputField.ContentType.IntegerNumber;
        }

        public void ValueChanged(string value)
        {
            gameSetting.value = int.Parse(value);
        }

        public void EndedEdit(string value)
        {
            gameSetting.value = int.Parse(value);
            gameSetting.Save();
        }
    }
}
