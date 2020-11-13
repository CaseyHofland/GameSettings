using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class IntSettingSlider : UISetting<IntSetting>, ISettingSlider
    {
        public virtual void ResetView(Slider slider)
        {
            slider.wholeNumbers = true;
        }

        public void UpdateView(Slider slider)
        {
            slider.SetValueWithoutNotify(derivedGameSetting.value);
        }

        public void ValueChanged(float value)
        {
            derivedGameSetting.value = Mathf.RoundToInt(value);
        }
    }
}

