using UnityEngine.UI;

namespace GameSettings.UI
{
    public interface ISettingScrollbarInterpreter : ISettingSelectableInterpreter
    {
        void UpdateView(Scrollbar scrollbar);
        void ResetView(Scrollbar scrollbar);
        void ValueChanged(float value);
    }

    public interface ISettingScrollbarInterpreter<T> : ISettingScrollbarInterpreter, ISettingSelectableInterpreter<T> where T : GameSetting
    {
    }
}

