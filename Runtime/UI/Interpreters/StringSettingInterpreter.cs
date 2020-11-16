using UnityEngine.UI;

namespace GameSettings.UI
{
    public class StringSettingInterpreter : SettingInterpreter<StringSetting>, ISettingInputFieldInterpreter
    {
        public virtual void UpdateView(InputField inputField)
        {
            inputField.SetTextWithoutNotify(gameSetting.value);
        }

        public virtual void ResetView(InputField inputField)
        {
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
