using TMPro;

namespace GameSettings.UI.TMPro
{
    public interface ISettingTMP_DropdownInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(TMP_Dropdown tmp_Dropdown);
        void ResetView(TMP_Dropdown tmp_Dropdown);
        void ValueChanged(int value);
    }

    public interface ISettingTMP_DropdownInterpreter<T> : ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}
