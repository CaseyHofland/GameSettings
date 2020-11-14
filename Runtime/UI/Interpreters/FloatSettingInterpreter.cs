using UnityEngine.UI;

namespace GameSettings.UI
{
    public class FloatSettingInterpreter : SettingInterpreter<FloatSetting>, ISettingSliderInterpreter, ISettingScrollbarInterpreter, ISettingInputFieldInterpreter
    {
        public void UpdateView(Slider slider)
        {
            slider.SetValueWithoutNotify(gameSetting.value);
        }

        public void ResetView(Slider slider)
        {
        }

        public void ValueChanged(float value)
        {
            gameSetting.value = value;
            gameSetting.Save();
        }

        public void UpdateView(Scrollbar scrollbar)
        {
            scrollbar.SetValueWithoutNotify(gameSetting.value);
        }

        public void ResetView(Scrollbar scrollbar)
        {
        }

        public void UpdateView(InputField inputField)
        {
            inputField.SetTextWithoutNotify(gameSetting.value.ToString());
        }

        public void ResetView(InputField inputField)
        {
            inputField.contentType = InputField.ContentType.DecimalNumber;
        }

        public void ValueChanged(string value)
        {
            gameSetting.value = float.Parse(value);
        }

        public void EndedEdit(string value)
        {
            gameSetting.value = float.Parse(value);
            gameSetting.Save();
        }
    }
}
