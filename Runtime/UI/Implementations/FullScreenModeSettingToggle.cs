using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class FullScreenModeSettingToggle : UISetting<FullScreenModeSetting>, ISettingToggle
    {
        public virtual void ValueChanged(bool value)
        {
            derivedGameSetting.value = value ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        }

        public virtual void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(derivedGameSetting.value != FullScreenMode.Windowed);
        }

        public virtual void ResetView(Toggle toggle)
        {
        }
    }
}
