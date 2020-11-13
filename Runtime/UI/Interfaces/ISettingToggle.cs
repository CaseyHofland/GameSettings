using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingToggle : ISettingSelectable
    {
        void UpdateView(Toggle toggle);
        void ResetView(Toggle toggle);
        void ValueChanged(bool value);
    }
}

