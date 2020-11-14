using UnityEngine.UI;

namespace GameSettings.UI
{
    public class FloatUISetting : UISetting<FloatSetting>, ISettingSlider<FloatSetting>
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
        }
    }
}

