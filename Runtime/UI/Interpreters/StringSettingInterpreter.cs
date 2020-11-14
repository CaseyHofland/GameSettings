using UnityEngine.UI;

namespace GameSettings.UI
{
    public class StringSettingInterpreter : SettingInterpreter<StringSetting>, ISettingInputFieldInterpreter
    {
        public void UpdateView(InputField inputField)
        {
            inputField.SetTextWithoutNotify(gameSetting.value);
        }

        public void ResetView(InputField inputField)
        {
        }

        public void ValueChanged(string value)
        {
            gameSetting.value = value;
        }

        public void EndedEdit(string value)
        {
            gameSetting.value = value;
            gameSetting.Save();
        }
    }
}
