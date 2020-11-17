using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingSelectableInterpreter
    {
        GameSetting gameSetting { get; set; }

        void UpdateView(Selectable selectable);
        void ResetUI(Selectable selectable);
    }

    public interface ISettingSelectableInterpreter<T> : ISettingSelectableInterpreter where T : GameSetting
    {
        new T gameSetting { get; set; }
    }
}
