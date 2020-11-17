using UnityEngine.UI;

namespace GameSettings.UI
{
    public class StringSettingInterpreter : SettingInterpreter<StringSetting>, ISettingInputFieldInterpreter
    {
        public virtual void UpdateView(InputField inputField)
        {
            inputField.SetTextWithoutNotify(gameSetting.value);
        }

        public virtual void ResetUI(InputField inputField)
        {
        }

        public char ValidateInput(string text, int charIndex, char addedChar)
        {
            return addedChar;
        }

        public virtual void ValueChanged(string value)
        {
            gameSetting.value = value;
        }

        public virtual void EndedEdit(string value)
        {
            gameSetting.value = value;
            gameSetting.Save();
        }
    }
}
