using UnityEngine.UI;

namespace GameSettings.UI
{
    public class AudioSettingSlider : UISetting<AudioSetting>, ISettingSlider
    {
        public virtual void ResetView(Slider slider)
        {
        }

        public virtual void UpdateView(Slider slider)
        {
            slider.SetValueWithoutNotify(derivedGameSetting.value);
        }

        public virtual void ValueChanged(float value)
        {
            derivedGameSetting.value = value;
        }
    }
}
