using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingInputFieldInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(InputField inputField);
        void ResetView(InputField inputField);
        void ValueChanged(string value);
        void EndedEdit(string value);
    }

    public interface ISettingInputFieldInterpreter<T> : ISettingInputFieldInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}
