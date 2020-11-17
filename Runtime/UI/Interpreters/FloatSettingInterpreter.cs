using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class FloatSettingInterpreter : SettingInterpreter<FloatSetting>, ISettingSliderInterpreter, ISettingScrollbarInterpreter
    {
        [HideInInspector] public float ratio = 1f;
        [HideInInspector] public float adjustment = 0f;

        protected float Interpret(float value) => value / ratio - adjustment;
        protected float ReverseInterpret(float value) => (value + adjustment) * ratio;

        protected virtual float alteredValue
        {
            get => ReverseInterpret(gameSetting.value);
            set => gameSetting.value = Interpret(value);
        }

        public virtual void UpdateView(Slider slider)
        {
            slider.SetValueWithoutNotify(alteredValue);
        }

        public virtual void ResetUI(Slider slider)
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

        public virtual void ResetUI(Scrollbar scrollbar)
        {
        }
    }
}
