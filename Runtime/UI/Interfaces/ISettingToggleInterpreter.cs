using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingToggleInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(Toggle toggle);
        void ResetUI(Toggle toggle);
        void ValueChanged(bool value);
    }

    public interface ISettingToggleInterpreter<T> : ISettingToggleInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}
