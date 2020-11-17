using TMPro;

namespace GameSettings.UI.TMPro
{
    public class StringSettingTMP_Interpreter : StringSettingInterpreter, ISettingTMP_InputFieldInterpreter
    {
        public void UpdateView(TMP_InputField tmp_InputField)
        {
            tmp_InputField.SetTextWithoutNotify(gameSetting.value);
        }

        public void ResetUI(TMP_InputField tmp_InputField)
        {
        }
    }
}
