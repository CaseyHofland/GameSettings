using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingSlider : ISettingSelectable
    {
        void UpdateView(Slider slider);
        void ResetView(Slider slider);
        void ValueChanged(float value);
    }
}

