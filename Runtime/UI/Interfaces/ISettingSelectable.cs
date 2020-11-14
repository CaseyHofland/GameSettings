using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingSelectable
    {
        GameSetting gameSetting { get; set; }

        void UpdateView(Selectable selectable);
        void ResetView(Selectable selectable);
    }

    public interface ISettingSelectable<T> : ISettingSelectable where T : GameSetting
    {
        new T gameSetting { get; set; }
    }
}
