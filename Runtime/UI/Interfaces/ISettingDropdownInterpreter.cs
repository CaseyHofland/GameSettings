using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingDropdownInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(Dropdown dropdown);
        void ResetView(Dropdown dropdown);
        void ValueChanged(int value);
    }

    public interface ISettingDropdownInterpreter<T> : ISettingDropdownInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}
