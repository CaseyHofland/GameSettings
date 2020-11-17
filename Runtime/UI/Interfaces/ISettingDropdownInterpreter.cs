using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingDropdownInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(Dropdown dropdown);
        void ResetUI(Dropdown dropdown);
        void ValueChanged(int value);
    }

    public interface ISettingDropdownInterpreter<T> : ISettingDropdownInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}
