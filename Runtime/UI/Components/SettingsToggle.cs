using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    [RequireComponent(typeof(Toggle))]
    public class SettingsToggle : SettingsSelectable
    {
        public Toggle toggle => (Toggle)selectable;

        public ISettingToggle settingToggle => (ISettingToggle)settingSelectable;

        protected virtual void OnEnable()
        {
            if(settingToggle != null)
            {
                toggle.onValueChanged.AddListener(settingToggle.ValueChanged);
            }
        }

        private void OnDisable()
        {
            if(settingToggle != null)
            {
                toggle.onValueChanged.RemoveListener(settingToggle.ValueChanged);

            }
        }
    }
}
