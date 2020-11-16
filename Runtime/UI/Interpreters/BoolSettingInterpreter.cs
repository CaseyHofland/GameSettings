using UnityEngine;
using UnityEngine.UI;

namespace GameSettings.UI
{
    public class BoolSettingInterpreter : SettingInterpreter<BoolSetting>, ISettingToggleInterpreter
    {
        [Tooltip("Shown the opposite value.")] public bool flip = false;

        protected virtual bool alteredValue
        {
            get => gameSetting.value != flip;
            set => gameSetting.value = value != flip;
        }

        public virtual void UpdateView(Toggle toggle)
        {
            toggle.SetIsOnWithoutNotify(alteredValue);
        }

        public virtual void ResetView(Toggle toggle)
        {
        }

        public virtual void ValueChanged(bool value)
        {
            alteredValue = value;
            gameSetting.Save();
        }
    }
}
