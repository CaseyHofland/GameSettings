using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingSelectable
    {
        void UpdateView(Selectable selectable);
        void ResetView(Selectable selectable);
    }
}
