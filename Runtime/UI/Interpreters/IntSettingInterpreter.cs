using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class IntSettingInterpreter : SettingInterpreter<IntSetting>, ISettingSliderInterpreter, ISettingInputFieldInterpreter
    {
        [Tooltip("Alter the shown value.")] public int alterValue = 0;
        [Tooltip("Multiply the shown value. Applied after Alter Value.")] public int muliplyValue = 1;

        protected virtual int alteredValue
        {
            get => (gameSetting.value + alterValue) * muliplyValue;
            set => gameSetting.value = value / muliplyValue - alterValue;
        }

        public virtual void UpdateView(Slider slider)
        {
            slider.SetValueWithoutNotify(alteredValue);
        }

        public virtual void ResetView(Slider slider)
        {
            slider.wholeNumbers = true;
        }

        public virtual void ValueChanged(float value)
        {
            alteredValue = Mathf.RoundToInt(value);
            gameSetting.Save();
        }

        public virtual void UpdateView(InputField inputField)
        {
            inputField.SetTextWithoutNotify(alteredValue.ToString());
        }

        public virtual void ResetView(InputField inputField)
        {
            inputField.contentType = InputField.ContentType.IntegerNumber;
        }

        public virtual void ValueChanged(string value)
        {
            alteredValue = int.Parse(value);
        }

        public virtual void EndedEdit(string value)
        {
            alteredValue = int.Parse(value);
            gameSetting.Save();
        }
    }
}
