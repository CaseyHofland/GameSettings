using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class IntSettingInterpreter : SettingInterpreter<IntSetting>, ISettingSliderInterpreter
    {
        [HideInInspector] public int ratio = 1;
        [HideInInspector] public int adjustment = 0;

        protected int Interpret(int value) => value / ratio - adjustment;
        protected int ReverseInterpret(int value) => (value + adjustment) * ratio;

        protected virtual int alteredValue
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
            slider.wholeNumbers = true;
        }

        public virtual void ValueChanged(float value)
        {
            alteredValue = Mathf.RoundToInt(value);
            gameSetting.Save();
        }
    }
}
