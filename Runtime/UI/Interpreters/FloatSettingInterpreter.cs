using UnityEngine.UI;

namespace GameSettings.UI
{
    public class FloatSettingInterpreter : SettingInterpreter<FloatSetting>, ISettingSliderInterpreter, ISettingScrollbarInterpreter, ISettingInputFieldInterpreter
    {
        //[Tooltip("Alter the shown value.")] public float alterValue = 0f;
        //[Tooltip("Multiply the shown value. Aplied after alterValue.")] public float multiplyValue = 1f;

        public float ratio = 1f;
        public float adjustment = 0f;

        protected float Interpret(float value) => value * ratio + adjustment;
        protected float ReverseInterpret(float value) => (value - adjustment) / ratio;

        protected virtual float alteredValue
        {
            get => ReverseInterpret(gameSetting.value);
            set => gameSetting.value = Interpret(value);
        }

        public virtual void UpdateView(Slider slider)
        {
            slider.SetValueWithoutNotify(alteredValue);
        }

        public virtual void ResetView(Slider slider)
        {
        }

        public virtual void ValueChanged(float value)
        {
            alteredValue = value;
            gameSetting.Save();
        }

        public virtual void UpdateView(Scrollbar scrollbar)
        {
            scrollbar.SetValueWithoutNotify(alteredValue);
        }

        public virtual void ResetView(Scrollbar scrollbar)
        {
        }

        public virtual void UpdateView(InputField inputField)
        {
            inputField.SetTextWithoutNotify(alteredValue.ToString());
        }

        public virtual void ResetView(InputField inputField)
        {
            inputField.contentType = InputField.ContentType.DecimalNumber;
        }

        public virtual void ValueChanged(string value)
        {
            alteredValue = float.Parse(value);
        }

        public virtual void EndedEdit(string value)
        {
            alteredValue = float.Parse(value);
            gameSetting.Save();
        }
    }
}
