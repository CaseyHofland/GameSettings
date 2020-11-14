using UnityEngine.UI;

namespace GameSettings.UI
{
    public class BoolSettingInterpreter : SettingInterpreter<BoolSetting>, ISettingToggleInterpreter
    {
        public void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(gameSetting.value);
        }

        public void ResetView(Toggle toggle)
        {
        }

        public void ValueChanged(bool value)
        {
            gameSetting.value = value;
            gameSetting.Save();
        }
    }
}
