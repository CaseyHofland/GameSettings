using TMPro;

namespace GameSettings.UI.TMPro
{
    public interface ISettingTMP_InputFieldInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(TMP_InputField tmp_InputField);
        void ResetView(TMP_InputField tmp_InputField);
        void ValueChanged(string value);
        void EndedEdit(string value);
        void Selected(string value);
        void Deselected(string value);
    }

    public interface ISettingTMP_InputFieldInterpreter<T> : ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}
