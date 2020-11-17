using TMPro;

namespace GameSettings.UI.TMPro
{
    public interface ISettingTMP_InputFieldInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(TMP_InputField tmp_InputField);
        void ResetUI(TMP_InputField tmp_InputField);
        char ValidateInput(string text, int charIndex, char addedChar);
        void ValueChanged(string value);
        void EndedEdit(string value);
    }

    public interface ISettingTMP_InputFieldInterpreter<T> : ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}
