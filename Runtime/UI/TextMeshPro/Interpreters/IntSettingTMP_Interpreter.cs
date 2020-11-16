using TMPro;

namespace GameSettings.UI.TMPro
{
    public class IntSettingTMP_Interpreter : IntSettingInterpreter, ISettingTMP_InputFieldInterpreter
    {
        public void UpdateView(TMP_InputField tmp_InputField)
        {
            tmp_InputField.SetTextWithoutNotify(alteredValue.ToString());
        }

        public void ResetView(TMP_InputField tmp_InputField)
        {
            tmp_InputField.contentType = TMP_InputField.ContentType.IntegerNumber;
        }

        public void Selected(string value)
        {
        }

        public void Deselected(string value)
        {
        }
    }
}
