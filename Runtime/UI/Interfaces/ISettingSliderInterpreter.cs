using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingSliderInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(Slider slider);
        void ResetUI(Slider slider);
        void ValueChanged(float value);
    }

    public interface ISettingSliderInterpreter<T> : ISettingSliderInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}

