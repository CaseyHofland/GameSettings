using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingInputFieldInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(InputField inputField);
        void ResetUI(InputField inputField);
        char ValidateInput(string text, int charIndex, char addedChar);
        void ValueChanged(string value);
        void EndedEdit(string value);
    }

    public interface ISettingInputFieldInterpreter<T> : ISettingInputFieldInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}
